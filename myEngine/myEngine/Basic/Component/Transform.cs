using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace myEngine
{
    public enum SpaceMode
    {
        local,
        global
    }

    public struct Transform
    {
        SpaceMode mode;

        public Vector2 position;
        public float rotation;
        public Vector2 scale;

        //FIELDS
        /*
        public Vector2 position
        {
            get 
            {
                return m_localPos;
            }

            set
            {
                m_localPos = value;
            }
        }



        public float rotation
        {
            get { return m_localRot; }
            set { m_localRot = value; }
        }

        public Vector2 scale
        {
            get { return m_localScale; }
            set { m_localScale = value; }
        }
        */

        private Vector2 m_localPos;
        private float m_localRot;
        private Vector2 m_localScale;

        private Vector2 m_globalPos;
        private float m_globalRot;
        private Vector2 m_globalScale;

        //CONSTRUCTOR
        public Transform(Vector2 pos, float rot, Vector2 scale)
        {
            mode = SpaceMode.local;

            m_localPos = Vector2.Zero;
            m_localRot = 0;
            m_localScale = Vector2.One;

            m_globalPos = Vector2.Zero;
            m_globalRot = 0;
            m_globalScale = Vector2.One;

            //INIT
            this.position = Vector2.Zero;
            this.rotation = rot;
            this.scale = Vector2.One;
        }
    }
}
