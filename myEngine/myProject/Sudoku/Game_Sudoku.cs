using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;

namespace myEngine.myProject.Sudoku
{
    public class Game_Sudoku : Entity
    {
        //FIELDS
        public static Grid grid;
        public static Menu menu;
        public static UI_Sudoku ui;

        //CONSTRUCTOR
        public Game_Sudoku()
        {
            grid = new Grid();
            menu = new Menu();
            ui = new UI_Sudoku(grid);
        }

        //METHODS
        public override void Update()
        {
        }

        public void OnGridIsComplete()
        {
            Console.WriteLine("GRID IS COMPLETE");
        }
    }
}
