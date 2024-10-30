using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    public class StockItem //created public class
    {
        //Creating Fields for the class
        private int code_item;
        private string name_item;
        private int quantity_in_item;
        
        public int Code
        {
            get
            {
                return code_item;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Item code must be a positive integer. ");
                }
                else
                {
                    code_item = value;
                }
            }
        }

        public string Name
        {
            get
            {
                return name_item;
            }
            set
            {
                if (value == "")
                {
                    throw new ArgumentException("Item name cannot be blank. ");
                }
                else if (value.Trim().Length == 0)
                {
                    throw new ArgumentException("Item name cannot be just spaces. ");
                }
                else
                {
                    name_item = value;
                }
            }
        }
        public int QuantityInStock
        {
            get
            {
                return quantity_in_item;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be zero or negative. ");
                }
                else
                {
                    quantity_in_item = value;
                }
            }
        }
        // p means parameter
        public StockItem(int pCode, string pName, int pquantityInStock)
        {
            if ((pCode <= 0) && (pName == "") && (pquantityInStock <= 0))
            {
                throw new ArgumentException("Item code must be a positive integer. Item name cannot be blank. Quantity cannot be zero or negative. ");
            }
            else if ((pCode <= 0) && (pName.Contains(" ")))
            {
                throw new ArgumentException("Item code must be a positive integer. Item name cannot be just spaces. ");
            }
            else
            {
                Code = pCode;
                Name = pName;
                QuantityInStock = pquantityInStock;
            }
        }
        //Functions
        public void AddQuantity(int quantity_item)
        {
            if (quantity_item <= 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }
            else
            {
                QuantityInStock += quantity_item;
            }
        }
        //
        public void SubtractQuantity(int quantity_item)
        {
            if (quantity_item < 0)
            {
                throw new ArgumentException("Quantity cannot be negative");
            }
            else
            {
                if (quantity_item > quantity_in_item)
                {
                    throw new ArgumentException("Insufficient quantity in stock");
                }
                else
                {
                    QuantityInStock -= quantity_item;
                }
            }
        }


    }

}
