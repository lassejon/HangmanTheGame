using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Controller
{
    public class Serializer
    {
        private const string Path = "/Users/lassejon/the_odin_project/c#-projects/HangmanTheGame/Files/";
        private const string WordsFile = "5desk.txt";
        private const string SavedGamesFile = "savedGames.txt";
        
        public string[] ReadWords()
        {
            var words = Array.Empty<string>();
            
            if (File.Exists(Path + WordsFile))
            { 
                words = File.ReadAllLines(Path + WordsFile);
            }

            return words;
        }

        public List<string[]> ReadSavedGames()
        {
            var savedGames = new List<string[]>();
            
            if (File.Exists(Path + SavedGamesFile))
            {
                var file = File.ReadLines(Path + SavedGamesFile);
                savedGames.AddRange(file.Select(line => line.Split(";")));
            }

            return savedGames;
        }

        public void WriteGame(string game)
        {
            using (var sw = File.AppendText(Path + SavedGamesFile)) {
                sw.WriteLine(game);
            }
        }
    }
}