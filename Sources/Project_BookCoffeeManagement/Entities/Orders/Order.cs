using Project_BookCoffeeManagement.Entities.People.Customers;
using Project_BookCoffeeManagement.Entities.People.Staffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Orders
{
    public class Order
    {
        #region Attributes
        protected string orderID;
        protected double? chargedMoney;
        protected double? totalPayment;
        protected string status;
        protected int? priorityNumber;
        protected DateTime? dateCreated;
        protected VIP customer;
        protected Cashier chargedCashier;

        public string OrderID
        {
            get
            {
                return orderID;
            }

            set
            {
                orderID = value;
            }
        }
        public double? ChargedMoney
        {
            get
            {
                return chargedMoney;
            }

            set
            {
                chargedMoney = value;
            }
        }
        public double? TotalPayment
        {
            get
            {
                return totalPayment;
            }

            set
            {
                totalPayment = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
        public int? PriorityNumber
        {
            get
            {
                return priorityNumber;
            }

            set
            {
                priorityNumber = value;
            }
        }
        public DateTime? DateCreated
        {
            get
            {
                return dateCreated;
            }

            set
            {
                dateCreated = value;
            }
        }
        protected VIP Customer
        {
            get
            {
                return customer;
            }

            set
            {
                customer = value;
            }
        }
        protected Cashier ChargedCashier
        {
            get
            {
                return chargedCashier;
            }

            set
            {
                chargedCashier = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(string orderID, double chargedMoney, double totalPayment, string status, int priorityNumber, DateTime dateCreated, VIP customer, Cashier chargedCashier)
        {
            this.orderID = orderID;
            this.chargedMoney = chargedMoney;
            this.totalPayment = totalPayment;
            this.status = status;
            this.priorityNumber = priorityNumber;
            this.dateCreated = dateCreated;
            if (customer != null)
                this.Customer = customer;
            else
                this.Customer = new VIP();
            if (chargedCashier != null)
                this.chargedCashier = chargedCashier;
            else
                this.chargedCashier = new Cashier();

            return true;
        }

        public Order(string orderID, double chargedMoney, double totalPayment, string status, int priorityNumber, DateTime dateCreated, VIP customer, Cashier chargedCashier)
        {
            Init(orderID, chargedMoney, totalPayment, status, priorityNumber, dateCreated, customer, chargedCashier);
        }

        public Order()
        {
            Init("0", 0, 0, "", 0, DateTime.Now, null, null);
        }
        #endregion

        public string GetVipID()
        {
            return Customer.VipID;
        }

        public bool SetVipID(string id)
        {
            Customer.VipID = id;
            return true;
        }
    }
}
