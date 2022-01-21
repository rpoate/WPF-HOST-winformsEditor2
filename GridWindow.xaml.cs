using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Windows.Forms.Integration;

namespace WPF_HOST_winformsEditor
{
    /// <summary>
    /// Interaction logic for GridWindow.xaml
    /// </summary>
    public partial class GridWindow : Window
    {
        private List<User> users;
        public GridWindow()
        {
            InitializeComponent();

            users = new List<User>
            {
                new User() { Id = 1, Name = "John Smith", Birthday = new DateTime(1971, 7, 23), Profile = "<p>testing 1</p>" },
                new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17), Profile = "<p>testing 2</p><p><b>testing</b> 2</p>" },
                new User() { Id = 3, Name = "Sammy Smith", Birthday = new DateTime(1991, 9, 2), Profile = "<p>testing 3</p><p><b>testing</b> 3</p><p><b>testing</b> 3</p>" },
                new User() { Id = 4, Name = "Irene Kim", Birthday = new DateTime(1971, 7, 23), Profile = "<p>testing 1</p>" },
                new User() { Id = 5, Name = "Holly Beams", Birthday = new DateTime(1974, 1, 17), Profile = "<p>testing 2</p><p><b>testing</b> 2</p>" },
                new User() { Id = 6, Name = "Oscar Plenty", Birthday = new DateTime(1991, 9, 2), Profile = "<p>testing 3</p><p><b>testing</b> 3</p><p><b>testing</b> 3</p>" }
            };

            dgSimple.ItemsSource = users;
            dgSimple.LoadingRowDetails += DgSimple_LoadingRowDetails;

        }

        private void DgSimple_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            ((Zoople.HTMLEditControl)((WindowsFormsHost)e.DetailsElement).Child).DocumentHTML = ((User)e.Row.DataContext).Profile;
            ((Zoople.HTMLEditControl)((WindowsFormsHost)e.DetailsElement).Child).Tag = ((User)e.Row.DataContext).Id;
        }

        private void htmlEditor_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            MainWindow oWindow = new MainWindow
            {
                HTML = ((Zoople.HTMLEditControl)sender).DocumentHTML
            };

            oWindow.Owner = Window.GetWindow(this);
            oWindow.ShowDialog();

            users.FirstOrDefault(o => o.Id == (int)((Zoople.HTMLEditControl)sender).Tag).Profile = oWindow.HTML;
            ((Zoople.HTMLEditControl)sender).DocumentHTML = oWindow.HTML;

            oWindow.Close();

        }

        private void htmlEditor_CancellableUserInteraction(object sender, Zoople.CancellableUserInteractionEventsArgs e)
        {
            e.Cancel = true; // cancel any keyboard or mouse events
        }
    }

    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public string Profile { get; set; }
    }
}
