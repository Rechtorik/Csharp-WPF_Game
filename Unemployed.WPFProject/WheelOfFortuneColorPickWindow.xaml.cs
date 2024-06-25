using System.Windows;
using System.Windows.Media;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for WheelOfFortuneColorPickWindow.xaml
    /// </summary>
    public partial class WheelOfFortuneColorPickWindow : Window
    {
        private WheelOfFortuneWindow WheelOfFortuneWindow { get; set; }
        public WheelOfFortuneColorPickWindow(WheelOfFortuneWindow wheelOfFortuneWindow)
        {
            WheelOfFortuneWindow = wheelOfFortuneWindow;
            InitializeComponent();
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            WheelOfFortuneWindow.GuessedRed = true;
            WheelOfFortuneWindow.GuessedNumber = null;
            WheelOfFortuneWindow.pick_textblock.Text = string.Empty;
            WheelOfFortuneWindow.pick_textblock.Background = Brushes.Red;
            Close();
        }

        private void Black_Click(object sender, RoutedEventArgs e)
        {
            WheelOfFortuneWindow.GuessedRed = false;
            WheelOfFortuneWindow.GuessedNumber = null;
            WheelOfFortuneWindow.pick_textblock.Text = string.Empty;
            WheelOfFortuneWindow.pick_textblock.Background = Brushes.Black;
            Close();
        }
    }
}
