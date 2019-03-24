using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Foods
{
    public class Ingredient
    {
        #region Attributes
        protected int? quantity;
        protected IngredientDetails details;

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
        protected IngredientDetails Details
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
                return Details.Name;
            }

            set
            {
                Details.Name = value;
            }
        }
        public string Description
        {
            get
            {
                return Details.Description;
            }

            set
            {
                Details.Description = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(int? quantity, IngredientDetails details)
        {
            this.Quantity = quantity;
            if (details != null)
                this.Details = details;
            else
                this.Details = new IngredientDetails();
            return true;
        }
        public Ingredient()
        {
            Init(0, null);
        }

        public Ingredient(int? quantity, IngredientDetails details)
        {
            Init(quantity, details);
        }
        #endregion

        public IngredientDetails GetIngredientDetails()
        {
            return this.Details;
        }
    }
}
