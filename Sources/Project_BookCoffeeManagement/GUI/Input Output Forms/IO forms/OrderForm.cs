using Project_BookCoffeeManagement.BLL.Orders;
using Project_BookCoffeeManagement.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_BookCoffeeManagement.Entities.Books;
using Project_BookCoffeeManagement.Entities.Foods;
using Project_BookCoffeeManagement.BLL;
using Project_BookCoffeeManagement.BLL.Books;
using Project_BookCoffeeManagement.BLL.Foods;
using Project_BookCoffeeManagement.BLL.People.Customers;

namespace Project_BookCoffeeManagement.GUI.Input_Output_Forms
{
    public partial class OrderForm : FormTemplate
    {
        private string mode;
        private OrderManager manager;
        private Order oldOrder;

        public OrderForm(string cmd)
        {
            ThreadManager.DisplayLoadingScreen();
            Load(cmd);
            ThreadManager.CloseLoadingScreen();           
        }

        public OrderForm(string cmd, Order order)
        {
            ThreadManager.DisplayLoadingScreen();
            Load(cmd, order);
            ThreadManager.CloseLoadingScreen();
        }

        private void Load(string cmd)
        {
            InitializeComponent();
            manager = new OrderManager();
            AddRecommendData();
            switch (cmd)
            {
                case "Create": LoadCreateForm(); break;
                case "Update": LoadUpdateForm(); break;
                case "Cancel": LoadCancelForm(); break;
                case "View": LoadViewForm(); break;
            }
            LoadTheme();
            LoadLanguage();
            bunifuCustomTextbox__list_selectedBooks.Tag = null;
            bunifuCustomTextbox__list_selectedDishesDrinks.Tag = null;
        }

        private void AddRecommendData()
        {
            bunifuDropdown_Status.Items = manager.GetOrderStatusList().ToArray();
            bunifuCustomTextbox_CashierName.Text = ParameterManager.GetCurrentStaff().FullName;
            bunifuCustomTextbox_CurentTime.Text = DateTime.Now.ToString();
        }

        private void Load(string cmd, Order order)
        {
            oldOrder = order;
            Load(cmd);
            DisplayOrderToScreen();
        }

        private void DisplayOrderToScreen()
        {      
            bunifuCustomTextbox_VIP.Text = manager.GetVipIDInOrder(oldOrder.OrderID);
            if (bunifuCustomTextbox_VIP.Text != "")
                bunifuCheckbox_VIPChecker.Checked = true;
            List<Food> food = manager.GetFoodListFromOrder(oldOrder.OrderID);
            DisplayFoodToScreen(food);

            List<Book> book = manager.GetBookListFromBookCalledOrder(oldOrder.OrderID);
            DisplayBooksToScreen(book);

            ReturnBookOrder returnData = manager.GetBookReturnOrderInfo(oldOrder.OrderID);
            if (returnData != null)
            {
                DisplayReturnOrderInfo(returnData);
            }

            DisplayBasicInformationToScreen();
        }

        private void DisplayReturnOrderInfo(ReturnBookOrder returnData)
        {
            bunifuCheckbox_BorrowedBookCode.Checked = true;
            bunifuCustomTextbox_BorrowedBookCode.Text = returnData.BorrowOrderID;

            bunifuCustomTextbox_BorrowedBookInfo.Text = "";
            string printres = "";
            printres += "Late days: " + returnData.LateDays.ToString() +Environment.NewLine;
            List<Book> data = null;
            if (mode == "add")
                data = manager.GetBookListFromBookCalledOrder(returnData.BorrowOrderID);
            else
                data = manager.GetBookListFromBookReturnedOrder(oldOrder.OrderID);

            foreach (Book bk in data)
            {
                printres += "Book ID: " + bk.BookID + " (" + bk.BookName + ")" + Environment.NewLine;
            }
            bunifuCustomTextbox_BorrowedBookInfo.Text = printres;
            returnData.Books = data;
            bunifuCustomTextbox_BorrowedBookInfo.Tag = returnData;
        }

