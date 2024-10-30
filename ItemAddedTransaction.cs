using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class ItemAddedTransaction : Transaction //subclass 
    {
        public string StockItemName { get; set; }

        public int QuantityAdded { get; set; }

        public int StockItemCode { get; set; }

        public ItemAddedTransaction(DateTime item_transaction_date_time, int item_stock_code, string item_stock_name, int item_quantity_added) : base(null, item_transaction_date_time)
        {
            StockItemCode = item_stock_code;
            StockItemName = item_stock_name;
            QuantityAdded = item_quantity_added;
            TransactionDatetime = item_transaction_date_time;
            TransactionName = "Item added";
        }

        public override string ToString()
        {
            return string.Format(TransactionDatetime.ToString("dd/MM/yyyy HH:mm") + " "
            + TransactionName + "       - Item " + StockItemCode + ": "
            + StockItemName + " added. Quantity in stock: " + QuantityAdded);

        }
    }
}
