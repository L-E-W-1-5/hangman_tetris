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
using System.Windows.Shapes;
using WPF.Backend;

namespace WPF.MainForms
{
    /// <summary>
    /// Interaction logic for HighScores.xaml
    /// </summary>
    public partial class HighScores : Window
    {
        public HighScores()
        {
            InitializeComponent();
        }

        private void HighScoresListBox_Loaded(object sender, RoutedEventArgs e)
        {

            // TODO - Get text aligned + maybe add 'number of games' as a property to the profile to create a ratio of wins to games?

            List<ProfileModel> availableProfiles = Utility.GetAllProfiles();

            var orderedByScore = availableProfiles.OrderByDescending(x => x.HangmanScore);

            foreach (ProfileModel profile in orderedByScore)
            {
                HighScoresListBox.Items.Add($"{profile.UserName,0} {"-",6} {profile.HangmanScore,10}, {profile.TetrisScore,14}");
            }
            // TODO - Create a button for arranging the high scores either in order of hangman score or order of tetris score
        }
    }
}
