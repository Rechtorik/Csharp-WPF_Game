using System.Windows;
using System.Windows.Media;
using Unemployed.CommonLibrary;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for WheelOfFortuneWindow.xaml
    /// </summary>
    public partial class WheelOfFortuneWindow : Window
    {
        public int? GuessedNumber { get; set; }
        public bool? GuessedRed { get; set; }
        public CasinoWindow CasinoWindow { get; set; }
        public WheelOfFortuneWindow(CasinoWindow casinoWindow)
        {
            InitializeComponent();
            CasinoWindow = casinoWindow;
            GuessedRed = true;
        }

        private void ColourType_Click(object sender, RoutedEventArgs e)
        {
            WheelOfFortuneColorPickWindow wheelOfFortuneColorPickWindow = new(this);
            wheelOfFortuneColorPickWindow.Show();
        }

        private void NumberType_Click(object sender, RoutedEventArgs e)
        {
            WheelOfFortuneNumberPicker numberPicker = new(this);
            numberPicker.Show();
        }

        private void Bet_Button_Click(object sender, RoutedEventArgs e)
        {
            int bet = (int)bet_slider.Value;
            WheelOfFortune wheelOfFortune = new(bet, GuessedNumber, GuessedRed);
            if (wheelOfFortune.Result % 2 == 0)
            {
                result_textblock.Background = Brushes.Red;
            }
            else
            {
                result_textblock.Background = Brushes.Black;
            }
            result_textblock.Text = wheelOfFortune.Result.ToString();
            result_stackpanel.Visibility = Visibility.Visible;

            if (wheelOfFortune.Won())
            {
                int earned = wheelOfFortune.Earn();
                CasinoWindow.MainWindow.Game.Money += earned;
                MessageBox.Show($"The wheel landed on {wheelOfFortune.Result}\nYou earned {earned}€!");
            }
            else
            {
                MessageBox.Show($"The wheel landed on {wheelOfFortune.Result}\nYou lost {bet}€!");
            }
            CasinoWindow.MainWindow.Game.Money -= bet;
            CasinoWindow.MainWindow.Game.GamesPlayed++;

            CasinoWindow.Show();
            Close();
        }

        private void Walk_Away_Button_Click(object sender, RoutedEventArgs e)
        {
            CasinoWindow.Show();
            Close();
        }
    }
}
