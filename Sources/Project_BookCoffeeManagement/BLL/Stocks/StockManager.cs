using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.Stocks;
using Project_BookCoffeeManagement.BLL.Foods;

namespace Project_BookCoffeeManagement.BLL.Stocks
{
    class StockManager : Manager
    {
        protected IngredientManager igrManager;

        public StockManager()
        {
            igrManager = new IngredientManager();
        }

        #region Get Table
        private Table<DAL.Producer> GetProducerTable()
        {
            return db.GetTable<DAL.Producer>();
        }
        private Table<DAL.IngredientInStockDetail> GetIngredientInStockDetailsTable()
        {
            return db.GetTable<DAL.IngredientInStockDetail>();
        }
        private Table<DAL.IngredientDetail> GetIngredientDetailTable()
        {
            return db.GetTable<DAL.IngredientDetail>();
        }

        private Table<DAL.StockOrder> GetStockOrderTable()
        {
            return db.GetTable<DAL.StockOrder>();
        }

        private Table<DAL.StockOrderDetail> GetStockOrderDetailTable()
        {
            return db.GetTable<DAL.StockOrderDetail>();
        }
        #endregion

        #region Get Data
        public List<StockItem> GetStockItems()
        {
            Table<DAL.Producer> producerTable = this.GetProducerTable();
            Table<DAL.IngredientInStockDetail> ingredientInStockDetailTable = this.GetIngredientInStockDetailsTable();
            Table<DAL.IngredientDetail> ingredientDetailTable = this.GetIngredientDetailTable();
            var res = (from ingInSkDetails in ingredientInStockDetailTable
                       join pr in producerTable on ingInSkDetails.producerID equals pr.producerID
                       join ingDetails in ingredientDetailTable on ingInSkDetails.ingredientDetailsID equals ingDetails.ingredientDetailsID
                       select new StockItem
                       {
                           Name = ingDetails.name,
                           Description = ingDetails.description,
                           Quantity = ingInSkDetails.quantity,
                           ProducerName = pr.name
                       });
            return res.ToList();
        }

        public List<object> SearchOrder(string searchPharse1, string type1, string searchPharse2, string type2, string searchPharse3, string type3, string searchConstraint1, string searchConstraint2)
        {
            throw new NotImplementedException();
        }

        internal List<StockItem> SearchStock(string keyword)
        {
            List<StockItem> res = GetStockItems();
            return res.Where(s => s.Name.ToLower().Contains(keyword.ToLower()) || s.ProducerName.ToLower().Contains(keyword.ToLower())).ToList();
        }

        public List<string> GetProducerList()
        {
            Table<DAL.Producer> producerTable = GetProducerTable();

            var res = (from producer in producerTable
                       select producer.name);

            return res.ToList();
        }

        public int GetProducerCode(string producerName)
        {
            if (producerName == null)
                return 0;
            Table<DAL.Producer> producerTable = GetProducerTable();

            var res = (from producer in producerTable
                       where producer.name == producerName
                       select producer.producerID).FirstOrDefault();

            if (res == default(int))
            {
                AddNewProducer(producerName);
                return GetProducerCode(producerName);
            }
            return res;
        }

        #endregion

