using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batlefield_of_Space
{
   abstract class Spaceship
    {
        string Name;
        int Healt;
        int Speed;
        int Basedamage;
        public Texture2D Texture { get; set; }
        private Rectangle position;

        public Game GAME
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public Game Game
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }
    }
}
