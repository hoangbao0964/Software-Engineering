using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.Orders;
using System.Data.Linq;
using Project_BookCoffeeManagement.Entities.Foods;
using Project_BookCoffeeManagement.BLL.Foods;
using Project_BookCoffeeManagement.Entities.Books;
using Project_BookCoffeeManagement.BLL.Books;
using Project_BookCoffeeManagement.BLL.People.Customers;
using Project_BookCoffeeManagement.BLL.Stocks;

namespace Project_BookCoffeeManagement.BLL.Orders
{
    class OrderManager : Manager
    {
        private string availableStatusStr = "Processing";

        #region Get Table
        public Table<DAL.OrderBasicInfo> GetOrderBasicInfoTable()
        {
            return db.GetTable<DAL.OrderBasicInfo>();
        }

        public Table<DAL.OrderStatus> GetOrderStatusTable()
        {
            return db.GetTable<DAL.OrderStatus>();
        }

        public Table<DAL.VIPOrder> GetVipOrderTable()
        {
            return db.GetTable<DAL.VIPOrder>();
        }

        public Table<DAL.FoodCalled> GetFoodCalledTable()
        {
            return db.GetTable<DAL.FoodCalled>();
        }

        public Table<DAL.BookCalled> GetBookCalledTable()
        {
            return db.GetTable<DAL.BookCalled>();
        }

        public Table<DAL.BookReturnOrder> GetBookReturnOrderTable()
        {
            return db.GetTable<DAL.BookReturnOrder>();
        }

        public Table<DAL.BookReturned> GetBookReturnTable()
        {
            return db.GetTable<DAL.BookReturned>();
        }

        public Table<DAL.BookBorrowOrder> GetBookBorrowOrderTable()
        {
            return db.GetTable<DAL.BookBorrowOrder>();
        }
        #endregion

        #region Get Data
        public List<Order> GetOrders()
        {
            Table<DAL.OrderBasicInfo> orderBasicTable = GetOrderBasicInfoTable();
            Table<DAL.OrderStatus> orderStatusTable = GetOrderStatusTable();

            var res = (from order in orderBasicTable
                       join orderStatus in orderStatusTable on order.orderStatusCode equals orderStatus.orderStatusCode
                       select new Order
                       {
                           OrderID = order.orderID,
                           ChargedMoney = order.charge,
                           TotalPayment = order.totalPayment,
                           Status = orderStatus.name,
                           PriorityNumber = order.priorityNumber,
                           DateCreated = order.dateCreated
                       }
                       );

            return res.ToList();
        }

        public List<Order> GetProcessingOrder()
        {
            List<Order> res = GetOrders();
            return res.Where(s => s.Status == availableStatusStr).ToList();
        }

        public List<string> GetOrderStatusList()
        {
            Table<DAL.OrderStatus> orderStatusTable = GetOrderStatusTable();

            var res = (from orderStatus in orderStatusTable
                       select orderStatus.name);

            return res.ToList();
        }     

        public List<Order> GetTransactionHistory()
        {
            // Dummy init
            return GetOrders();
        }

        public List<Food> GetFoodListFromOrder(string orderID)
        {
            Table<DAL.FoodCalled> fdCalledTable = GetFoodCalledTable();

            var res = (from fdCalled in fdCalledTable
                       where fdCalled.orderID == orderID
                       select fdCalled).ToList();

            List<Food> data = new List<Food>();
            FoodManager fdManager = new FoodManager();
            foreach (DAL.FoodCalled food in res)
            {
                Food temp = fdManager.GetFood(food.foodID);
                temp.Quantity = food.quantity;
                data.Add(temp);
            }
            return data;
        }

        public Order GetOrderFromID(string oldOrderID)
        {
            List<Order> res = GetOrders();
            return res.Where(s => s.OrderID == oldOrderID).FirstOrDefault();
        }

        public List<object> SearchOrder(string searchPharse1, string type1, string searchPharse2, string type2, string searchPharse3, string type3, string searchConstraint1, string searchConstraint2)
        {
            throw new NotImplementedException();
        }

        public List<object> SearchTransaction(string searchPharse1, string type1, string searchPharse2, string type2, string searchPharse3, string type3, string searchConstraint1, string searchConstraint2)
        {
            throw new NotImplementedException();
        }

        internal List<Order> SearchOrder(string keyword)
        {
            List<Order> res = GetProcessingOrder();
            return res.Where(s => s.OrderID.ToLower().Contains(keyword.ToLower()) || s.PriorityNumber.ToString().ToLower().Contains(keyword.ToLower())).ToList();
        }

        internal List<Order> SearchTransaction(string keyword)
        {
            List<Order> res = GetOrders();
            return res.Where(s => s.OrderID.ToLower().Contains(keyword.ToLower())).ToList();
        }

