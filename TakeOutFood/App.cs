namespace TakeOutFood
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;

    public class App
    {
        private IItemRepository itemRepository;
        private ISalesPromotionRepository salesPromotionRepository;

        public App(IItemRepository itemRepository, ISalesPromotionRepository salesPromotionRepository)
        {
            this.itemRepository = itemRepository;
            this.salesPromotionRepository = salesPromotionRepository;
        }

        public string BestCharge(List<string> inputs)
        {
            //TODO: write code here

            List<string> foodCodes = new List<string>();
            List<double> foodCounts = new List<double>();

            foreach (var input in inputs)
            {
                var result = input.Split(" x ");
                foodCodes.Add(result[0]);
                foodCounts.Add(double.Parse(result[1]));
            }

            Food food = new Food();
            List<string> inputFoodName = food.GetFoodNames(foodCodes);
            List<double> foodPrice = food.GetFoodPrices(foodCodes);

            string text = "============= Order details =============\n";
            double totalOriginPrice = 0;
            for (int i = 0; i < inputFoodName.Count; i++)
            {
                double totalPricePerFood = foodPrice[i] * foodCounts[i];
                totalOriginPrice += totalPricePerFood;
                text += inputFoodName[i] + " x " + foodCounts[i].ToString() + " = " + totalPricePerFood.ToString() + " yuan\n";               
            }


            double totalhalfPrice = 0;

            List<string> promotionFoodList = new List<string>();
            for (int i = 0; i < inputFoodName.Count; i++)
            {
                Promotion promotionFood = new Promotion();
                if (promotionFood.IsPromotionFood(inputFoodName[i]))
                {
                    totalhalfPrice += foodPrice[i] / 2;
                    promotionFoodList.Add(inputFoodName[i]);
                }
            }

            if (promotionFoodList.Count == 2)
            {
                text += "-----------------------------------\n";
                text += "Promotion used:\n";
                text += "Half price for certain dishes "
                    + "(" + promotionFoodList[0] + ", " + promotionFoodList[1] + "), saving " + totalhalfPrice + " yuan\n";        
               
            }

            text += "-----------------------------------\n";
            double totalPrice = totalOriginPrice - totalhalfPrice;
            text += "Total：" + totalPrice + " yuan\n";
            text += "===================================";

            return text;
        }
    }
}
