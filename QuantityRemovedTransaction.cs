using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class QuantityRemovedTransaction : Transaction
    {

        public int StockItemCode { get; set; }
        public int NewQuantityInStock { get; set; }

        public int QuantityRemoved { get; set; }

        public string StockItemName { get; set; }

        public QuantityRemovedTransaction(DateTime item_transaction_date_time, int item_stock_code, string item_stock_name, int item_quantity_removed, int item_new_quantity_in_stock) : base(null, item_transaction_date_time)
        {
            TransactionDatetime = item_transaction_date_time;
            StockItemCode = item_stock_code;
            StockItemName = item_stock_name;
            QuantityRemoved = item_quantity_removed;
            NewQuantityInStock = item_new_quantity_in_stock;
            TransactionName = "Quantity removed";

        }



        public override string ToString()
        {
            return string.Format(
            TransactionDatetime.ToString("dd/MM/yyyy HH:mm") +
            " " + TransactionName + " - Item " + StockItemCode + ": " + StockItemName + ". Quantity removed: " + QuantityRemoved + ". New quantity in stock: " + NewQuantityInStock);
        }
    }
}
