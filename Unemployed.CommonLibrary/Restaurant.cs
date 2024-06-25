namespace Unemployed.CommonLibrary
{
    public class Restaurant(int price)
    {
        public int Price { get; set; } = price;

        public void Eat(Game game)
        {
            game.Money -= Price;
            game.DaysWithoutFood = 0;
            Price += 5;
        }
    }
}
