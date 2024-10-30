using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class QuantityAddedTransaction : Transaction
    {
        public int NewQuantityInStock { get; set; }
        public int QuantityAdded { get; set; }

        public string StockItemName { get; set; }

        public int StockItemCode { get; set; }

        public QuantityAddedTransaction(DateTime item_transaction_date_time, int item_stock_code, string item_stock_name, int item_quantity_added, int item_new_quantity_in_stock) : base(null, item_transaction_date_time)
        {
            TransactionDatetime = item_transaction_date_time;
            StockItemCode = item_stock_code;
            StockItemName = item_stock_name;
            QuantityAdded = item_quantity_added;
            NewQuantityInStock = item_new_quantity_in_stock;
            TransactionName = "Quantity added";
        }



        public override string ToString()
        {
            return string.Format(
            TransactionDatetime.ToString("dd/MM/yyyy HH:mm") +
            " " + TransactionName + " - Item " + StockItemCode + ": " + StockItemName + ". Quantity added: " + QuantityAdded + ". New quantity in stock: " + NewQuantityInStock);
        }

    }
}

