using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class StockManager
    {
        //Working with sorted dictionary
        public SortedDictionary<int, StockItem> StockItems { get; set; }
        public StockManager()
        {
            StockItems = new SortedDictionary<int, StockItem>();
        }
        //Functions
        public SortedDictionary<int, StockItem> GetAllStockItems()
        {
            return StockItems;
        }
        public StockItem CreateStockItem(int code, string name, int quantyInStock)
        {
            StockItem item = FindStockItem(code);
            if (item == null)
            {
                item = new StockItem(code, name, quantyInStock);
                StockItems.Add(item.Code, item);
                return item;
            }
            throw new Exception("Item code "+code+" already exists. Item not added.");
        }

        public StockItem FindStockItem(int code)
        {
            StockItem product;
            if (StockItems.ContainsKey(code))
            {
                return StockItems[code];
            }
            else
            {
                product = null;
            }
            return product;
        }

        public StockItem AddQuantityToStockItem(int code, int quantityToAdd)
        {
            StockItem product = FindStockItem(code);

            if (product == null)
            {
                throw new Exception("Stock item " + code + " not found. Quantity not added.");
            }
            else
            {
                product.QuantityInStock += quantityToAdd;
            }

            return product;
        }
        public StockItem RemoveQuantityFromStockItem(int code, int quantityToRemove)
        {
            StockItem product = FindStockItem(code);
            if (product == null)
            {
                throw new Exception("Stock item " + code + " not found. Quantity not removed.");
            }
            else
            {
                product.QuantityInStock -= quantityToRemove;
            }
            return product;
        }
        public StockItem DeleteStockItem(int code)
        {
            StockItem product = FindStockItem(code);
            if (product == null)
            {
                throw new Exception("Item has not been deleted because it cannot be found");
            }
            else if (product.QuantityInStock > 0)
            {
                throw new Exception("Item cannot be deleted because quantity in stock is not zero");
            }
            else
            {
                StockItems.Remove(code);
            }
            return product;
        }
    }
}
