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
using AvalonDock;
using FilesShelf.Models;

namespace FilesShelf.App.Controls
{
    /// <summary>
    /// Interaction logic for BookShelf.xaml
    /// </summary>
    public partial class BookShelf : UserControl
    {
        #region Fields and Properties

        private int rows;
        private List<Book> books;
        private int selectedBookI;

        public static BookDescription DescriptionPanel { get; set; }

        public int SelectedBookI
        {
            get
            {
                return this.selectedBookI;
            }
            set
            {
                this.selectedBookI = value;
                foreach (UIElement row in this.Rows_Stack.Children)
                {
                    StackPanel booksInRow = null;
                    if (row is BookShelfTopRow)
                    {
                        BookShelfTopRow rowObj = row as BookShelfTopRow;
                        booksInRow = rowObj.Books_Stack;
                    }
                    else if (row is BookShelfRow)
                    {
                        BookShelfRow rowObj = row as BookShelfRow;
                        booksInRow = rowObj.Books_Stack;
                    }
                    foreach (UIElement item in booksInRow.Children)
                    {
                        BookIcon bookObj = item as BookIcon;
                        if (value == bookObj.ShelfIndex)
                        {
                            bookObj.Select();
                        }
                        else
                        {
                            bookObj.Deselect();
                        }
                    }
                }
            }
        }    

        public List<Book> Books
        {
            get 
            {
                return this.books;
            }
            set
            {
                this.books = value;
                this.UpdateBookIcons(true);
            }
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                this.UpdateRows(value);
                this.rows = value;
            }
        }

        #endregion

        #region Methods

        //default constructor
        public BookShelf()
        {
            InitializeComponent();
            this.Rows = 1;
            this.PutDefaultNumberOfRows();
            this.books = new List<Book>();
        }

        //extended constructor
        public BookShelf(int numberOfRows):this()
        {
            this.Rows = numberOfRows;
        }

        public void AddRow()
        {
            if (this.Rows_Stack.Children.Count==0)
            {
                this.Rows_Stack.Children.Add(new BookShelfTopRow());
            }
            else
            {
                this.Rows_Stack.Children.Add(new BookShelfRow());
            }
        }

        public void RemoveRow()
        { 
            this.Rows_Stack.Children.RemoveAt(this.Rows_Stack.Children.Count-1);
        }

        private void PutDefaultNumberOfRows()
        {
            this.Rows = 6;
        }

        public void UpdateBookIcons(bool useDefaultIndex=false)
        {
            this.Rows_Stack.Children.Clear();           
            this.rows = 0;
            int k = 0;
            int shelfIndex = 0;
            int activeRowI = 0;
            this.Rows = 1;
            this.UpdateLayout();
            int l = ((int)this.ActualWidth- 94)/100;
            if (l <= 0)
            {
                l = 1;
            }

            if (this.books.Count == 0)
            {
                this.PutDefaultNumberOfRows();
            }
            foreach (Book b in this.books)
            {
                //b.Parent = null;
                if (k == l)
                {
                    k = 1;
                    activeRowI++;
                    this.Rows++;
                }
                else
                {
                    k++;
                }
                UIElement stackItem=this.Rows_Stack.Children[activeRowI];
                BookIcon s = new BookIcon();
                s.Data = b;
                s.ShelfIndex = shelfIndex;
                s.Shelf = this;                                
                if (shelfIndex == this.selectedBookI)
                {
                    s.Select();                    
                }
                shelfIndex++;
                if(stackItem is BookShelfTopRow)
                {
                    BookShelfTopRow shelf = stackItem as BookShelfTopRow;                    
                    shelf.Books_Stack.Children.Add(s);
                }
                else if(stackItem is BookShelfRow)
                {
                    BookShelfRow shelf =stackItem  as BookShelfRow;
                    shelf.Books_Stack.Children.Add(s);
                }
                
            }
            if (this.rows < 5)
            {
                Rows+=5-this.rows;
            }
            if (useDefaultIndex)
            {
                if (this.books.Count > 0)
                {
                    this.SelectedBookI = 0;
                    BookShelf.DescriptionPanel.DescriptionTarget = this.books[0];
                }
            }
        }

        public void UpdateRows(int newRowsCount)
        {
            if (newRowsCount > this.rows)
            {
                for (int rowi = this.rows; rowi <newRowsCount;rowi++)
                {
                    this.AddRow();
                }
            }
            else if (newRowsCount < this.rows)
            {
                for (int rowi = this.rows; rowi>newRowsCount; rowi--)
                {
                    this.RemoveRow();
                }
            }
        }

        #endregion

        #region Events

        private void BookShelf_Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.UpdateBookIcons();
        }

        #endregion

    }
}
