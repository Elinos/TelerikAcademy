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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FilesShelf.Models;
using FilesShelf.SQLite;

namespace FilesShelf.App.Controls
{
    /// <summary>
    /// Interaction logic for LibrarianListItem.xaml
    /// </summary>
    ///     
    public enum LibrarianItemType { InProgress, Failed, Completed, Awaiting }

    public partial class LibrarianListItem : UserControl
    {

        #region Fields and Properties

        public Task taskObject;
        private SQLiteDatabase db;
        private LibrarianWindow parentWindow;
        private bool showControls;

        public bool ShowControls
        {
            get
            {
                return this.showControls;
            }
            set
            {
                this.showControls = value;
                if (!(this.taskObject.CurrentState == State.InProgress))
                {
                    if (value == false)
                    {
                        this.TargetActions_Panel.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        this.TargetActions_Panel.Visibility = Visibility.Visible;
                    }
                }
            }
        }

        #endregion

        #region Methods

        //default constructor
        public LibrarianListItem(Task task, LibrarianWindow parent, SQLiteDatabase database)
        {
            InitializeComponent();
            this.taskObject = task;
            this.db = database;
            this.parentWindow = parent;
            SetItemVisualization(task);
        }

        private void SetItemVisualization(Task task)
        {
            LibrarianItemType itemType = TranslateStateToItemType(task.CurrentState);
            ColorOutline(itemType);
            this.TargetFileName_Label.Content = task.PathName;
            ;
            if (itemType == LibrarianItemType.Failed)
            {
                PutFailButtons();
                this.TargetFileNameProgressMessage_Label.Content = "Failed to find additional data for the file.";
            }
            else if (itemType == LibrarianItemType.InProgress)
            {
                PutProgressBar();
                this.TargetFileNameProgressMessage_Label.Content = "Additional data is being collected for the file.";
            }
            else if (itemType == LibrarianItemType.Awaiting)
            {
                this.TargetFileNameProgressMessage_Label.Content = "The file is awaiting to be processed.";
            }
            else if (itemType == LibrarianItemType.Completed)
            {
                this.TargetFileNameProgressMessage_Label.Content = "New data has been collected for the file.";
            }
        }

        private static LibrarianItemType TranslateStateToItemType(State itemState)
        {
            LibrarianItemType itemType = LibrarianItemType.Awaiting;
            switch (itemState)
            {
                case State.InProgress:
                    itemType = LibrarianItemType.InProgress;
                    break;
                case State.Failed:
                    itemType = LibrarianItemType.Failed;
                    break;
                case State.Completed:
                    itemType = LibrarianItemType.Completed;
                    break;
                default:
                    itemType = LibrarianItemType.Awaiting;
                    break;
            }
            return itemType;
        }

        private void ColorOutline(LibrarianItemType itemType)
        {
            SolidColorBrush background = null;
            SolidColorBrush foreground = null;
            SolidColorBrush border = null;
            if (itemType == LibrarianItemType.Failed)
            {
                background = new SolidColorBrush(Color.FromRgb(255, 240, 240));
                foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                border = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }
            else if (itemType == LibrarianItemType.InProgress)
            {
                background = new SolidColorBrush(Color.FromRgb(255, 243, 203));
                foreground = new SolidColorBrush(Color.FromRgb(255, 204, 0));
                border = new SolidColorBrush(Color.FromRgb(255, 204, 0));
            }
            else if (itemType == LibrarianItemType.Completed)
            {
                background = new SolidColorBrush(Color.FromRgb(240, 255, 240));
                foreground = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                border = new SolidColorBrush(Color.FromRgb(0, 255, 0));
            }
            else if (itemType == LibrarianItemType.Awaiting)
            {
                background = new SolidColorBrush(Color.FromRgb(240, 240, 255));
                foreground = new SolidColorBrush(Color.FromRgb(0, 0, 255));
                border = new SolidColorBrush(Color.FromRgb(0, 0, 255));
            }

            this.ColorItem(background, foreground, border);
        }

        private void ColorItem(SolidColorBrush background, SolidColorBrush foreground, SolidColorBrush border)
        {
            this.LibrarianItemContainer_Rectangle.Fill = background;
            this.LibrarianItemContainer_Rectangle.Stroke = border;
            this.TargetFileNameProgressMessage_Label.Foreground = foreground;
        }

        private void PutFailButtons()
        {
            //      <Button Margin="0 0 5 0">Help the librarian</Button>
            //<Button>Just add</Button>
            Button helpLibrarian = new Button();
            helpLibrarian.Margin = new Thickness(0, 0, 5, 0);
            helpLibrarian.Content = "Help the librarian";
            helpLibrarian.Click += HelpClick;
            Button justAdd = new Button();
            justAdd.Content = "Just add";
            justAdd.Click += JustAddClick;
            this.TargetActions_Panel.Children.Clear();
            this.TargetActions_Panel.Children.Add(helpLibrarian);
            this.TargetActions_Panel.Children.Add(justAdd);
        }

        private void PutCancelButton()
        {
            //      <Button Margin="0 0 5 0">Help the librarian</Button>
            //<Button>Just add</Button>
            Button justAdd = new Button();
            justAdd.Content = "Just add";
            justAdd.Click += JustAddClick;
            this.TargetActions_Panel.Children.Clear();
            this.TargetActions_Panel.Children.Add(justAdd);
        }

        public void UpdateTaskISBN()
        {
            if (!String.IsNullOrEmpty(this.taskObject.ISBN))
            {
                //Task.UpdateISBN(this.taskObject.ID, this.taskObject.ISBN, this.db);
                FilesShelf.Models.Database.DbTask.UpdateISBN(this.taskObject.ID,this.taskObject.ISBN, this.db);
                this.parentWindow.StartWorker(true, true);
                this.Visibility = Visibility.Collapsed;
            }
        }

        private void PutProgressBar()
        {
            // <ProgressBar IsIndeterminate="True" Width="100" Height="15" Margin="5"/>
            ProgressBar progress = new ProgressBar();
            progress.IsIndeterminate = true;
            progress.Width = 100;
            progress.Height = 15;
            progress.Margin = new Thickness(5);
            this.TargetActions_Panel.Children.Clear();
            this.TargetActions_Panel.Children.Add(progress);
        }

        #endregion

        #region Events

        private void JustAddClick(object sender, RoutedEventArgs e)
        {
            FilesShelf.Models.Database.DbBook.Insert(this.taskObject.PathName, this.db);            
            FilesShelf.Models.Database.DbTask.SetToJustAdded(this.taskObject.ID, this.db);
            this.parentWindow.StartWorker(true,true);            
            this.Visibility = Visibility.Collapsed;
        }

        public void HideButtons()
        {
            if (this.taskObject.CurrentState != State.InProgress)
            {
                this.TargetActions_Panel.Visibility = Visibility.Collapsed;
            }
        }

        public void ShowButtons()
        {
            this.TargetActions_Panel.Visibility = Visibility.Visible;
        }

        private void HelpClick(object sender, RoutedEventArgs e)
        {
            AskForISBNWindow helperWindow = new AskForISBNWindow(this);
            helperWindow.Show();
        }

        #endregion
    }
}
