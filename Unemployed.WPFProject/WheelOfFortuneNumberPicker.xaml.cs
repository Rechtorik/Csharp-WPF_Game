using System.Windows;
using System.Windows.Media;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for WheelOfFortuneNumberPicker.xaml
    /// </summary>
    public partial class WheelOfFortuneNumberPicker : Window
    {
        private WheelOfFortuneWindow WheelOfFortuneWindow { get; set; }
        public WheelOfFortuneNumberPicker(WheelOfFortuneWindow wheelOfFortuneWindow)
        {
            InitializeComponent();
            WheelOfFortuneWindow = wheelOfFortuneWindow;
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(1);
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(2);
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(3);
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(4);
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(5);
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(6);
        }

        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(7);
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(8);
        }

        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(9);
        }

        private void Ten_Click(object sender, RoutedEventArgs e)
        {
            SetNumber(10);
        }

        private void SetNumber(int number) 
        {
            WheelOfFortuneWindow.GuessedNumber = number;
            WheelOfFortuneWindow.GuessedRed = null;
            WheelOfFortuneWindow.pick_textblock.Text = $"{number}";
            if (number % 2 == 0)
            {
                WheelOfFortuneWindow.pick_textblock.Background = Brushes.Red;
            }
            else
            {
                WheelOfFortuneWindow.pick_textblock.Background = Brushes.Black;
            }
            Close();
        }
    }
}