        private void DisplayBasicInformationToScreen()
        {
            bunifuCustomTextbox_BillCode.Text = oldOrder.OrderID;
            bunifuCustomTextbox_CurentTime.Text = oldOrder.DateCreated.ToString();
            bunifuCustomTextbox_Priority.Text = oldOrder.PriorityNumber.ToString();
            bunifuMetroTextbox_GrandTotal.Text = oldOrder.TotalPayment.ToString();
            bunifuMetroTextbox_ChangeGiven.Text = oldOrder.ChargedMoney.ToString();
            bunifuMetroTextbox_AmountTendered.Text = (oldOrder.TotalPayment - oldOrder.ChargedMoney).ToString();
            bunifuDropdown_Status.selectedIndex = Array.IndexOf(bunifuDropdown_Status.Items, oldOrder.Status); 
        }

        private void DisplayFoodToScreen(List<Food> orderItems)
        {
            bunifuCustomTextbox__list_selectedDishesDrinks.Text = "";
            string printres = "";
            foreach (Food fd in orderItems)
            {
                printres += fd.Name + " x" + fd.Quantity + Environment.NewLine;
                UpdateTotalPayment(double.Parse(fd.Price.ToString()) * fd.Quantity);
            }
            bunifuCustomTextbox__list_selectedDishesDrinks.Text = printres;
        }     

        private void DisplayBooksToScreen(List<Book> books)
        {
            bunifuCustomTextbox__list_selectedBooks.Text = "";
            string printres = "";
            foreach (Book bk in books)
            {
                printres += "Book ID: " + bk.BookID + " (" + bk.BookName + ")" + Environment.NewLine;
                UpdateTotalPayment(double.Parse(bk.Price.ToString()) * ParameterManager.GetBookBorrowFeePercentage() / 100);
            }
            bunifuCustomTextbox__list_selectedBooks.Text = printres;
        }     

        private void LoadCancelForm()
        {
            bunifuTileButton_Execute.LabelText = "Cancel order";
            mode = "delete";
            DisableFields();
        }

        private void DisableFields()
        {
            bunifuImageButton_ChooseBook.Enabled = false;
            bunifuImageButton_ChooseDish_Drink.Enabled = false;
            bunifuCustomTextbox_Priority.ReadOnly = true;
            bunifuCustomTextbox_Voucher.ReadOnly = true;
            if (mode != "update")
                bunifuDropdown_Status.Items = new string[] { oldOrder.Status };
            bunifuDropdown_Status.selectedIndex = 0;
            bunifuMetroTextbox_AmountTendered.Enabled = false;
            bunifuCustomTextbox_VIP.ReadOnly = true;
            bunifuCustomTextbox_BorrowedBookCode.ReadOnly = true;
            bunifuCheckbox_BorrowedBookCode.Enabled = false;
            bunifuCheckbox_VIPChecker.Enabled = false;
            bunifuCheckbox_Voucher.Enabled = false;
        }

        private void LoadUpdateForm()
        {
            bunifuTileButton_Execute.LabelText = "Update order";
            mode = "update";
            DisableFields();
        }

        private void LoadCreateForm()
        {
            bunifuTileButton_Execute.LabelText = "Create order";
            mode = "add";
        }

        private void LoadViewForm()
        {
            bunifuTileButton_Execute.LabelText = "OK";
            mode = "view";
            DisableFields();
        }

        private void bunifuImageButton_ChooseDish_Drink_Click(object sender, EventArgs e)
        {
            Select_Dish_Drink_Form CallForm = new Select_Dish_Drink_Form();
            DialogResult res = CallForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                bunifuCustomTextbox__list_selectedDishesDrinks.Tag = CallForm.selectedFoods;
                bunifuMetroTextbox_GrandTotal.Text = "0";
                DisplayFoodToScreen(CallForm.selectedFoods);

                bunifuImageButton_ChooseBook.Enabled = false;
                bunifuCheckbox_BorrowedBookCode.Enabled = false;
            }
        }

