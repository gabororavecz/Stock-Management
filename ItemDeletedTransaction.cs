using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class ItemDeletedTransaction : Transaction
    {
        //Variables
        public int StockItemCode { get; set; }
        public string StockItemName { get; set; }

        //Constructor
        public ItemDeletedTransaction(DateTime item_transaction_date_time, int item_stock_code, string item_stock_name) : base(null, item_transaction_date_time)
        {
            StockItemCode = item_stock_code;
            StockItemName = item_stock_name;
            TransactionDatetime = item_transaction_date_time;
            TransactionName = "Item deleted";

        }
            public override string ToString()
        {
            return string.Format(
            TransactionDatetime.ToString("dd/MM/yyyy HH:mm") +
            " " + TransactionName + "     - Item " + StockItemCode + ": " + StockItemName + " deleted.");
        }
    }
        

}



