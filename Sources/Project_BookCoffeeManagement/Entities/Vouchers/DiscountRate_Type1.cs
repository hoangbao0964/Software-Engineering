using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Vouchers
{
    class DiscountRate_Type1 : DiscountRate
    {
        #region Attributes
        protected double discountRate;
        public double DiscountRate
        {
            get
            {
                return discountRate;
            }

            set
            {
                discountRate = value;
            }
        }
        #endregion

        #region Constrcutors
        public DiscountRate_Type1()
        {
            discountRate = 0;
        }

        public DiscountRate_Type1(double rate) : base()
        {
            discountRate = rate;
        }

        public DiscountRate_Type1(double rate, string description) : base(description)
        {
            discountRate = rate;
        }
        #endregion
    }
}
