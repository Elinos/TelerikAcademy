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
    /// Interaction logic for EditableText.xaml
    /// </summary>
    public partial class EditableText : UserControl
    {
        #region Fields and Properties

        private int fontSize;
        private string text;
        public string Field;

        public int TextSize
        {
            get
            {
                return this.fontSize;
            }
            set
            {
                this.fontSize = value;
                this.Text_TextBox.FontSize = value;
            }
        }

        public string Text
        {
            get
            {
                return this.text;
            }
            set
            {
                this.text = value;
                this.Text_TextBox.Text = value;
            }
        }

        #endregion

        #region Methods

        //constructor
        public EditableText()
        {
            InitializeComponent();
            this.HideEditIcon();
        }

        private void ShowEditIcon()
        {
            this.EditIndicator_Image.Visibility = Visibility.Visible;
        }

        private void HideEditIcon()
        {
            this.EditIndicator_Image.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Events

        private void Text_TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.Text_TextBox.BorderThickness = new Thickness(1);
            this.HideEditIcon();
        }

        private void Text_TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            this.Text_TextBox.BorderThickness = new Thickness(0);
        }

        private void Text_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.text = Text_TextBox.Text;
            this.Field = Text_TextBox.Text;
        }

        private void Text_TextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            this.ShowEditIcon();
        }

        private void Text_TextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            this.HideEditIcon();
        }

        #endregion
    }
}
