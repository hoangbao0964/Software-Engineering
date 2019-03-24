using Project_BookCoffeeManagement.Entities.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Stocks
{
    public class Ingredient_Stock
    {
        #region Attributes
        protected IngredientDetails ingredient;
        protected Producer producer;

        public IngredientDetails Ingredient
        {
            get
            {
                return ingredient;
            }

            set
            {
                ingredient = value;
            }
        }
        public Producer Producer
        {
            get
            {
                return producer;
            }

            set
            {
                producer = value;
            }
        }

        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(IngredientDetails ingredient, Producer producer)
        {
            if (ingredient != null)
                this.Ingredient = ingredient;
            else
                this.Ingredient = new IngredientDetails();
            if (producer != null)
                this.Producer = producer;
            else
                this.Producer = new Producer();

            return true;
        }

        public Ingredient_Stock()
        {
            Init(null, null);
        }

        public Ingredient_Stock(IngredientDetails ingredient, Producer producer)
        {
            Init(ingredient, producer);
        }
        #endregion

        public IngredientDetails GetIngredientDetails()
        {
            return Ingredient;
        }
    }
}
