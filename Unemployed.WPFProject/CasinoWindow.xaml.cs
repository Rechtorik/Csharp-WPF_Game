using System.Windows;
using System.Windows.Input;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for CasinoWindow.xaml
    /// </summary>
    public partial class CasinoWindow : Window
    {
        public MainWindow MainWindow { get; set; }
        public CasinoWindow(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            InitializeComponent();
        }

        private void Go_out_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Show();
            MainWindow.OnShow();
            Close();
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            if (!CanPlay())
            {
                return;
            }
            DiceWindow diceWindow = new(this)
            {
                DataContext = MainWindow.Game
            };
            diceWindow.Show();
            Hide();
        }

        private bool CanPlay() {
            if (MainWindow.Game.GamesPlayed < (CommonLibrary.Game.GamesLimit) && MainWindow.Game.Money > 0)
            {
                return true;
            }
            if (MainWindow.Game.Money <= 0)
            {
                MessageBox.Show($"You have no money!");
                return false;
            }
            MessageBox.Show($"You can't play more than {CommonLibrary.Game.GamesLimit} games per day!");
            return false;
        }

        private void CoinFlip_Click(object sender, RoutedEventArgs e)
        {
            if (!CanPlay())
            {
                return;
            }
            CoinFlipWindow coinFlipWindow = new(this)
            {
                DataContext = MainWindow.Game
            };
            coinFlipWindow.Show();
            Hide();
        }

        private void WheelOfFortune_Click(object sender, RoutedEventArgs e)
        {
            if (!CanPlay())
            {
                return;
            }
            WheelOfFortuneWindow wheelOfFortuneWindow = new(this)
            {
                DataContext = MainWindow.Game
            };
            wheelOfFortuneWindow.Show();
            Hide();
        }
        private void Dice_MouseEnter(object sender, MouseEventArgs e)
        {
            describtion_textblock.Text = "Bet on number that will be larger than sum of 2 dice\n (the riskier = the more you earn ¯\\_(͠≖ ͜ʖ͠≖)_/¯ )";
        }

        private void Coin_MouseEnter(object sender, MouseEventArgs e)
        {
            describtion_textblock.Text = "Bet on Heads or Tails (2x bet)";
        }

        private void Wheel_MouseEnter(object sender, MouseEventArgs e)
        {
            describtion_textblock.Text = "Bet on colour (2x bet), or on specific number (10x bet)";
        }

        private void SetDescriptionToNull_MouseLeave(object sender, MouseEventArgs e) 
        {
            describtion_textblock.Text = string.Empty;
        }
    }
}
