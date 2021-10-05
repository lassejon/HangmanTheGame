using System;
using System.Collections.Generic;
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

                switch (guess)
                {
                    case "save":
                    case "save game":
                    case "savegame":
                        SaveGame();
                        Console.WriteLine("Game has been saved.");
                        break;
                }
            } while (guess != null && guess.Length != 1);

            return char.Parse(guess ?? string.Empty);
        }

        private void SaveGame()
        {
            Game.Save();
        }

        private void LoadGame()
        {
            var savedGames = Game.GetSaved();
            if (savedGames.Count > 0)
            {
                ShowSavedGames(savedGames);
                var gameNumber = -1;

                var choice = "";
                do
                {
                    Console.WriteLine("Choose a game to load. Write a number corresponding to the game");
                    choice = Console.ReadLine();
                } while (!int.TryParse(choice, out gameNumber) ||
                         (gameNumber < 0 || gameNumber > savedGames.Count));

                var word = savedGames[gameNumber][0];
                var hiddenWord = savedGames[gameNumber][1];
                var incorrectGuessesLeft = savedGames[gameNumber][2];
                var incorrectGuesses = savedGames[gameNumber][3];

                Game.Load(word, hiddenWord, incorrectGuessesLeft, incorrectGuesses);
            }
            else
            {
                Console.WriteLine("There aren't any saved games ready to load.");
                Console.WriteLine("Starting new game instead");
            }
        }
        
        private void ShowSavedGames(List<string[]> savedGames)
        {
            for (var i = 0; i < savedGames.Count; i++)
            {
                Console.WriteLine($"({i}) Hidden word: {savedGames[i][1]} Incorrect guesses left: {savedGames[i][2]}");
            }
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