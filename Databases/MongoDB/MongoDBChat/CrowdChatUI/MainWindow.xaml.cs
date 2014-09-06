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
using MongoDB.Driver.Builders;
using MongoDBData;
using MongoDBModels;
using System.Timers;
using System.Collections.ObjectModel;
using System.Threading;

namespace CrowdChatUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User currentUser;
        private DBData dbData;
        private readonly ObservableCollection<Post> posts;
        private DateTime lastUpdatDateTime;
        private Thread updatePostAsync;


        public MainWindow()
        {
            InitializeComponent();
            Keyboard.Focus(LoginTB);
            this.dbData = new DBData();
            this.posts = new ObservableCollection<Post>();
            this.lastUpdatDateTime = DateTime.Now;
            this.PostListView.ItemsSource = this.posts;
            this.UpdatePostsEachMsAsync();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.updatePostAsync.Abort();
            Application.Current.Shutdown();
        }

        private void ScrollListViewToBottom()
        {
            this.PostListView.SelectedIndex = this.PostListView.Items.Count - 1;
            this.PostListView.ScrollIntoView(this.PostListView.SelectedItem);
        }

        private void UpdatePosts()
        {
            this.UpdatePosts(DateTime.Now);
        }

        private async void UpdatePosts(DateTime time)
        {
            this.lastUpdatDateTime = time.AddMinutes(-30);
            var getPostsSince = await this.GetPostsSince(this.lastUpdatDateTime);
            var newPosts = getPostsSince.Where(n => !(posts.Select(n1 => n1.Id).Contains(n.Id)));

            foreach (var post in newPosts)
            {
                this.posts.Add(post);
            }

            this.ScrollListViewToBottom();
        }

        private Task<IList<Post>> GetPostsSince(DateTime time)
        {
            return Task.Run(
                () =>
                {
                    var result = dbData.GetPostsSince(time);
                    return result;
                });
        }

        private void UpdatePostsEachMsAsync(int timeout = 1000)
        {
            this.updatePostAsync = new Thread(
                () =>
                {
                    while (true)
                    {
                        this.PostListView.Dispatcher.BeginInvoke((Action)this.UpdatePosts);
                        Thread.Sleep(timeout);
                    }
                });

            this.updatePostAsync.Start();
        }

        private void LoginBtnClick(object sender, RoutedEventArgs e)
        {
            var username = LoginTB.Text;
            this.currentUser = ReturnUserFromDB(username);
            LoginGrid.Visibility = Visibility.Collapsed;
            PostsGrid.Visibility = Visibility.Visible;
            PostTB.Focusable = true;
            Keyboard.Focus(PostTB);
            LoginBTN.IsDefault = false;
            SendBTN.IsDefault= true;
        }

        private User ReturnUserFromDB(string username)
        {
            var user = dbData.FindUserByName(username);
            if (user == null)
            {
                user = dbData.AddUser(username);
            }

            return user;
        }

        private void SendBtnClick(object sender, RoutedEventArgs e)
        {
            var msg = PostTB.Text;
            dbData.AddPost(currentUser, msg);
            PostTB.Text = "";
        }
    }
}
