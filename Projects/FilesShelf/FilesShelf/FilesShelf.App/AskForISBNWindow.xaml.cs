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
using System.Windows.Shapes;
using FilesShelf.App.Controls;
using FilesShelf.Models;

namespace FilesShelf.App
{
    /// <summary>
    /// Interaction logic for AskForISBNWindow.xaml
    /// </summary>
    public partial class AskForISBNWindow : Window
    {
        #region Fields and Properties

        private LibrarianListItem parentListItem;

        #endregion

        #region Methods

        //default constructor
        public AskForISBNWindow(LibrarianListItem parent)
        {
            InitializeComponent();
            this.parentListItem = parent;
        }

        #endregion

        #region Events

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            this.parentListItem.taskObject.ISBN = this.ISBN_Textbox.Text;
            this.parentListItem.taskObject.CurrentState = State.Waiting;
            this.parentListItem.UpdateTaskISBN();
            this.Close();
        }

        #endregion

    }
}
