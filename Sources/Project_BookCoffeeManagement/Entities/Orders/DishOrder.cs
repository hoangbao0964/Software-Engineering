using Project_BookCoffeeManagement.Entities.Foods;
using Project_BookCoffeeManagement.Entities.People.Customers;
using Project_BookCoffeeManagement.Entities.People.Staffs;
using Project_BookCoffeeManagement.Entities.Vouchers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Orders
{
    class DishOrder : Order
    {
        #region Attributes
        protected List<Food> orderItems;
        protected Voucher voucher;

        public List<Food> OrderItems
        {
            get
            {
                return orderItems;
            }

            set
            {
                orderItems = value;
            }
        }
        public Voucher Voucher
        {
            get
            {
                return voucher;
            }

            set
            {
                voucher = value;
            }
        }
        #endregion

        #region Constructors & Init methods
        public virtual bool Init(List<Food> items, Voucher voucher)
        {
            if (items != null)
                this.OrderItems = items;
            else
                this.OrderItems = new List<Food>();
            this.Voucher = voucher;

            return true;
        }

        public DishOrder() : base()
        {
            Init(null, null);
        }

        public DishOrder(string orderID, double chargedMoney, double totalPayment, string status, int priorityNumber, DateTime dateCreated, VIP customer, Cashier chargedCashier, List<Food> items, Voucher voucher) : base(orderID,chargedMoney,totalPayment, status, priorityNumber, dateCreated, customer, chargedCashier)
        {
            Init(items, voucher);
        }
        #endregion
    }
}
