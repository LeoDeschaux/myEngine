using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public abstract class Player : GameObject
    {
        //FIELDS
        public Raquette raquette;
        public float speed = 500;

        public Transform anchorPoint;
        public Collider2D collider;

        public string name = "Player_Default";
        public PlayerIndex playerIndex;
        //SCORE
        public int score = 0;
        private string scoreKey = "PlayerScore";
        public int lives = 3;

        //BALL
        public bool isHoldingTheBall = false;

        //CONSTRUCTOR 
        public Player()
        {
            raquette = new Raquette();
            anchorPoint = new Transform();

            AddComponent(new Collider2D(raquette.sprite));
        }

        //METHODS
        public void LoadScore()
        {
            if (Save_RunTime.data.ContainsKey((scoreKey + playerIndex).ToString()))
                score = Int32.Parse(Save_RunTime.data[(scoreKey + playerIndex).ToString()]);
        }

        public void SaveScore()
        {
            Save_RunTime.data.Remove((scoreKey+playerIndex).ToString());
            Save_RunTime.data.Add((scoreKey+playerIndex).ToString(), score.ToString());
        }


        //UPDATE & DRAW
        public abstract override void Update();

        public override void Draw(SpriteBatch spriteBatch)
        {
        }

        public override void OnCollision(Collider2D other)
        {
        }
        
        public void RemoveLife()
        {
            lives--;

            if (lives == 0)
                OnPlayerDie();
        }

        public void OnPlayerGetRemovedStock()
        {
            //AUDIO
            int i = 0;
            if (lives == 3)
                i = 0;
            else if (lives == 2)
                i = 2;
            else if (lives == 1)
                i = 3;
            else if (lives <= 0)
                i = 3;

            AudioSource.PlaySoundEffect(Ressources.target_hit_sounds[i]);

            //REMOVE LIFE
            RemoveLife();

            //UPDATE UI
            ((UI_Pong)Scene_Pong.ui).RemoveLife(this);

        }

        private Player GetAdversaire()
        {
            Player adversaire = Scene_Pong.game.player1;
            if (adversaire.playerIndex == this.playerIndex)
                adversaire = Scene_Pong.game.player2;

            return adversaire;
        }

        private void OnPlayerDie()
        {
            Particle p = new Particle(DrawSimpleShape.GetTexture(10, 10));
            p.Color = Color.White;
            p.Speed = 10;
            p.TTL = 0.5f;

            ParticleProfile pp = new ParticleProfile(p);
            pp.burstMode = true;
            pp.burstAmount = 150;

            ParticleEngine pe = new ParticleEngine(pp, raquette.sprite.transform.position);
            raquette.sprite.Destroy();

            Settings.GAME_SPEED = 0.2f;

            Scene_Pong.game.OnGameOver(playerIndex);
        }
    }
}