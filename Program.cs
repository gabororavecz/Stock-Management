using System;
using System.Collections.Generic;



namespace StockManagement
{
    public class Program
    {
        private static AdminUI adminUI;
        public static void Main(string[] args)
        {
            StockManager stock_Manager = new StockManager();
            TransactionManager transaction_Manager = new TransactionManager();
            adminUI = new AdminUI(stock_Manager, transaction_Manager);
            // This is the main programma that executes the main menu with its options
            ProgramCODE();
        }
        private static void ProgramCODE()
        {
            DisplayMenu();
            int data_input = ReadInteger("Please select the option you would like: ");
            while (data_input != 7)
            {
                switch (data_input)
                {
                    case 1:
                        ViewStockLevels();
                        break;
                    case 2:
                        ViewTransactionLog();
                        break;
                    case 3:
                        AddANewItemOfStock();
                        break;
                    case 4:
                        AddQuantityToAStockItem();
                        break;
                    case 5:
                        DeleteAStockItem();
                        break;
                    case 6:
                        RemoveQuantityFromAStockItem();
                        break;
                    default:
                        Console.WriteLine("\nOpps this did not work, please try again.");
                        break;
                }
                DisplayMenu();
                data_input = ReadInteger("Chose from these options");
            }
        }
        // These methods below are part of the AdminUi class to execute
        private static void DisplayMenu()
        {
            Console.WriteLine("\n");
            Console.WriteLine("1 - View Stock Levels");
            Console.WriteLine("2 - View Transaction Log");
            Console.WriteLine("3 - Add a new product to the stock");
            Console.WriteLine("4 - Add quantity to the stock item");
            Console.WriteLine("5 - Remove stock item");
            Console.WriteLine("6 - Remove quantity from stock item");
            Console.WriteLine("7 - Exit the program");
            Console.WriteLine("\n");
        }
        public static void ViewTransactionLog()
        {
            DisplayResults(adminUI.ViewTransactionLog());
        }
        public static void ViewStockLevels()
        {
            DisplayResults(adminUI.ViewStockLevels());
        }
        // The data has to be converted in the command prompt because it is a list string from adminUI 
        private static int ReadInteger(string input)
        {
            try
            {
                Console.Write(input + ": ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }
        private static string ReadString(string input)
        {
            Console.Write(input + ": ");
            return Convert.ToString(Console.ReadLine());
        }

        public static void AddANewItemOfStock()
        {
            int item_stock_code = ReadInteger("\nItem Code");
            string item_stock_name = ReadString("Item Name");
            int item_stock_quantityStock = ReadInteger("Quantity in Stock");
            try
            {
                DisplayResults(adminUI.AddANewItemOfStock(item_stock_code, item_stock_name, item_stock_quantityStock));
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
        public static void AddQuantityToAStockItem()
        {
            int item_stock_code = ReadInteger("\nProduct Code");
            int item_stock_quantityToAdd = ReadInteger("Quantity To Add");
            try
            {
                DisplayResults(adminUI.AddQuantityToAStockItem(item_stock_code, item_stock_quantityToAdd));
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
        public static void DeleteAStockItem()
        {
            int item_stock_code = ReadInteger("\nProduct Code");
            try
            {
                DisplayResults(adminUI.DeleteAStockItem(item_stock_code));
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
        public static void RemoveQuantityFromAStockItem()
        {
            int item_stock_code = ReadInteger("\nProduct Code");
            int item_stock_quantityToRemove = ReadInteger("Quantity To Remove");
         
            try
            {
                DisplayResults(adminUI.RemoveQuantityFromAStockItem(item_stock_code, item_stock_quantityToRemove));
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
        public static void DisplayResults(List<string> item_data)
        {
            string item_result = String.Join("\n", item_data);
            Console.WriteLine($"{item_result}");
        }



    }
}
