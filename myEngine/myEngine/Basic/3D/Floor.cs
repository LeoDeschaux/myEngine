using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Floor : GameObject
    {
        //FIELDS
        private int floorWidth;
        private int floorHeight;
        private VertexBuffer floorBuffer;
        private GraphicsDevice device;
        private Color[] floorColors = new Color[2] { Color.White, Color.Black };

        private float tileSize;

        private Camera3D camera;

        private BasicEffect effect;

        //CONSTRUCTOR
        public Floor(GraphicsDevice device, Camera3D camera, int width, int height, float tileSize)
        {
            this.device = device;
            this.floorWidth = width;
            this.floorHeight = height;
            this.tileSize = tileSize;

            BuildFloorBuffer();

            this.drawOrder = -10;

            this.camera = camera;

            effect = new BasicEffect(device);
        }

        private void BuildFloorBuffer()
        {
            List<VertexPositionColor> vertexList = new List<VertexPositionColor>();
            int counter = 0;

            //
            for(int x = 0; x < floorWidth; x++)
            {
                counter++;
                for(int z = 0; z < floorHeight; z++)
                {
                    counter++;
                    foreach (VertexPositionColor vertex in FloorTile(x,z, floorColors[counter % 2]))
                    {
                        vertexList.Add(vertex); 
                    }
                }
            }

            floorBuffer = new VertexBuffer(device, VertexPositionColor.VertexDeclaration, vertexList.Count, BufferUsage.None);
            floorBuffer.SetData<VertexPositionColor>(vertexList.ToArray());
        }

        private List<VertexPositionColor> FloorTile(int xOffset, int zOffset, Color tileColor)
        {
            List<VertexPositionColor> vList = new List<VertexPositionColor>();

            xOffset = xOffset * (int)tileSize;
            zOffset = zOffset * (int)tileSize;

            vList.Add(new VertexPositionColor(new Vector3(xOffset, 0, zOffset), tileColor));
            vList.Add(new VertexPositionColor(new Vector3(tileSize + xOffset, 0, zOffset), tileColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset, 0, tileSize + zOffset), tileColor));

            vList.Add(new VertexPositionColor(new Vector3(tileSize + xOffset, 0, zOffset), tileColor));
            vList.Add(new VertexPositionColor(new Vector3(tileSize + xOffset, 0, tileSize + zOffset), tileColor));
            vList.Add(new VertexPositionColor(new Vector3(xOffset, 0, tileSize + zOffset), tileColor));

            return vList;
        }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            DrawModel();
        }

        private void DrawModel()
        {
            Engine.game.GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            device.RasterizerState = RasterizerState.CullNone;

            effect.VertexColorEnabled = true;
            effect.World = Matrix.CreateTranslation(Vector3.Zero);
            effect.View = camera.viewMatrix;
            effect.Projection = camera.projectionMatrix;

            foreach(EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();
                device.SetVertexBuffer(floorBuffer);
                device.DrawPrimitives(PrimitiveType.TriangleList, 0, floorBuffer.VertexCount / 3);
            }
        }
    }
}
