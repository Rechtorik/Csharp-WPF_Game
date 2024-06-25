using System.Windows;
using Unemployed.CommonLibrary;

namespace Unemployed.WPFProject
{
    /// <summary>
    /// Interaction logic for Restaurant.xaml
    /// </summary>
    public partial class Restaurant : Window
    {
        public Player Player { get; set; }
        public Game Game { get; set; }
        public Restaurant(Game game)
        {
            Game = game;
            Player = Game.Player;
            InitializeComponent();
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (Player.Money >= Game.Restaurant.Price)
            {
                Game.Restaurant.Eat(Game);
                Close();
            }
            else
            {
                MessageBox.Show("You don't have enough money!");
            }
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
