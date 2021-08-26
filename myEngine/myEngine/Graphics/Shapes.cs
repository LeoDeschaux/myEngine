using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Shapes : IDisposable
    {
        private bool isDisposed;

        private Game game;
        private BasicEffect effect;

        private VertexPositionColor[] vertices;
        private int[] indices;

        private int shapeCount;
        private int vertexCount;
        private int indexCount;

        private bool started;

        public Shapes(Game game)
        {
            isDisposed = false;

            this.game = game ?? throw new ArgumentNullException("GAME");
            effect = new BasicEffect(game.GraphicsDevice);
            effect.TextureEnabled = false;
            effect.FogEnabled = false;
            effect.LightingEnabled = false;
            effect.PreferPerPixelLighting = false;

            /*
            effect.World = Matrix.Identity;
            effect.View = Matrix.Identity;
            effect.Projection = Matrix.Identity;
            */
            effect.VertexColorEnabled = true;

            const int MaxVertexCount = 1024;
            const int MaxIndexCount = MaxVertexCount * 3;


            vertices = new VertexPositionColor[MaxVertexCount];
            indices = new int[MaxIndexCount];

            shapeCount = 0;
            vertexCount = 0;
            indexCount = 0;

            started = false;
        }

        public void Dispose()
        {
            if (isDisposed)
                return;

            effect?.Dispose();
            isDisposed = true;
        }

        public void Begin(Camera2D? camera)
        {
            if(started)
                throw new Exception("Batching is already starded");

            if (camera is null)
            {
                Viewport vp = game.GraphicsDevice.Viewport;
                effect.View = Matrix.Identity;
                effect.Projection = Matrix.CreateOrthographicOffCenter(0, vp.Width, vp.Height, 0, 0, 1);
                //effect.Projection = Matrix.CreateOrthographicOffCenter(0, vp.Width, 0, vp.Height, 0, 1);
            }
            else
            {
                Viewport vp = game.GraphicsDevice.Viewport;
                effect.View = Matrix.Identity;
                effect.Projection = camera.transformMatrix * Matrix.CreateOrthographicOffCenter(0, vp.Width, vp.Height, 0, 0, 1);
            }

            started = true;
        }

        public void End()
        {
            EnsureStarted();

            Flush();

            started = false;
        }

        public void Flush()
        {
            if (shapeCount == 0)
                return;

            EnsureStarted();

            GraphicsDevice device = this.game.GraphicsDevice;
            int primitiveCount = this.indexCount / 3;

            EffectPassCollection passes = this.effect.CurrentTechnique.Passes;
            for (int i = 0; i < passes.Count; i++)
            {
                EffectPass pass = passes[i];
                pass.Apply();

                device.DrawUserIndexedPrimitives<VertexPositionColor>(
                PrimitiveType.TriangleList,
                this.vertices,
                0,
                this.vertexCount,
                this.indices,
                0,
                primitiveCount);
        }

            shapeCount = 0;
            vertexCount = 0;
            indexCount = 0;
        }

        private void EnsureStarted()
        {
            if (!started)
                throw new Exception("Batching was never starded");
        }

        private void EnsureSpace(int shapeVertexCount, int shapeIndexCount)
        {
            if (shapeIndexCount > vertices.Length)
                throw new Exception("Max shape vertex count is: " + vertices.Length);
            if (shapeIndexCount > indices.Length)
                throw new Exception("Max shape index count is: " + indices.Length);

            if (vertexCount + shapeVertexCount > vertices.Length ||
                indexCount + shapeIndexCount > indices.Length)
                Flush();
        }

        public void DrawRectangleFill(float x, float y, float width, float height, Color color)
        {
            EnsureStarted();

            const int shapeVertexCount = 4;
            const int shapeIndexCount = 6;

            EnsureSpace(shapeVertexCount, shapeIndexCount);

            float left = x;
            float right = x + width;
            float bottom = y + height;
            float top = y;

            Vector2 a = new Vector2(left, top);
            Vector2 b = new Vector2(right, top);
            Vector2 c = new Vector2(right, bottom);
            Vector2 d = new Vector2(left, bottom);

            indices[indexCount++] = 0 + vertexCount;
            indices[indexCount++] = 1 + vertexCount;
            indices[indexCount++] = 2 + vertexCount;
            indices[indexCount++] = 0 + vertexCount;
            indices[indexCount++] = 2 + vertexCount;
            indices[indexCount++] = 3 + vertexCount;

            vertices[vertexCount++] = new VertexPositionColor(new Vector3(a, 0f), color);
            vertices[vertexCount++] = new VertexPositionColor(new Vector3(b, 0f), color);
            vertices[vertexCount++] = new VertexPositionColor(new Vector3(c, 0f), color);
            vertices[vertexCount++] = new VertexPositionColor(new Vector3(d, 0f), color);

            shapeCount++;
        }

        public void DrawRectangle(float x, float y, float width, float height, float thickness, Color color)
        {
            float left = x;
            float right = x + width;
            float bottom = y;
            float top = y + height;

            Vector2 a = new Vector2(left, top);
            Vector2 b = new Vector2(right, top);
            Vector2 c = new Vector2(right, bottom);
            Vector2 d = new Vector2(left, bottom);

            DrawLine(a, b, thickness, color);
            DrawLine(b, c, thickness, color);
            DrawLine(c, d, thickness, color);
            DrawLine(d, a, thickness, color);
        }

        public void DrawLine(Vector2 a, Vector2 b, float thickness, Color color)
        {
            EnsureStarted();

            const int shapeVertexCount = 4;
            const int shapeIndexCount = 6;

            EnsureSpace(shapeVertexCount, shapeIndexCount);

            const float minThickness = 1;
            const float maxThickness = 10;

            thickness = MathHelper.Clamp(thickness, minThickness, maxThickness);

            float halfThickness = thickness / 2;

            Vector2 e1 = b - a;
            e1.Normalize();
            e1 *= halfThickness;
            
            Vector2 e2 = -e1;
            //Vector2 n1 = new Vector2(-e1.Y, e1.X);
            Vector2 n1 = new Vector2(e1.Y, -e1.X);
            
            Vector2 n2 = -n1;

            Vector2 q1 = a + n1 + e2;
            Vector2 q2 = b + n1 + e1;
            Vector2 q3 = b + n2 + e1;
            Vector2 q4 = a + n2 + e2;

            indices[indexCount++] = 0 + vertexCount;
            indices[indexCount++] = 1 + vertexCount;
            indices[indexCount++] = 2 + vertexCount;
            indices[indexCount++] = 0 + vertexCount;
            indices[indexCount++] = 2 + vertexCount;
            indices[indexCount++] = 3 + vertexCount;

            vertices[vertexCount++] = new VertexPositionColor(new Vector3(q1, 0f), color);
            vertices[vertexCount++] = new VertexPositionColor(new Vector3(q2, 0f), color);
            vertices[vertexCount++] = new VertexPositionColor(new Vector3(q3, 0f), color);
            vertices[vertexCount++] = new VertexPositionColor(new Vector3(q4, 0f), color);

            shapeCount++;
        }

        public void DrawCircle(Vector2 center, float radius, int points, float thickness, Color color)
        {
            const int minPoints = 3;
            const int maxPoints = 256;

            points = MathHelper.Clamp(points, minPoints, maxPoints);

            float deltaAngle = MathHelper.TwoPi / (float)points;
            float angle = 0f + MathHelper.Pi;

            float ax = MathF.Sin(angle) * radius + center.X;
            float ay = MathF.Cos(angle) * radius + center.Y;

            for (int i = 0; i < points; i++)
            {
                angle += deltaAngle;

                float bx = MathF.Sin(angle) * radius + center.X;
                float by = MathF.Cos(angle) * radius + center.Y;

                DrawLine(new Vector2(ax, ay), new Vector2(bx, by), thickness, color);

                ax = bx;
                ay = by;
            }
        }

        public void DrawCircleFill(Vector2 center, float radius, int points, Color color)
        {
            EnsureStarted();

            const int MIN_POINTS = 3;
            const int MAX_POINTS = 256;

            points = MathHelper.Clamp(points, MIN_POINTS, MAX_POINTS);
            int shapeVertexCount = points;
            int shapeTriangleCount = shapeVertexCount - 2;
            int shapeIndexCount = shapeTriangleCount * 3;

            EnsureSpace(shapeVertexCount, shapeIndexCount);

            int index = 1;

            for (int i = 0; i < shapeTriangleCount; i++)
            {
                indices[indexCount++] = 0 + vertexCount;
                indices[indexCount++] = index + vertexCount;
                indices[indexCount++] = index + 1 + vertexCount;

                index++;
            }

            float deltaAngle = MathHelper.TwoPi / (float)points;
            float angle = 0f;

            float ax = MathF.Sin(angle) * radius + center.X;
            float ay = MathF.Cos(angle) * radius + center.Y;

            for (int i = 0; i < shapeVertexCount; i++)
            {
                angle += deltaAngle;

                float bx = MathF.Sin(angle) * radius + center.X;
                float by = MathF.Cos(angle) * radius + center.Y;

                vertices[vertexCount++] = new VertexPositionColor(new Vector3(ax + center.X, -ay + center.Y, 0f), color);

                ax = bx;
                ay = by;
            }

            shapeCount++;
        }

        public void DrawPolygon(Vector2[] vertices, Matrix transform, float thickness, Color color)
        {
            for(int i = 0; i < vertices.Length; i++)
            {
                Vector2 a = vertices[i];
                Vector2 b = vertices[(i + 1) % vertices.Length];

                a = Vector2.Transform(a, transform) * new Vector2(1, -1);
                b = Vector2.Transform(b, transform) * new Vector2(1, -1);

                DrawLine(a, b, thickness, color);
            }
        }

        public void DrawPolygonFill(Vector2[] vertices, Color color)
        {
            if (vertices.Length < 3)
                throw new ArgumentException("vertices");

            //EnsureStarted();
            //EnsureSpace(vertices.Length, 000_000);

            throw new NotImplementedException();

        }
    }
}
