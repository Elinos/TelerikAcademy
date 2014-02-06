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

namespace FilesShelf.App.Controls
{
    /// <summary>
    /// Interaction logic for StarRate.xaml
    /// </summary>
    public partial class StarRate : UserControl
    {
        #region Fields and Properties

        private float rating;
        private bool isEditable;
        private float backupRating;
        private bool isBackupSet;
        private int maxValue;
        
        
        public int MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {                
                this.maxValue = value;
            }
        }

        public float Rating
        {
            get
            {
                return this.rating;
            }
            set
            {
                this.rating = value;
                UpdateStarRateFields();
            }
        }

        public bool IsEditable
        {
            get
            {
                return this.isEditable;
            }
            set
            {
                if (value == true)
                {
                    SetEditingEventsForStars();
                    Stars_Stack.Visibility = Visibility.Visible;
                }
                else
                {
                    Stars_Stack.Visibility = Visibility.Collapsed;
                }
                this.isEditable = value;
            }
        }

        #endregion

        #region Methods

        //default constructor
        public StarRate()
        {
            InitializeComponent();
            this.IsEditable = false;
        }

        private void SetEditingEventsForStars()
        {
            foreach (object starObj in this.Stars_Stack.Children)
            {
                Image star = starObj as Image;
                star.MouseDown += Star_Click;
                star.MouseEnter += Star_MouseOver;
            }
        }

        private void UpdateStarRateFields()
        {
            float starRate = this.rating;
            this.Rating_Label.Content = String.Format("{0:0.0}/{1}", this.rating,maxValue); 
            foreach (object starObj in this.Stars_Stack.Children)
            {
                Image star = starObj as Image;
                star.Source = new BitmapImage(new Uri("pack://application:,,,/Images/starGray.bmp"));
                if (starRate >= 1)
                {
                    star.Source = new BitmapImage(new Uri("pack://application:,,,/Images/star.bmp"));
                }
                else if (starRate > 0)
                {
                    star.Source = new BitmapImage(new Uri("pack://application:,,,/Images/halfStar.bmp"));
                }                
                starRate--;
            }
        }

        #endregion

        #region Events

        private void Star_Click(object sender, MouseButtonEventArgs e)
        {
            if (this.isEditable)
            {
                Image senderStar = sender as Image;
                this.Rating = float.Parse(senderStar.Tag as string);
                this.backupRating = this.rating;
                isBackupSet = false;
            }
        }

        private void Star_MouseOver(object sender, MouseEventArgs e)
        {
            if (this.isEditable)
            {
                if (!isBackupSet)
                {
                    this.backupRating = this.rating;
                    isBackupSet = true;
                }
                Image senderStar = sender as Image;
                this.Rating = float.Parse(senderStar.Tag as string);
            }
        }

        private void Stars_MouseLeave(object sender, MouseEventArgs e)
        {
            if (this.isEditable)
            {
                this.Rating = backupRating;
                isBackupSet = false;
            }
        }

        #endregion
    }
}
