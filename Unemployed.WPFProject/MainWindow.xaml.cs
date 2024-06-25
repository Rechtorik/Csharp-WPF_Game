using System.Windows;
using Unemployed.CommonLibrary;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game { get; init; }
        public MainWindow(string nameOfPlayer)
        {
            InitializeComponent();
            Game = new Game(nameOfPlayer);
            DataContext = Game;
        }

        private void Apartment_Click(object sender, RoutedEventArgs e)
        {
            if (Game.Money >= Game.Rent)
            {
                MessageBoxResult result = MessageBox.Show(
                    "Do you want to go to sleep?",
                    "Sleep",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question
                );

                if (result == MessageBoxResult.Yes)
                {
                    Game.EndDay();
                    if (Game.DaysWithoutFood == 4)
                    {
                        EndGame("You was starving so much, that I had to end this game!");
                    }
                }
            }
            else
            {
                MessageBox.Show($"You don't have enough money for your rent!");
                OnShow();
            }
        }

        private void Casino_Click(object sender, RoutedEventArgs e)
        {
            if (Game.GamesPlayed > Game.GamesLimit)
            {
                MessageBox.Show($"You can't play more than {Game.GamesLimit} games per day!");
                return;
            }
            CasinoWindow casino = new(this)
            {
                DataContext = Game
            };
            casino.Show();
            Hide();
        }

        private void Restaurant_Click(object sender, RoutedEventArgs e)
        {
            Restaurant restaurant = new(Game)
            {
                DataContext = Game.Restaurant,
                Owner = this
            };
            restaurant.Show();
        }

        public void OnShow()
        {
            if ((Game.Money < Game.Rent && Game.GamesPlayed == Game.GamesLimit) || Game.Money <= 0)
            {
                EndGame("You don't have enough money for your rent!");
                Hide();
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void EndGame(string reason)
        {
            EndGame endGame = new(reason)
            {
                DataContext = Game
            };
            endGame.Show();
            Close();
        }
    }
}