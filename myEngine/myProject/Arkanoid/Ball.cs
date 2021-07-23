using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine.myProject.Arkanoid
{
    public class Ball : GameObject
    {
        //FIELDS
        Sprite sprite;

        bool hasBeenShot = false;
        Paddle paddle;

        Vector2 direction;
        float speed = 500;

        Collider2D collider;

        //CONSTRUCTOR
        public Ball(Paddle paddle)
        {
            this.paddle = paddle;

            sprite = new Sprite();
            sprite.color = Color.Green;
            sprite.transform = this.transform;
            sprite.dimension = new Vector2(30, 30);

            AddComponent(new Collider2D(sprite));
        }

        int i = 0;

        //METHODS
        public override void Update()
        {
            if(hasBeenShot)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
        }

        public override void LateUpdate()
        {
            if(!hasBeenShot)
            {
                Vector2 pos = new Vector2(paddle.transform.position.X, paddle.transform.position.Y - (sprite.dimension.Y * 2));
                this.transform.position = pos;
            }
        }

        public void Serve()
        {
            direction = new Vector2(0, -1);
            hasBeenShot = true;
        }

        public override void OnCollision(Collider2D other)
        {
            other.gameObject.Destroy();
        }
    }
}
