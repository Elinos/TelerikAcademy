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
using FilesShelf.Models.Database;
using System.IO;
namespace FilesShelf.App.Controls
{
    /// <summary>
    /// Interaction logic for BookDescription.xaml
    /// </summary>
    public partial class BookDescription : UserControl
    {
        #region Fields and Properties

        public MainWindow ContainerWindow { get; set; }
        private Book descriptionTarget;

        public Book DescriptionTarget
        {
            get
            {
                return this.descriptionTarget;
            }
            set
            {
                this.descriptionTarget = value;
                //there is no book to describe, so hide all the controls
                bool doShowDesc = value == null;
                if (doShowDesc)
                {
                    this.HideDescription();
                }
                else
                {
                    this.Populate();
                    this.ShowDescription();
                }
                //update MainWindow controls
                if (this.ContainerWindow != null)
                {
                    this.ContainerWindow.ToggleDeleteAndOpenSelectedBookButtons(!doShowDesc);
                }
            }
        }

        public bool IsShowingData { get; set; }

        #endregion

        #region Methods

        //default constructor
        public BookDescription()
        {
            InitializeComponent();
            this.DescriptionTarget = null;
        }

        //extended constructor
        public BookDescription(Book bookToDescribe)
            : this()
        {
            this.DescriptionTarget = bookToDescribe;
        }

        public void ShowDescription()
        {
            this.BookDescription_Container.Visibility = Visibility.Visible;
            this.IsShowingData = true;

        }

        public void HideDescription()
        {
            this.BookDescription_Container.Visibility = Visibility.Hidden;
            this.IsShowingData = false;
        }

        //this method fills the editable controls with data
        public void Populate()
        {
            //TO DO: FILL WITH DescriptionTarget data
            //book cover
            string filename = String.Format("Data\\covers\\{0}.jpg",this.descriptionTarget.Isbn);
            bool fileExists = File.Exists(filename);
            if (fileExists)
            {
                this.BookCoverPreview_Image.Source = MainWindow.ToBitmapSource(new System.Drawing.Bitmap(filename));
            }
            else
            {
                this.BookCoverPreview_Image.Source = new BitmapImage(new Uri("pack://application:,,,/Data/covers/defaultCover.jpg"));
            }   
            //general information
            this.BookTitle_Editable.Text = this.DescriptionTarget.Title;
            this.BookAuthors_Editable.Text = String.Join(" ,", this.DescriptionTarget.Authors);
            this.BookDescription_Editable.Text = this.DescriptionTarget.Description;
            this.BookGenres_Editable.Text = String.Join(", ", this.DescriptionTarget.Genres);
            //star rates
            this.BookLibraryThing_StarRate.Rating = (float)this.DescriptionTarget.SiteRating;
            this.BookUser_StarRate.Rating = (float)this.DescriptionTarget.UserRating;
            //publication information
            this.BookPublisher_Editable.Text = this.DescriptionTarget.Publisher;
            //this.BookPublishDate_Editable.Text = this.DescriptionTarget.PublicationDate.Value.ToString("dd.MM.yyyy");
        }

        #endregion

        #region Events

