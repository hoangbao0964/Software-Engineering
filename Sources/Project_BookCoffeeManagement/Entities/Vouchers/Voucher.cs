using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Vouchers
{
    class Voucher
    {
        #region Attributes
        protected string voucherID;
        protected DateTime publishDate;
        protected DateTime expireDate;
        protected DiscountRate discount;

        public string VoucherID
        {
            get
            {
                return voucherID;
            }

            set
            {
                voucherID = value;
            }
        }
        public DateTime PublishDate
        {
            get
            {
                return publishDate;
            }

            set
            {
                publishDate = value;
            }
        }
        public DateTime ExpireDate
        {
            get
            {
                return expireDate;
            }

            set
            {
                expireDate = value;
            }
        }
        public DiscountRate Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(string voucherID, DateTime publishDate, DateTime expireDate, DiscountRate discount)
        {
            VoucherID = voucherID;
            PublishDate = publishDate;
            ExpireDate = expireDate;
            Discount = discount;

            return true;
        }

        public Voucher()
        {
            Init("", DateTime.Now, DateTime.Now, null);
        }

        public Voucher(string voucherID, DateTime publishDate, DateTime expireDate, DiscountRate discount)
        {
            Init(voucherID, publishDate, expireDate, discount);
        }
        #endregion
    }
}
