using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Shapes3D : GameObject
    {
        //FIELDS
        private Game game;
        private BasicEffect effect;

        private VertexBuffer buffer;
        private GraphicsDevice device;
        private Camera3D camera;

        public Shapes3D(GraphicsDevice device, Camera3D camera)
        {
            this.device = device;
            this.camera = camera;

            effect = new BasicEffect(device);

            buffer = new VertexBuffer(device, VertexPositionColor.VertexDeclaration, 0, BufferUsage.None);
        }

        public void DrawTriangle(Vector3 center, float size, Color color)
        {
            List<VertexPositionColor> vList = new List<VertexPositionColor>();


            vList.Add(new VertexPositionColor(new Vector3(0, 0.8f, 0), color));
            vList.Add(new VertexPositionColor(new Vector3(0.5f, 0, 0), color));
            vList.Add(new VertexPositionColor(new Vector3(-0.5f, 0, 0), color));

            buffer = new VertexBuffer(device, VertexPositionColor.VertexDeclaration, vList.Count, BufferUsage.None);
            buffer.SetData<VertexPositionColor>(vList.ToArray());
        }

        public void DrawLine(Vector3 start, Vector3 end, float size, Color TOCHANGE)
        {
            List<VertexPositionColor> vList = new List<VertexPositionColor>();

            size = size / 100;

            Color color = new Color(0, 0, 0);
            color.R += 20;
            color.G += 20;
            color.B += 20;

            vList.Add(new VertexPositionColor(new Vector3(start.X, start.Y, start.Z), color));
            vList.Add(new VertexPositionColor(new Vector3(start.X + size, start.Y, start.Z), color));
            vList.Add(new VertexPositionColor(new Vector3(end.X, end.Y, end.Z), color));

            color.R += 200;
            color.G += 200;
            color.B += 200;

            vList.Add(new VertexPositionColor(new Vector3(end.X, end.Y, end.Z), color));
            vList.Add(new VertexPositionColor(new Vector3(end.X + size, end.Y, end.Z), color));
            vList.Add(new VertexPositionColor(new Vector3(start.X + size, start.Y, start.Z), color));


            buffer = new VertexBuffer(device, VertexPositionColor.VertexDeclaration, vList.Count, BufferUsage.None);
            buffer.SetData<VertexPositionColor>(vList.ToArray());
        }

        public void DrawCube(Vector3 center, float size, Color TOCHANGE)
        {
            List<VertexPositionColor> vList = new List<VertexPositionColor>();

            Color color = new Color(0, 0, 0);
            color.R += 20;
            color.G += 20;
            color.B += 20;

            //TOP
            vList.Add(new VertexPositionColor(new Vector3(-1, 1, 1), color));
            vList.Add(new VertexPositionColor(new Vector3(1, 1, 1), color));
            vList.Add(new VertexPositionColor(new Vector3(-1, 1, -1), color));

            /*
            vList.Add(new VertexPositionColor(new Vector3(-1, 1, 0), color));
            vList.Add(new VertexPositionColor(new Vector3(1, 1, 0), color));
            vList.Add(new VertexPositionColor(new Vector3(-1, -1, 0), color));

            color.R += 20;
            color.G += 20;
            color.B += 20;

            vList.Add(new VertexPositionColor(new Vector3(1, 1, 0), color));
            vList.Add(new VertexPositionColor(new Vector3(1, -1, 0), color));
            vList.Add(new VertexPositionColor(new Vector3(-1, -1, 0), color));
            */

            buffer = new VertexBuffer(device, VertexPositionColor.VertexDeclaration, vList.Count, BufferUsage.None);
            buffer.SetData<VertexPositionColor>(vList.ToArray());
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            device.RasterizerState = RasterizerState.CullNone;

            DrawModel();
        }

        private void DrawModel()
        {
            if (buffer.VertexCount == 0)
                return;

            effect.VertexColorEnabled = true;
            //effect.World = Matrix.CreateTranslation(Vector3.Zero);

            effect.World = Matrix.Identity *
                Matrix.CreateScale(1) *
                Matrix.CreateRotationY(MathHelper.ToRadians(90)) *
                Matrix.CreateTranslation(Vector3.Zero);

            effect.View = camera.viewMatrix;
            effect.Projection = camera.projectionMatrix;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.SetVertexBuffer(buffer);
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, buffer.VertexCount / 3);
            }
        }
    }
}