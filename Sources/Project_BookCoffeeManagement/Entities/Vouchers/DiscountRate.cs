using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Vouchers
{
    abstract class DiscountRate
    {
        #region Attributes
        protected string description;

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

        #region Constructors
        public DiscountRate(string description)
        {
            Description = description;
        }

        public DiscountRate()
        {
            Description = "";
        }
        #endregion
    }
}
