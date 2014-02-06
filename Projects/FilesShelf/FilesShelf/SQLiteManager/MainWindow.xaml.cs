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
using FilesShelf.SQLite;
using System.Data;
using Microsoft.Win32;

namespace SQLiteManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
             this.database= new SQLiteDatabase("MediaLibrary.sqlite");
        }

        private SQLiteDatabase database;

        private void ExecuteQuery(string queryString)
        {
            try
            {
                DataTable books;
                //SOME EXAMPLE QUERIES
                //DROP TABLE IF EXISTS 'books'
                //CREATE TABLE IF NOT EXISTS 'books' (id INTEGER PRIMARY KEY AUTOINCREMENT,title TEXT NULL)
                //INSERT INTO 'books'(title) VALUES('newbook')
                //SELECT COUNT(*) FROM 'books'
                //SELECT * FROM 'books'
                //UPDATE 'books' SET title='new book between 5 and 10' WHERE id>5 AND id<10
                //SELECT id as [identifier],title as [book's title] FROM 'books' WHERE title='newbook'
                //DELETE FROM 'books' WHERE id>10
                String query = queryString;
                books = this.database.GetDataTable(query);
                //YOU CAN ALSO USE ExecuteScalar()(for single value result) or ExecuteNonQuery() methods.
                this.QueryResults_DataGrid.ItemsSource = books.DefaultView;                   
            }
            catch (Exception fail)
            {
                String error = "The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n\n";
                MessageBox.Show(error);
            }

        }

        private void ExecuteQuery_Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.QueryString_Combo.Text.ToUpper() == "SOURCE")
            {
                string loadedFilename = "";
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.FileName = ""; // Default file name
                dlg.DefaultExt = ".sqlite"; // Default file extension
                dlg.Filter = "SQLite databases (.sqlite)|*.sqlite"; // Filter files by extension 

                // Show open file dialog box
                Nullable<bool> result = dlg.ShowDialog();

                // Process open file dialog box results 
                if (result == true)
                {
                    // Open document 
                    loadedFilename = dlg.FileName;
                }
                if (!String.IsNullOrEmpty(loadedFilename))
                {
                    this.database = new SQLiteDatabase(loadedFilename);
                }
            }
            else
            {
                ExecuteQuery(this.QueryString_Combo.Text);
                ComboBoxItem newQuery = new ComboBoxItem();
                newQuery.Content = this.QueryString_Combo.Text;
                if (!this.QueryString_Combo.Items.Contains(newQuery))
                {
                    this.QueryString_Combo.Items.Add(newQuery);
                }
            }
        }
    }
}
