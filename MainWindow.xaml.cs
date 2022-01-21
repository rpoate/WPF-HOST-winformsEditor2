using System;
using System.Windows;
using System.Windows.Forms;

namespace WPF_HOST_winformsEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string HTML { 
            get 
            {
                return htmlEditor.DocumentHTML;
            }
            set 
            { 
                htmlEditor.DocumentHTML = value;
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            htmlEditor.DocumentLoadComplete += HtmlEditor_DocumentLoadComplete;

            htmlEditor.CSSText = "body {font-family: arial}";
            htmlEditor.FontSizesList = "10pt;12pt;14pt;18pt;22pt";
        }

        private void HtmlEditor_DocumentLoadComplete(object sender, EventArgs e)
        {

        }
    }
}
