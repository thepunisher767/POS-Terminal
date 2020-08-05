using System;
using System.Collections.Generic;

namespace POS_Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> foodMenu = new List<Product>();
            foodMenu.Add(new Product("MacDouble", CategoryList.Food, "Double patty with cheese", 1.99));
            foodMenu.Add(new Product("Big Mac", CategoryList.Food, "Double patty with cheese and special sauce", 3.99));
            foodMenu.Add(new Product("Quarter Pounder w/ cheese", CategoryList.Food, "1/4 lb patty with cheese", 3.99));
            foodMenu.Add(new Product("The Implication", CategoryList.Food, "2x 1/4 lb patties with cheese and special sauce", 7.99));
            foodMenu.Add(new Product("Fries", CategoryList.Food, "Salty french fries", 1.99));
            foodMenu.Add(new Product("MacChicken", CategoryList.Food, "Chicken sandwich", 1.99));
            foodMenu.Add(new Product("MacFlurry", CategoryList.Dessert, "Ice cream", 1.99));
            foodMenu.Add(new Product("Cookie", CategoryList.Dessert, "Chocolate Chip cookie", 0.99));
            foodMenu.Add(new Product("Pepsi", CategoryList.Drink, "Soda", 1.99));
            foodMenu.Add(new Product("Root Beer", CategoryList.Drink, "Soda", 1.99));
            foodMenu.Add(new Product("Mountain Dew", CategoryList.Drink, "Soda", 1.99));
            foodMenu.Add(new Product("Water", CategoryList.Drink, "Healthy drink", 1.99));

            Console.WriteLine("Welcome to Paddy's Pub!");

            ListMenu(foodMenu);
            bool continueFlag = true;
            while(continueFlag)
            {
                Console.Write("What would you like to order?: ");
                Console.Write("How many would you like?: ");
                Console.Write("Would you like to order more?: ");
                Console.Write($"Here is the total (TOTAL). What is the amount tendered?: ");
                Console.Write($"Here is your change: ");
                Console.Write($"Here is your receipt: ");
            }

        }
        public static void ListMenu(List<Product> foodMenu)
        {
            for (int i = 0; i < foodMenu.Count; i++)
            {
                string menuOutput = String.Format("{0,-4} {1, -1}", $"{i + 1}.", $"{foodMenu[i]}");
                Console.WriteLine(menuOutput);
            }
        }
    }
}
