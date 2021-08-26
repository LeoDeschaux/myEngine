using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Game_Asteroid
    {
        //FIELDS
        Player player;
        Asteroid_Spawner spawner;
        //UI

        //CONSTRUCTOR
        public Game_Asteroid()
        {
            this.player = new Player();
            this.spawner = new Asteroid_Spawner();

        }

        //METHODS
    }
}
