using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class TransactionManager
    {
        public List<Transaction> Transactions { get; set; }
        public List<ItemAddedTransaction> ItemAdded { get; set; }
        public TransactionManager()
        {
            Transactions = new List<Transaction>();
        }
        public List<Transaction> GetAllTransactions()
        {
            return Transactions;
        }
        public void RecordItemAdded(StockItem item_stock)
        {
            Transactions.Add(new ItemAddedTransaction(DateTime.Now, item_stock.Code, item_stock.Name, item_stock.QuantityInStock));
        }
        public void RecordItemDeleted(StockItem item_stock)
        {
            Transactions.Add(new ItemDeletedTransaction(DateTime.Now, item_stock.Code, item_stock.Name));
        }
        public void RecordQuantityAdded(StockItem item_stock, int quantityAdded)
        {
            Transactions.Add(new QuantityAddedTransaction(DateTime.Now, item_stock.Code, item_stock.Name, quantityAdded, item_stock.QuantityInStock));
        }
        public void RecordQuantityRemoved(StockItem item_stock, int quantityRemoved)
        {
            Transactions.Add(new QuantityRemovedTransaction(DateTime.Now, item_stock.Code, item_stock.Name, quantityRemoved, item_stock.QuantityInStock));
        }
    }


}
