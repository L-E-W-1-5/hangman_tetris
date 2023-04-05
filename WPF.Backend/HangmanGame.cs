using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF.Backend
{
    public class HangmanGame
    {
        private string? Word { get; set; }
        public char[] WordGuessed { get; set; }
        private string GuessedLetters { get; set; } = string.Empty;  
        public ProfileModel PlayerOne { get; set; }
        public ProfileModel? PlayerTwo { get; set; }
        bool SinglePlayer = false;
        public bool GameComplete = false;
        public int NumberOfGames;
        public StringBuilder? returnString;
        

        public HangmanGame(string word, ProfileModel playerOne, ProfileModel? playerTwo = null, bool SinglePlayer = false) 
        {
            Word = word.ToLower();

            WordGuessed = new char[Word.Length];

            PlayerOne = playerOne;

            PlayerTwo = playerTwo;

            this.SinglePlayer = SinglePlayer;
        }


        public void SwitchPlayersForNextTurn()
        {
            ProfileModel temporary;
            temporary = PlayerOne;
            PlayerOne = PlayerTwo;
            PlayerTwo = temporary;
        }


        public string Setup()
        {
            returnString = new();

            GameComplete = false;

            if (Word != null && WordGuessed != null)
            {                           
                for (int i = 0; i < Word.Length; i++)
                {
                    WordGuessed[i] = '_';

                    returnString.Append("_.");
                }            
            }
                    // Gets rid of the last '.' dot.
            return returnString.ToString().Remove(returnString.Length-1);
        }


        public string MakeGuess(char letter) 
        {     
            returnString = new(); 

            if (Word.Contains(letter) && !GuessedLetters.Contains(letter))
            {
                var letterIndex = Word.Select((character, index) => new { character, index })
                    .Where(word => word.character == letter)
                    .Select(word => word.index)
                    .ToList();

                foreach (int i in letterIndex)
                {
                    WordGuessed[i] = letter;
                }            
            }
            // Creates the string to send back to Hangman.cs
            for (int i = 0; i <= WordGuessed.Length - 1; i++)
            {
                returnString.Append($"{WordGuessed[i]}.");
            };

            GuessedLetters += letter;   

            return returnString.ToString().Remove(returnString.Length-1);
        }


        public bool IsWin() 
        {
            int counter = 0;

            for (int i = 0; i <= WordGuessed.Length - 1; i++)
            {
                if (Word[i] == WordGuessed[i]) counter++;

                if (counter == Word.Length)
                {
                    GameComplete = true;
                    return true;
                }
            }
            return false;
        }


        public void YouWin()     
        {
            if (!SinglePlayer)
            {
                SwitchPlayersForNextTurn();         
            }
            // Counts number of wins for 1 player games.
            NumberOfGames++;

            SaveWinnerAsync();
        }


        private async void SaveWinnerAsync()
        {
            await SaveWinner();
        }


        private Task SaveWinner()
        {
            Task task = Task.Run(() => Utility.AddScoreToProfile(PlayerOne));
            return task;
        }


        public void OutOfGuesses()
        {
            if (!SinglePlayer)
            {
                SaveWinnerAsync();

                SwitchPlayersForNextTurn();
            }
        }
    }
}
