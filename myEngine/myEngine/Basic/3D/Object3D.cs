using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Object3D : GameObject
    {
        //FIELDS
        public Transform3D transform3D;
        public Model model;

        public static BasicEffect GlobalEffect;

        public BasicEffect effect;

        private Camera3D camera;

        public bool isVisible = true;

        public Object3D(Camera3D camera)
        {
            if(GlobalEffect == null)
            {
                GlobalEffect = new BasicEffect(Engine.graphics.GraphicsDevice);
            }

            transform3D = new Transform3D();
            model = Ressources.Load<Model>("myContent/3D/DEFAULT_CUBE");

            effect = new BasicEffect(Engine.graphics.GraphicsDevice);

            this.camera = camera;
        }

        //METHODS
        public override void Update() { }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            if(isVisible)
                camera.DrawModel(this);
        }
    }
}
