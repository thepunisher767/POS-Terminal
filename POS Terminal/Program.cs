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
            foodMenu.Add(new Product("Water", CategoryList.Drink, "Healthy drink", .99));

            Console.WriteLine("Welcome to Paddy's Pub!\n\n");

            bool newOrder = true;
            while(newOrder)
            {
                Cart.shoppingCart.Clear();
                ListMenu(foodMenu);
                int userChoice = CheckMenu(foodMenu);
                if (userChoice == 13)
                {
                    break;
                }
                string userContinue = TakeQuantity(foodMenu, userChoice);
                while (userContinue == "y")
                {
                    Console.Clear();
                    Console.WriteLine("Would you like to see the menu again? (y/n): ");
                    string userMenuChoice = YesOrNo(Console.ReadLine());
                    if (userMenuChoice == "y")
                    {
                        Console.Clear();
                        ListMenu(foodMenu);
                    }
                    userChoice = CheckMenu(foodMenu);
                    if (userChoice == 13)
                    {
                        break;
                    }
                    userContinue = TakeQuantity(foodMenu, userChoice);
                }
                double subTotal = Cart.GetCartSubTotal(Cart.shoppingCart);
                double salesTax = Cart.GetSalesTax(subTotal);
                double grandTotal = Cart.GrandTotal(subTotal, salesTax);
                Console.WriteLine();
                Console.WriteLine("{0,-6} {1,-6} {2, -6}", $"Cart Subtotal: {subTotal:C2}", $"Sales Tax: {salesTax:C2}", $"Total owed: {grandTotal:C2}");
                Console.Write($"\nWhat is the amount tendered?: ");
                double userPayment = CashValidation(Console.ReadLine(), grandTotal);
                double change = Cart.ReturnChange(userPayment, grandTotal);
                Console.Write($"\nHere is your change: ${change}");
                Console.Write($"\n\nWould you like a receipt? (y/n): ");
                string receipt = YesOrNo(Console.ReadLine());
                if (receipt == "y")
                {
                    Console.Clear();
                    Receipt(Cart.shoppingCart, subTotal, salesTax, grandTotal, userPayment, change);
                }
                Console.Write($"\n\nWould you like to make another order? (y/n): ");
                string orderAnother = YesOrNo(Console.ReadLine());
                if (orderAnother == "y")
                {
                    Console.Clear();
                }
                else
                {
                    newOrder = false;
                }
            }
            Console.WriteLine("\n\nThank you!!!!");
        }

        public static int CheckMenu(List<Product> foodMenu)
        {
            Console.Write("\n\nWhat would you like to order? (menu number): ");
            int userChoice = MenuValidation(Console.ReadLine());
            return userChoice;
        }

        public static string TakeQuantity(List<Product> foodMenu, int userChoice)
        {
            Console.Write("\nHow many would you like?: ");
            int userQuantity = QuantityValidation(Console.ReadLine());
            Cart.AddToCart(foodMenu[userChoice - 1], userQuantity);
            Console.WriteLine($"Added x{userQuantity} {foodMenu[userChoice - 1].Name}(s) for a total of ${Math.Round(Cart.GetQuantityCost(foodMenu[userChoice - 1].Price, userQuantity), 2)}.");
            Console.Write("\nWould you like to order more?: ");
            string userContinue = YesOrNo(Console.ReadLine());
            return userContinue;
        }

        public static void ListMenu(List<Product> foodMenu)
        {
            for (int i = 0; i < foodMenu.Count; i++)
            {
                string menuOutput = String.Format("{0,-4} {1, -1}", $"{i + 1}.", $"{foodMenu[i]}");
                Console.WriteLine(menuOutput);
            }
            Console.WriteLine("{0,-4} {1,-1}", $"{foodMenu.Count + 1}.", "Exit");
        }

        public static double CashValidation(string userInput, double grandTotal)
        {
            double validDbl;
            while (!double.TryParse(userInput, out validDbl) || validDbl < grandTotal)
            {
                if (!double.TryParse(userInput, out validDbl))
                {
                    Console.Write("Please enter a valid quantity: ");
                    userInput = Console.ReadLine();
                }
                else
                {
                    Console.Write("Please enter an amount that will satisfy the bill: ");
                    userInput = Console.ReadLine();
                }
            }
            return Math.Round(validDbl, 2);
        }

        public static int QuantityValidation(string userInput)
        {
            int validInt;
            while(!int.TryParse(userInput, out validInt))
            {
                Console.Write("Please enter a valid quantity: ");
                userInput = Console.ReadLine();
            }
            return validInt;
        }

        public static int MenuValidation(string userInput)
        {
            int validInt;
            while (!int.TryParse(userInput, out validInt) || validInt > 14 || validInt < 1)
            {
                Console.Write("Please enter a valid selection from the menu: ");
                userInput = Console.ReadLine();
            }
            return validInt;
        }

        public static string YesOrNo(string userInput)
        {
            while(userInput.ToLower() != "y" && userInput.ToLower() != "n")
            {
                Console.Write("Please enter a valid choice (y/n): ");
                userInput = Console.ReadLine();
            }
            return userInput;
        }

        public static void Receipt(Dictionary<Product,int> shoppingCart, double subTotal, double salesTax, double grandTotal, double userPayment, double change)
        {
            Console.WriteLine("##################################################");
            Console.WriteLine("{0,-48} {1, 1}", "#", "#");
            foreach (KeyValuePair<Product, int> item in shoppingCart)
            {
                //Console.WriteLine($"{item.Value}x {item.Key.Name}");
                Console.WriteLine("{0,-30} {1, 6} {2,12}", $"# {item.Key.Name}", $"x{item.Value}", $"{item.Value*item.Key.Price:C2} #");
            }
            Console.WriteLine("{0,-48} {1, 1}", "#", "#");
            Console.WriteLine("{0,-23} {1, 24} {2, 1}", "#", $"Subtotal: {subTotal:C2}", "#");
            Console.WriteLine("{0,-23} {1, 24} {2, 1}", "#", $"Tax: {salesTax:C2}", "#");
            Console.WriteLine("{0,-23} {1, 24} {2, 1}", "#", $"Total: {grandTotal:C2}", "#");
            Console.WriteLine("{0,-23} {1, 24} {2, 1}", "#", $"=================", "#");
            Console.WriteLine("{0,-23} {1, 24} {2, 1}", "#", $"Paid: {userPayment:C2}", "#");
            Console.WriteLine("{0,-48} {1, 1}", "#", "#");
            Console.WriteLine("{0,-23} {1, 24} {2, 1}", "#", $"Change: {change:C2}", "#");
            Console.WriteLine("##################################################");
        }
    }
}
