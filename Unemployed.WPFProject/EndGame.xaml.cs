using System.Windows;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for EndGame.xaml
    /// </summary>
    public partial class EndGame : Window
    {
        public string Reason { get; set; }
        public EndGame(string reason)
        {
            InitializeComponent();
            Reason = reason;
            reason_textblock.Text = Reason;
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Again_Click(object sender, RoutedEventArgs e)
        {
            Intro intro = new();
            intro.Show();
            Close();
        }
    }
}
