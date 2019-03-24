using Project_BookCoffeeManagement.BLL.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Foods
{
    public class Food
    {
        #region Attributes
        protected string name;
        protected double? price;
        protected string status;
        protected string description;
        protected List<Ingredient> ingredients;
        protected int quantity;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public double? Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        protected List<Ingredient> Ingredients
        {
            get
            {
                return ingredients;
            }

            set
            {
                ingredients = value;
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
        public virtual bool Init(string name, double? price, string status, string description, List<Ingredient> ingredients)
        {
            this.Name = name;
            this.Price = price;
            this.Status = status;
            this.Description = description;
            if (ingredients != null)
                Ingredients = ingredients;
            else
                Ingredients = new List<Ingredient>();
            return true;
        }

        public Food()
        {
            Init("", 0, "", "", null);
        }

        public Food(string name, double? price, string status, string description)
        {
            Init(name, price, status, description, null);
        }

        public Food(string name, double? price, string status, string description, List<Ingredient> ingredients)
        {
            Init(name, price, status, description, ingredients);
        }

        #endregion

        #region Methods
        public List<Ingredient> GetIngredients()
        {
            return Ingredients;
        }

        public bool AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            return true;
        }

        public bool SetIngredients(List<Ingredient> ingredients)
        {
            Ingredients = ingredients;
            return true;
        }

        public bool UpdateIngredientList()
        {
            IngredientManager manager = new IngredientManager();
            return SetIngredients(manager.GetFoodIngredientList(Name));
        }

        internal string ValidateFields()
        {
            if (name == "")
                return "A name must be specified";
            if (price < 0)
                return "Price must not be a negative number";
            if (ingredients == null || ingredients.Count == 0)
                return "No ingredient selected";
            foreach (Ingredient igr in ingredients)
            {
                if (igr.Quantity <= 0)
                    return "A ingredient must have a positive number of quantity";
            }

            return "";
        }
        #endregion
    }
}
