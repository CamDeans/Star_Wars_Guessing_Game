using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Final Assignemt MS4 - Wheel Of Fortune (Single Player) */
// Name: Cameron Deans

namespace Assignment2_MS1_CDeans
{
    class Player
    {
        private int playerScore;
        private int numberOfWins;
        private int numberOfLosses;

        public string PlayersName { set; get; }

        public int PlayerScore
        {
            set
            {
                playerScore = value;
            }
            get
            {
                return playerScore;
            }
        }
      

        public int NumberOfLosses
        {
            set
            {
                numberOfLosses = value;
            }
            get
            {
                return numberOfLosses;
            }
        }

        public int NumberOfWins
        {
            set
            {
               numberOfWins = value;
            }
            get
            {
                return numberOfWins;
            }
        }
      
    }
}
