using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using myEngine.myProject.Snake;

namespace myEngine.myProject.Snake
{
    public enum CellState
    {
        empty,
        head,
        body,
        apple
    }

    public class Grid : Entity
    {
        //FIELDS
        public int size { get; private set; } = 10;
        private CellState[,] grid;

        private Sprite[,] sprites;
        float spriteSize = 50;

        Vector2 start;


        //CONSTRUCTOR
        public Grid()
        {
            grid = new CellState[size, size];
            sprites = new Sprite[size, size];

            ClearGrid();
        }

        //METHODS
        public void SetPlayerPos(GridPosition pos)
        {
            if (pos.X < 0 || pos.Y < 0 || pos.X >= size || pos.Y >= size)
                return;

            ClearGrid();

            InitSprites();

            Console.Clear();

            grid[pos.X, pos.Y] = CellState.head;

            DisplayGridToConsole();
        }

        private void ClearGrid()
        {
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                    grid[x, y] = CellState.empty;
        }

        private void InitSprites()
        {
            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                {
                    Sprite s = sprites[x, y];
                    s = new Sprite();
                    s.color = Color.White;
                    s.orderInLayer = -500;

                    s.dimension = new Vector2(spriteSize, spriteSize); 
                    
                    start = new Vector2(Settings.Get_Screen_Center().X - ((size * spriteSize * 1.1f)/2), Settings.Get_Screen_Center().Y - ((size * spriteSize * 1.1f))/2);
                    start = new Vector2(start.X + spriteSize/2, start.Y + spriteSize/2);

                    s.transform.position = new Vector2(start.X + (x * spriteSize * 1.1f), start.Y + (y * spriteSize * 1.1f));

                }
        }

        public void DisplayGridToConsole()
        {
            for(int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    Console.Write("|");

                    //FILL CELL
                    if (grid[x, y] == CellState.empty)
                        Console.Write(".");
                    else if (grid[x, y] == CellState.head)
                        Console.Write("X");
                    else if (grid[x, y] == CellState.body)
                        Console.Write("+");
                    else if (grid[x, y] == CellState.apple)
                        Console.Write("o");
                }
                Console.Write("|");
                
                Console.WriteLine();
            }
        }

        public override void Draw(SpriteBatch sprite)
        {
            DrawSimpleShape.DrawRuller(start, Color.Green);
            DrawSimpleShape.DrawRuller(Settings.Get_Screen_Center());
        }
    }
}
