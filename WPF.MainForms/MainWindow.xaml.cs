using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Backend;
using Tetris;


            // Find a better list of words to use for 1 player games.
            // Create a 'total games played' property to ProfileModel so i can create average win % etc
            // Add a second game to the main menu screen, add high scores etc
            // Add a test file?


namespace WPF.MainForms
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IProfileRequester, ICaller
    {
        ProfileModel? UserOne { get; set; }
        
        public MainWindow() 
        {
            InitializeComponent();

            WireUpCombobox();

        }

        private void WireUpCombobox()
        {
            List<ProfileModel> availableProfiles = Utility.GetAllProfiles();

            ProfilesCombo.ItemsSource = null;

            ProfilesCombo.ItemsSource = availableProfiles;

            ProfilesCombo.DisplayMemberPath = "UserName";
        }

        private void HangmanButton_Click(object sender, RoutedEventArgs e)
        {
            UserOne = (ProfileModel)ProfilesCombo.SelectedItem;

            if (UserOne != null)
            {
                Hangman hangman = new(UserOne); 

                hangman.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("You need to select a profile first.");
            }
        }

        private void CreateProfile_Click(object sender, RoutedEventArgs e)
        {
            EnterUserName enterUserName = new(this);

            enterUserName.Show();
        }

        public void ProfileComplete(ProfileModel profile)
        {
            UserOne = profile;
            
            WireUpCombobox();
        }

        private void HighScoresButton_Click(object sender, RoutedEventArgs e)
        {
            HighScores highScores = new();

            highScores.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ = StartTimeDateAsync();
        }

        private static DateTime Timer { get => DateTime.Now; }

        private async Task StartTimeDateAsync()
        {
            while (true)
            {
                await Task.Delay(1000);
                TimeText.Text = $"{Timer}";
            }
        }

        private void TetrisButton_Click(object sender, RoutedEventArgs e)
        {
            UserOne = (ProfileModel)ProfilesCombo.SelectedItem;

            if (UserOne != null)
            {
                Tetris.MainWindow tetrisOpen = new(this);
                tetrisOpen.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("You need to select a profile first.");
            }

           
        }

        public void OpenForm(int score)
        {
            // TODO - Add tetris score to profile.. 

            Utility.AddTetrisScoreToProfile(UserOne, score);

            this.Show();
        }
    }
}
