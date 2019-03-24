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
    class BorrowBookOrder : BookOrder
    {
        #region Attributes
        #endregion

        #region Constructor & Initialize methods
        public BorrowBookOrder() : base()
        {
        }

        public BorrowBookOrder(string orderID, double chargedMoney, double totalPayment, string status, int priorityNumber, DateTime dateCreated, VIP customer, Cashier chargedCashier, List<Book> newBooks) : base(orderID, chargedMoney, totalPayment, status, priorityNumber, dateCreated, customer, chargedCashier, newBooks)
        {
        }
        #endregion
    }
}
