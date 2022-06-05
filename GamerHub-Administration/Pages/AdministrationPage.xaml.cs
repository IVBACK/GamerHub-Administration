using GamerHub_Administration.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GamerHub_Administration.Pages
{
    /// <summary>
    /// Interaction logic for AdministrationPage.xaml
    /// </summary>
    public partial class AdministrationPage : Page
    {
        private Admin admin;
        private List<Post> postList = new();
        private List<User> userList = new();

        public AdministrationPage(Admin admin) : base()
        {
            InitializeComponent();
            this.admin = admin;
            IdTextBox.Text = admin.Id.ToString();
            NameTextBox.Text = admin.Name;
            EmailTextBox.Text = admin.Email;
            RefreshPostList();
            RefreshUserList();
        }

        private void PostRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Post post = (Post)PostDataGrid.SelectedItem;
            if (post != null)
            {
                ShowPostRemoveDialog();
            }
            else
            {
                MessageBox.Show("No Item Selected");
            }
        }

        private void PostAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new PostCreatingPage(admin.Token));
        }

        private async void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            await RefreshPostList();
        }

        public async Task RefreshPostList()
        {
            postList = await ApiAcces.GetPostsAsync(admin.Token);
            PostDataGrid.ItemsSource = postList;
        }

        private async void ShowPostRemoveDialog()
        {
            string msgtext = "Do you want to remove selected post?";
            string txt = "Post Remove Confirm";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxResult result = MessageBox.Show(msgtext, txt, button);

            switch (result)
            {
                case MessageBoxResult.OK:
                    Post post = (Post)PostDataGrid.SelectedItem;
                    await ApiAcces.DeletePostAsync(post.PostId, admin.Token);
                    await RefreshPostList();
                    break;

                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void PostUpdateButton_Click(object sender, RoutedEventArgs e)
        {
            Post post = (Post)PostDataGrid.SelectedItem;
            if (post != null)
            {
                this.NavigationService.Navigate(new PostUpdatePage(admin.Token, post));
            }
            else
            {
                MessageBox.Show("No Item Selected");
            }
        }


        /// ///////////////////////////////////////


        public async Task RefreshUserList()
        {
            userList = await ApiAcces.GetUsersAsync(admin.Token);
            UserDataGrid.ItemsSource = userList;
        }


        private void UserRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            ShowUserRemoveDialog();
        }

        private async void UserRefreshButton_Click(object sender, RoutedEventArgs e)
        {
            await RefreshUserList();
        }

        private async void ShowUserRemoveDialog()
        {
            string msgtext = "Do you want to remove selected user?";
            string txt = "User Remove Confirm";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxResult result = MessageBox.Show(msgtext, txt, button);

            switch (result)
            {
                case MessageBoxResult.OK:
                    User user = (User)UserDataGrid.SelectedItem;
                    await ApiAcces.DeleteUserAsync(user.Id, admin.Token);
                    await RefreshUserList();
                    break;

                case MessageBoxResult.Cancel:
                    break;
            }
        }

        private void UserDataGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            User user = (User)UserDataGrid.SelectedItem;
            this.NavigationService.Navigate(new FriendsPage(user.Name, admin.Token, user.Id));
        }
    }
}
