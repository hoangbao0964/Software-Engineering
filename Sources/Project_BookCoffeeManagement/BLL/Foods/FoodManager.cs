using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.Foods;
using System.Data.Linq;

namespace Project_BookCoffeeManagement.BLL.Foods
{
    public class FoodManager : Manager
    {
        private IngredientManager ingredientManager;
        private string availableStatus = "Available";

        public FoodManager()
        {
            ingredientManager = new IngredientManager();
        }

        #region Get Table
        private Table<DAL.FoodStatus> GetFoodStatusTable()
        {
            return db.GetTable<DAL.FoodStatus>();
        }

        public Table<DAL.Food> GetFoodTable()
        {
            return db.GetTable<DAL.Food>();
        }
        #endregion

        #region Get Data
        public List<Food> GetMenu()
        {
            Table<DAL.Food> foodTable = GetFoodTable();
            Table<DAL.FoodStatus> foodStatusTable = GetFoodStatusTable();

            var res = from food in foodTable
                      join foodStatus in foodStatusTable on food.foodStatusID equals foodStatus.foodStatusID
                      select new Food
                      {
                          Name = food.name,
                          Description = food.description,
                          Price = food.price,
                          Status = foodStatus.name
                      };

            return res.ToList();
        }

        public List<Food> GetAvailableMenu()
        {
            List<Food> res = GetMenu();
            return res.Where(s => s.Status == availableStatus).ToList();
        } 

        public List<object> SearchFood(string searchPharse1, string type1, string searchPharse2, string type2, string searchPharse3, string type3, string searchConstraint1, string searchConstraint2)
        {
            throw new NotImplementedException();
        }

        internal List<Food> SearchFood(string keyword)
        {
            List<Food> res = GetMenu();
            return Filter(keyword, res);      
        }

        public int GetFoodIDByName(string name)
        {
            Table<DAL.Food> foodTable = GetFoodTable();

            var res = (from fd in foodTable
                       where fd.name == name
                       select fd.foodID).FirstOrDefault();

            return res;
        }

        public List<string> GetFoodStatusList()
        {
            Table<DAL.FoodStatus> fdStatusTable = GetFoodStatusTable();

            var res = (from fdStatus in fdStatusTable
                       select fdStatus.name);

            return res.ToList();
        }

        public int GetFoodStatusIDByName(string status)
        {
            Table<DAL.FoodStatus> fdStatusTable = GetFoodStatusTable();

            var res = (from fdStatus in fdStatusTable
                       where fdStatus.name == status
                       select fdStatus.foodStatusID).FirstOrDefault();

            return res;

        }

        internal List<Food> Filter(string keyword, List<Food> availableFoods)
        {
            double temp = double.MinValue;
            double.TryParse(keyword, out temp);
            return availableFoods.Where(s => s.Name.ToLower().Contains(keyword.ToLower()) || s.Price <= temp).ToList();
        }

        public Food GetFood(int foodID)
        {
            Table<DAL.Food> foodTable = GetFoodTable();
            Table<DAL.FoodStatus> foodStatusTable = GetFoodStatusTable();

            var res = (from food in foodTable
                       join foodStatus in foodStatusTable on food.foodStatusID equals foodStatus.foodStatusID
                       where food.foodID == foodID
                       select new Food
                       {
                           Name = food.name,
                           Description = food.description,
                           Price = food.price,
                           Status = foodStatus.name
                       }).FirstOrDefault();

            return res;
        }
        #endregion

        #region Update Data
        public string AddOrUpdateMenuItem(Food newFood)
        {
            Table<DAL.Food> foodTable = GetFoodTable();
            var matchedFood = (from fd in foodTable
                               where fd.name == newFood.Name
                               select fd).FirstOrDefault();

            if (matchedFood == null)    // Add
            {
                try
                {
                    DAL.Food addData = new DAL.Food();
                    addData.name = newFood.Name;
                    addData.description = newFood.Description;
                    addData.price = newFood.Price;
                    addData.foodStatusID = GetFoodStatusIDByName(newFood.Status);

                    foodTable.InsertOnSubmit(addData);
                    foodTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedFood != null)   // Update
            {
                try
                {
                    matchedFood.name = newFood.Name;
                    matchedFood.description = newFood.Description;
                    matchedFood.price = newFood.Price;
                    matchedFood.foodStatusID = GetFoodStatusIDByName(newFood.Status);

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            string res = ingredientManager.AddOrUpdateIngredientInFood(newFood);
            if (res != "")
                return res;
            return "";
        }

        public string DeleteMenuItems(string name)
        {
            int foodID = GetFoodIDByName(name);

            // Delete IngredientsInFood table
            List<int> deleteIngredientIDs = ingredientManager.GetIngredientIDList(foodID);
            string res = ingredientManager.DeleteIngredientInFood(foodID);
            if (res != "")
                return res;

            // Delete Food table
            Table<DAL.Food> fdTable = GetFoodTable();

            var matchedFood = (from fd in fdTable
                               where fd.foodID == foodID
                               select fd).FirstOrDefault();

            try
            {
                fdTable.DeleteOnSubmit(matchedFood);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            foreach (int ingredientID in deleteIngredientIDs)
            {
                res = ingredientManager.DeleteIngredients(ingredientID);
                if (res != "")
                    return res;
            }

            return "";
        }
        #endregion




    }
}
