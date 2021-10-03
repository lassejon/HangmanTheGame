using System;
using System.IO;

namespace Controller
{
    public class Serializer
    {
        private const string WordsFilePath = "/Users/lassejon/the_odin_project/c#-projects/HangmanTheGame/Files/5desk.txt";
        
        public Serializer()
        {
        }

        public string[] ReadWords()
        {
            var words = Array.Empty<string>();
            
            if (File.Exists(WordsFilePath))
            { 
                words = File.ReadAllLines(WordsFilePath);
            }

            return words;
        }
    }
}