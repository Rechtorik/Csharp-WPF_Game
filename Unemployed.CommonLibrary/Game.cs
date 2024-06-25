using System.ComponentModel;

namespace Unemployed.CommonLibrary
{
    public class Game : INotifyPropertyChanged
    {
        public const int _gamesLimit = 5;
        private int _daysSurvived;
        private int _gamesPlayed;

        public Player Player { get; init; }
        public Apartment Apartment { get; init; }
        public Restaurant Restaurant { get; init; }
        public int DaysSurvived
        {
            get => _daysSurvived; set
            {
                _daysSurvived = value;
                OnPropertyChanged(nameof(DaysSurvived));
            }
        }
        public int Money
        {
            get { return Player.Money; } set 
            { 
                Player.Money = value;
                OnPropertyChanged(nameof(Money));
            }
        }
        public int DaysWithoutFood
        {
            get { return Player.DaysWithoutFood; }
            set
            {
                Player.DaysWithoutFood = value;
                OnPropertyChanged(nameof(DaysWithoutFood));
            }
        }
        public int GamesPlayed
        {
            get => _gamesPlayed;
            set
            {
                _gamesPlayed = value;
                OnPropertyChanged(nameof(GamesPlayed));
            }
        }
        public string NameOfPlayer
        {
            get { return Player.Name; }
        }
        public static int GamesLimit
        {
            get { return _gamesLimit; }
        }
        public int Rent
        {
            get { return Apartment.Rent; }
            set
            {
                Apartment.Rent = value;
                OnPropertyChanged(nameof(Rent));
            }
        }


        public Game(string nameOfPlayer) =>
            (Player, Apartment, Restaurant, DaysSurvived) = (new Player(nameOfPlayer, 100), new Apartment(), new Restaurant(10), 1);

        public event PropertyChangedEventHandler? PropertyChanged;

        public void EndDay()
        {
            Money -= Rent;
            DaysSurvived++;
            DaysWithoutFood++;
            Rent += 5;
            Restaurant.Price += 5;
            GamesPlayed = 0;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
