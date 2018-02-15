using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batlefield_of_Space
{
    class CHARACTER
    {
        public Enums.Orientation CharOrientation;
        public int[] TextureFrameSize = new int[4] {3,7,11,15 };
        public float Interval = 70;
        public int FrameWidth = 32;
        public int FrameHegiht = 48;
        public int CurrentFrameX = 0;
        public int CurrentFrameY = 0;
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public Texture2D Texture { get; set; }
        private Rectangle position;

        public Rectangle Position
        {
            get { return position; }
            set { position = value; }
        }
        private Rectangle hitbox;
        private Rectangle Hitbox
        {
            get { return hitbox; }
            set { hitbox = value; }
        }

        public CHARACTER(Rectangle _Position, Texture2D _Texture , int _ScreenWidth, int _ScreenHeight)
        {
            this.Position = _Position;
            this.Hitbox = new Rectangle(position.X - 10, position.Y - 10, position.Width + 20, position.Height + 20);
            this.Texture = _Texture;
            this.ScreenHeight = _ScreenHeight;
            this.ScreenWidth = _ScreenWidth;
        }
        public void Move(int moveX, int moveY)
        {
            if ((this.position.X + this.position.Width + moveX < ScreenWidth) && (this.position.X + moveX > 0))
                this.position.X += moveX;
            if ((this.position.Y + this.position.Height + moveY < ScreenHeight) && (this.position.Y + moveY > 0))
                this.position.Y += moveY;

            Hitbox = new Rectangle(position.X - 10, position.Y - 10, position.Width + 20, position.Y + 20);
        }
        public void Animation(Enums.Orientation newOrientation)
        {
            if (newOrientation == this.CharOrientation)
            {
                if (this.CurrentFrameX<this.TextureFrameSize[(int)this.CharOrientation])
                {
                    this.CurrentFrameX++;
                }
                else
                {
                    
                    this.CurrentFrameX = (int)this.CharOrientation * 4;
                }
            }
            else
            {
                this.CharOrientation = newOrientation;
                this.CurrentFrameX = (int)this.CharOrientation * 4;
            }
        }

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
