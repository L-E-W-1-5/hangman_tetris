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
    /// Interaction logic for EnterUserName.xaml
    /// </summary>
    public partial class EnterUserName : Window
    {
        private IProfileRequester CallingForm;

        public EnterUserName(IProfileRequester calling)     
        {
            CallingForm = calling;

            InitializeComponent();

            WireUpCombobox();
        }

        private void WireUpCombobox()
        {
            List<ProfileModel> availableProfiles = Utility.GetAllProfiles();

            SelectName.ItemsSource = null;

            SelectName.ItemsSource = availableProfiles;

            SelectName.DisplayMemberPath = "UserName";
        }

        private void CreateProfileButton_Click(object sender, RoutedEventArgs e)
        {
            CreateProfile();        
        }

        private void CreateProfile()
        {
            ProfileModel userName = new();
            string name;
            bool ValidName = false;

            while (!ValidName)
            {
                if (EnterNameTextBox.Text == "" && SelectName.Text != null)
                {
                    userName = (ProfileModel)SelectName.SelectedItem;
                    ValidName = true;
                }
                else
                {
                    name = EnterNameTextBox.Text;

                    userName.UserName = name;

                    if (Utility.NameExists(userName))
                    {
                        EnterNameTextBox.Text = "";
                        MessageBox.Show("That userName already exists, either choose that name in the dropdown box or choose another name.");
                    }
                    else
                    {
                        ValidName = true;
                        Utility.CreateProfile(userName);
                    }
                }
            }
            CallingForm.ProfileComplete(userName);

            this.Close();
        }

        private void EnterNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                CreateProfile();
            }
        }
    }
}
