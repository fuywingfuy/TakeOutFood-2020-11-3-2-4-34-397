using System;
using System.Collections.Generic;
using System.Text;

namespace TakeOutFood
{
    public class Food
    {
        public List<string> GetFoodNames(List<string> foodCodes)
        {
            List<string> foodNames = new List<string>();
            foreach (var foodCode in foodCodes)
            {
                if (foodCode == "ITEM0001")
                {
                    foodNames.Add("Braised chicken");
                }
                if (foodCode == "ITEM0013")
                {
                    foodNames.Add("Chinese hamburger");
                }
                if (foodCode == "ITEM0022")
                {
                    foodNames.Add("Cold noodles");
                }
            }
            return foodNames;
        }


        public List<double> GetFoodPrices(List<string> foodCodes)
        {
            List<double> foodPrice = new List<double>();
            foreach (var foodCode in foodCodes)
            {
                if (foodCode == "ITEM0001")
                {
                    foodPrice.Add(18);
                }
                if (foodCode == "ITEM0013")
                {
                    foodPrice.Add(6);
                }
                if (foodCode == "ITEM0022")
                {
                    foodPrice.Add(8);
                }
            }
            return foodPrice;
        }
    }
}
