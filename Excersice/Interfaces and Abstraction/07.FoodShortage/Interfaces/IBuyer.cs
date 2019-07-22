using System;
using System.Collections.Generic;
using System.Text;

namespace _07.FoodShortage.Interfaces
{
    public interface IBuyer
    {
        int Food { get; }

        void BuyFood();
    }
}
