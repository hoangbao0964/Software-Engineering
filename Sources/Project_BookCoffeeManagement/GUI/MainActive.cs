using Project_BookCoffeeManagement.BLL;
using Project_BookCoffeeManagement.BLL.Books;
using Project_BookCoffeeManagement.BLL.Contact;
using Project_BookCoffeeManagement.BLL.Foods;
using Project_BookCoffeeManagement.BLL.Orders;
using Project_BookCoffeeManagement.BLL.People.Customers;
using Project_BookCoffeeManagement.BLL.People.Staffs;
using Project_BookCoffeeManagement.BLL.Stocks;
using Project_BookCoffeeManagement.Entities.Books;
using Project_BookCoffeeManagement.Entities.Foods;
using Project_BookCoffeeManagement.Entities.Orders;
using Project_BookCoffeeManagement.Entities.People.Customers;
using Project_BookCoffeeManagement.Entities.People.Staffs;
using Project_BookCoffeeManagement.Entities.Stocks;
using Project_BookCoffeeManagement.GUI.Input_Output_Forms;
using Project_BookCoffeeManagement.GUI.Input_Output_Forms.IO_forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project_BookCoffeeManagement
{
    public partial class MainActive : Form
    {
        #region Attributes
        private OrderManager orderManager;
        private FoodManager foodManager;
        private BookManager bookManager;
        private VIPManager vipManager;
        private StaffManager staffManager;
        private StockManager stockManager;
        private ContactManager contactManager;
        private Staff staffInfo;
        #endregion

        #region Initialize
        private void InitData(string staffID)
        {
            ThemeManager.LoadThemeFromFile();
            LoadTheme();
            LoadLanguage();

            orderManager = new OrderManager();
            foodManager = new FoodManager();
            bookManager = new BookManager();
            vipManager = new VIPManager();
            staffManager = new StaffManager();
            stockManager = new StockManager();
            contactManager = new ContactManager();

            InitStaffInfo(staffID);
            ParameterManager.SetStaffInfo(staffInfo);
            UpdateProcessingOrder();
            UpdateBooks();
            UpdateVIPs();
            UpdateMenu();
            UpdateListOfStaff();
            UpdateStocks();
            UpdateTrasactionHistory();
            UpdateWishlist();
            LoadReport();

            textBox_LoggedInUsername.Text = staffInfo.FullName + Environment.NewLine + "(" + staffInfo.CurrentPosition + ")";
        }

        public MainActive(string staffID)
        {
            InitializeComponent();
            InitData(staffID);
            ThreadManager.CloseLoadingScreen();     
        }

        private void InitStaffInfo(string staffID)
        {  
            Staff newStaff = staffManager.GetStaff(staffID);
            
            string staffPosition = newStaff.CurrentPosition;
            if (staffPosition == "Cashier")
            {
                Cashier typecastStaff = new Cashier(newStaff.Address, newStaff.CivilianID, newStaff.ContactNumber, newStaff.DateOfBirth, newStaff.FullName, newStaff.Gender, newStaff.CurrentPosition, newStaff.CurrentSalaryPerHour, newStaff.StaffID, newStaff.StaffStatus, newStaff.WorkingHours, "", "", newStaff.Description, newStaff.Occupation);
                staffInfo = typecastStaff;
            }
            else if (staffPosition == "Manger")
            {
                Entities.People.Staffs.Manager typecastStaff = new Entities.People.Staffs.Manager(newStaff.Address, newStaff.CivilianID, newStaff.ContactNumber, newStaff.DateOfBirth, newStaff.FullName, newStaff.Gender, newStaff.CurrentPosition, newStaff.CurrentSalaryPerHour, newStaff.StaffID, newStaff.StaffStatus, newStaff.WorkingHours, "", "", newStaff.Description, newStaff.Occupation);
                staffInfo = typecastStaff;
            }
            else if (staffPosition == "Keeper")
            {
                WarehouseManager typecastStaff = new WarehouseManager(newStaff.Address, newStaff.CivilianID, newStaff.ContactNumber, newStaff.DateOfBirth, newStaff.FullName, newStaff.Gender, newStaff.CurrentPosition, newStaff.CurrentSalaryPerHour, newStaff.StaffID, newStaff.StaffStatus, newStaff.WorkingHours, "", "", newStaff.Description, newStaff.Occupation);
                staffInfo = typecastStaff;
            }
            else if (staffPosition == "Staff")
            {
                RegularStaff typecastStaff = new RegularStaff(newStaff.Address, newStaff.CivilianID, newStaff.ContactNumber, newStaff.DateOfBirth, newStaff.FullName, newStaff.Gender, newStaff.CurrentPosition, newStaff.CurrentSalaryPerHour, newStaff.StaffID, newStaff.StaffStatus, newStaff.WorkingHours, "", "", newStaff.Description, newStaff.Occupation);
                staffInfo = typecastStaff;
            }
            else
                staffInfo = null;
            
            //staffInfo = newStaff;
        }

        private void bunifuImageButton_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ChangeTab(string tabName)
        {
            ThreadManager.DisplayLoadingScreen();
            int newTabIndex = -1;
            switch(tabName)
            {
                case "Order":
                    newTabIndex = 0;
                    UpdateProcessingOrder();
                    break;
                case "Menu":
                    newTabIndex = 1;
                    UpdateMenu();
                    break;
                case "Book":
                    newTabIndex = 2;
                    UpdateBooks();
                    break;
                case "VIP":
                    newTabIndex = 3;
                    UpdateVIPs();
                    break;
                case "Staff":
                    newTabIndex = 4;
                    UpdateListOfStaff();
                    break;
                case "Stock":
                    newTabIndex = 5;
                    UpdateStocks();
                    break;
                case "Transaction history":
                    newTabIndex = 6;
                    UpdateTrasactionHistory();
                    break;
                case "Contact":
                    newTabIndex = 7;
                    break;
                case "Wishlist":
                    newTabIndex = 8;
                    UpdateWishlist();
                    break;
                case "Report":
                    newTabIndex = 9;
                    LoadReport();
                    break;
            }

            tabControl_ActiveForm.SelectedIndex = newTabIndex;
            ThreadManager.CloseLoadingScreen();
        }

        private void UpdateProcessingOrder()
        {
            dataGridView_DisplayOrder.DataSource = orderManager.GetProcessingOrder();
        }

        private void UpdateMenu()
        {
            dataGridView_DisplayMenu.DataSource = foodManager.GetMenu();
        }

        private void UpdateBooks()
        {
            dataGridView_DisplayBook.DataSource = bookManager.GetBooks();
        }

        private void UpdateWishlist()
        {
            dataGridView_DisplayWishlist.DataSource = bookManager.GetBooksInWishlist();
        }

        private void UpdateVIPs()
        {
            dataGridView_DisplayVIP.DataSource = vipManager.GetVIPs();
        }

        private void UpdateListOfStaff()
        {   if (staffInfo.CanViewAllStaff())
                dataGridView_DisplayStaff.DataSource = staffManager.GetStaffs();
            else
            {
                InitStaffInfo(staffInfo.StaffID);
                List<Staff> currentSelfStaffList = new List<Staff>();
                currentSelfStaffList.Add(staffInfo);
                dataGridView_DisplayStaff.DataSource = currentSelfStaffList;
            }
        }

        private void UpdateStocks()
        {
            dataGridView_DisplayStock.DataSource = stockManager.GetStockItems();
        }

        private void UpdateTrasactionHistory()
        {
            dataGridView_DisplayHistory.DataSource = orderManager.GetTransactionHistory();
        }

        private void LoadReport()
        {
            // TODO: This line of code loads data into the 'Book_Coffee_DBDataSet.View_TotalIncome' table. You can move, or remove it, as needed.
            this.view_TotalIncomeTableAdapter.Fill(this.Book_Coffee_DBDataSet.View_TotalIncome);
            // TODO: This line of code loads data into the 'Book_Coffee_DBDataSet.View_Salaries' table. You can move, or remove it, as needed.
            this.View_SalariesTableAdapter.Fill(this.Book_Coffee_DBDataSet.View_Salaries);
            this.reportViewer1.RefreshReport();
        }

        private void DisplayContact()
        {
            // Display data & set tag
            throw new NotImplementedException();
        }
        #endregion

        #region Handling sidemenu buttons
        private void bunifuFlatButton_OpenFeature_Order_Click(object sender, EventArgs e)
        {
            ChangeTab("Order");
        }

        private void bunifuFlatButton_OpenFeature_Menu_Click(object sender, EventArgs e)
        {
            ChangeTab("Menu");
        }

        private void bunifuFlatButton_OpenFeature_Book_Click(object sender, EventArgs e)
        {
            ChangeTab("Book");
        }

        private void bunifuFlatButton_OpenFeature_VIP_Click(object sender, EventArgs e)
        {
            ChangeTab("VIP");
        }

        private void bunifuFlatButton_OpenFeature_Staff_Click(object sender, EventArgs e)
        {
            ChangeTab("Staff");
        }

        private void bunifuFlatButton_OpenFeature_Stock_Click(object sender, EventArgs e)
        {
            ChangeTab("Stock");
        }

        private void bunifuFlatButton_OpenFeature_TransactionHistory_Click(object sender, EventArgs e)
        {
            ChangeTab("Transaction history");
        }

        private void bunifuFlatButton_OpenFeature_Contact_Click(object sender, EventArgs e)
        {
            ChangeTab("Contact");
        }

        #endregion

        #region Order feature
        private void bunifuTileButton_CreateOrder_Click(object sender, EventArgs e)
        {   
            if (staffInfo.CanCreateOrder())
                CallOrderForm("Create", null);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_UpdateOrder_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanUpdateOrder())
                CallOrderForm("Update", ((List<Order>)dataGridView_DisplayOrder.DataSource)[dataGridView_DisplayOrder.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_CancelOrder_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanCancelOrder())
                CallOrderForm("Cancel", ((List<Order>)dataGridView_DisplayOrder.DataSource)[dataGridView_DisplayOrder.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void CallOrderForm(string cmd, Order data)
        {
            Form CallForm;
            if (data == null)
                CallForm = new OrderForm(cmd);
            else
                CallForm = new OrderForm(cmd, data);
            CallForm.ShowDialog();
            ChangeTab("Order");
        }
        private void dataGridView_DisplayOrder_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallOrderForm("View", ((List<Order>)dataGridView_DisplayOrder.DataSource)[dataGridView_DisplayOrder.CurrentCell.RowIndex]);
        }

        private void bunifuFlatButton_CreateVouchers_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanAddVoucher())
            {
                Form CallForm = new VoucherForm();
                CallForm.ShowDialog();
            }
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }    
        #endregion

        #region Menu feature
        private void bunifuTileButton_AddMenuItem_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanAddMenu())
                CallMenuForm("Add", null);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_UpdateMenuItem_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanUpdateMenu())
                CallMenuForm("Update", ((List<Food>)dataGridView_DisplayMenu.DataSource)[dataGridView_DisplayMenu.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_DeleteMenuItem_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanDeleteBook())
                CallMenuForm("Delete", ((List<Food>)dataGridView_DisplayMenu.DataSource)[dataGridView_DisplayMenu.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void dataGridView_DisplayMenu_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallMenuForm("View", ((List<Food>)dataGridView_DisplayMenu.DataSource)[dataGridView_DisplayMenu.CurrentCell.RowIndex]);
        }

        private void CallMenuForm(string cmd, Food food)
        {
            Form CallForm;
            if (food != null)
                CallForm = new MenuForm(cmd, food);
            else
                CallForm = new MenuForm(cmd);
            CallForm.ShowDialog();
            ChangeTab("Menu");
        }
        #endregion

        #region Book feature
        private void bunifuTileButton_AddBook_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanAddBook())
                CallBookForm("Add", null);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_UpdateBook_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanUpdateBook())
                CallBookForm("Update", ((List<Book>)dataGridView_DisplayBook.DataSource)[dataGridView_DisplayBook.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }     

        private void bunifuTileButton_DeleteBook_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanDeleteBook())
                CallBookForm("Delete", ((List<Book>)dataGridView_DisplayBook.DataSource)[dataGridView_DisplayBook.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void dataGridView_DisplayBook_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallBookForm("View", ((List<Book>)dataGridView_DisplayBook.DataSource)[dataGridView_DisplayBook.CurrentCell.RowIndex]);
        }

        private void CallBookForm(string cmd, Book book)
        {
            Form CallForm;
            if (book != null)
                CallForm = new BookForm(cmd, book);
            else
                CallForm = new BookForm(cmd);
            CallForm.ShowDialog();
            ChangeTab("Book");
        }

        private void bunifuFlatButton_ViewWishlist_Click(object sender, EventArgs e)
        {
            ChangeTab("Wishlist");
        }
        #endregion

        #region Wishlist feature
        private void bunifuTileButton_AddWishlistItem_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanAddWishlist())
                CallWishlistForm("Add", null);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_UpdateWishlistItem_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanUpdateWishlist())
                CallWishlistForm("Update", ((List<BookDetails>)dataGridView_DisplayWishlist.DataSource)[dataGridView_DisplayWishlist.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_DeleteWishlistItem_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanDeleteWishlist())
                CallWishlistForm("Delete", ((List<BookDetails>)dataGridView_DisplayWishlist.DataSource)[dataGridView_DisplayWishlist.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void dataGridView_DisplayWishlist_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallWishlistForm("View", ((List<BookDetails>)dataGridView_DisplayWishlist.DataSource)[dataGridView_DisplayWishlist.CurrentCell.RowIndex]);
        }

        private void CallWishlistForm(string cmd, BookDetails details)
        {
            Form CallForm;
            if (details != null)
                CallForm = new WishlistForm(cmd, details);
            else
                CallForm = new WishlistForm(cmd);
            CallForm.ShowDialog();
            ChangeTab("Wishlist");
        }

        private void bunifuFlatButton_BackToBookFeature_Click(object sender, EventArgs e)
        {
            tabControl_ActiveForm.SelectedIndex = 2;
        }
        #endregion

        #region VIP feature
        private void bunifuTileButton_AddVIP_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanAddVIP())
                CallVIPForm("Add", null);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_UpdateVIP_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanUpdateVIP())
                CallVIPForm("Update", ((List<VIP>)dataGridView_DisplayVIP.DataSource)[dataGridView_DisplayVIP.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void dataGridView_DisplayVIP_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallVIPForm("View", ((List<VIP>)dataGridView_DisplayVIP.DataSource)[dataGridView_DisplayVIP.CurrentCell.RowIndex]);
        }

        private void CallVIPForm(string cmd, VIP customer)
        {
            Form CallForm;
            if (customer == null)
                CallForm = new VIPForm(cmd);
            else
                CallForm = new VIPForm(cmd, customer);
            CallForm.ShowDialog();
            ChangeTab("VIP");
        }
        #endregion

        #region Staff feature
        private void bunifuFlatButton_ViewSchedule_Click(object sender, EventArgs e)
        {
            Form CallForm = new ScheduleForm("View only");
            CallForm.ShowDialog();
            ChangeTab("Staff");
        }

        private void bunifuFlatButton_CreateSchedule_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanCreateSchedule())
            {
                Form CallForm = new ScheduleForm("Edit schedule");
                CallForm.ShowDialog();
                ChangeTab("Staff");
            }
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_AddStaff_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanUpdateStaff())
                CallStaffForm("Add", null);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_UpdateStaff_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanUpdateStaff())
                CallStaffForm("Update", ((List<Staff>)dataGridView_DisplayStaff.DataSource)[dataGridView_DisplayStaff.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void dataGridView_DisplayStaff_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallStaffForm("View", ((List<Staff>)dataGridView_DisplayStaff.DataSource)[dataGridView_DisplayStaff.CurrentCell.RowIndex]);
        }

        private void CallStaffForm(string cmd, Staff staff)
        {
            Form CallForm;
            if (staff == null)
                CallForm = new StaffForm(cmd);
            else
                CallForm = new StaffForm(cmd, staff);
            CallForm.ShowDialog();
            ChangeTab("Staff");
        }
        #endregion

        #region Stock feature
        private void bunifuTileButton_AddStockItem_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanAddStockItem())
                CallStockItemForm("Add", null);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void bunifuTileButton_UpdateStockItem_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanUpdateStockItem())
                CallStockItemForm("Update", ((List<StockItem>)dataGridView_DisplayStock.DataSource)[dataGridView_DisplayStock.CurrentCell.RowIndex]);
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void dataGridView_DisplayStock_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallStockItemForm("View", ((List<StockItem>)dataGridView_DisplayStock.DataSource)[dataGridView_DisplayStock.CurrentCell.RowIndex]);
        }

        private void CallStockItemForm(string cmd, StockItem stockItem)
        {
            Form CallForm;
            if (stockItem == null)
                CallForm = new Stock_ItemForm(cmd);
            else
                CallForm = new Stock_ItemForm(cmd, stockItem);
            CallForm.ShowDialog();
            ChangeTab("Stock");
        }

        private void bunifuFlatButton_CreateOrder_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanCreateStockOrder())
            {
                Form Callform = new StockForm();
                Callform.ShowDialog();
                ChangeTab("Stock");
            }
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }
        #endregion

        #region Transaction history feature
        private void bunifuFlatButton_GenerateReport_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanGenerateReport())
            {
                ChangeTab("Report");
            }
            else
                ErrorManager.MessageDisplay("You don't have access to this feature", "", "Permission Denied");
        }

        private void dataGridView_DisplayHistory_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CallOrderForm("View", ((List<Order>)dataGridView_DisplayHistory.DataSource)[dataGridView_DisplayHistory.CurrentCell.RowIndex]);
            ChangeTab("Transaction history");
        }

        #endregion

        #region Log out
        private void bunifuThinButton_LogOut_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }


        #endregion

        #region Detail search
        private void CallAdvanceSearch(string strFeature)
        {
            Form CallForm = new SearchForm(strFeature);
            CallForm.ShowDialog();
        }
        private void bunifuImageButton_SearchOrder_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox_SearchOrder.Text == "" || bunifuMetroTextbox_SearchOrder.Text == "Input search keyword...")
                CallAdvanceSearch("Order");
            else
                FilterOrder(bunifuMetroTextbox_SearchOrder.Text);
        }

        private void bunifuImageButton_SearchMenu_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox_SearchMenu.Text == "" || bunifuMetroTextbox_SearchOrder.Text == "Input search keyword...")
                CallAdvanceSearch("Menu");
            else
                FilterMenu(bunifuMetroTextbox_SearchMenu.Text);

        }

        private void bunifuImageButton_SearchBook_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox_SearchBook.Text == "" || bunifuMetroTextbox_SearchOrder.Text == "Input search keyword...")
                CallAdvanceSearch("Book");
            else
                FilterBook(bunifuMetroTextbox_SearchBook.Text);
        }

        private void bunifuImageButton_SearchVIP_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox_SearchVIP.Text == "" || bunifuMetroTextbox_SearchOrder.Text == "Input search keyword...")
                CallAdvanceSearch("VIP");
            else
                FilterVIP(bunifuMetroTextbox_SearchVIP.Text);
        }

        private void bunifuImageButton_SearchStaff_Click(object sender, EventArgs e)
        {
            if (staffInfo.CanViewAllStaff())
            {
                if (bunifuMetroTextbox_SearchStaff.Text == "" || bunifuMetroTextbox_SearchOrder.Text == "Input search keyword...")
                    CallAdvanceSearch("Staff");
                else
                    FilterStaff(bunifuMetroTextbox_SearchStaff.Text);
            } 
        }

        private void bunifuImageButton_SearchStock_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox_SearchStock.Text == "" || bunifuMetroTextbox_SearchOrder.Text == "Input search keyword...")
                CallAdvanceSearch("Stock");
            else
                FilterStock(bunifuMetroTextbox_SearchStock.Text);
        }

        private void bunifuImageButton_SearchTransactionHistory_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox_SearchTranasctionHistory.Text == "" || bunifuMetroTextbox_SearchOrder.Text == "Input search keyword...")
                CallAdvanceSearch("History");
            else
                FilterTransaction(bunifuMetroTextbox_SearchTranasctionHistory.Text);
        }
    
        private void bunifuImageButton_SearchWishlist_Click(object sender, EventArgs e)
        {
            if (bunifuMetroTextbox_SearchTranasctionHistory.Text == "" || bunifuMetroTextbox_SearchOrder.Text == "Input search keyword...")
                CallAdvanceSearch("Wishlist");
            else
                FilterWishlist(bunifuMetroTextbox_SearchWishlist.Text);
        }

        private void bunifuMetroTextbox_SearchOrder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterOrder(bunifuMetroTextbox_SearchOrder.Text);
        }

        private void bunifuMetroTextbox_SearchMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterMenu(bunifuMetroTextbox_SearchMenu.Text);
        }

        private void bunifuMetroTextbox_SearchStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterStock(bunifuMetroTextbox_SearchStock.Text);
        }

        private void bunifuMetroTextbox_SearchBook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterBook(bunifuMetroTextbox_SearchBook.Text);
        }

        private void bunifuMetroTextbox_SearchWishlist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterWishlist(bunifuMetroTextbox_SearchWishlist.Text);
        }

        private void bunifuMetroTextbox_SearchTranasctionHistory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterTransaction(bunifuMetroTextbox_SearchTranasctionHistory.Text);
        }

        private void bunifuMetroTextbox_SearchVIP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterVIP(bunifuMetroTextbox_SearchVIP.Text);
        }

        private void bunifuMetroTextbox_SearchStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                FilterStaff(bunifuMetroTextbox_SearchStaff.Text);
        }

        private void FilterMenu(string keyword)
        {
            List<Food> res = foodManager.SearchFood(keyword);
            dataGridView_DisplayMenu.DataSource = res;
        }

        private void FilterOrder(string keyword)
        {
            List<Order> res = orderManager.SearchOrder(keyword);
            dataGridView_DisplayOrder.DataSource = res;
        }

        private void FilterBook(string keyword)
        {
            List<Book> res = bookManager.SearchBook(keyword);
            dataGridView_DisplayBook.DataSource = res;
        }

        private void FilterVIP(string keyword)
        {
            List<VIP> res = vipManager.SearchVip(keyword);
            dataGridView_DisplayVIP.DataSource = res;
        }

        private void FilterStaff(string keyword)
        {
            if (staffInfo.CanViewAllStaff())
            {
                List<Staff> res = staffManager.SearchStaff(keyword);
                dataGridView_DisplayStaff.DataSource = res;
            }
            else
                ErrorManager.MessageDisplay("You can't use this function", "", "It is useless to search if you can only view yourself, right?");
        }

        private void FilterStock(string keyword)
        {
            List<StockItem> res = stockManager.SearchStock(keyword);
            dataGridView_DisplayStock.DataSource = res;
        }

        private void FilterTransaction(string keyword)
        {
            List<Order> res = orderManager.SearchTransaction(keyword);
            dataGridView_DisplayHistory.DataSource = res;
        }

        private void FilterWishlist(string keyword)
        {
            List<BookDetails> res = bookManager.SearchWishList(keyword);
            dataGridView_DisplayWishlist.DataSource = res;
        }
        #endregion

        #region Handling setting button
        private void bunifuImageButton_Setting_Click(object sender, EventArgs e)
        {
            Form CallForm = new SettingForm();
            CallForm.ShowDialog();
            LoadTheme();
            LoadLanguage();
            this.Update();
        }

        private void LoadTheme()
        {
            //
            // Header
            //
            panel_Header.BackColor = ThemeManager.NormalColor;
            ChangeSideMenuTheme();
            ChangeTabOrderTheme();
            ChangeTabMenuTheme();
            ChangeTabBookTheme();
            ChangeTabVIPTheme();
            ChangeTabStaffTheme();
            ChangeTabStockTheme();
            ChangeTabTransactionHistoryTheme();
            ChangeTabContactTheme();
            ChangeTabWishlistTheme();
        }
        #endregion

        #region Change theme
        private void ChangeSideMenuTheme()
        {
            //
            // Header
            //
            panel_Header.BackColor = ThemeManager.NormalColor;
            panel_Header.ForeColor = ThemeManager.ButtonForeColor;
            //
            //  Side menu
            //
            panel_SideMenu.BackColor = ThemeManager.MenuColor;
            textBox_ShowUsername.BackColor = ThemeManager.MenuColor;
            textBox_ShowUsername.ForeColor = ThemeManager.ButtonForeColor;
            bunifuThinButton_LogOut.BackColor = ThemeManager.MenuColor;
            bunifuThinButton_LogOut.IdleFillColor = ThemeManager.MenuColor;
            bunifuThinButton_LogOut.ActiveFillColor = ThemeManager.NormalColor;
            bunifuThinButton_LogOut.IdleForecolor = ThemeManager.ButtonForeColor;
            bunifuThinButton_LogOut.ActiveForecolor = ThemeManager.ButtonForeColor;
            textBox_LoggedInUsername.BackColor = ThemeManager.MenuColor;
            textBox_LoggedInUsername.ForeColor = ThemeManager.ButtonForeColor;
            bunifuImageButton_Setting.BackColor = ThemeManager.MenuColor;
            //Sidemenu button OnHoverColor
            bunifuFlatButton_OpenFeature_Order.OnHovercolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Menu.OnHovercolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Book.OnHovercolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_VIP.OnHovercolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Staff.OnHovercolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Stock.OnHovercolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_TransactionHistory.OnHovercolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Contact.OnHovercolor = ThemeManager.NormalColor;
            //Sidemenu button Activecolor
            bunifuFlatButton_OpenFeature_Order.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Menu.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Book.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_VIP.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Staff.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Stock.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_TransactionHistory.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_OpenFeature_Contact.Activecolor = ThemeManager.NormalColor;
            //Sidemenu button forecolor
            bunifuFlatButton_OpenFeature_Order.Textcolor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Menu.Textcolor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Book.Textcolor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_VIP.Textcolor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Staff.Textcolor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Stock.Textcolor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_TransactionHistory.Textcolor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Contact.Textcolor = ThemeManager.ButtonForeColor;
            //Side menu button onhovertextcolor
            bunifuFlatButton_OpenFeature_Order.OnHoverTextColor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Menu.OnHoverTextColor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Book.OnHoverTextColor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_VIP.OnHoverTextColor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Staff.OnHoverTextColor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Stock.OnHoverTextColor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_TransactionHistory.OnHoverTextColor = ThemeManager.ButtonForeColor;
            bunifuFlatButton_OpenFeature_Contact.OnHoverTextColor = ThemeManager.ButtonForeColor;
        }

        private void ChangeTabOrderTheme()
        {
            //
            // Tab: Order
            //
            //Background
            tabPage_Order.BackColor = ThemeManager.BackgroundColor;
            //Textbox: Search
            bunifuMetroTextbox_SearchOrder.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchOrder.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchOrder.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchOrder.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchOrder.ForeColor = ThemeManager.ForeColor;
            //Button: Create
            bunifuTileButton_CreateOrder.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_CreateOrder.color = ThemeManager.NormalColor;
            bunifuTileButton_CreateOrder.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_CreateOrder.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Update
            bunifuTileButton_UpdateOrder.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_UpdateOrder.color = ThemeManager.NormalColor;
            bunifuTileButton_UpdateOrder.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_UpdateOrder.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Cancel
            bunifuTileButton_CancelOrder.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_CancelOrder.color = ThemeManager.NormalColor;
            bunifuTileButton_CancelOrder.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_CancelOrder.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Create voucher
            bunifuFlatButton_CreateVouchers.Normalcolor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateVouchers.BackColor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateVouchers.OnHovercolor = ThemeManager.FocusColor;
            bunifuFlatButton_CreateVouchers.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateVouchers.Textcolor = ThemeManager.ButtonForeColor;
        }

        private void ChangeTabMenuTheme()
        {
            //
            // Tab: Menu
            //
            //Background
            tabPage_Menu.BackColor = ThemeManager.BackgroundColor;
            //Textbox: Search
            bunifuMetroTextbox_SearchMenu.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchMenu.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchMenu.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchMenu.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchMenu.ForeColor = ThemeManager.ForeColor;
            //Button: Add
            bunifuTileButton_AddMenuItem.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_AddMenuItem.color = ThemeManager.NormalColor;
            bunifuTileButton_AddMenuItem.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_AddMenuItem.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Update
            bunifuTileButton_UpdateMenuItem.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_UpdateMenuItem.color = ThemeManager.NormalColor;
            bunifuTileButton_UpdateMenuItem.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_UpdateMenuItem.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Delete
            bunifuTileButton_DeleteMenuItem.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_DeleteMenuItem.color = ThemeManager.NormalColor;
            bunifuTileButton_DeleteMenuItem.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_DeleteMenuItem.ForeColor = ThemeManager.ButtonForeColor;
        }

        private void ChangeTabBookTheme()
        {
            //
            // Tab: Book
            //
            //Background
            tabPage_Book.BackColor = ThemeManager.BackgroundColor;
            //Textbox: Search
            bunifuMetroTextbox_SearchBook.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchBook.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchBook.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchBook.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchBook.ForeColor = ThemeManager.ForeColor;
            //Button: Add
            bunifuTileButton_AddBook.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_AddBook.color = ThemeManager.NormalColor;
            bunifuTileButton_AddBook.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_AddBook.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Update
            bunifuTileButton_UpdateBook.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_UpdateBook.color = ThemeManager.NormalColor;
            bunifuTileButton_UpdateBook.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_UpdateBook.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Delete
            bunifuTileButton_DeleteBook.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_DeleteBook.color = ThemeManager.NormalColor;
            bunifuTileButton_DeleteBook.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_DeleteBook.ForeColor = ThemeManager.ButtonForeColor;
            //Button: View Wishlist
            bunifuFlatButton_ViewWishlist.Normalcolor = ThemeManager.NormalColor;
            bunifuFlatButton_ViewWishlist.BackColor = ThemeManager.NormalColor;
            bunifuFlatButton_ViewWishlist.OnHovercolor = ThemeManager.FocusColor;
            bunifuFlatButton_ViewWishlist.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_ViewWishlist.Textcolor = ThemeManager.ButtonForeColor;
        }

        private void ChangeTabVIPTheme()
        {
            //
            // Tab: VIP
            //
            //Background
            tabPage_VIP.BackColor = ThemeManager.BackgroundColor;
            //Textbox: Search
            bunifuMetroTextbox_SearchVIP.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchVIP.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchVIP.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchVIP.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchVIP.ForeColor = ThemeManager.ForeColor;
            //Button: Add
            bunifuTileButton_AddVIP.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_AddVIP.color = ThemeManager.NormalColor;
            bunifuTileButton_AddVIP.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_AddVIP.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Update
            bunifuTileButton_UpdateVIP.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_UpdateVIP.color = ThemeManager.NormalColor;
            bunifuTileButton_UpdateVIP.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_UpdateVIP.ForeColor = ThemeManager.ButtonForeColor;
        }

        private void ChangeTabStaffTheme()
        {
            //
            // Tab: Staff
            //
            //Background
            tabPage_Staff.BackColor = ThemeManager.BackgroundColor;
            //Textbox: Search
            bunifuMetroTextbox_SearchStaff.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchStaff.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchStaff.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchStaff.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchStaff.ForeColor = ThemeManager.ForeColor;
            //Button: Add
            bunifuTileButton_AddStaff.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_AddStaff.color = ThemeManager.NormalColor;
            bunifuTileButton_AddStaff.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_AddStaff.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Update
            bunifuTileButton_UpdateStaff.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_UpdateStaff.color = ThemeManager.NormalColor;
            bunifuTileButton_UpdateStaff.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_UpdateStaff.ForeColor = ThemeManager.ButtonForeColor;
            //Button: View Schedule
            bunifuFlatButton_ViewSchedule.Normalcolor = ThemeManager.NormalColor;
            bunifuFlatButton_ViewSchedule.BackColor = ThemeManager.NormalColor;
            bunifuFlatButton_ViewSchedule.OnHovercolor = ThemeManager.FocusColor;
            bunifuFlatButton_ViewSchedule.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_ViewSchedule.Textcolor = ThemeManager.ButtonForeColor;
            //Button: Create Schedule
            bunifuFlatButton_CreateSchedule.Normalcolor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateSchedule.BackColor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateSchedule.OnHovercolor = ThemeManager.FocusColor;
            bunifuFlatButton_CreateSchedule.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateSchedule.Textcolor = ThemeManager.ButtonForeColor;
        }

        private void ChangeTabStockTheme()
        {
            //
            // Tab: Stock
            //
            //Background
            tabPage_Stock.BackColor = ThemeManager.BackgroundColor;
            //Textbox: Search
            bunifuMetroTextbox_SearchStock.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchStock.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchStock.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchStock.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchStock.ForeColor = ThemeManager.ForeColor;
            //Button: Add 
            bunifuTileButton_AddStockItem.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_AddStockItem.color = ThemeManager.NormalColor;
            bunifuTileButton_AddStockItem.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_AddStockItem.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Update
            bunifuTileButton_UpdateStockItem.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_UpdateStockItem.color = ThemeManager.NormalColor;
            bunifuTileButton_UpdateStockItem.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_UpdateStockItem.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Create Order
            bunifuFlatButton_CreateOrder.Normalcolor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateOrder.BackColor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateOrder.OnHovercolor = ThemeManager.FocusColor;
            bunifuFlatButton_CreateOrder.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_CreateOrder.Textcolor = ThemeManager.ButtonForeColor;
        }

        private void ChangeTabTransactionHistoryTheme()
        {
            //
            // Tab: Stock
            //
            //Background
            tabPage_TransactionHistory.BackColor = ThemeManager.BackgroundColor;
            //Textbox: Search
            bunifuMetroTextbox_SearchTranasctionHistory.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchTranasctionHistory.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchTranasctionHistory.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchTranasctionHistory.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchTranasctionHistory.ForeColor = ThemeManager.ForeColor;
            // Button: Genereate Report 
            bunifuFlatButton_GenerateReport.Normalcolor = ThemeManager.NormalColor;
            bunifuFlatButton_GenerateReport.BackColor = ThemeManager.NormalColor;
            bunifuFlatButton_GenerateReport.OnHovercolor = ThemeManager.FocusColor;
            bunifuFlatButton_GenerateReport.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_GenerateReport.Textcolor= ThemeManager.ButtonForeColor;
        }

        private void ChangeTabWishlistTheme()
        {
            //
            // Tab: Wishlist
            //
            //Background
            tabPage_Wishlist.BackColor = ThemeManager.BackgroundColor;
            //Textbox: Search
            bunifuMetroTextbox_SearchWishlist.BackColor = ThemeManager.BackgroundColor;
            bunifuMetroTextbox_SearchWishlist.BorderColorFocused = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchWishlist.BorderColorIdle = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchWishlist.BorderColorMouseHover = ThemeManager.NormalColor;
            bunifuMetroTextbox_SearchWishlist.ForeColor = ThemeManager.ForeColor;

            //Button: Add
            bunifuTileButton_AddWishlistItem.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_AddWishlistItem.color = ThemeManager.NormalColor;
            bunifuTileButton_AddWishlistItem.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_AddWishlistItem.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Update
            bunifuTileButton_UpdateWishlistItem.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_UpdateWishlistItem.color = ThemeManager.NormalColor;
            bunifuTileButton_UpdateWishlistItem.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_UpdateWishlistItem.ForeColor = ThemeManager.ButtonForeColor;
            //Button: Delete
            bunifuTileButton_DeleteWishlistItem.BackColor = ThemeManager.NormalColor;
            bunifuTileButton_DeleteWishlistItem.color = ThemeManager.NormalColor;
            bunifuTileButton_DeleteWishlistItem.colorActive = ThemeManager.FocusColor;
            bunifuTileButton_DeleteWishlistItem.ForeColor = ThemeManager.ButtonForeColor;
            //Button: View Wishlist
            bunifuFlatButton_BackToBookFeature.Normalcolor = ThemeManager.NormalColor;
            bunifuFlatButton_BackToBookFeature.BackColor = ThemeManager.NormalColor;
            bunifuFlatButton_BackToBookFeature.OnHovercolor = ThemeManager.FocusColor;
            bunifuFlatButton_BackToBookFeature.Activecolor = ThemeManager.NormalColor;
            bunifuFlatButton_BackToBookFeature.Textcolor = ThemeManager.ButtonForeColor;
        }

        private void ChangeTabContactTheme()
        {
            //
            // Tab: Contact
            //
            //Background
            tabPage_Contact.BackColor = ThemeManager.BackgroundColor;
        }

        #endregion
        private void LoadLanguage()
        {
            LanguageManager LanguageSwitch = new LanguageManager();
            //
            //Side menu
            //
            bunifuFlatButton_OpenFeature_Order.Text = LanguageSwitch.ChangeName(bunifuFlatButton_OpenFeature_Order.Name);
            bunifuFlatButton_OpenFeature_Menu.Text = LanguageSwitch.ChangeName(bunifuFlatButton_OpenFeature_Menu.Name);
            bunifuFlatButton_OpenFeature_Book.Text = LanguageSwitch.ChangeName(bunifuFlatButton_OpenFeature_Book.Name);
            bunifuFlatButton_OpenFeature_VIP.Text = LanguageSwitch.ChangeName(bunifuFlatButton_OpenFeature_VIP.Name);
            bunifuFlatButton_OpenFeature_Staff.Text = LanguageSwitch.ChangeName(bunifuFlatButton_OpenFeature_Staff.Name);
            bunifuFlatButton_OpenFeature_Stock.Text = LanguageSwitch.ChangeName(bunifuFlatButton_OpenFeature_Stock.Name);
            bunifuFlatButton_OpenFeature_TransactionHistory.Text = LanguageSwitch.ChangeName(bunifuFlatButton_OpenFeature_TransactionHistory.Name);
            bunifuFlatButton_OpenFeature_Contact.Text = LanguageSwitch.ChangeName(bunifuFlatButton_OpenFeature_Contact.Name);
            //
            // Tab Order
            //
            bunifuMetroTextbox_SearchOrder.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchOrder.Name);
            bunifuFlatButton_CreateVouchers.Text = LanguageSwitch.ChangeName(bunifuFlatButton_CreateVouchers.Name);
            bunifuTileButton_CreateOrder.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_CreateOrder.Name);
            bunifuTileButton_UpdateOrder.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_UpdateOrder.Name);
            bunifuTileButton_CancelOrder.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_CancelOrder.Name);
            //
            // Tab Menu
            //
            bunifuMetroTextbox_SearchMenu.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchMenu.Name);
            bunifuTileButton_AddMenuItem.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_AddMenuItem.Name);
            bunifuTileButton_UpdateMenuItem.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_UpdateMenuItem.Name);
            bunifuTileButton_DeleteMenuItem.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_DeleteMenuItem.Name);
            //
            // Tab Book
            //
            bunifuMetroTextbox_SearchBook.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchBook.Name);
            bunifuFlatButton_ViewWishlist.Text = LanguageSwitch.ChangeName(bunifuFlatButton_ViewWishlist.Name);
            bunifuTileButton_AddBook.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_AddBook.Name);
            bunifuTileButton_UpdateBook.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_UpdateBook.Name);
            bunifuTileButton_DeleteBook.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_DeleteBook.Name);
            //
            // Tab VIP
            //
            bunifuMetroTextbox_SearchVIP.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchVIP.Name);
            bunifuTileButton_AddVIP.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_AddVIP.Name);
            bunifuTileButton_UpdateVIP.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_UpdateVIP.Name);
            //
            // Tab Staff
            //
            bunifuMetroTextbox_SearchStaff.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchStaff.Name);
            bunifuFlatButton_ViewSchedule.Text = LanguageSwitch.ChangeName(bunifuFlatButton_ViewSchedule.Name);
            bunifuFlatButton_CreateSchedule.Text = LanguageSwitch.ChangeName(bunifuFlatButton_CreateSchedule.Name);
            bunifuTileButton_AddStaff.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_AddStaff.Name);
            bunifuTileButton_UpdateStaff.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_UpdateStaff.Name);
            //
            // Tab Stock
            //
            bunifuMetroTextbox_SearchStock.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchStock.Name);
            bunifuFlatButton_CreateOrder.Text = LanguageSwitch.ChangeName(bunifuFlatButton_CreateOrder.Name);
            bunifuTileButton_AddStockItem.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_AddStockItem.Name);
            bunifuTileButton_UpdateStockItem.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_UpdateStockItem.Name);
            //
            // Tab Transaction history
            //
            bunifuMetroTextbox_SearchTranasctionHistory.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchTranasctionHistory.Name);
            bunifuFlatButton_GenerateReport.Text = LanguageSwitch.ChangeName(bunifuFlatButton_GenerateReport.Name);
            //
            // Tab Contact
            //
                //nothing to do here (-_ - ")
            //
            // Tab Wishlist
            //
            bunifuMetroTextbox_SearchWishlist.Text = LanguageSwitch.ChangeName(bunifuMetroTextbox_SearchWishlist.Name);
            bunifuTileButton_AddWishlistItem.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_AddWishlistItem.Name);
            bunifuTileButton_UpdateWishlistItem.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_UpdateWishlistItem.Name);
            bunifuTileButton_DeleteWishlistItem.LabelText = LanguageSwitch.ChangeName(bunifuTileButton_DeleteWishlistItem.Name);
            //
            // ETC
            //
            textBox_ShowUsername.Text = LanguageSwitch.ChangeName(textBox_ShowUsername.Name);
            bunifuThinButton_LogOut.ButtonText = LanguageSwitch.ChangeName(bunifuThinButton_LogOut.Name);
        }
        
    }
}
