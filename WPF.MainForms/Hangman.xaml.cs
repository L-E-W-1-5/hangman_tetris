using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF.Backend;

namespace WPF.MainForms
{
    /// <summary>
    /// Interaction logic for Hangman.xaml
    /// </summary>
    public partial class Hangman : Window, IProfileRequester
    {
        public string? Word { get; set; }
        HangmanGame? Game { get; set; }
        public int GuessesLeft { get; set; } = 10;
        ProfileModel CurrentUser { get; set; }
        ProfileModel? SecondPlayer { get; set; } = null;
        bool SinglePlayer = false;



        public Hangman(ProfileModel currentUser)
        {            
            InitializeComponent();

            PlayerMenu.Visibility = Visibility.Visible; 
            
            CurrentUser = currentUser;
        }


        private void OnePlayerButton_Click(object sender, RoutedEventArgs e)
        {
            SinglePlayer = true;

            PlayerMenu.Visibility = Visibility.Hidden;

            StartGame();
            // TODO - Create a better word library
        }


        private void TwoPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            // From selecting 2 Player mode, another form opens to get second player name.
            // Then that form calls the 'ProfileComplete' method below, which then asks the player to select a word
            // after opening the 'SelectWordHangmanForm' form.

            SinglePlayer = false;
        
            EnterUserName enterUserName = new(this);

            enterUserName.Show();

            PlayerMenu.Visibility = Visibility.Hidden;          
        }


        public void SelectWord(ProfileModel profile)
        {
            GuessesLeft = 10;

            UsedLetters.Text = "";

            SelectWordHangmanForm selectWord = new(this, profile);

            selectWord.Show();
        }


        public void ProfileComplete(ProfileModel profile)
        {
            // After entering Player 2's name, Player 1 picks the word.
            SecondPlayer = profile;

            SelectWord(CurrentUser);
        }


        public void StartGame(string word = "")
        {
            if (SinglePlayer)
            {     
                GuessesLeft = 12;

                GuessCount.Text = GuessesLeft.ToString();

                UsedLetters.Text = "";

                WhosGuess.Text = CurrentUser.UserName;

                // Gets a random word from a file containing a library of words.
                Word = Utility.GetWord();

                Game = new(Word, CurrentUser, SinglePlayer: true);
            }
            else
            {
                Game = new(word, CurrentUser, SecondPlayer);

                WhosGuess.Text = Game.PlayerTwo.UserName;
            }
               
            string guessedChars = Game.Setup();
          
            guessedLetters.Text = guessedChars; 
        } 


        public void TakeTurn(char letter)
        {
            
            if (UsedLetters.Text.Contains(letter.ToString().ToUpper()))
            {
                MessageBox.Show("You have already used that letter, pick another.");
                return;
            }

            UsedLetters.Text += letter.ToString().ToUpper();

            guessedLetters.Text = Game?.MakeGuess(letter);

            GuessesLeft--;

            GuessCount.Text = GuessesLeft.ToString();

            if (Game != null && Game.IsWin())
            {
                // Without this messageBox, the last letter guessed of the word doesnt appear before a new game starts?
                MessageBox.Show("You Win!");
                
                Finished();
            }
            else if (Game != null && GuessesLeft == 0)
            {
                MessageBox.Show("Out Of Guesses!");

                Game.OutOfGuesses();

                Finished();
            }
        }


        private void Finished()
        {
            if (SinglePlayer && Game.IsWin())
            {
                Game.YouWin();

                PlayerOneScore.Text = Game.NumberOfGames.ToString();

                StartGame();
            }
            else if (SinglePlayer && !Game.IsWin())
            {
                StartGame();
            }

            // With a 2 Player game there will always be a winner. 
            else if (!SinglePlayer)
            {
                Game.YouWin();

                CurrentUser = Game.PlayerOne;

                SecondPlayer = Game.PlayerTwo;

                SelectWord(Game.PlayerOne);
            }
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit?", "Quit?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                MainWindow mainWindow = new();

                mainWindow.Show();

                this.Close();
            }          
        }


        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // TODO - must be a cleaner way of getting the value of the keypress.
            string k = e.Key.ToString().ToLower();
          
            TakeTurn(k[0]);
        }

        private void Qbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('q');
        }

        private void Wbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('w');
        }

        private void Ebutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('e');
        }

        private void Rbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('r');
        }

        private void Tbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('t');
        }

        private void Ybutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('y');
        }

        private void Ubutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('u');
        }

        private void Ibutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('i');
        }

        private void Obutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('o');
        }

        private void Pbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('p');
        }

        private void Abutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('a');
        }

        private void Sbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('s');
        }

        private void Dbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('d');
        }

        private void Fbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('f');
        }

        private void Gbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('g');
        }

        private void Hbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('h');
        }

        private void Jbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('j');
        }

        private void Kbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('k');
        }

        private void Lbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('l');
        }

        private void Zbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('z');
        }

        private void Xbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('x');
        }

        private void Cbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('c');
        }

        private void Vbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('v');
        }

        private void Bbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('b');
        }

        private void Nbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('n');
        }

        private void Mbutton_Click(object sender, RoutedEventArgs e)
        {
            TakeTurn('m');
        }

       
    }
}
