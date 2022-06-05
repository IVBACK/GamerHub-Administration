using GamerHub_Administration.Models;
using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace GamerHub_Administration.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
            SetVersionLabel();
            UrlTextBox.Text = "https://gamerhubapi.azurewebsites.net/";
        }
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(UrlTextBox.Text))
            {
                MessageBox.Show("Api Url Needed");
                return;
            }

            Admin adminLoginRequest = new Admin()
            {
                Email = EmailTextBox.Text,
                Password = PasswordTextBox.Password.ToString()
            };

            ApiAcces.uri = new Uri(UrlTextBox.Text);
            Admin admin = await ApiAcces.AdminLogin(adminLoginRequest);

            if (admin != null)
            {
                this.NavigationService.Navigate(new AdministrationPage(admin));
            }
            else
            {
                MessageBox.Show("Wrong Password Or Email!");
            }
        }

        private void SetVersionLabel()
        {
            VersionLabel.Content = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }


    }
}
