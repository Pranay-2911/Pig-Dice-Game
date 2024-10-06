using Pig_Dice_Game.Controller;
using System;

namespace Pig_Dice_Game.Presentation
{
    internal class GameMenu
    {
        static GameManager manager = new GameManager();

        public static void GameStart()
        {
           
            Console.WriteLine("=============Welcome to the Pig Dice Game!=============");
            Console.WriteLine();

            bool gamePaused = false; 

            // Main game loop keeps running until the player decides to exit
            while (!gamePaused)
            {
                GameStop(ref gamePaused);
            }
        }

        public static void GameStop(ref bool gamePaused)
        {
            bool gameOver = false; 

            // Loop continues until the game is over
            while (!gameOver)
            {
                int turnScore = 0; 
                bool turnOver = false; 

                Console.WriteLine($"Your total score: {manager.GetTotalScore()}");

                
                DiceStart(ref turnOver, ref turnScore);

                // Check if the player has won the game
                if (manager.CheckWin())
                {
                    Console.WriteLine($"Congratulations! You won with a total score of {manager.GetTotalScore()}.");
                    gameOver = true;

                    Console.WriteLine();
                    Console.WriteLine($"Enter 1 to play again\n" +
                                      $"Enter 0 to Exit");
                    int check = int.Parse(Console.ReadLine());

                    //Function to check whether the player wants to replay or exit
                    CheckUser(check, ref gamePaused);
                }
                else
                {
                    Console.WriteLine("Your score is not enough to clear the game");
                    Console.WriteLine("Next turn starts.");
                }
            }
        }

        public static void DiceStart(ref bool turnOver, ref int turnScore)
        {
            
            while (!turnOver)
            {
                Console.WriteLine($"Your turn score: {turnScore}");
                Console.WriteLine();
                Console.WriteLine("Enter 'r' to Roll or 'h' to Hold:");
                Console.WriteLine();

                string action = Console.ReadLine().ToLower();

                // Handle the player's decision to roll or hold
                if (action == "r")
                {
                    int roll = manager.RollDice();
                    Console.WriteLine($"You rolled a {roll}");
                    
                    CheckRoll(ref turnOver, ref turnScore, roll);
                }
                else if (action == "h")
                {
                    // Player decides to hold, so add turn score to the total score
                    manager.HoldTurn(turnScore);
                    Console.WriteLine($"You held. Your total score is now {manager.GetTotalScore()}.");
                    turnOver = true;
                }
                else
                {
                    // Invalid input 
                    Console.WriteLine("Invalid input! Please enter 'r' to Roll or 'h' to Hold.");
                }
            }
        }

        public static void CheckRoll(ref bool turnOver, ref int turnScore, int roll)
        {
            // If the player rolls a 1, they lose their turn score, and their turn ends
            if (roll == 1)
            {
                Console.WriteLine("=============Oh no! You rolled a 1. You lose your turn score.==============");
                turnScore = 0; 
                turnOver = true; // End the player's turn
            }
            else
            {
                // Add the rolled value to the turn score if it's not a 1
                turnScore += roll;
            }
        }

        //Function to handle user's input on whether they want to play again or exit
        public static void CheckUser(int check, ref bool gamePaused)
        {
            // If the user enters 0, they want to exit, so pause the game
            if (check == 0)
            {
                gamePaused = true;
                return; // Exit the method, ending the game loop
            }

            // If the user chooses to replay, reset the game state
            manager.RePlay(); // Calls the method in GameManager to reset scores and start a new game
        }
    }
}
