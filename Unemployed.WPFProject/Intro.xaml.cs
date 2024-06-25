using System.Windows;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for Intro.xaml
    /// </summary>
    public partial class Intro : Window
    {
        public Intro()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new(name_textbox.Text);
            mainWindow.Show();
            Close();
        }
    }
}
