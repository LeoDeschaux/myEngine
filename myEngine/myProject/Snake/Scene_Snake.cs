using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

using myEngine.myProject.Snake;

namespace myEngine
{
    public class Scene_Snake : IScene
    {
        //FIELDS
        Game_Snake game;
        //TO ADD: UI

        //CONSTRUCTOR
        public Scene_Snake()
        {
            Text t = new Text();
            t.s = "Snake_Game";
            t.color = Color.White;

            game = new Game_Snake();
        }

        //METHODS
        public override void Update()
        {

        }

        public override void Draw(SpriteBatch sprite)
        {

        }
    }
}