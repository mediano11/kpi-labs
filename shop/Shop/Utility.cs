using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Utility
    {
        public static int GetValidInput(string text, int minLimit, int maxLimit)
        {
            bool valid = false;
            string input;
            int choice = 0;

            while (!valid )
            {
                Console.Write($"Enter {text}: ");
                input =  Console.ReadLine();
                valid = GetInput(input, out choice, minLimit, maxLimit);
                if (!valid)
                    Console.WriteLine("Invalid input. Try again.");
            }

            return choice;
        }
        public static bool GetInput(string stringToConvert, out int intOutValue, int minLimit, int maxLimit)
        {
            bool parsed = int.TryParse(stringToConvert, out intOutValue);
            return parsed && intOutValue >= minLimit && intOutValue <= maxLimit;
        }
        public static string CheckPassword()
        {
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.Enter:
                        return password;
                    case ConsoleKey.Backspace:
                        if (password.Length > 0)
                        {
                            password = password.Substring(0, (password.Length - 1));
                            Console.Write("\b \b");
                        }
                        break;
                    default:
                        password += key.KeyChar;
                        Console.Write("*");
                        break;
                }
            }
        }
        public static void PrintProductTable(List<Product> productList)
        {
            var output = new StringBuilder();
            output.AppendLine("-----------------------------------------------------");
            output.AppendLine(String.Format("| {0,-12}| {1,-20}| {2,-14}|", "Product ID", "Product name", "Product price"));
            output.AppendLine("-----------------------------------------------------");
            foreach (var item in productList)
                output.AppendLine(item.toRow());
            output.AppendLine("-----------------------------------------------------");
            Console.Write(output);
        }

        public static void PrintBasketTable(List<BasketItem> basketList)
        {
            var output = new StringBuilder();
            output.AppendLine("---------------------------------------------------------------------------------------------");
            output.AppendLine(String.Format("| {0,-12}| {1,-12}| {2,-20}| {3,-14:C2}| {4,-24}|", "Customer ID", "Product ID", "Product name", "Product price", "Date"));
            output.AppendLine("---------------------------------------------------------------------------------------------");
            foreach (var item in basketList)
                output.AppendLine(item.toRow());
            output.AppendLine("---------------------------------------------------------------------------------------------");
            Console.Write(output);
        }
        
        public static void PrintHistoryTable(List<HistoryItem> historyList)
        {
            var output = new StringBuilder();
            output.AppendLine("-----------------------------------------------");
            output.AppendLine(String.Format("| {0,-8}| {1,-20}| {2,-12:C2}|", "Item ID", "Item Name", "Item Price"));
            output.AppendLine("-----------------------------------------------");
            foreach (var item in historyList)
            {
                output.AppendLine(item.toRow());
            }
            output.AppendLine("-----------------------------------------------");
            Console.Write(output);
        }
    }
}
