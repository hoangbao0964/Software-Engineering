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
    abstract class BookOrder : Order
    {
        #region Attributes
        protected List<Book> books;

        public List<Book> Books
        {
            get
            {
                return books;
            }

            set
            {
                books = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(List<Book> newBooks)
        {
            if (newBooks == null)
                books = new List<Book>();
            else
                books = newBooks;
            return true;
        }

        public BookOrder() : base()
        {
            Init(null);
        }

        public BookOrder(string orderID, double chargedMoney, double totalPayment, string status, int priorityNumber, DateTime dateCreated, VIP customer, Cashier chargedCashier, List<Book> newBooks) : base(orderID, chargedMoney, totalPayment, status, priorityNumber, dateCreated, customer, chargedCashier)
        {
            Init(newBooks);
        }
        #endregion
    }
}