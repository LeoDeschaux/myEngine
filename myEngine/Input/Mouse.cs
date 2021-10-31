using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace myEngine
{
    public static class Mouse
    {
        //FIELDS
        public static Point position;
        public static Vector2 sensitivity;

        //CONSTRUCTOR
        public static void Update()
        {
            float ratioX = (float)Engine.game.Window.ClientBounds.Width / (float)Settings.SCREEN_WIDTH;
            float ratioY = (float)Engine.game.Window.ClientBounds.Height / (float)Settings.SCREEN_HEIGHT;

            position = new Point((int)(Microsoft.Xna.Framework.Input.Mouse.GetState().X / ratioX), 
                                 (int)(Microsoft.Xna.Framework.Input.Mouse.GetState().Y / ratioY));
        }
    }
}