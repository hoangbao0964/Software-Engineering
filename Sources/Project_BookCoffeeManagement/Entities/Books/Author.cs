using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Books
{
    public class Author
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

        #region Constructors & Initialize functions
        public Author(string name, string description)
        {
            Init(name, description);
        }

        public Author()
        {
            Init("", "");
        }

        public virtual bool Init(string name, string description)
        {
            this.Name = name;
            this.Description = description;

            return true;
        }
        #endregion
    }
}
