using Project_BookCoffeeManagement.Entities.Books;
using Project_BookCoffeeManagement.Entities.People.Customers;
using Project_BookCoffeeManagement.Entities.People.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Orders
{
    class ReturnBookOrder : BookOrder
    {
        #region Attributes
        protected string borrowOrderID;
        protected int? lateDays;

        public string BorrowOrderID
        {
            get
            {
                return borrowOrderID;
            }

            set
            {
                borrowOrderID = value;
            }
        }
        public int? LateDays
        {
            get
            {
                return lateDays;
            }

            set
            {
                lateDays = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(string borrowID, int lateReturn)
        {
            BorrowOrderID = borrowID;
            LateDays = lateReturn;

            return true;
        }

        public ReturnBookOrder() : base()
        {
            Init("0", 0);
        }

        public ReturnBookOrder(string orderID, double chargedMoney, double totalPayment, string status, int priorityNumber, DateTime dateCreated, VIP customer, Cashier chargedCashier, List<Book> newBooks, string borrowID, int lateReturn) : base(orderID, chargedMoney, totalPayment, status, priorityNumber, dateCreated, customer, chargedCashier, newBooks)
        {
            Init(borrowID, lateReturn);
        }
        #endregion
    }
}