        public string GetVipIDInOrder(string orderID)
        {
            Table<DAL.VIPOrder> vipOrderTable = GetVipOrderTable();

            var res = (from vip in vipOrderTable
                       where vip.orderID == orderID
                       select vip.vipID).FirstOrDefault();

            return res;
        }

        public List<Book> GetBookListFromBookCalledOrder(string orderID)
        {
            Table<DAL.BookCalled> bkCalledTable = GetBookCalledTable();

            var res = (from bkCalled in bkCalledTable
                       where bkCalled.orderID == orderID
                       select bkCalled.bookID).ToList();

            List<Book> data = new List<Book>();
            BookManager bkManager = new BookManager();
            foreach (string bookID in res)
            {
                data.Add(bkManager.GetBooks(bookID));             
            }
            return data;
        }

        public List<Book> GetBookListFromBookReturnedOrder(string orderID)
        {
            Table<DAL.BookReturned> bkReturnedTable = GetBookReturnTable();

            var res = (from bkCalled in bkReturnedTable
                       where bkCalled.orderID == orderID
                       select bkCalled.bookID).ToList();

            List<Book> data = new List<Book>();
            BookManager bkManager = new BookManager();
            foreach (string bookID in res)
            {
                data.Add(bkManager.GetBooks(bookID));
            }
            return data;
        }

        public ReturnBookOrder GetBookReturnOrderInfo(string orderID)
        {
            Table<DAL.BookReturnOrder> bkReturnOrderTable = GetBookReturnOrderTable();

            var res = (from order in bkReturnOrderTable
                       where order.orderID == orderID
                       select new ReturnBookOrder
                       {
                           LateDays = order.lateDays,
                           BorrowOrderID = order.bookBorrowOrderID
                       }).FirstOrDefault();

            return res;
        }

        public bool IsCorrectBookBorrowOrder(string orderID)
        {
            Table<DAL.BookBorrowOrder> bkBorrowOrderTable = GetBookBorrowOrderTable();

            var res = (from order in bkBorrowOrderTable
                       where order.orderID == orderID
                       select order).FirstOrDefault();

            return (res != null);
        }

        public int GetOrderStatusCode(string orderStatus)
        {
            Table<DAL.OrderStatus> statusTable = GetOrderStatusTable();

            return (from st in statusTable
                    where st.name == orderStatus
                    select st.orderStatusCode).FirstOrDefault();
        }
        #endregion

        #region Update Data
        public string AddOrUpdateDishOrder(DishOrder order)
        {
            string orderID = (order.OrderID == "") ? GenerateDishOrderID(order) : order.OrderID;
            string err = AddOrUpdateOrderBasicInfo(order, orderID);
            if (err != "")
                return err;

            if (order.GetVipID() != "")
            {
                err = AddOrUpdateVIPInOrder(orderID, order.GetVipID(), true);
                if (err != "")
                    return err;
            }

            err = AddOrUpdateFoodInOrder(orderID, order.OrderItems);
            if (err != "")
                return err;

            return "";
        }

