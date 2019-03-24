using Project_BookCoffeeManagement.Entities.Foods;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.BLL.Foods
{
    public class IngredientManager : Manager
    {
        #region Get Table
        public Table<DAL.Ingredient> GetIngredientsTable()
        {
            return db.GetTable<DAL.Ingredient>();
        }

        public Table<DAL.IngredientDetail> GetIngredientDetailTable()
        {
            return db.GetTable<DAL.IngredientDetail>();
        }

        public Table<DAL.IngredientsInFood> GetIngredientsInFoodTable()
        {
            return db.GetTable<DAL.IngredientsInFood>();
        }

        #endregion

        #region Get Data
        public List<IngredientDetails> GetIngredientDetails()
        {
            Table<DAL.IngredientDetail> ingredientDetailsTable = GetIngredientDetailTable();

            var res = (from ingredientDetails in ingredientDetailsTable
                       select new IngredientDetails
                       {
                           Name = ingredientDetails.name,
                           Description = ingredientDetails.description
                       });
            
            return res.ToList();
        }

        public List<Ingredient> GetFoodIngredientList(string foodName)
        {
            FoodManager foodManager = new FoodManager();
            Table<DAL.Food> foodTable = foodManager.GetFoodTable();
            Table<DAL.IngredientsInFood> ingredientsInFoodTable = GetIngredientsInFoodTable();
            Table<DAL.Ingredient> ingredientTable = GetIngredientsTable();
            Table<DAL.IngredientDetail> ingredientDetailTable = GetIngredientDetailTable();

            var res = (from food in foodTable
                       join ingreInFood in ingredientsInFoodTable on food.foodID equals ingreInFood.foodID
                       join ingre in ingredientTable on ingreInFood.ingredientID equals ingre.ingredientID
                       join ingreDetails in ingredientDetailTable on ingre.ingredientDetailsID equals ingreDetails.ingredientDetailsID
                       where food.name == foodName
                       select new Ingredient
                       {
                           Name = ingreDetails.name,
                           Description = ingreDetails.description,
                           Quantity = ingre.quantity
                       });

            return res.ToList();
        }

        public List<int> GetIngredientIDList(int foodID)
        {
            Table<DAL.IngredientsInFood> igrInFoodTable = GetIngredientsInFoodTable();
            List<int> res = (from igrInFood in igrInFoodTable
                             where igrInFood.foodID == foodID
                             select igrInFood.ingredientID).ToList();
            return res;
        }

        public int GetIngredientDetailsID(string name)
        {
            Table<DAL.IngredientDetail> igrDetailsTable = GetIngredientDetailTable();

            var res = (from igrDetails in igrDetailsTable
                       where name == igrDetails.name
                       select igrDetails.ingredientDetailsID).FirstOrDefault();

            return res;
        }

        internal List<IngredientDetails> Filter(string keyword, List<IngredientDetails> ingredientDetails)
        {
            return ingredientDetails.Where(s => s.Name.ToLower().Contains(keyword.ToLower())).ToList();
        }
        #endregion

        #region Update Data
        public string AddOrUpdateIngredientInFood(Food newFood)
        {
            FoodManager foodManager = new FoodManager();
            int foodID = foodManager.GetFoodIDByName(newFood.Name);
            string res = DeleteIngredientInFood(foodID);
            if (res != "")
                return res;
            if (newFood.GetIngredients() == null)
                return "";
            foreach (Ingredient igr in newFood.GetIngredients())
            {
                res = AddOrUpdateIngredientDetails(igr.GetIngredientDetails());
                if (res != "")
                    return res;
                try
                {
                    int ingredientDetailsID = GetIngredientDetailsID(igr.Name);

                    DAL.Ingredient newIgredient = new DAL.Ingredient();
                    newIgredient.ingredientDetailsID = ingredientDetailsID;
                    newIgredient.quantity = igr.Quantity;
                    Table<DAL.Ingredient> igrTable = GetIngredientsTable();
                    igrTable.InsertOnSubmit(newIgredient);
                    igrTable.Context.SubmitChanges();

                    DAL.IngredientsInFood newIgrInFood = new DAL.IngredientsInFood();
                    newIgrInFood.foodID = foodID;
                    newIgrInFood.ingredientID = newIgredient.ingredientID;
                    Table<DAL.IngredientsInFood> igrInFoodTable = GetIngredientsInFoodTable();
                    igrInFoodTable.InsertOnSubmit(newIgrInFood);
                    igrInFoodTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        public string DeleteIngredientInFood(int foodID)
        {
            Table<DAL.IngredientsInFood> igrInFoodTable = this.GetIngredientsInFoodTable();

            do
            {
                var matchedData = (from igrInFood in igrInFoodTable
                                   where igrInFood.foodID == foodID
                                   select igrInFood).FirstOrDefault();
                if (matchedData == null)
                    break;
                try
                {
                    igrInFoodTable.DeleteOnSubmit(matchedData);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }               
            }
            while (true);
            return "";
        }

        public string AddOrUpdateIngredientDetails(IngredientDetails ingredientDetails)
        {
            Table<DAL.IngredientDetail> igrDetailsTable = GetIngredientDetailTable();

            var matchedDetails = (from igrDetails in igrDetailsTable
                                  where igrDetails.name == ingredientDetails.Name
                                  select igrDetails).FirstOrDefault();

            if (matchedDetails == null)     // Add
            {
                try
                {
                    DAL.IngredientDetail newData = new DAL.IngredientDetail();
                    newData.name = ingredientDetails.Name;
                    newData.description = ingredientDetails.Description;

                    igrDetailsTable.InsertOnSubmit(newData);
                    igrDetailsTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedDetails != null)
            {
                try
                {
                    matchedDetails.name = ingredientDetails.Name;
                    matchedDetails.description = ingredientDetails.Description;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        public string DeleteIngredients(int ingredientID)
        {
            Table<DAL.Ingredient> igrTable = GetIngredientsTable();
            var matchedData = (from igr in igrTable
                               where igr.ingredientID == ingredientID
                               select igr).FirstOrDefault();

            try
            {
                igrTable.DeleteOnSubmit(matchedData);
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
