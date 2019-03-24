using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Books
{
    public class Publisher
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

        #region Constructors & Initialize methods
        public virtual bool Init(string name, string description)
        {
            this.Name = name;
            this.Description = description;

            return true;
        }

        public Publisher()
        {
            Init("", "");
        }

        public Publisher(string name, string description)
        {
            Init(name, description);
        }
        #endregion
    }
}