        public string AddOrUpdateOrderBasicInfo(Order order, string newOrderIDForAddOrder)
        {
            Table<DAL.OrderBasicInfo> orderTable = GetOrderBasicInfoTable();

            var matchedRes = (from o in orderTable
                              where o.orderID == order.OrderID
                              select o).FirstOrDefault();

            string orderID = "";
            if (matchedRes == null)
            {
                DAL.OrderBasicInfo newData = new DAL.OrderBasicInfo();
                try
                {
                    newData.orderID = newOrderIDForAddOrder;
                    newData.dateCreated = order.DateCreated;
                    newData.priorityNumber = order.PriorityNumber;
                    newData.totalPayment = order.TotalPayment;
                    newData.charge = order.ChargedMoney;
                    newData.orderStatusCode = GetOrderStatusCode(order.Status);
                    newData.cashierID = ParameterManager.GetCurrentStaff().StaffID;

                    orderTable.InsertOnSubmit(newData);
                    orderTable.Context.SubmitChanges();

                    orderID = newData.orderID;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
            {
                try
                {
                    matchedRes.orderStatusCode = GetOrderStatusCode(order.Status);
                    db.SubmitChanges();

                    orderID = matchedRes.orderID;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        private string AddOrUpdateFoodInOrder(string orderID, List<Food> orderItems)
        {
            Table<DAL.FoodCalled> foodOrderTable = GetFoodCalledTable();
            DeleteFoodInOrder(orderID);
            FoodManager fdManager = new FoodManager();
            IngredientManager igrManager = new IngredientManager();
            StockManager stkManager = new StockManager();
            foreach (Food fd in orderItems)
            {
                DAL.FoodCalled data = new DAL.FoodCalled();
                try
                {
                    data.orderID = orderID;
                    data.foodID = fdManager.GetFoodIDByName(fd.Name);
                    data.quantity = fd.Quantity;

                    // Update quantity in stock
                    foreach (Ingredient igr in igrManager.GetFoodIngredientList(fd.Name))
                    {
                        string err = stkManager.DecreaseIngredientQuantityInStock(igrManager.GetIngredientDetailsID(igr.Name), data.quantity * int.Parse(igr.Quantity.ToString()));
                        if (err != "")
                            return err;
                    }

                    foodOrderTable.InsertOnSubmit(data);
                    foodOrderTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "";
        }

        public string AddOrUpdateBorrowBookOrder(BorrowBookOrder order)
        {
            string orderID = (order.OrderID == "") ? GenerateBookBorrowOrderID(order) : order.OrderID;
            string err = AddOrUpdateOrderBasicInfo(order, orderID);
            if (err != "")
                return err;

            err = AddOrUpdateVIPInOrder(orderID, order.GetVipID(), true);
            if (err != "")
                return err;

            Table<DAL.BookBorrowOrder> bkBorrowOrderTable = GetBookBorrowOrderTable();
            var matchedRes = (from borrowOrder in bkBorrowOrderTable
                              where borrowOrder.orderID == orderID
                              select borrowOrder).FirstOrDefault();

            if (matchedRes == null)
            {
                DAL.BookBorrowOrder data = new DAL.BookBorrowOrder();
                try
                {
                    data.orderID = orderID;
                    bkBorrowOrderTable.InsertOnSubmit(data);
                    bkBorrowOrderTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            err = AddOrUpdateBooksInBorrowOrder(orderID, order.Books);
            if (err != "")
                return err;

            return "";

        }

        private string AddOrUpdateBooksInBorrowOrder(string orderID, List<Book> books)
        {
            Table<DAL.BookCalled> bookOrderTable = GetBookCalledTable();
            DeleteBookInBorrowOrder(orderID);
            BookManager bkManager = new BookManager();
            foreach (Book book in books)
            {
                DAL.BookCalled data = new DAL.BookCalled();
                try
                {
                    data.orderID = orderID;
                    data.bookID = book.BookID;

                    bookOrderTable.InsertOnSubmit(data);
                    bookOrderTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                bkManager.SetBookStatus(book.BookID, 2);
            }
            return "";
        }

        public string AddOrUpdateReturnBookOrder(ReturnBookOrder order)
        {
            string orderID = (order.OrderID == "") ? GenerateBookReturnOrderID(order) : order.OrderID;
            string err = AddOrUpdateOrderBasicInfo(order, orderID);
            if (err != "")
                return err;

            Table<DAL.BookReturnOrder> bkReturnOrderTable = GetBookReturnOrderTable();
            var matchedRes = (from returnOrder in bkReturnOrderTable
                              where returnOrder.bookBorrowOrderID == order.BorrowOrderID
                              select returnOrder).FirstOrDefault();

            if (matchedRes == null)
            {
                DAL.BookReturnOrder data = new DAL.BookReturnOrder();
                try
                {
                    data.orderID = orderID;
                    data.bookBorrowOrderID = order.BorrowOrderID;
                    data.lateDays = order.LateDays;
                    bkReturnOrderTable.InsertOnSubmit(data);
                    bkReturnOrderTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            err = AddOrUpdateBooksInReturnOrder(orderID, order.Books);
            if (err != "")
                return err;

            return "";
        }

        private string AddOrUpdateBooksInReturnOrder(string orderID, List<Book> books)
        {
            Table<DAL.BookReturned> bookOrderTable = GetBookReturnTable();
            DeleteBookInReturnOrder(orderID);
            BookManager bkManager = new BookManager();
            foreach (Book book in books)
            {
                DAL.BookReturned data = new DAL.BookReturned();
                try
                {
                    data.orderID = orderID;
                    data.bookID = book.BookID;

                    bookOrderTable.InsertOnSubmit(data);
                    bookOrderTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

                bkManager.SetBookStatus(book.BookID, 1);
            }
            return "";
        }

        private string DeleteBookInBorrowOrder(string orderID)
        {
            Table<DAL.BookCalled> bookOrderTable = GetBookCalledTable();

            var res = (from bkOrder in bookOrderTable
                       where bkOrder.orderID == orderID
                       select bkOrder).ToList();

            foreach (DAL.BookCalled data in res)
            {
                try
                {
                    bookOrderTable.DeleteOnSubmit(data);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        private string DeleteBookInReturnOrder(string orderID)
        {
            Table<DAL.BookReturned> bookOrderTable = GetBookReturnTable();

            var res = (from bkOrder in bookOrderTable
                       where bkOrder.orderID == orderID
                       select bkOrder).ToList();

            foreach (DAL.BookReturned data in res)
            {
                try
                {
                    bookOrderTable.DeleteOnSubmit(data);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        private string DeleteFoodInOrder(string orderID)
        {
            Table<DAL.FoodCalled> foodOrderTable = GetFoodCalledTable();

            var res = (from fdOrder in foodOrderTable
                       where fdOrder.orderID == orderID
                       select fdOrder).ToList();

            foreach (DAL.FoodCalled data in res)
            {
                try
                {
                    foodOrderTable.DeleteOnSubmit(data);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        private string AddOrUpdateVIPInOrder(string orderID, string vipID, bool IsAddViPDate)
        {
            Table<DAL.VIPOrder> vipTable = GetVipOrderTable();

            var matchedRes = (from o in vipTable
                              where o.orderID == orderID
                              select o).FirstOrDefault();

            if (matchedRes == null)
            {
                DAL.VIPOrder newData = new DAL.VIPOrder();
                try
                {
                    newData.orderID = orderID;
                    newData.vipID = vipID;

                    vipTable.InsertOnSubmit(newData);
                    vipTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedRes != null)
            {
                try
                {
                    matchedRes.orderID = orderID;
                    matchedRes.vipID = vipID;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            if (IsAddViPDate)
            {
                new VIPManager().IncreaseVipMembership(vipID);
            }
            return "";
        }

        internal string DeleteOrder(string orderID)
        {
            DeleteBookInBorrowOrder(orderID);
            DeleteBookInReturnOrder(orderID);
            DeleteFoodInOrder(orderID);
            DeleteBookBorrowOrder(orderID);
            DeleteBookReturnOrder(orderID);
            DeleteVipOrder(orderID);

            Table<DAL.OrderBasicInfo> orderTable = GetOrderBasicInfoTable();
            var res = (from order in orderTable
                       where orderID == order.orderID
                       select order).FirstOrDefault();

            if (res != null)
            {
                try
                {
                    orderTable.DeleteOnSubmit(res);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "";
        }

        private string DeleteVipOrder(string orderID)
        {
            Table<DAL.VIPOrder> orderTable = GetVipOrderTable();

            var res = (from order in orderTable
                       where order.orderID == orderID
                       select order).ToList();

            foreach (DAL.VIPOrder data in res)
            {
                try
                {
                    orderTable.DeleteOnSubmit(data);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        private string DeleteBookReturnOrder(string orderID)
        {
            Table<DAL.BookReturnOrder> orderTable = GetBookReturnOrderTable();

            var res = (from order in orderTable
                       where order.orderID == orderID
                       select order).ToList();

            foreach (DAL.BookReturnOrder data in res)
            {
                try
                {
                    orderTable.DeleteOnSubmit(data);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        private string DeleteBookBorrowOrder(string orderID)
        {
            Table<DAL.BookBorrowOrder> orderTable = GetBookBorrowOrderTable();

            var res = (from order in orderTable
                       where order.orderID == orderID
                       select order).ToList();

            foreach (DAL.BookBorrowOrder data in res)
            {
                try
                {
                    orderTable.DeleteOnSubmit(data);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }
        #endregion

        #region ID Generate
        public string GenerateDishOrderID(DishOrder order)
        {
            string res = "DIOR";
            if (order.GetVipID() == "")
                res += "R";
            else
                res += "V";
            res += "N_";     // Hiện chưa có chức băng voucher
            res += order.DateCreated.Value.Date.ToString("ddMMyy") + "_";

            Table<DAL.OrderBasicInfo> orderTable = GetOrderBasicInfoTable();
            var matchedRes = (from o in orderTable
                              where o.orderID.Contains(res) == true
                              select o).ToList();

            res += (matchedRes.Count + 1).ToString();

            return res;
        }

        public string GenerateBookBorrowOrderID(BookOrder order)
        {
            string res = "BBAHVN_";
            res += order.DateCreated.Value.Date.ToString("ddMMyy") + "_";

            Table<DAL.OrderBasicInfo> orderTable = GetOrderBasicInfoTable();
            var matchedRes = (from o in orderTable
                              where o.orderID.Contains(res) == true
                              select o).ToList();

            res += (matchedRes.Count + 1).ToString();

            return res;
        }

        public string GenerateBookReturnOrderID(ReturnBookOrder order)
        {
            string res = "";
            if (order.LateDays == 0)
                res = "BROS";
            else
                res = "BROD";
            res += "VN_";
            res += order.DateCreated.Value.Date.ToString("ddMMyy") + "_";

            Table<DAL.OrderBasicInfo> orderTable = GetOrderBasicInfoTable();
            var matchedRes = (from o in orderTable
                              where o.orderID.Contains(res) == true
                              select o).ToList();

            res += (matchedRes.Count + 1).ToString();

            return res;
        }
 
        #endregion
    }
}
