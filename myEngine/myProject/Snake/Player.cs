using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Input;
using myEngine.myProject.Snake;

namespace myEngine.myProject.Snake
{
    public class Player : GameObject
    {
        //FIELDS

        //CONSTRUCTOR
        public Player()
        {

        }

        //METHODS
        public override void Update()
        {
            if (Input.GetKeyDown(Keys.Up))
                return; //

            if (Input.GetKeyDown(Keys.Down))
                return; //

            if (Input.GetKeyDown(Keys.Left))
                return; //

            if (Input.GetKeyDown(Keys.Right))
                return; //
        }

    }
}
