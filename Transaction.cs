using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public abstract class Transaction //abstract means you can not create objects from the class 
    {
        public DateTime TransactionDatetime { get; set; }

        public string TransactionName { get; set; }

        //Abstract class from Constructor

        public Transaction(string item_name, DateTime item_date_Time)
        {
            TransactionName = item_name;
            TransactionDatetime = item_date_Time;
        }

        public abstract override string ToString(); //outputs value from Constructor
    }
}