        #region Update Data
        public string AddorUpdateStockIngredient(StockItem newItem)
        {
            Table<DAL.IngredientDetail> igrDetailTable = GetIngredientDetailTable();
            Table<DAL.IngredientInStockDetail> igrInStockDetailTable = GetIngredientInStockDetailsTable();

            string res = igrManager.AddOrUpdateIngredientDetails(newItem.GetIngredientInStock().GetIngredientDetails());
            if (res != "")
                return res;

            int ingredientDetailID = igrManager.GetIngredientDetailsID(newItem.Name);

            var matchedRes = (from igrInStockDetails in igrInStockDetailTable
                              where igrInStockDetails.ingredientDetailsID == ingredientDetailID
                              select igrInStockDetails).FirstOrDefault();

            if (matchedRes == null)
            {
                DAL.IngredientInStockDetail newData = new DAL.IngredientInStockDetail();
                try
                {
                    newData.ingredientDetailsID = ingredientDetailID;
                    newData.quantity = int.Parse(newItem.Quantity.ToString());
                    newData.producerID = GetProducerCode(newItem.ProducerName);

                    igrInStockDetailTable.InsertOnSubmit(newData);
                    igrInStockDetailTable.Context.SubmitChanges();
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
                    matchedRes.producerID = GetProducerCode(newItem.ProducerName);

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            return "";
        }

        private string AddNewProducer(string producerName)
        {
            Table<DAL.Producer> producerTable = GetProducerTable();
            DAL.Producer newData = new DAL.Producer();
            try
            {
                newData.name = producerName;
                producerTable.InsertOnSubmit(newData);
                producerTable.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
            
        }

        public string AddStockOrder(StockOrder newStockOrder)
        {        
            Table<DAL.StockOrder> stockOrderTable = GetStockOrderTable();

            DAL.StockOrder stockOrder = new DAL.StockOrder();
            try
            {
                Random rnd = new Random();
                stockOrder.stockOrderID = rnd.Next().ToString();         // Dummy init
                stockOrder.charge = 0;
                stockOrder.chargedWarehouseManager = ParameterManager.GetCurrentStaff().StaffID;
                stockOrder.totalPayment = newStockOrder.TotalPayment;
                stockOrder.dateCreated = newStockOrder.DateCreated;

                stockOrderTable.InsertOnSubmit(stockOrder);
                stockOrderTable.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            var matchedRes = (from stock in stockOrderTable
                              where stock.dateCreated == newStockOrder.DateCreated && stock.totalPayment == newStockOrder.TotalPayment && stock.chargedWarehouseManager == ParameterManager.GetCurrentStaff().StaffID
                              select stock).FirstOrDefault();

            if (matchedRes == null)
                return "Some error occur while retrieve the stock order ID";


            string stockOrderID = matchedRes.stockOrderID;

            foreach (StockOrderDetails details in newStockOrder.GetStockOrderDetails())
            {
                string err = AddStockOrderDetails(stockOrderID, details.Quantity, details.Details.Ingredient.Name);
                if (err != "")
                    return err;
            }        

            return "";
        }

        private string AddStockOrderDetails(string stockOrderID, int quantity, string ingredientName)
        {
            Table<DAL.StockOrderDetail> stockOrderDetailTable = GetStockOrderDetailTable();
            int ingredientDetailsID = igrManager.GetIngredientDetailsID(ingredientName);

            DAL.StockOrderDetail newData = new DAL.StockOrderDetail();
            try
            {
                newData.stockOrderID = stockOrderID;
                newData.quantity = quantity;
                newData.stockItemDetailsID = ingredientDetailsID;

                stockOrderDetailTable.InsertOnSubmit(newData);
                stockOrderDetailTable.Context.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return IncreaseIngredientQuantityInStock(ingredientDetailsID, quantity);
        }

        private string IncreaseIngredientQuantityInStock(int ingredientDetailsID, int quantity)
        {
            Table<DAL.IngredientInStockDetail> igrInStockDetailTable = GetIngredientInStockDetailsTable();

            var matchedRes = (from igrInStockDetails in igrInStockDetailTable
                              where igrInStockDetails.ingredientDetailsID == ingredientDetailsID
                              select igrInStockDetails).FirstOrDefault();

            try
            {
                matchedRes.quantity += quantity;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        
            return "";
        }

        public string DecreaseIngredientQuantityInStock(int ingredientDetailsID, int quantity)
        {
            Table<DAL.IngredientInStockDetail> igrInStockDetailTable = GetIngredientInStockDetailsTable();

            var matchedRes = (from igrInStockDetails in igrInStockDetailTable
                              where igrInStockDetails.ingredientDetailsID == ingredientDetailsID
                              select igrInStockDetails).FirstOrDefault();

            try
            {
                matchedRes.quantity -= quantity;
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
        #endregion
    }
}
