using GamerHub_Administration.Models;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GamerHub_Administration.Pages
{
    /// <summary>
    /// Interaction logic for FriendsPage.xaml
    /// </summary>
    public partial class FriendsPage : Page
    {
        private List<User> friendList = new();
        private int? userId;
        private string token;

        public FriendsPage(string name, string token, int? id) : base()
        {
            InitializeComponent();
            this.userId = id;
            this.token = token;
            FriendOfLabel.Content = "Friends Of " + name;
            RefreshFriendsList();
        }

        public async void RefreshFriendsList()
        {
            friendList = await ApiAcces.GetFriendsAsync(token, userId);
            FriendsDataGrid.ItemsSource = friendList;
        }
    }
}
