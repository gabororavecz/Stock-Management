using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class AdminUI
    {

        public StockManager stockMgr { get; private set; }

        public TransactionManager transactionMgr { get; private set; }
        public AdminUI(StockManager stockMgr, TransactionManager transactionMgr)
        {
            this.stockMgr = stockMgr;
            this.transactionMgr = transactionMgr;
        }

        public List<string> AddANewItemOfStock(int item_code, string item_name, int item_quantityInStock)
        {
            List<string> results = new List<string>();
            StockItem stock_item = stockMgr.FindStockItem(item_code);
            if (stock_item == null)
            {
                results.Add("Item added. Item code: " + item_code);
                stockMgr.CreateStockItem(item_code, item_name, item_quantityInStock);
                transactionMgr.RecordItemAdded(new StockItem(item_code, item_name, item_quantityInStock));
            }
            else
            {
                results.Add("Item code " + item_code + " already exists. Item not added.");
            }



            return results;
        }
        public List<string> DeleteAStockItem(int item_code)
        {
            List<string> results = new List<string>();
            StockItem stock_item = stockMgr.FindStockItem(item_code);
            if (stock_item == null)
            {
                results.Add("Item has not been deleted because it cannot be found");
            }
            else
            {
                stockMgr.DeleteStockItem(item_code);
                transactionMgr.RecordItemDeleted(new StockItem(stock_item.Code, stock_item.Name, stock_item.QuantityInStock));
                results.Add("Item " + item_code + " deleted.");
            }
            return results;
        }
        public List<string> ViewStockLevels()
        {
            List<string> results = new List<string>();
            if (stockMgr.GetAllStockItems().Count > 0)
            {
                results.Add("\nStock Levels");
                results.Add("============");
                results.Add("\tItem code\tItem name           \tQuantity in stock");
                foreach (StockItem item in stockMgr.StockItems.Values)
                {
                    results.Add(item.Code + "\t\t" + item.Name + "\t\t" + item.QuantityInStock);
                }
            }
            else
            {
                results.Add("\nStock Levels");
                results.Add("============");
                results.Add("No stock items");
            }
            return results;
        }
        public List<string> AddQuantityToAStockItem(int item_code, int item_quantityToAdd)
        {
            List<string> results = new List<string>();
            StockItem stock_item = stockMgr.FindStockItem(item_code);
            if (stock_item == null)
            {
                results.Add("Stock item " + item_code + " not found. Quantity not added.");
            }
            else
            {
                stockMgr.AddQuantityToStockItem(item_code, item_quantityToAdd);
                transactionMgr.RecordQuantityAdded(new StockItem(stock_item.Code, stock_item.Name, stock_item.QuantityInStock), item_quantityToAdd);
                results.Add("Quantity added to item: " + item_code + ". New quantity in stock: " + stock_item.QuantityInStock);
            }
            return results;
        }
        public List<string> RemoveQuantityFromAStockItem(int item_code, int item_quantityToRemove)
        {
            List<string> results = new List<string>();
            StockItem stock_item = stockMgr.FindStockItem(item_code);
            if (stock_item == null)
            {
                results.Add("Stock item " + item_code + " not found. Quantity not removed.");
            }
            else
            {
                stockMgr.RemoveQuantityFromStockItem(stock_item.Code, item_quantityToRemove);
                transactionMgr.RecordQuantityRemoved(new StockItem(stock_item.Code, stock_item.Name, stock_item.QuantityInStock), item_quantityToRemove);
                results.Add("Quantity removed from item: " + item_code + ". New quantity in stock: " + stock_item.QuantityInStock);
            }
            return results;
        }

        public List<string> ViewTransactionLog()
        {
            List<string> results = new List<string>();
            if (transactionMgr.GetAllTransactions().Count > 0)
            {
                results.Add("\nTransaction log");
                results.Add("===============");
                foreach (Transaction stock_item in transactionMgr.Transactions)
                {
                    results.Add(Convert.ToString(stock_item));
                }
            }
            else
            {
                results.Add("\nTransaction log");
                results.Add("===============");
                results.Add("No transactions");
            }
            return results;
        }
    }
}
