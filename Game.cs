using System;

/* Final Assignemt MS4 - Wheel Of Fortune (Single Player) */
// Name: Cameron Deans

namespace Assignment2_MS1_CDeans
{
    class Game
    {
        private static readonly string[] wordArray = { "v", "iv", "iii", "r2d2", "lucas", "wookie", "hansolo", "princess", "skywalker", "millennium", "mandalorian", "christophsis", "numidianprime"};
        private static readonly string[] hintArray = { "HINT: The Empire Strikes Back - Episode#", "HINT: A New Hope - Episode#",
            "HINT: Revenge Of The Sith - Episode#", "HINT: Artoo-Deetoo - Acronym", "HINT: George _____",  "HINT: Humanoid Aliens Native To The Forest Planet Kashyyk",
            "HINT: Harrison Ford Charater Name - No Spaces", "HINT: ________ Leia ", "HINT: Luke _________", "HINT: __________ Falcon", "HINT: Space Technically In The Outer Rim",
            "Hint: During The Clone Wars The Battle Of ____________ Occurs Here", "Hint: Rainforest Paradise That Is A Haven To Smugglers And thieves - No Spaces"};
        private string targetWord, hint;

        public string AssignTargetWord()
        {
            string targetWordAssigned;

            Random rand = new Random();
            int randomNumber = rand.Next(0, 13);

            targetWordAssigned = wordArray[randomNumber];

            return targetWordAssigned;
        }

        public string TargetWord
        {
            set
            {
                targetWord = value;
            }
            get
            {
                return targetWord;
            }
        }

        public string AssignHint(string targetWord)
        {
            string hintAssigned = "No Hint Here!";
            
            for (int index = 0; index < targetWord.Length; index++)
            {
                if (targetWord == wordArray[index])
                {
                    hintAssigned = hintArray[index];
                }

            }
            return hintAssigned;
        }

        public string Hint
        {
            set
            {
                hint = value;
            }
            get
            {
                return hint;
            }
        }
    }
}
