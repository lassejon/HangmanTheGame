using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class Game
    {
        private Serializer Serializer { get; set; }
        public string Word { get; private set; }
        public string HiddenWord { get; private set; }
        public List<char> IncorrectGuesses { get; private set; }
        public int IncorrectGuessesLeft { get; private set; }
        
        private Random Random { get;  set; }

        public Game()
        {
            Serializer = new Serializer();
            Random = new Random();
            Word = InitialiseWord();
            HiddenWord = InitialiseHiddenWord();
            IncorrectGuesses = new List<char>();
            IncorrectGuessesLeft = 12;
        }

        private string InitialiseHiddenWord()
        {
            var hiddenWord = "";
            for (var i = 0; i < Word.Length; i++)
            {
                hiddenWord += "_";
            }

            return hiddenWord;
        }

        private string UpdateHiddenWord(char guess)
        {
            var result = "";
            for (var i = 0; i < Word.Length; i++)
            {
                result += Word[i] == guess ? guess : HiddenWord[i];
            }

            return result;
        }

        private bool IsCorrectGuess(char guess)
        {
            return Word.Contains(guess);
        }
        
        private string RandomWord()
        {
            var words = Serializer.ReadWords();
            var randomIndex = Random.Next(words.Length);
            var randomWord = words[randomIndex];

            return randomWord;
        }

        private string InitialiseWord()
        {
            var word = "";
            while (word.Length is > 12 or < 5)
            {
                word = RandomWord().ToLower();
            }

            return word;
        }

        public bool IsWin()
        {
            return Word == HiddenWord;
        }

        public bool IsLoss()
        {
            return IncorrectGuessesLeft <= 0;
        }

        public void MakeGuess(char guess)
        {
            guess = char.ToLower(guess);
            if (IsCorrectGuess(guess))
            {
                HiddenWord = UpdateHiddenWord(guess);
            }
            else
            {
                IncorrectGuessesLeft--;
                IncorrectGuesses.Add(guess);
            }
        }

        public List<string[]> GetSaved()
        {
            return Serializer.ReadSavedGames();
        }

        public void Load(string word, string hiddenWord, string incorrectGuessesLeft, string incorrectGuesses)
        {
            Word = word;
            HiddenWord = hiddenWord;
            IncorrectGuessesLeft = int.Parse(incorrectGuessesLeft);
            IncorrectGuesses = incorrectGuesses.Split(",").ToList().Select(char.Parse).ToList();
        }

        public void Save()
        {
            var game = $"{Word};{HiddenWord};{IncorrectGuessesLeft};{string.Join(",", IncorrectGuesses)}";
            Serializer.WriteGame(game);
        }

        public bool IsValidGuess(char guess)
        {
            return !IncorrectGuesses.Contains(guess) && !HiddenWord.Contains(guess);
        }
    }
}