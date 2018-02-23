using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batlefield_of_Space
{
    class Spell
    {
        public Texture2D Texture { get; set; }
        public int Damage { get; set; }
       // public Rectangle Bounds { get { return bounds; } set { bounds = value; } }
        public bool IsActive { get; set; }
    }
}
