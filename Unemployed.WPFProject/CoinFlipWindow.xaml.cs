using System.Windows;
using Unemployed.CommonLibrary;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for CoinFlipWindow.xaml
    /// </summary>
    public partial class CoinFlipWindow : Window
    {
        public CasinoWindow CasinoWindow { get; set; }
        private bool _head = true;
        public CoinFlipWindow(CasinoWindow casinoWindow)
        {
            CasinoWindow = casinoWindow;
            InitializeComponent();
        }

        private void Walk_Away_Button_Click(object sender, RoutedEventArgs e)
        {
            CasinoWindow.Show();
            Close();
        }

        private void Bet_Button_Click(object sender, RoutedEventArgs e)
        {
            int bet = (int)bet_slider.Value;
            CoinFlip coinFlipGame = new(bet, _head);
            if (coinFlipGame.Won())
            {
                int earned = coinFlipGame.Earn();
                CasinoWindow.MainWindow.Game.Money += earned;
                MessageBox.Show($"{coinFlipGame.GetResultSring()} fell on a coin\nYou earned {earned}€!");
            }
            else
            {
                MessageBox.Show($"{coinFlipGame.GetResultSring()} fell on a coin\nYou lost {bet}€!"); 
            }
            CasinoWindow.MainWindow.Game.Money -= bet;
            CasinoWindow.MainWindow.Game.GamesPlayed++;

            CasinoWindow.Show();
            Close();
        }

        private void Tails_Click(object sender, RoutedEventArgs e)
        {
            current_textblock.Text = "Tails";
            _head = false;
        }

        private void Heads_Click(object sender, RoutedEventArgs e)
        {
            current_textblock.Text = "Heads";
            _head = true;
        }
    }
}
