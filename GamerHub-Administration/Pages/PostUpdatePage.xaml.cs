using GamerHub_Administration.Models;
using System.Windows;
using System.Windows.Controls;

namespace GamerHub_Administration.Pages
{
    /// <summary>
    /// Interaction logic for PostUpdatePage.xaml
    /// </summary>
    public partial class PostUpdatePage : Page
    {
        private string token;
        Post post;

        public PostUpdatePage(string token, Post postSelected) : base()
        {
            InitializeComponent();
            this.token = token;
            this.post = postSelected;
            ImageLink.Text = this.post.Image;
            Title.Text = this.post.Title;
            Content.Text = this.post.Content;
            GameName.Text = this.post.GameName;
        }

        private async void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            Post postUpdated = new Post()
            {
                Image = ImageLink.Text,
                Title = Title.Text,
                Content = Content.Text,
                GameName = GameName.Text,
                PostId = post.PostId
            };
            await ApiAcces.PostUpdateAsync(postUpdated, token);
        }

        private void btnDialogCancel_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
