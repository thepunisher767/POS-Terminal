using System;
using System.Collections.Generic;
using System.Text;

namespace POS_Terminal
{
    public class Cart
    {
        public static Dictionary<Product, int> shoppingCart = new Dictionary<Product, int>();
        //public static List<Product> shoppingCart = new List<Product>();

        /*public static void AddToCart(Product item, int itemCount)
        {
            if (shoppingCart.ContainsKey(item))
            {
                shoppingCart[item] += itemCount;
            }
            shoppingCart[item] = itemCount;
        }
        */

        public static Dictionary<Product, int> AddToCart(Product item, int quantity)
        {
            if (shoppingCart.ContainsKey(item))
            {
                shoppingCart[item] += quantity;
            }
            shoppingCart[item] = quantity;
            return shoppingCart;
        }
        

        public static double GetQuantityCost(double itemPrice, int itemCount)
        {
            double quantityCost = itemPrice * itemCount;
            return quantityCost;
        }

        public static double GetCartSubTotal(Dictionary<Product, int> shoppingCart)
        {
            double subTotal = 0;
            foreach (KeyValuePair<Product, int> item in shoppingCart)
            {
                subTotal = +item.Key.Price * item.Value;
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
        public static string TotalItemCount(Dictionary<Product, int> cart)
        {
            return "";
        }
        



    }
}
