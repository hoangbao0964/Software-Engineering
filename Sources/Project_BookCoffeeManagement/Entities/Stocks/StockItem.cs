using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Stocks
{
    public class StockItem
    {
        #region Attributes
        protected int? quantity;
        protected Ingredient_Stock details;

        public int? Quantity
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

        protected Ingredient_Stock Details
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

        public string Name
        {
            get
            {
                return details.Ingredient.Name;
            }

            set
            {
                details.Ingredient.Name = value;
            }
        }

        public string Description
        {
            get
            {
                return details.Ingredient.Description;
            }

            set
            {
                details.Ingredient.Description = value;
            }
        }

        public string ProducerName
        {
            get
            {
                return details.Producer.Name;
            }

            set
            {
                details.Producer.Name = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(int quantity, Ingredient_Stock details)
        {
            this.Quantity = quantity;
            if (details != null)
                this.Details = details;
            else
                this.Details = new Ingredient_Stock();

            return true;
        }

        public StockItem()
        {
            Init(0, null);
        }

        public StockItem(int quantity, Ingredient_Stock details)
        {
            Init(quantity, details);
        }
        #endregion

        public Ingredient_Stock GetIngredientInStock()
        {
            return Details;
        }

        internal string ValidateFields()
        {
            if (Name == "")
                return "An ingredient's name must be specified";

            return "";
        }
    }
}
