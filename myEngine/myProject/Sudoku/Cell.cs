using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Sudoku
{
    public class Cell : GameObject
    {
        //FIELDS
        public Button button;

        //CONSTRUCTOR
        public Cell(Vector2 position, Vector2 dimension)
        {
            transform.position = position;

            button = new Button();
            button.transform = this.transform;
            button.sprite.transform = this.transform;
            button.text.transform = this.transform;

            button.sprite.color = Color.White;
            button.sprite.dimension = new Vector2(dimension.X, dimension.Y);

            button.text.s = "";
            button.text.alignment = Alignment.Center;

            button.onButtonPressed.SetFunction(OnClic);
            //button.onButtonRelease.PlayFunction(SetIsReady);
            //button.onButtonPressedOutside.SetFunction(ClicOutside);
        }

        public override void Update()
        {
            //TODO: either clic on a button and DO ACTION or clic outside menu and CLOSE MENU

            if (Input.GetMouseUp(MouseButton.Left) && isCellSelected && !finishedSpawned)
            {
                finishedSpawned = true;
                Console.WriteLine("UP CLICK");
            }

            if (Input.GetMouseDown(MouseButton.Left) && isCellSelected && finishedSpawned)
            {
                Console.WriteLine("DOWN CLICK");
                menu?.Destroy();
                isCellSelected = false;
                finishedSpawned = false;
            }

            //CHECK IF onButtonPressedOutside need refactoring
            //CHECK IF GetMouseDown need refactoring 
        }

        bool isCellSelected = false;
        bool finishedSpawned = false;

        //METHODS
        GridMenu menu;
        private void ClicOutside()
        {
        }

        public void OnClic()
        {
            menu = new GridMenu(this);
            isCellSelected = true;
        }

        public void OnSubButtonClic()
        {
            //menu.Destroy();
            //isCellSelected = false;
        }
        
        public override void OnDestroy()
        {
            button.sprite.Destroy();
        }
    }
}