        //when the title has been edited
        private void BookTitle_Editable_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.DescriptionTarget.Title != this.BookTitle_Editable.Text)
            {
                //change message
                string message = "Confirm editing?";
                bool isEditingApproved = MainWindow.AskForConfirmation(message);
                //cancel if edit is not approved
                if (!isEditingApproved)
                {
                    return;
                }
                //doing some editing here
                this.DescriptionTarget.Title = this.BookTitle_Editable.Text;
                DbBook.Update(this.DescriptionTarget.ID, this.DescriptionTarget, this.ContainerWindow.Data);
                this.ContainerWindow.RepeatQuery(false);
            }
        }

        //when the athors have been edited
        private void BookAuthors_Editable_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.BookAuthors_Editable.Text != String.Join(", ", this.DescriptionTarget.Authors))
            {
                //change message
                string message = "Confirm editing?";
                bool isEditingApproved = MainWindow.AskForConfirmation(message);
                //cancel if edit is not approved
                if (!isEditingApproved)
                {
                    return;
                }
                string[] splittedAuthors = this.BookAuthors_Editable.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                this.DescriptionTarget.Authors = new List<Person>();
                foreach (var author in splittedAuthors)
                {
                    Person toAdd = new Person();
                    toAdd.FullName = author;
                    this.DescriptionTarget.Authors.Add(toAdd);
                }
                DbBook.Update(this.DescriptionTarget.ID, this.DescriptionTarget, this.ContainerWindow.Data);
                this.ContainerWindow.RepeatQuery(false);
            }
        }

        //when the description has been edited
        private void BookDescription_Editable_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.DescriptionTarget.Description != this.BookDescription_Editable.Text)
            {
                //change message
                string message = "Confirm editing?";
                bool isEditingApproved = MainWindow.AskForConfirmation(message);
                //cancel if edit is not approved
                if (!isEditingApproved)
                {
                    return;
                }
                //doing some editing here
                this.DescriptionTarget.Description = this.BookDescription_Editable.Text;
                DbBook.Update(this.DescriptionTarget.ID, this.DescriptionTarget, this.ContainerWindow.Data);
                this.ContainerWindow.RepeatQuery(false);
            }
        }

        private void BookGenres_Editable_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.BookGenres_Editable.Text != String.Join(", ", this.DescriptionTarget.Genres))
            {
                //change message
                string message = "Confirm editing?";
                bool isEditingApproved = MainWindow.AskForConfirmation(message);
                //cancel if edit is not approved
                if (!isEditingApproved)
                {
                    return;
                }
                //doing some editing here
                string[] splittedGenres = this.BookGenres_Editable.Text.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                this.DescriptionTarget.Genres = new List<Genre>();
                foreach (var genre in splittedGenres)
                {
                    Genre toAdd = new Genre();
                    toAdd.Name = genre;
                    this.DescriptionTarget.Genres.Add(toAdd);
                }
                DbBook.Update(this.DescriptionTarget.ID, this.DescriptionTarget, this.ContainerWindow.Data);
                this.ContainerWindow.RepeatQuery(false);
            }
        }

        //when the user book rating is changed
        private void BookUserStarRate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (this.DescriptionTarget.UserRating != (decimal)this.BookUser_StarRate.Rating)
            {
                //change message
                string message = "Confirm editing?";
                bool isEditingApproved = MainWindow.AskForConfirmation(message);
                //cancel if edit is not approved
                if (!isEditingApproved)
                {
                    return;
                }
                //doing some editing here
                this.DescriptionTarget.UserRating = (decimal)this.BookUser_StarRate.Rating;
                DbBook.Update(this.DescriptionTarget.ID, this.DescriptionTarget, this.ContainerWindow.Data);
                this.ContainerWindow.RepeatQuery(false);
            }
        }

        //when publisher is edited
        private void BookPublisher_Editable_LostFocus(object sender, RoutedEventArgs e)
        {
            if (this.DescriptionTarget.Publisher != this.BookPublisher_Editable.Text)
            {
                //change message
                string message = "Confirm editing?";
                bool isEditingApproved = MainWindow.AskForConfirmation(message);
                //cancel if edit is not approved
                if (!isEditingApproved)
                {
                    return;
                }
                //doing some editing here
                this.DescriptionTarget.Publisher = this.BookPublisher_Editable.Text;
                DbBook.Update(this.DescriptionTarget.ID, this.DescriptionTarget, this.ContainerWindow.Data);
                this.ContainerWindow.RepeatQuery(false);
            }
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.OpenFile(this.descriptionTarget.PathName);
        }

        //when the publish date is edited
        /*private void BookPublishDate_Editable_LostFocus(object sender, RoutedEventArgs e)
        {
            DateTime date;
            if (DateTime.TryParse(this.BookPublishDate_Editable.Text, out date))
            {
                if (this.DescriptionTarget.PublicationDate != date)
                {
                    //change message
                    string message = "Confirm editing?";
                    bool isEditingApproved = MainWindow.AskForConfirmation(message);
                    //cancel if edit is not approved
                    if (!isEditingApproved)
                    {
                        return;
                    }
                    //doing some editing here
                    this.DescriptionTarget.PublicationDate = date;
                    DbBook.Update(this.DescriptionTarget.ID, this.DescriptionTarget, this.ContainerWindow.Data);
                }
            }
            else
            {
                MainWindow.ShowMessage("Wrong date format");
            }

        }*/

        #endregion


    }
}
