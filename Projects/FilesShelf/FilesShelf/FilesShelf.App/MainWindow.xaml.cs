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
using FilesShelf.App.Controls;
using FilesShelf.SQLite;
using drawing = System.Drawing;
using System.Net;
using System.Data;
using AvalonDock;
using AvalonDock.Layout;
using FilesShelf.Models;
using System.IO;

namespace FilesShelf.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Fields and Properties

        private bool isLibrarianWorking;
        public LibrarianWindow libWindow;
        public SQLiteDatabase Data;
        private QueryManager queriesManager;
        public BooksLibrary booksLibrary;

        public bool IsLibrarianWorking
        {
            get
            {
                return this.isLibrarianWorking;
            }
            set
            {
                UpdateWorkMonitor(value, "Librarian is working");
                this.isLibrarianWorking = value;
            }
        }

        #endregion

        #region Methods

        //default constructor
        public MainWindow()
        {
            InitializeComponent();
            //init db
            this.InitDb("Data\\MediaLibrary.sqlite");
            //init queryManager, it makes a defalt query, when initilized
            this.queriesManager = new QueryManager();
            queriesManager.db = this.Data;
            //init delete and open buttons
            this.ToggleDeleteAndOpenSelectedBookButtons(false);
            //init librarian
            InitLibrarian();
            //set description panel refferances
            SetDescriptionRefferances();
            this.queriesManager.Request = new QueryRequest("", GroupByType.ByTitleStartingLetter);
            PopulateControls(queriesManager.Response);
            this.SelectFirstGroupFromGroupsList();
            //Test();
        }

        //remove later in the show
        private void Test()
        {
            List<Book> booka = new List<Book>();
            List<Book> bookb = new List<Book>();
            booka.Add(new Book());
            booka.Add(new Book());
            booka.Add(new Book());
            booka.Add(new Book());
            bookb.Add(new Book());
            List<Book> bookc = new List<Book>();
            bookc.Add(new Book());
            bookc.Add(new Book());
            bookc.Add(new Book());
            bookc.Add(new Book());
            bookc.Add(new Book());
            bookc.Add(new Book());
            bookc.Add(new Book());
            bookc.Add(new Book());
            bookc.Add(new Book());
            //test add shelf tabs
            AddShelfTab("new s", booka);
            AddShelfTab("as", bookb);
            UpdateActiveShelfTab(bookc);
            //testing groups list control
            for (int i = 0; i < 20; i++)
            {
                this.AddNewGroupToGroupsList("new group");
            }

            //this.DeleteAllShelfTabs();

        }

        //not tested
        /*public static drawing.Bitmap getImageFromURL(String sURL)
        {
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(sURL);
            myRequest.Method = "GET";
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(myResponse.GetResponseStream());
            myResponse.Close();
            return bmp;
        }

        public static BitmapSource ToBitmapSource(string filename)
        {
            drawing.Bitmap sourceBitmap = new drawing.Bitmap(filename);
            return ToBitmapSource(sourceBitmap);
        }
        */
        public static BitmapSource ToBitmapSource(drawing.Bitmap source)
        {
            BitmapSource bitSrc = null;

            var hBitmap = source.GetHbitmap();
            bitSrc = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                hBitmap,
                IntPtr.Zero,
                Int32Rect.Empty,
                BitmapSizeOptions.FromEmptyOptions());
            return bitSrc;
        }

        public void RepeatQuery(bool reset=true)
        {
            if (this.queriesManager != null)
            {
                this.queriesManager.GenerateResponse();
                this.PopulateControls(this.queriesManager.Response,reset);
            }
        }

        public void ToggleDeleteAndOpenSelectedBookButtons(bool makeActive)
        {
            this.OpenSelectedBook_MenuItem.IsEnabled = makeActive;
            this.DeleteSelectedBook_MenuItem.IsEnabled = makeActive;
        }

        private void SetDescriptionRefferances()
        {
            BookIcon.DescriptionPanel = this.booksDescriptionPanel;
            BookShelf.DescriptionPanel = this.booksDescriptionPanel;
            this.booksDescriptionPanel.ContainerWindow = this;
        }

        private void InitLibrarian()
        {
            this.IsLibrarianWorking = false;
            this.libWindow = new LibrarianWindow(this);

            //this.booksLibrary = new BooksLibrary();
        }


        private void InitDb(string datasource)
        {
            this.Data = new SQLiteDatabase(datasource);
        }

        public static void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public static bool AskForConfirmation(string message)
        {
            MessageBoxResult messageBoxRes = MessageBox.Show(message, "Confirm?", MessageBoxButton.YesNo);
            return messageBoxRes == MessageBoxResult.Yes;
        }

        private void ShowLibrarianWindow()
        {
            if (this.libWindow != null)
            {
                libWindow.Show();
            }
        }

        private void UpdateWorkMonitor(bool isActive, string messageWhenActive = "working")
        {
            if (isActive)
            {
                StackPanel monitorStack = new StackPanel();
                monitorStack.Orientation = Orientation.Horizontal;
                Label monitorMessage = new Label();
                ProgressBar progressMonitor = new ProgressBar();
                progressMonitor.Width = 50;
                progressMonitor.Height = 10;
                progressMonitor.IsIndeterminate = true;
                progressMonitor.Margin = new Thickness(2);
                this.WorkMonitor_BarItem.Content = progressMonitor;
                this.WorkMonitorMessage_BarItem.Content = messageWhenActive;
            }
            else
            {
                this.WorkMonitorMessage_BarItem.Content = "ready";
                this.WorkMonitor_BarItem.Content = null;
            }
        }

        private void ExecuteNewQueryRequest(string searchTerm)
        {
            QueryRequest newRequest = new QueryRequest(searchTerm, this.queriesManager.Request.GroupingType);
            this.queriesManager.Request = newRequest;
        }

        private void ExecuteNewQueryRequest(GroupByType groupingType)
        {
            string searchTerm = this.SearchTerm_TextCombo.Text;
            QueryRequest newRequest = new QueryRequest(searchTerm, groupingType);
            this.queriesManager.Request = newRequest;
        }

        private void PopulateControls(Dictionary<string, List<Book>> response,bool reset=true)
        {
            if (reset)
            {
                this.DeleteAllShelfTabs();
                this.booksDescriptionPanel.DescriptionTarget = null;                
            }
            DeleteAllGroupsFromGroupsList();           
            var keys = response.Keys.OrderBy(x => x);            
            foreach (var key in keys)
            {
                AddNewGroupToGroupsList(key);
            }            
        }

        public static void OpenFile(string fileName)
        {
            try
            {
                if (!File.Exists(fileName))
                {
                    throw new IOException();
                }
                System.Diagnostics.Process.Start(fileName);
            }
            catch (IOException)
            {                
                throw new Exception("The selected file cannot be opened.");
            }
        }

        #endregion

        #region Groups list Methods

        private void AddNewGroupToGroupsList(string groupName)
        {
            this.FilterResultGroups_List.Items.Add(groupName);
        }

        private void DeleteAllGroupsFromGroupsList()
        {

            this.FilterResultGroups_List.Items.Clear();
        }

        private void SelectFirstGroupFromGroupsList()
        {
            this.FilterResultGroups_List.SelectedIndex = 0;
        }

        private string GetSelectedGroupIdentifier()
        {
            string group = "";
            if (this.FilterResultGroups_List.SelectedItem != null)
            {
                ListBoxItem selGroupItem = this.FilterResultGroups_List.SelectedItem as ListBoxItem;
                group = selGroupItem.Content as string;
            }
            return group;
        }

        #endregion

        #region Document tab Methods

        public void AddShelfTab(string tabTitle, List<Book> shelfCollection)
        {
            LayoutDocument document = new LayoutDocument();
            document.Title = tabTitle;            
            document.IsSelectedChanged += LayoutDocument_IsSelectedChanged;
            //adding some content to the tab
            BookShelf tabShelf = new BookShelf(6);
            tabShelf.Books = shelfCollection;
            document.Content = tabShelf;
            this.BookShelf_Pane.Children.Add(document);
            this.BookShelf_Pane.SelectedContentIndex = this.BookShelf_Pane.Children.Count-1;
        }

        public void UpdateActiveShelfTab(List<Book> updatedShelfCollection)
        {
            int activeDocumentIndex = this.BookShelf_Pane.SelectedContentIndex;
            LayoutDocument activeDocument = this.BookShelf_Pane.Children[activeDocumentIndex] as LayoutDocument;
            BookShelf tabShelf = new BookShelf(6);
            tabShelf.Books = updatedShelfCollection;
            activeDocument.Content = tabShelf;
        }

        public void DeleteAllShelfTabs()
        {
            this.BookShelf_Pane.Children.Clear();
        }

        #endregion

        #region Events

        private void LayoutDocument_IsSelectedChanged(object sender, EventArgs e)
        {
            int activeDocumentIndex = this.BookShelf_Pane.SelectedContentIndex;
            if (activeDocumentIndex >= 0 && this.BookShelf_Pane.Children[activeDocumentIndex] is LayoutDocument)
            {
                LayoutDocument activeDocument = this.BookShelf_Pane.Children[activeDocumentIndex] as LayoutDocument;
                object potentialShelf = activeDocument.Content;
                if (potentialShelf is BookShelf)
                {
                    BookShelf shelf = potentialShelf as BookShelf;
                    this.booksDescriptionPanel.DescriptionTarget = shelf.Books[0];
                    shelf.SelectedBookI = 0;
                }
            }
            else
            {
                this.booksDescriptionPanel.DescriptionTarget = null;
            }
        }

        private void AboutBoxLauncher_Button_Click(object sender, RoutedEventArgs e)
        {
            AboutFilesShelf aboutBox = new AboutFilesShelf();
            aboutBox.Show();
        }

        private void Import_Button_Click(object sender, RoutedEventArgs e)
        {
            ImportFilesWindow importWindow = new ImportFilesWindow(this);
            importWindow.Show();
        }

        private void CloseApp_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Librarian_Button_Click(object sender, RoutedEventArgs e)
        {
            this.ShowLibrarianWindow();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.libWindow != null)
            {
                this.libWindow.StopWorker();
            }
        }

        private void OpenSelectedBook_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenFile(this.booksDescriptionPanel.DescriptionTarget.PathName);
        }

        private void DeleteSelectedBook_Click(object sender, RoutedEventArgs e)
        {
            //check for user confirmation, before deleting the selected book
            bool isApproved = MainWindow.AskForConfirmation("Are you sure you want to delete this book?");
            if (!isApproved)
            {
                return;
            }
            //delete book here
            Book selectedBook = this.booksDescriptionPanel.DescriptionTarget;
            List<Book> updatedShelfCollection = this.queriesManager.Response[selectedBook.Title[0].ToString()];            
            updatedShelfCollection.Remove(selectedBook);
            FilesShelf.Models.Database.DbBook.Delete(selectedBook.ID,this.Data);
            UpdateActiveShelfTab(updatedShelfCollection);
            if (updatedShelfCollection.Count <1)
            {
                this.RepeatQuery();
            }
        }

        private void ExecuteSearch_Click(object sender, RoutedEventArgs e)
        {
            //get new searchTerm
            string newSearchTerm = this.SearchTerm_TextCombo.Text;
            if (!this.SearchTerm_TextCombo.Items.Contains(newSearchTerm))
            {
                this.SearchTerm_TextCombo.Items.Add(newSearchTerm);
            }
            //make new request
            //this.ExecuteNewQueryRequest(newSearchTerm);
            //wait for response...
            this.Cursor = Cursors.Wait;
            //finished waiting            
            //get responcs  
            Dictionary<string, List<Book>> queryResponse = this.queriesManager.Response;
            //some other stuff, like fill Groups list with keys of response
            this.ExecuteNewQueryRequest(newSearchTerm);
            PopulateControls(this.queriesManager.Response);
            this.SelectFirstGroupFromGroupsList();
            this.Cursor = Cursors.Arrow;
        }

        private void FilterResultsGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selItem = this.FilterResultGroups_List.SelectedItem;
            if (selItem != null && selItem is string)
            {
                string groupName = selItem as string;
                AddShelfTab(groupName, this.queriesManager.Response[groupName]);
                this.BookShelf_Pane.SelectedContentIndex = this.BookShelf_Pane.Children.Count - 1;
            }
        }

        private void AuthorsGroupByButton_Click(object sender, RoutedEventArgs e)
        {
            this.queriesManager.Request = new QueryRequest(this.SearchTerm_TextCombo.Text, GroupByType.ByAuthor);
            PopulateControls(queriesManager.Response);
        }

        private void Books_Click(object sender, RoutedEventArgs e)
        {
            this.queriesManager.Request = new QueryRequest(this.SearchTerm_TextCombo.Text, GroupByType.ByTitleStartingLetter);
            PopulateControls(this.queriesManager.Response);
        }

        private void Genres_Click(object sender, RoutedEventArgs e)
        {
            this.queriesManager.Request = new QueryRequest(this.SearchTerm_TextCombo.Text, GroupByType.ByGenres);
            PopulateControls(queriesManager.Response);
        }

        //DONT KNOW WHAT TO USE FOR

        private void GroupByConditionChange_Click(object sender, RoutedEventArgs e)
        {
            //if (this.GroupByStartingLetter_Radio.IsChecked == true)
            //{
            //    this.ExecuteNewQueryRequest(GroupByType.ByTitleStartingLetter);
            //}
            //else if (this.GroupByAuthors_Radio.IsChecked == true)
            //{
            //    this.ExecuteNewQueryRequest(GroupByType.ByAuthor);
            //}
            //else
            //{
            //    this.ExecuteNewQueryRequest(GroupByType.ByRating);
            //}
            //something similar to the method above            
        }

        private void SpecificLabel_OnClick(object sender, EventArgs e)
        {
            /*foreach (var ch in FilterGroups_Stack.Children)
            {
                ((Label)ch).Foreground = Brushes.Black;
            }

            ((Label)sender).Foreground = Brushes.DarkGray;
            ((Label)sender).Focus();*/
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            /*FilterTypeLabel.Content = Authors.Name;

            SQLiteDatabase database = new SQLiteDatabase("MediaLibrary.sqlite");
            string query = "SELECT * FROM 'Authors'";

            DataTable authors;
            authors = database.GetDataTable(query);

            FilterGroups_Stack.Children.Clear();
            foreach (DataRow r in authors.Rows)
            {
                Label authorFilter = new Label();
                authorFilter.Content = r["AuthorName"].ToString();
                authorFilter.Focusable = true;
                authorFilter.MouseDown += SpecificLabel_OnClick;
                FilterGroups_Stack.Children.Add(authorFilter);
            }*/
        }

        //private void Books_Click(object sender, RoutedEventArgs e)
        //{
        //    /*FilterTypeLabel.Content = Books.Name;

        //    SQLiteDatabase database = new SQLiteDatabase("MediaLibrary.sqlite");
        //    string query = "SELECT * FROM 'Books'";

        //    DataTable books;
        //    books = database.GetDataTable(query);

        //    FilterGroups_Stack.Children.Clear();
        //    foreach (DataRow r in books.Rows)
        //    {
        //        Label booksFilter = new Label();
        //        booksFilter.Content = r["title"].ToString();
        //        booksFilter.Focusable = true;
        //        booksFilter.MouseDown += SpecificLabel_OnClick;
        //        FilterGroups_Stack.Children.Add(booksFilter);
        //    }

        //    //test add shelf tabs
        //    AddShelfTab("new s", booksLibrary.MediaList);
        //    AddShelfTab("as", booksLibrary.MediaList);
        //    UpdateActiveShelfTab(booksLibrary.MediaList);*/
        //}

        //private void Genres_Click(object sender, RoutedEventArgs e)
        //{
        //    /* FilterTypeLabel.Content = Genres.Name;

        //     SQLiteDatabase database = new SQLiteDatabase("MediaLibrary.sqlite");
        //     string query = "SELECT * FROM 'Genres'";

        //     DataTable genres = database.GetDataTable(query);

        //     FilterGroups_Stack.Children.Clear();
        //     foreach (DataRow genre in genres.Rows)
        //     {
        //         Label genreFilter = new Label();
        //         genreFilter.Content = genre["genre"].ToString();
        //         genreFilter.Focusable = true;
        //         genreFilter.MouseDown += SpecificLabel_OnClick;
        //         FilterGroups_Stack.Children.Add(genreFilter);
        //     }*/
        //}

        private void Movies_Click(object sender, RoutedEventArgs e)
        {
            //FilterTypeLabel.Content = Movies.Name;
            // FilterGroups_Stack.Children.Clear();
        }

        private void Songs_Click(object sender, RoutedEventArgs e)
        {
            //FilterTypeLabel.Content = Songs.Name;
            //FilterGroups_Stack.Children.Clear();
        }

        private void Rating_Click(object sender, RoutedEventArgs e)
        {
            //FilterTypeLabel.Content = Rating.Name;
            //FilterGroups_Stack.Children.Clear();
        }

        private void Authors_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Books_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void Genres_GotFocus(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
