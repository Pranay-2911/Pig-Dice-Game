using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pig_Dice_Game.Controller
{
    internal class GameManager
    {
        private const int winningScore = 20;
        private int totalScore = 0;
        private Random random = new Random();

        // Method to get the current total score
        public int GetTotalScore()
        {
            return totalScore;
        }

        // Method to get a random dice roll (1 to 6)
        public int RollDice()
        {
            return random.Next(1, 7);
        }

        // Method to check if the player has won
        public bool CheckWin()
        {
            return totalScore >= winningScore;
        }

        // Method to update the total score after holding
        public void HoldTurn(int turnScore)
        {
            totalScore += turnScore;
        }

        //Methos to Reset the value to replay
        public void RePlay()
        {
            totalScore = 0;
        }
    }
}
