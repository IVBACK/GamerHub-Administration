using GamerHub_Administration.Models;
using System.Windows;
using System.Windows.Controls;

namespace GamerHub_Administration.Pages
{
    /// <summary>
    /// Interaction logic for PostCreatePage.xaml
    /// </summary>
    public partial class PostCreatingPage : Page
    {
        private string token;
        public PostCreatingPage(string token) : base()
        {
            InitializeComponent();
            this.token = token;
        }

        private async void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            Post post = new Post()
            {
                Image = ImageLink.Text,
                Title = Title.Text,
                Content = Content.Text,
                GameName = GameName.Text
            };

            await ApiAcces.AddPostAsync(post, token);

        }

        private void btnDialogCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
