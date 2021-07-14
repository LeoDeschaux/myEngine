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

    public static class CellColors
    {
        public static Color empty = Color.White;
        public static Color head = Color.Green;
        public static Color body = Color.Green;
        public static Color apple = Color.Red;
    }

    public class Grid : Entity
    {
        //FIELDS
        public int size { get; private set; } = 10;
        private CellState[,] grid;

        private Sprite[,] sprites;
        float spriteSize = 50;

        Vector2 start;

        private Player snake;

        private Apple_Spawner spawner;

        //CONSTRUCTOR
        public Grid(Player snake)
        {
            grid = new CellState[size, size];
            SetGridEmpty();

            sprites = new Sprite[size, size];
            InitSprites();

            this.snake = snake;
            SetPlayerPos();

            spawner = new Apple_Spawner();

            DrawGrid();
        }

        //METHODS
        public void UpdateGrid()
        {
            //UPDATE SNAKE POS
            SetNextPlayerPos();
            DrawGrid();
        }

        public void DrawGrid()
        {
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    sprites[x, y].color = CellColors.empty;
                    sprites[x, y].texture = DrawSimpleShape.GetTexture();
                }
            }

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (grid[x, y] == CellState.empty)
                        sprites[x, y].color = CellColors.empty;
                    else if (grid[x, y] == CellState.head)
                    {
                        sprites[x, y].texture = snake.head.texture;
                        //sprites[x, y].spriteEffect = snake.head.spriteEffect;
                        sprites[x, y].transform.rotation = snake.head.transform.rotation;
                    }
                        
                    else if (grid[x, y] == CellState.body)
                        sprites[x, y].color = CellColors.body;
                    else if (grid[x, y] == CellState.apple)
                        sprites[x, y].color = CellColors.apple;
                }
            }
        }

        private void SetPlayerPos()
        {
            IntVec2 pos = snake.gridPosition;

            if (pos.X < 0 || pos.Y < 0 || pos.X >= size || pos.Y >= size)
                return;

            SetGridEmpty();

            grid[pos.X, pos.Y] = CellState.head;

            //Console.Clear();
            DisplayGridToConsole();
        }

        private void SetNextPlayerPos()
        {
            IntVec2 pos = snake.gridPosition + snake.direction;

            if (pos.X < 0 || pos.Y < 0 || pos.X >= size || pos.Y >= size)
                return;

            snake.gridPosition += snake.direction;

            SetGridEmpty();

            grid[pos.X, pos.Y] = CellState.head;

            Console.Clear();
            DisplayGridToConsole();
        }

        private void SetGridEmpty()
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
                    sprites[x, y] = new Sprite();
                    sprites[x, y].color = Color.White;
                    sprites[x, y].orderInLayer = -500;

                    sprites[x, y].dimension = new Vector2(spriteSize, spriteSize); 
                    
                    start = new Vector2(Settings.Get_Screen_Center().X - ((size * spriteSize * 1.1f)/2), Settings.Get_Screen_Center().Y - ((size * spriteSize * 1.1f))/2);
                    start = new Vector2(start.X + ((spriteSize * 1.1f)/2), start.Y + ((spriteSize * 1.1f)/2));

                    sprites[x, y].transform.position = new Vector2(start.X + (x * spriteSize * 1.1f), start.Y + (y * spriteSize * 1.1f));
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
            //DrawSimpleShape.DrawRuller(start, Color.Green);
            //DrawSimpleShape.DrawRuller(Settings.Get_Screen_Center());
        }
    }
}
