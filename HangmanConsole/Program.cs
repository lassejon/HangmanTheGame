using System;
using Controller;

namespace HangmanConsole
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var game = new GameConsole();
            
            game.PlayGame();
        }
    }
}