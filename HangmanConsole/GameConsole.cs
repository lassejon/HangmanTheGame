using System;
using Controller;

namespace HangmanConsole
{
    public class GameConsole
    {
        private Game Game { get; set; }
        
        public GameConsole()
        {
            Game = new Game();
        }

        public void Welcome()
        {
            Console.WriteLine("Let's play some Hangman!");
            Console.WriteLine("You can guess a character each turn and you guess incorrect 12 times.");
            Console.WriteLine("If you at any time wants to save the game, you can type: save game");
            Console.WriteLine();
        }

        public void GameChoice()
        {
            Console.WriteLine("Do you want to play a new game or load a saved game?");
            Console.WriteLine("Type either: new game or load game");

            if (!NewGame())
            {
                LoadGame();
            }
        }

        public void PlayGame()
        {
            Welcome();
            GameChoice();
            StartGame();
            
            if (Game.IsWin())
            {
                Console.WriteLine($"You guessed the word and won the game! Congratulations!");
            }
            
            if (Game.IsLoss())
            {
                Console.WriteLine("You couldn't guess the word soon enough. You lost! Boohoo xD");
            }
            
            Console.WriteLine($"The word was {Game.Word}.");
        }

        private void StartGame()
        {
            while (!Game.IsLoss() && !Game.IsWin())
            {
                PlayRound();
            }
        }

        private void PlayRound()
        {
            Console.WriteLine($"Hidden word: {Game.HiddenWord}");
            Console.WriteLine($"Incorrect guesses left: {Game.IncorrectGuessesLeft}");
            Console.WriteLine($"Characters you already guessed: {string.Join(", ", Game.IncorrectGuesses)}");
            Console.WriteLine();

            var guess = Guess();
            if (Game.IsValidGuess(guess))
            {
                Game.MakeGuess(guess);
            }
            else
            {
                Console.WriteLine("You already guessed that! Try again.");     
            }
        }

        private char Guess()
        {
            string guess;
            do
            {
                Console.Write("Make a valid guess (only one character at a time): ");
                guess = Console.ReadLine();
            } while (guess != null && guess.Length != 1);

            return char.Parse(guess ?? string.Empty);
        }
        private void LoadGame()
        {
            
        }
        private bool NewGame()
        {
            while(true)
            {
                var choice = Console.ReadLine()?.ToLower();

                switch (choice)
                {
                    case "new":
                    case "new game":
                    case "newgame":
                        return true;
                    case "load":
                    case "load game":
                    case "loaddgame":
                        return false;
                    default:
                        Console.WriteLine("Type: new game");
                        Console.WriteLine("or: load game");
                        break;
                }
            }
        }
    }
}