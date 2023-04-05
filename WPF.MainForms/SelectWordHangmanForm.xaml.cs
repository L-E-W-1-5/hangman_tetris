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
    /// Interaction logic for SelectWordHangmanForm.xaml
    /// </summary>
    public partial class SelectWordHangmanForm : Window
    {
        Hangman Hangman;

        public SelectWordHangmanForm(Hangman hangman, ProfileModel profile)
        {
            Hangman = hangman;
            InitializeComponent();
            WhosWord.Text = profile.UserName;
        }

       

        private void CreateWordButton_Click(object sender, RoutedEventArgs e)
        {
            CreateWord();
        }

        private void CreateWord()
        {
            if (Validate())
            {
                string word = EnterWordText.Text;

                Hangman.Show();

                Hangman.StartGame(word);

                this.Close();
            }       // TODO - Finish this method.
            // else... messagebox..
        }

        private bool Validate()
        {
            if (EnterWordText.Text == "") return false; // TODO - Create validation for the word..

            if (EnterWordText.Text.Length < 2) return false;

            // if (!word.Contains() < 'a' || !word.Contains() > 'z') TODO - needs to be a for loop checking individual chars to do this.
            return true;
        }

        private void EnterWordText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CreateWord();
            }
        }
    }
}
