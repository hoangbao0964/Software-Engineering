using Project_BookCoffeeManagement.Entities.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Vouchers
{
    class DiscountRate_Type2 : DiscountRate
    {
        #region Attributes
        protected Food buyProduct;
        protected Food freeProduct;

        public Food BuyProduct
        {
            get
            {
                return buyProduct;
            }

            set
            {
                buyProduct = value;
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
        public virtual bool Init(Food buyProduct, Food freeProduct)
        {
            this.BuyProduct = buyProduct;
            this.FreeProduct = freeProduct;
   			return true;
        }

        public DiscountRate_Type2(Food buyProduct, Food freeProduct) : base()
        {
            Init(buyProduct, freeProduct);
        }

        public DiscountRate_Type2() : base()
        {
            Init(null, null);
        }

        public DiscountRate_Type2(Food buyProduct, Food freeProduct, string description) : base(description)
        {
            Init(buyProduct, freeProduct);
        }

        #endregion
    }
}
