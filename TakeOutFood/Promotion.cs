using System;
using System.Collections.Generic;
using System.Text;

namespace TakeOutFood
{
    public class Promotion
    {
        public bool IsPromotionFood(string foodName)
        {

            return (foodName == "Braised chicken" || foodName == "Cold noodles");
        }
    }
}
