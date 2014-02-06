using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FilesShelf.App.Controls;
using System.ComponentModel;
using System.Threading;
using FilesShelf.Models;
using dbObjects = FilesShelf.Models.Database;
using System.Net;
using System.IO;
using System.Reflection;

namespace FilesShelf.App
{
    /// <summary>
    /// Interaction logic for LibrarianWindow.xaml
    /// </summary>
    public partial class LibrarianWindow : Window
    {
        #region Fields and Properties

        private readonly BackgroundWorker backgroundWorker = new BackgroundWorker();
        private MainWindow parentWindow;

        #endregion

        #region Methods

        //default constructor
        public LibrarianWindow(MainWindow parentWindow)
        {
            this.Cursor = Cursors.Arrow;
            InitializeComponent();
            InitBackgroundWorker();
            this.parentWindow = parentWindow;
            this.StartWorker();
        }

        private void PopulateTasksList(Task[] activeTasks)
        {
            this.LibrarianTasks_List.Children.Clear();
            foreach (Task task in activeTasks)
            {
                LibrarianListItem listItem = new LibrarianListItem(task, this, this.parentWindow.Data);
                this.LibrarianTasks_List.Children.Add(listItem);
            }
        }

        #endregion

        #region backgroundWorker Methods

        public void StartWorker(bool checkIfBusy=false,bool refreshWindow=false)
        {
            if (checkIfBusy == true && this.backgroundWorker.IsBusy == true)
            {
                return;
            }
            dbObjects.DbTask.RefreshTasks(parentWindow.Data);
            dbObjects.DbTask.DeleteUnusedTasks(parentWindow.Data);            
            Task[] activeTasks = dbObjects.DbTask.SelectAllTasks(parentWindow.Data);
            if (activeTasks.Length == 0)
            {
                return;
            }
            bool hasItemInProgress = false;
            bool hasWaitingItem = false;
            foreach (Task task in activeTasks)
            {
                if (task.CurrentState == State.InProgress)
                {
                    hasItemInProgress = true;
                }
                else if (task.CurrentState == State.Waiting)
                {
                    hasWaitingItem = true;
                }
            }
            if (hasWaitingItem)
            {
                this.parentWindow.IsLibrarianWorking = true;
            }
            //if no item is being processed
            if (!hasItemInProgress && hasWaitingItem)
            {
                dbObjects.DbTask.SetNewItemInProgress(this.parentWindow.Data);
                //Task.SetInProgress(activeTasks[0].ID,this.parentWindow.Data);
            }
            Task[] updatedTasks = dbObjects.DbTask.SelectAllTasks(parentWindow.Data);
            //populate tasks list
            PopulateTasksList(updatedTasks);
            this.Librarian_PorgressBar.Maximum = updatedTasks.Length;
            this.Librarian_PorgressBar.Value = 0;
            if (hasWaitingItem || hasItemInProgress)
            {
                this.HideButtonsInList();
                this.backgroundWorker.RunWorkerAsync(this.parentWindow.Data);
            }
            if (refreshWindow)
            {
                this.parentWindow.RepeatQuery();            
            }
        }

        private void InitBackgroundWorker()
        {
            backgroundWorker.DoWork += worker_DoWork;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.RunWorkerCompleted += worker_RunWorkerCompleted;
            backgroundWorker.ProgressChanged += worker_ProgressChanged;
            this.backgroundWorker.WorkerSupportsCancellation = true;
        }

        private void InsertBookOnTaskCompletion(Book book)
        {
            dbObjects.DbBook.Insert(book, this.parentWindow.Data);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            SQLite.SQLiteDatabase database = e.Argument as SQLite.SQLiteDatabase;
            Task[] tasks = dbObjects.DbTask.SelectAllTasks(database);
            int currentItemIndex = 1;
            foreach (var task in tasks)
            {
                if (task.CurrentState == State.Waiting || task.CurrentState == State.InProgress)
                {              
                    //do work here
                    var book = new Book { PathName = task.PathName };
                    if (!String.IsNullOrEmpty(task.ISBN))
                    {
                        book.Isbn = task.ISBN;
                        BooksLibrary.CreateBook(book);
                        task.CurrentState = (book.Title != null) ? State.Completed : State.Failed;
                    }
                    else
                    {
                        var parsedText = BookLibraryManager.ParseUsingPdfBox(@book.PathName);
                        if (parsedText == null)
                        {
                            task.CurrentState = State.Failed;
                        }
                        else
                        {
                            var processedIsbn = BookLibraryManager.GetIsbn(parsedText);
                            if (processedIsbn != null)
                            {
                                book.Isbn = processedIsbn;
                                BooksLibrary.CreateBook(book);

                                task.CurrentState = book.Title != null ? State.Completed : State.Failed;
                            }
                            else
                            {
                                task.CurrentState = State.Failed;
                            }
                        }
                    }
                    //try to download the cover
                    if (task.CurrentState != State.Failed)
                    {
                        bool succToDownloadImage = DownloadImageByUrl(book.Cover, book.Isbn);
                        if (!succToDownloadImage)
                        {
                            task.CurrentState = State.Failed;
                            continue;
                        }
                    }
                    //
                    if (task.CurrentState == State.Completed)
                    {
                        dbObjects.DbTask.SetToCompleted(task.ID, database);
                        this.InsertBookOnTaskCompletion(book);                        
                    }
                    else if (task.CurrentState == State.Failed)
                    {
                        dbObjects.DbTask.SetToFailed(task.ID, database);
                    }
                    dbObjects.DbTask.SetNewItemInProgress(database);
                    Task[] newUpdatedTasks = dbObjects.DbTask.SelectAllTasks(database);
                    backgroundWorker.ReportProgress(currentItemIndex, newUpdatedTasks);
                }
                currentItemIndex++;
            }
        }

            static bool DownloadImageByUrl(string url,string id)
            {
                try
                {
                    WebClient webClient = new WebClient();
                    url = url.Remove(4, 1);
                    string baseDir = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    webClient.DownloadFile(url, baseDir+String.Format(@"\\Data\\covers\\{0}.jpg", id));
                    return true;
                }
                catch
                {
                    return false;
                    //throw new ArgumentException(String.Format("Librarian failed to download the book cover image: {0}", url));
                }
            }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.Librarian_PorgressBar.Value = e.ProgressPercentage;
            Task[] newUpdatedTasks = e.UserState as Task[];
            PopulateTasksList(newUpdatedTasks);
            HideButtonsInList();
        }

        private void HideButtonsInList()
        {
            foreach (LibrarianListItem item in this.LibrarianTasks_List.Children)
            {
                item.HideButtons();
            }
        }

        private void worker_RunWorkerCompleted(object sender,
                                               RunWorkerCompletedEventArgs e)
        {
            MainWindow.ShowMessage("Librarian has finished importing your files!");
            this.parentWindow.RepeatQuery();            
            this.parentWindow.IsLibrarianWorking = false;
            ShowButtonsInList();
            StartWorker();
        }

        private void ShowButtonsInList()
        {
            foreach (LibrarianListItem item in this.LibrarianTasks_List.Children)
            {
                item.ShowButtons();
            }
        }

        public void StopWorker()
        {
            this.backgroundWorker.CancelAsync();
            this.Close();
        }

        #endregion

        #region Events

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        #endregion
    }
}
