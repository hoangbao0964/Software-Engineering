using Project_BookCoffeeManagement.Entities.People.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.Foods;

namespace Project_BookCoffeeManagement.Entities.Stocks
{
    class StockOrder
    {
        #region Attributes
        protected string stockOrderID;
        protected DateTime dateCreated;
        protected double totalPayment;
        protected List<StockOrderDetails> items;
        protected WarehouseManager chargedStaff;

        public string StockOrderID
        {
            get
            {
                return stockOrderID;
            }

            set
            {
                stockOrderID = value;
            }
        }
        public DateTime DateCreated
        {
            get
            {
                return dateCreated;
            }

            set
            {
                dateCreated = value;
            }
        }
        public double TotalPayment
        {
            get
            {
                return totalPayment;
            }

            set
            {
                totalPayment = value;
            }
        }

        protected List<StockOrderDetails> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }
        protected WarehouseManager ChargedStaff
        {
            get
            {
                return chargedStaff;
            }

            set
            {
                chargedStaff = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(string stockOrderID, DateTime dateCreated, double totalPayment, List<StockOrderDetails> items, WarehouseManager chargedStaff)
        {
            this.StockOrderID = stockOrderID;
            this.DateCreated = dateCreated;
            this.TotalPayment = totalPayment;
            if (items != null)
                this.Items = items;
            else
                this.Items = new List<StockOrderDetails>();
            this.ChargedStaff = chargedStaff;

            return true;
        }

        public StockOrder()
        {
            Init("", DateTime.Now, 0, null, null);
        }

        public StockOrder(string stockOrderID, DateTime dateCreated, double totalPayment, List<StockOrderDetails> items, WarehouseManager chargedStaff)
        {
            Init(stockOrderID, dateCreated, totalPayment, items, chargedStaff);
        }
      
        #endregion

        public List<StockOrderDetails> GetStockOrderDetails()
        {
            return Items;
        }

        public void SetStockOrderDetails(List<Ingredient> data)
        {
            foreach (Ingredient igr in data)
            {
                StockOrderDetails newData = new StockOrderDetails();
                newData.Quantity = int.Parse(igr.Quantity.ToString());
                newData.Details.GetIngredientDetails().Name = igr.Name;
                Items.Add(newData);
            }
        }

        internal string ValidateFields()
        {
            if (totalPayment < 0)
                return "Price must be positive";
            if (items.Count == 0)
                return "No items selected";
            foreach (StockOrderDetails item in items)
            {
                if (item.Quantity <= 0)
                    return "Quantity must be greater than 0";
            }
            return "";
        }
    }
}
