using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batlefield_of_Space
{
   public class Enums
    {
        public enum GameState
        {
            Start = 0,
            Play = 1,
            Stop = 2
        }
        public enum MenuState
        {
            Start = 0,
            Newgame = 1,
            Load = 2 , 
            Game = 3

        }
        public enum species
        {
            alien1 = 0 ,
            alien2 = 1 ,
            alien3 = 2 
        }
        public enum Orientation
        {
            Down = 0 ,
            Left = 1 , 
            Right = 2 , 
            Up = 3 
        }
        public enum PlayState
        {
            Default = 0,
            Player =1 ,
            Enemy = 2,
            Pause = 3
        }


    }
}
