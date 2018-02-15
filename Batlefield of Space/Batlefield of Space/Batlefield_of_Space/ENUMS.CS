using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Batlefield_of_Space
{
   public class Enums
    {
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

        public enum GameState
        {
            Start = 1,
            Play = 2,
            Stop = 3
        }
        public enum MenuState
        {
            Start = 1,
            Newgame = 2,
            Load = 3 , 
            Game = 4

        }
        public enum species
        {
            alien1 = 1 ,
            alien2 = 2 ,
            alien3 = 3 
        }
        public enum Orientation
        {
            Down = 0 ,
            Left = 1 , 
            Right = 2 , 
            Up = 3 
        }
    }
}
