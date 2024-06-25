using System.Windows;
using Unemployed.CommonLibrary;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for DiceWindow.xaml
    /// </summary>
    public partial class DiceWindow : Window
    {
        public CasinoWindow CasinoWindow { get; set; }
        public DiceWindow(CasinoWindow casinoWindow)
        {
            CasinoWindow = casinoWindow;
            InitializeComponent();
        }

        private void Bet_Button_Click(object sender, RoutedEventArgs e)
        {
            int bet = (int)bet_slider.Value;
            int upperLimit = (int)upperLimit_slider.Value;

            DiceGame diceGame = new(bet, upperLimit);
            firstDice.Text = diceGame.FirstDice.ToString();
            secondDice.Text = diceGame.SecondDice.ToString();
            if (diceGame.Won())
            {
                int earned = diceGame.Earn();
                CasinoWindow.MainWindow.Game.Money += earned;
                MessageBox.Show($"Sum was {diceGame.SecondDice + diceGame.FirstDice}\nYou earned {earned}€!");
            }
            else
            {
                MessageBox.Show($"You lost {bet}€!");
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
