using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unemployed.CommonLibrary
{
    public class Player
    {
        public string Name { get; init; }
        public int Money { get; set; }
        public int DaysWithoutFood { get; set; }

        public Player(string name, int money) =>
            (Name, Money, DaysWithoutFood) = (name, money, 0);
    }
}