        private void bunifuImageButton_ChooseBook_Click(object sender, EventArgs e)
        {
            Select_Book_Form CallForm = new Select_Book_Form();
            DialogResult res = CallForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                bunifuCustomTextbox__list_selectedBooks.Tag = CallForm.selectedBooks;
                bunifuMetroTextbox_GrandTotal.Text = "0";
                DisplayBooksToScreen(CallForm.selectedBooks);

                bunifuImageButton_ChooseDish_Drink.Enabled = false;
                bunifuCheckbox_BorrowedBookCode.Enabled = false;
            }
        }

        private void bunifuTileButton_Execute_Click(object sender, EventArgs e)
        {
            string err = "";
            if (mode == "view")
            {
                this.Close();
                return;
            }
            if (mode == "delete")
            {
                ThreadManager.DisplayLoadingScreen();
                err = manager.DeleteOrder(bunifuCustomTextbox_BillCode.Text);
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "Cancel order successfully", "Cancel order failed");              
                return;
            }
            ThreadManager.DisplayLoadingScreen();
            if (mode == "update")
            {
                Order order = new Order();
                order.OrderID = bunifuCustomTextbox_BillCode.Text;
                order.DateCreated = Convert.ToDateTime(bunifuCustomTextbox_CurentTime.Text);
                int temp = 0;
                int.TryParse(bunifuCustomTextbox_Priority.Text, out temp);
                order.PriorityNumber = temp;
                order.TotalPayment = double.Parse(bunifuMetroTextbox_GrandTotal.Text);
                order.ChargedMoney = double.Parse(bunifuMetroTextbox_ChangeGiven.Text);
                order.Status = bunifuDropdown_Status.selectedValue;
                if (bunifuCheckbox_VIPChecker.Checked)
                    order.SetVipID(bunifuCustomTextbox_VIP.Text);
                else
                    order.SetVipID("");

                err = manager.AddOrUpdateOrderBasicInfo(order, order.OrderID);
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "Update order successfully", "Update order failed");
                return;
            }
            if (bunifuImageButton_ChooseDish_Drink.Enabled == true)
            {
                DishOrder order = new DishOrder();
                try
                {
                    order.OrderID = bunifuCustomTextbox_BillCode.Text;
                    order.DateCreated = Convert.ToDateTime(bunifuCustomTextbox_CurentTime.Text);
                    int temp = 0;
                    int.TryParse(bunifuCustomTextbox_Priority.Text, out temp);
                    order.PriorityNumber = temp;
                    order.TotalPayment = double.Parse(bunifuMetroTextbox_GrandTotal.Text);
                    order.ChargedMoney = double.Parse(bunifuMetroTextbox_ChangeGiven.Text);
                    order.Status = bunifuDropdown_Status.selectedValue;
                    if (bunifuCheckbox_VIPChecker.Checked)
                        order.SetVipID(bunifuCustomTextbox_VIP.Text);
                    else
                        order.SetVipID("");
                    order.OrderItems = (List<Food>)bunifuCustomTextbox__list_selectedDishesDrinks.Tag;
                }
                catch (Exception ex)
                {
                    ThreadManager.CloseLoadingScreen();
                    ErrorManager.MessageDisplay(ex.Message, "", "Extract data falied");                
                    return;
                }
                err = manager.AddOrUpdateDishOrder(order);
                ThreadManager.CloseLoadingScreen();
                ErrorManager.MessageDisplay(err, "Add dish order successfully", "Add dish order failed");      
            }
            else if (bunifuImageButton_ChooseBook.Enabled == true)
            {
                BorrowBookOrder order = new BorrowBookOrder();
                try
                {
                    order.OrderID = bunifuCustomTextbox_BillCode.Text;
                    order.DateCreated = Convert.ToDateTime(bunifuCustomTextbox_CurentTime.Text);
                    int temp = 0;
                    int.TryParse(bunifuCustomTextbox_Priority.Text, out temp);
                    order.PriorityNumber = temp;
                    order.TotalPayment = double.Parse(bunifuMetroTextbox_GrandTotal.Text);
                    order.ChargedMoney = double.Parse(bunifuMetroTextbox_ChangeGiven.Text);
                    order.Status = bunifuDropdown_Status.selectedValue;
                    if (bunifuCheckbox_VIPChecker.Checked)
                        order.SetVipID(bunifuCustomTextbox_VIP.Text);
                    else
                    {
                        ThreadManager.CloseLoadingScreen();
                        ErrorManager.MessageDisplay("No VIP ID input", "", "This feature require a VIP ID to be used");
                        return;
                    }
                    order.Books = (List<Book>)bunifuCustomTextbox__list_selectedBooks.Tag;

                    err = manager.AddOrUpdateBorrowBookOrder(order);
                    ErrorManager.MessageDisplay(err, "Add book borrow order successfully", "Add book borrow order failed");
                }
                catch (Exception ex)
                {
                    ErrorManager.MessageDisplay(ex.Message, "", "Extract data falied");
                    ThreadManager.CloseLoadingScreen();
                    return;
                }
                ThreadManager.CloseLoadingScreen();
            }
            else if (bunifuCheckbox_BorrowedBookCode.Checked == true)
            {
                ReturnBookOrder order = (ReturnBookOrder)bunifuCustomTextbox_BorrowedBookInfo.Tag;
                try
                {
                    order.OrderID = bunifuCustomTextbox_BillCode.Text;
                    order.DateCreated = Convert.ToDateTime(bunifuCustomTextbox_CurentTime.Text);
                    int temp = 0;
                    int.TryParse(bunifuCustomTextbox_Priority.Text, out temp);
                    order.PriorityNumber = temp;
                    order.TotalPayment = double.Parse(bunifuMetroTextbox_GrandTotal.Text);
                    order.ChargedMoney = double.Parse(bunifuMetroTextbox_ChangeGiven.Text);
                    order.Status = bunifuDropdown_Status.selectedValue;
                    if (bunifuCheckbox_VIPChecker.Checked)
                        order.SetVipID(bunifuCustomTextbox_VIP.Text);

                    err = manager.AddOrUpdateReturnBookOrder(order);
                    ThreadManager.CloseLoadingScreen();
                    ErrorManager.MessageDisplay(err, "Add book return order successfully", "Add book return order failed");
                }
                catch (Exception ex)
                {
                    ThreadManager.CloseLoadingScreen();
                    ErrorManager.MessageDisplay(ex.Message, "", "Extract data falied");
                    return;
                }
            }
            if (err == "")
                this.Close();

        }

        private void bunifuMetroTextbox_AmountTendered_OnValueChanged(object sender, EventArgs e)
        {
            UpdateChargedMoney();
        }

        private void UpdateChargedMoney()
        {
            try
            {
                double total = double.Parse(bunifuMetroTextbox_GrandTotal.Text);
                double given = double.Parse(bunifuMetroTextbox_AmountTendered.Text);
                bunifuMetroTextbox_ChangeGiven.Text = (total - given).ToString();
            }
            catch
            {

            }
        }

        private void UpdateTotalPayment(double price)
        {
            double totalPayment = 0;
            double.TryParse(bunifuMetroTextbox_GrandTotal.Text, out totalPayment);
            totalPayment += price;
            if (bunifuCheckbox_VIPChecker.Checked == true)
                totalPayment -= totalPayment * ParameterManager.GetVIPDiscount() / 100;
            bunifuMetroTextbox_GrandTotal.Text = totalPayment.ToString();
            UpdateChargedMoney();
        }

        private void bunifuCheckbox_VIPChecker_Click(object sender, EventArgs e)
        {         
            VIPManager vipmanager = new VIPManager();
            if (!vipmanager.IsVIP(bunifuCustomTextbox_VIP.Text))
            {
                ErrorManager.MessageDisplay("Incorrect VIP ID", "", "Incorrect info. Plese recheck.");
                bunifuCheckbox_VIPChecker.Checked = false;
            }
            else
            {
                UpdateTotalPayment(0);
                bunifuCheckbox_VIPChecker.Enabled = false;
                bunifuCustomTextbox_VIP.Enabled = false;
            }
        }

        private void bunifuCheckbox_BorrowedBookCode_Click(object sender, EventArgs e)
        {
            if (manager.IsCorrectBookBorrowOrder(bunifuCustomTextbox_BorrowedBookCode.Text))
            {
                Order borrowOrderInfo = manager.GetOrderFromID(bunifuCustomTextbox_BorrowedBookCode.Text);
                ReturnBookOrder returnBookOrder = new ReturnBookOrder();
                int lateDays = DateTime.Now.CompareTo(borrowOrderInfo.DateCreated.Value.Date) - ParameterManager.GetMaxBookBorrowDays();
                returnBookOrder.LateDays = (lateDays < 0) ? 0 : lateDays;
                returnBookOrder.BorrowOrderID = bunifuCustomTextbox_BorrowedBookCode.Text;
                DisplayReturnOrderInfo(returnBookOrder);

                bunifuMetroTextbox_GrandTotal.Text = "0";
                double payment = double.Parse(borrowOrderInfo.TotalPayment.ToString());
                UpdateTotalPayment(-payment);

                if (lateDays > 0)
                {
                    if (payment < 300000)
                        UpdateTotalPayment(lateDays * ParameterManager.getLateFee(1));
                    else if (payment < 700000)
                        UpdateTotalPayment(lateDays * ParameterManager.getLateFee(2));
                    else
                        UpdateTotalPayment(lateDays * ParameterManager.getLateFee(3));
                }

                bunifuCustomTextbox_VIP.Text = manager.GetVipIDInOrder(borrowOrderInfo.OrderID);
                bunifuCheckbox_VIPChecker.Checked = true;
                bunifuCheckbox_VIPChecker.Enabled = false;
                bunifuCustomTextbox_VIP.Enabled = false;

                bunifuImageButton_ChooseBook.Enabled = false;
                bunifuImageButton_ChooseDish_Drink.Enabled = false;
                bunifuCheckbox_BorrowedBookCode.Enabled = false;
            }
            else
            {
                ErrorManager.MessageDisplay("Incorrect book borrow order ID", "", "Incorrect info. Plese recheck.");
                bunifuCheckbox_BorrowedBookCode.Checked = false;
            }

        }

        #region Load Theme & Language
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            bunifuCustomLabel_HeaderName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_HeaderName.Tag.ToString());
            bunifuCustomLabel_BillCode.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_BillCode.Name);
            bunifuCustomLabel_DateCreated.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_DateCreated.Name);
            bunifuCustomLabel_Dishes_Drinks_List.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Dishes_Drinks_List.Name);
            bunifuCustomLabel_Books_List.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Books_List.Name);
            bunifuCustomLabel_Priority.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Priority.Name);
            bunifuCustomLabel_Voucher.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Voucher.Name);
            bunifuCustomLabel_OldSlip.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_OldSlip.Name);
            bunifuCustomLabel_Status.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_Status.Name);
            bunifuCustomLabel_CashierName.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_CashierName.Name);
            bunifuCustomLabel_GrandTotal.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_GrandTotal.Name);
            bunifuCustomLabel_AmountTendered.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_AmountTendered.Name);
            bunifuCustomLabel_ChangeGiven.Text = LanguageSwitch.ChangeName(bunifuCustomLabel_ChangeGiven.Name);
        }

        private void LoadTheme()
        {
            this.BackColor = ThemeManager.BackgroundColor;
            //Header
            panel_Header.BackColor = ThemeManager.NormalColor;
            bunifuCustomLabel_HeaderName.ForeColor = ThemeManager.ButtonForeColor;
            //Label
            bunifuCustomLabel_BillCode.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_DateCreated.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Dishes_Drinks_List.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Books_List.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Priority.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_VIP.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Voucher.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_OldSlip.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_Status.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_CashierName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_GrandTotal.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_AmountTendered.ForeColor = ThemeManager.ForeColor;
            bunifuCustomLabel_ChangeGiven.ForeColor = ThemeManager.ForeColor;
            //Textbox + Combobox
            bunifuCustomTextbox_BillCode.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_BillCode.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_CurentTime.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_CurentTime.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox__list_selectedDishesDrinks.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox__list_selectedDishesDrinks.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox__list_selectedBooks.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox__list_selectedBooks.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Priority.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Priority.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_VIP.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_VIP.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_Voucher.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_Voucher.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_BorrowedBookCode.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_BorrowedBookCode.ForeColor = ThemeManager.ForeColor;
            bunifuDropdown_Status.NomalColor = ThemeManager.BackgroundColor;
            bunifuDropdown_Status.onHoverColor = ThemeManager.FocusColor;
            bunifuDropdown_Status.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_CashierName.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_CashierName.ForeColor = ThemeManager.ForeColor;
            bunifuCustomTextbox_BorrowedBookInfo.BackColor = ThemeManager.BackgroundColor;
            bunifuCustomTextbox_BorrowedBookInfo.ForeColor = ThemeManager.ForeColor;
            bunifuMetroTextbox_GrandTotal.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_GrandTotal.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_GrandTotal.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_GrandTotal.BorderColorMouseHover = ThemeManager.MenuColor;
            bunifuMetroTextbox_GrandTotal.ForeColor = ThemeManager.ForeColor;
            bunifuMetroTextbox_AmountTendered.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_AmountTendered.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_AmountTendered.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_AmountTendered.BorderColorMouseHover = ThemeManager.MenuColor;
            bunifuMetroTextbox_AmountTendered.ForeColor = ThemeManager.ForeColor;
            bunifuMetroTextbox_ChangeGiven.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_ChangeGiven.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_ChangeGiven.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_ChangeGiven.BorderColorMouseHover = ThemeManager.MenuColor;
            bunifuMetroTextbox_ChangeGiven.ForeColor = ThemeManager.ForeColor;         
            //Button color
            bunifuTileButton_Execute.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_Execute.color = ThemeManager.NormalColor;
            bunifuTileButton_Execute.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_Execute.ForeColor = ThemeManager.ButtonForeColor;
            bunifuImageButton_ChooseDish_Drink.BackColor = ThemeManager.BackgroundColor;
            bunifuImageButton_ChooseBook.BackColor = ThemeManager.BackgroundColor;
            //Checkbox color
            bunifuCheckbox_Voucher.BackColor = ThemeManager.NormalColor;
            bunifuCheckbox_Voucher.CheckedOnColor = ThemeManager.NormalColor;
            bunifuCheckbox_Voucher.ForeColor = ThemeManager.ButtonForeColor;
            bunifuCheckbox_VIPChecker.BackColor = ThemeManager.NormalColor;
            bunifuCheckbox_VIPChecker.CheckedOnColor = ThemeManager.NormalColor;
            bunifuCheckbox_VIPChecker.ForeColor = ThemeManager.ButtonForeColor;
            bunifuCheckbox_BorrowedBookCode.BackColor = ThemeManager.NormalColor;
            bunifuCheckbox_BorrowedBookCode.CheckedOnColor = ThemeManager.NormalColor;
            bunifuCheckbox_BorrowedBookCode.ForeColor = ThemeManager.ButtonForeColor;
        }
        #endregion
    }
}
