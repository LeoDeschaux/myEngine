using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public class Target : GameObject
    {
        //FIELDS
        Sprite sprite;

        //CONSTRUCTOR
        public Target()
        {
            sprite = new Sprite(new Vector2(Settings.Get_Screen_Center().X, Settings.Get_Screen_Center().Y), new Vector2(50, 50));
            sprite.color = Color.HotPink;
            sprite.orderInLayer = -1000;
            sprite.transform.rotation = 45f;
            this.AddComponent(new Collider2D(sprite));
            this.GetComponent<Collider2D>().scale = 2;
        }

        //METHODS

        //UPDATE & DRAW
        public override void Update()
        {
        }

        public override void OnDestroy()
        {
            Particle p = new Particle(DrawSimpleShape.GetTexture(10, 10));
            p.Color = Color.HotPink;
            p.Speed = 10;
            p.TTL = 0.5f;

            ParticleProfile pp = new ParticleProfile(p);
            pp.burstMode = true;
            pp.burstAmount = 50;

            ParticleEngine pe = new ParticleEngine(pp, sprite.transform.position);

            //AUDIO
            AudioSource.PlaySoundEffect(Ressources.target_hit_small_v1);

            this.GetComponent<Collider2D>().Destroy();
            sprite.Destroy();
        }

        public override void OnCollision(Collider2D other)
        {
        }
    }
}
