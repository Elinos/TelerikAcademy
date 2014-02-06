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
using System.IO;

namespace FilesShelf.App.Controls
{
    /// <summary>
    /// Interaction logic for Book.xaml
    /// </summary>
    public partial class BookIcon : UserControl
    {
        #region Fields and Properties

        public Book Data
        {
            get
            {
                return this.data;
            }
            set
            {                               
                this.data = value;
                string filename = String.Format("Data\\covers\\{0}.jpg", data.Isbn);
                bool fileExists = File.Exists(filename);
                if (fileExists)
                {
                    this.BookCover_Image.Source = MainWindow.ToBitmapSource(new System.Drawing.Bitmap(filename));
                }
                else
                {
                    this.BookCover_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Data/covers/defaultCover.jpg"));
                }
            }
        }

        private Book data;
        public static BookDescription DescriptionPanel { get; set; }
        public int ShelfIndex { get; set; }
        public BookShelf Shelf { get; set; }

        #endregion

        #region Methods

        //default constructor
        public BookIcon()
        {
            InitializeComponent();                          
        }

        public void Select()
        {
            this.BookShadow_Effect.Color = Color.FromRgb(255, 255, 255);
            this.BookShadow_Effect.BlurRadius = 20;            
            this.BookShadow_Effect.ShadowDepth = 5;
            this.BookCover_Image.Margin = new Thickness(0);
            this.BookCoverEffect_Rect.Margin = new Thickness(0);
            this.BookCoverShadow_Rect.Margin = new Thickness(1);
        }

        public void Deselect()
        {
            this.BookShadow_Effect.Color = Color.FromRgb(0, 0, 0);
            this.BookShadow_Effect.BlurRadius = 10;
            this.BookShadow_Effect.ShadowDepth = 3;
            this.BookCover_Image.Margin = new Thickness(5);
            this.BookCoverEffect_Rect.Margin = new Thickness(5);
            this.BookCoverShadow_Rect.Margin = new Thickness(6);
        }

        public void ShowDataInDescription()
        {
            BookIcon.DescriptionPanel.DescriptionTarget = this.Data;
        }

        #endregion

        #region Events

        //when book is selected
        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Shelf.SelectedBookI = this.ShelfIndex;
            ShowDataInDescription();
        }

        #endregion

    }
}
