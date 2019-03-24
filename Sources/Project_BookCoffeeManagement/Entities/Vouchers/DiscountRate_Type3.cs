using Project_BookCoffeeManagement.Entities.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Vouchers
{
    class DiscountRate_Type3 : DiscountRate
    {
        #region Attributes
        protected int minimumProductRequired;
        protected Food freeProduct;

        public int MinimumProductRequired
        {
            get
            {
                return minimumProductRequired;
            }

            set
            {
                minimumProductRequired = value;
            }
        }

        public Food FreeProduct
        {
            get
            {
                return freeProduct;
            }

            set
            {
                freeProduct = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(int minProductRequired, Food freeFood)
        {
            MinimumProductRequired = minProductRequired;
            FreeProduct = freeFood;

            return true;
        }

        public DiscountRate_Type3() : base()
        {
            Init(0, null);
        }

        public DiscountRate_Type3(int minProductRequired, Food freeFood) : base()
        {
            Init(minProductRequired, freeFood);
        }

        public DiscountRate_Type3(int minProductRequired, Food freeFood, string description) : base(description)
        {
            Init(minProductRequired, freeFood);
        }
        #endregion
    }
}
