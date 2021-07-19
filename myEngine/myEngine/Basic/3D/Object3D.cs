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

        private Camera3D camera;

        //CONSTRUCTOR
        public Object3D(Camera3D camera)
        {
            transform3D = new Transform3D();
            model = Ressources.Load<Model>("myContent/3D/DEFAULT_CUBE");

            this.camera = camera;
        }

        //METHODS
        public override void Update() { }

        public override void Draw(SpriteBatch sprite, Matrix matrix)
        {
            camera.DrawModel(this);
        }
    }
}
