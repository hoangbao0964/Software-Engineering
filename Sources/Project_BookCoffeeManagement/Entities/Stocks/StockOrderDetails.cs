using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Stocks
{
    class StockOrderDetails
    {
        #region Attributes
        protected Ingredient_Stock details;
        protected int quantity;

        public Ingredient_Stock Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }
        public int Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(Ingredient_Stock stockDetails, int quantity)
        {
            if (stockDetails != null)
                Details = stockDetails;
            else
                Details = new Ingredient_Stock();

            Quantity = quantity;
            return true;
        }

        public StockOrderDetails()
        {
            Init(null, 0);
        }

        public StockOrderDetails(Ingredient_Stock stockDetails, int quantity)
        {
            Init(stockDetails, quantity);
        }
        #endregion
    }
}
