using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Terminal
{
    public class Cart
    {
        //public static Dictionary<Product, int> shoppingCart = new Dictionary<Product, int>();
        public static List<Product> shoppingCart = new List<Product>();

        /*public static void AddToCart(Product item, int itemCount)
        {
            if (shoppingCart.ContainsKey(item))
            {
                shoppingCart[item] += itemCount;
            }
            shoppingCart[item] = itemCount;
        }
        */

        public static List<Product> AddToCart(Product item, int itemCount)
        {
            for (int i = 1; i <= itemCount; i++)
            {
                shoppingCart.Add(item);
            }
            return shoppingCart;
        }
        

        public static double GetQuantityCost(double itemPrice, int itemCount)
        {
            double quantityCost = itemPrice * itemCount;
            return quantityCost;
        }

        public static double GetCartSubTotal(List<Product> shoppingCart)
        {
            double subTotal = 0;
            for (int i = 0; i < shoppingCart.Count; i++)
            {
                subTotal = subTotal + shoppingCart[i].Price;
            }
            return subTotal;
        }
        public static double GetSalesTax(double subTotal)
        {
            double salesTax = subTotal * .06;
            return salesTax;
        }
        public static double GrandTotal(double subTotal, double salesTax)
        {
            double grandTotal = subTotal + salesTax;
            return grandTotal;
        }
        public static double ReturnChange(double moneyIn, double grandTotal)
        {
            double changeToReturn = moneyIn - grandTotal;
            return changeToReturn;
        }
        /*public static string TotalItemCount(List<Product> foodMenu, Dictionary<Product, int> cart)
        {
            f



            return 0;
        }
        */



    }
}
