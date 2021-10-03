using System;
using System.Collections.Generic;
using System.Linq;

namespace Controller
{
    public class Game
    {
        private Serializer Serializor { get; set; }
        public string Word { get; private set; }
        public string HiddenWord { get; private set; }
        public List<char> IncorrectGuesses { get; private set; }
        public int IncorrectGuessesCount { get; private set; }
        
        private Random Random { get;  set; }

        public Game()
        {
            Serializor = new Serializer();
            Random = new Random();
            Word = InitialiseWord();
            HiddenWord = InitialiseHiddenWord();
            IncorrectGuesses = new List<char>();
            IncorrectGuessesCount = 0;
        }

        private string InitialiseHiddenWord()
        {
            var hiddenWordToGuess = "";
            for (var i = 0; i < Word.Length; i++)
            {
                hiddenWordToGuess += "_";
            }

            return hiddenWordToGuess;
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
            var words = Serializor.ReadWords();
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
            return IncorrectGuessesCount >= 12;
        }

        public void MakeGuess(char guess)
        {
            IncorrectGuessesCount++;
            guess = char.ToLower(guess);
            if (IsCorrectGuess(guess))
            {
                HiddenWord = UpdateHiddenWord(guess);
                return;
            }

            // if (IsWin())
            // {
            //     Console.WriteLine("WIN! WIN! WIN! WIN! WIN! WIN! WIN! WIN!");
            // }
            //
            // if (IsLoss())
            // {
            //     Console.WriteLine("Loss! Loss! Loss! Loss! Loss! Loss! Loss!");
            // }
            
            IncorrectGuesses.Add(guess);
        }

        public void Play()
        {
            Console.WriteLine(Word);
            Console.WriteLine(HiddenWord);

            var guessA = 'a';
            var guessM = 'b';
            var guessI = 'I';
            var guessW = 'g';
            var guesssO = 'o';
            var guessE = 'E';
            var guessY = 'y';
            var guessD = 'd';
            var guessK = 'r';
            var guessL = 'l';
            var guessZ = 's';
            var guesssC = 't';
            var guessU = 'U';
            var guessJ = 'C';
            
            MakeGuess(guessA);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessM);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessI);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessW);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guesssO);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessE);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessY);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessD);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessK);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessL);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessZ);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guesssC);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessU);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
            
            MakeGuess(guessJ);
            Console.WriteLine(HiddenWord);
            Console.WriteLine(string.Join(", ", IncorrectGuesses));
        }
    }
}