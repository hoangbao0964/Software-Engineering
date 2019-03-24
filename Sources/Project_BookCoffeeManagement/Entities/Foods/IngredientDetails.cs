using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Foods
{
    public class IngredientDetails
    {
        #region Attributes
        protected string name;
        protected string description;

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
        #endregion

        #region Contructors & Initialize methods
        public virtual bool Init(string name, string description)
        {
            this.name = name;
            this.description = description;
            return true;
        }

        public IngredientDetails()
        {
            Init("", "");
        }

        public IngredientDetails(string name, string description)
        {
            Init(name, description);
        }
        #endregion
    }
}
