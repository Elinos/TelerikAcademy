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
using System.IO;
using FilesShelf.Models;
using UrlHistoryLibrary;
using FilesShelf.SQLite;
using System.Collections;
using FilesShelf.Models.Database;

namespace FilesShelf.App
{
    /// <summary>
    /// Interaction logic for ImportFilesWindow.xaml
    /// </summary>
    public partial class ImportFilesWindow : Window
    {
        #region Fields and Properties

        private MainWindow parentWindow;

        #endregion

        #region Methods

        //default constructor
        public ImportFilesWindow()
        {
            InitializeComponent();
        }

        //extended constructor
        public ImportFilesWindow(MainWindow parentWindow)
            : this()
        {
            this.parentWindow = parentWindow;
        }


        private void SelectFolder(string pathName)
        {
            if (!String.IsNullOrEmpty(pathName))
            {
                this.FolderName_Textbox.Text = pathName;
            }
        }

        private static BitmapSource ToBitmapSource(System.Drawing.Bitmap source)
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

        private void AddSelectedFilesToDbForImport(string[] files)
        {
            if (this.parentWindow != null)
            {
                foreach (string file in files)
                {
                    DbTask.Insert(file, this.parentWindow.Data);
                }
            }
        }

        private void LoadRecentFiles()
        {
            try
            {
                this.Cursor = Cursors.Wait;
                List<string> recentPdfs = new List<string>();
                UrlHistoryWrapperClass urlHistory = new UrlHistoryWrapperClass();
                UrlHistoryWrapperClass.STATURLEnumerator enumerator = urlHistory.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    STATURL currentURL = enumerator.Current;
                    string currentUrlExt = currentURL.URL.Substring(currentURL.URL.Length - 3, 3);
                    string currentUrlProtocol = currentURL.URL.Substring(0, 4);
                    bool isTheURLaPdf = currentUrlExt == "pdf";
                    bool isTheURLProtocolaFile = currentUrlProtocol == "file";
                    if (isTheURLaPdf && isTheURLProtocolaFile)
                    {
                        string filename = currentURL.URL.Substring(8);
                        filename = filename.Replace("%20", " ");
                        filename = filename.Replace("/", @"\");
                        if (File.Exists(filename))
                        {
                            recentPdfs.Add(filename);
                        }
                    }
                    //if(enumerator.Current.)
                }
                this.RecentFiles_List.Items.Clear();
                foreach (string recentPdf in recentPdfs)
                {
                    ListBoxItem listItem = new ListBoxItem();
                    listItem.Content = recentPdf;
                    this.RecentFiles_List.Items.Add(listItem);
                }
                this.Cursor = Cursors.Arrow;
            }
            catch (Exception fail)
            {
                throw new Exception("An error occured when trying to load recent files list.");
                this.Cursor = Cursors.Arrow;
                return;
            }
        }

        private List<string> GetSelectedFilesFromDialog()
        {
            List<string> filesForImport = new List<string>();
            ListBox activeList = this.FilesInFolder_List;
            if (this.ExploreOptions_Tabs.SelectedIndex == 1)
            {
                activeList = this.RecentFiles_List;
            }
            foreach (ListBoxItem item in activeList.Items)
            {
                if (item.IsSelected)
                {
                    string fileForImport = item.Content as string;
                    if (File.Exists(fileForImport))
                    {
                        filesForImport.Add(SQLiteDatabase.EscapeSpecialChars(fileForImport));
                    }
                }
            }
            return filesForImport;
        }

        #endregion

        #region Events

        private void ImportFilesWithLibrarian_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.parentWindow != null)
            {
                this.Cursor = Cursors.Wait;
                List<string> filesForImport = GetSelectedFilesFromDialog();
                //add files for processing
                //REMOVE COMPLETED TASKS HERE!
                this.AddSelectedFilesToDbForImport(filesForImport.ToArray());
                //show librarian window
                this.parentWindow.libWindow = new LibrarianWindow(this.parentWindow);
                this.parentWindow.libWindow.Show();
                this.Cursor = Cursors.Arrow;
            }
            //close current window
            this.Close();
        }

        private void FilesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox senderListBox = sender as ListBox;
            int selectionIndex = senderListBox.SelectedIndex;
            ListBoxItem listItem = senderListBox.SelectedItem as ListBoxItem;
            string filename = "";
            if (listItem != null)
            {
                filename = listItem.Content as string;
            }
            bool fileDoesntExist=!File.Exists(filename);
            if (selectionIndex < 0 || fileDoesntExist)
            {
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri("Images/defaultBookBack.jpg", UriKind.Relative);
                logo.EndInit();
                this.FileIconPreview_Image.Source = logo;
                if (fileDoesntExist)
                {
                    this.FileParameters_TextBlock.Text = "The selected file does not exist.";
                }
                else
                {
                    this.FileParameters_TextBlock.Text = "No file selected.";
                }
            }
            else
            {
                System.Drawing.Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(filename);
                this.FileIconPreview_Image.Source = ToBitmapSource(icon.ToBitmap());
                this.FileParameters_TextBlock.Text = filename;
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BrowseFolder_Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string FolderName = dialog.SelectedPath;
            SelectFolder(FolderName);
        }

        private void FolderName_Textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string folderName = this.FolderName_Textbox.Text;
            this.FilesInFolder_List.Items.Clear();
            if (Directory.Exists(folderName))
            {
                string[] filesInDir = Directory.GetFiles(folderName, "*.pdf");
                foreach (string file in filesInDir)
                {
                    ListBoxItem lItem = new ListBoxItem();
                    lItem.Content = file;
                    this.FilesInFolder_List.Items.Add(lItem);
                }
            }
        }

        private void ImportFiles_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            List<string> filesForImport = this.GetSelectedFilesFromDialog();
            foreach (string fileToImport in filesForImport)
            {
                Models.Database.DbBook.Insert(fileToImport, this.parentWindow.Data);
            }
            this.Cursor = Cursors.Arrow;
            this.parentWindow.RepeatQuery();
            this.Close();
            //MainWindow.ShowMessage("Simply adding...");
        }

        private void SelectAll_Button_Click(object sender, RoutedEventArgs e)
        {
            ToggleFoldersListItemsCheckedState(true);
        }

        private void SelectNone_Button_Click(object sender, RoutedEventArgs e)
        {
            ToggleFoldersListItemsCheckedState(false);
        }

        private void ToggleFoldersListItemsCheckedState(bool state)
        {
            int selTabI = this.ExploreOptions_Tabs.SelectedIndex;
            ListBox activeListBox = this.FilesInFolder_List;
            if (activeListBox != null)
            {
                if (selTabI == 1)
                {
                    activeListBox = this.RecentFiles_List;
                }
                foreach (object item in activeListBox.Items)
                {
                    ListBoxItem lItem = item as ListBoxItem;
                    lItem.IsSelected = state;
                }
            }
        }


        private void RecentFilesList_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.RecentFiles_List.Items.Count == 0)
            {
                LoadRecentFiles();
            }
        }

        private void ExploreOptionTabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selTabI = this.ExploreOptions_Tabs.SelectedIndex;
            ListBox inactiveListBox = this.FilesInFolder_List;
            if (inactiveListBox != null)
            {
                if (selTabI == 0)
                {
                    inactiveListBox = this.RecentFiles_List;
                }
                foreach (object item in inactiveListBox.Items)
                {
                    ListBoxItem lItem = item as ListBoxItem;
                    lItem.IsSelected = false;
                }
            }
        }

        #endregion
    }
}
