namespace Unemployed.CommonLibrary
{
    public abstract class CasinoGame(int bet)
    {
        protected int Bet { get; set; } = bet;

        public abstract int Earn();
        public abstract bool Won();
    }

    public class DiceGame : CasinoGame
    {
        public int UpperLimit { get; set; }
        public int FirstDice { get; init; }
        public int SecondDice { get; init; }
        public DiceGame(int bet, int upperLimit) : base(bet)
        {
            UpperLimit = upperLimit;
            Random random = new();
            FirstDice = random.Next(1, 7);
            SecondDice = random.Next(1, 7);
        }

        public override int Earn()
        {
            switch (UpperLimit)
            {
                case 2:
                    {
                        return (int)(Bet * 10);
                    }
                case 3:
                    {
                        return (int)(Bet * 7);
                    }
                case 4:
                    {
                        return (int)(Bet * 4);
                    }
                case 5:
                    {
                        return (int)(Bet * 3);
                    }
                case 6:
                    {
                        return (int)(Bet * 2);
                    }
                case 7:
                    {
                        return (int)(Bet * 1.8f);
                    }
                case 8:
                    {
                        return (int)(Bet * 1.5);
                    }
                case 9:
                    {
                        return (int)(Bet * 1.2);
                    }
                case 10:
                    {
                        return (int)(Bet * 1.1);
                    }
                case 11:
                    {
                        return (int)(Bet * 1.05);
                    }
                case 12:
                    {
                        return Bet;
                    }
                default:
                    return Bet;
            }
        }

        public override bool Won()
        {
            return UpperLimit >= FirstDice + SecondDice;
        }
    }

    public class CoinFlip : CasinoGame
    {
        public bool Result { get; set; }
        private readonly bool _pick;
        public CoinFlip(int bet, bool isHeads) : base(bet)
        {
            _pick = isHeads;
            Random random = new();
            Result = random.Next(0, 2) == 1;
        }

        public string GetResultSring()
        {
            return Result ? "Heads" : "Tails";
        }

        public override int Earn()
        {
            return 2*Bet;
        }

        public override bool Won()
        {
            return Result == _pick;
        }
    }

    public class WheelOfFortune : CasinoGame
    {
        // PÁRNE ČÍSLA ČERVENÉ, NEPÁRNE ČIERNE
        public int Result { get; set; }
        private int? GuessedNumber { get; set; }
        private bool? GuessedRed { get; set; }
        public WheelOfFortune(int bet, int? number, bool? red) : base(bet)
        {
            Random random = new();
            Result = random.Next(1, 11);
            GuessedNumber = number;
            GuessedRed = red;
        }

        public override int Earn()
        {
            if (GuessedNumber.HasValue) 
            {
                return 10 * Bet;
            }
            return 2 * Bet;
        }

        public override bool Won()
        {
            if (GuessedNumber.HasValue)
            {
                return Result == GuessedNumber;
            }
            else
            {
                if (GuessedRed!.Value)
                {
                    return Result % 2 == 0;
                }
                else
                {
                    return Result % 2 == 1;
                }
            }
        }
    }
}
