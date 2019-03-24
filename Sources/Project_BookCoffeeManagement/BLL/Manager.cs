using Project_BookCoffeeManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.BLL
{
    public abstract class Manager
    {
        protected string connectionString;
        protected string connectionStringFilePath = "";
        protected static LinqToSQLDataContext db;
        
        public Manager()
        {
            connectionString = getConnectionStringFromFile(connectionStringFilePath);
            db = new LinqToSQLDataContext(connectionString);
        }

        private string getConnectionStringFromFile(string connectionStringFilePath)
        {
            //string str = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\Phate Opera\\Desktop\\WinApp___Book_coffee_management\\Sources\\Project_BookCoffeeManagement\\Book_Coffee_DB.mdf\"; Integrated Security = True; Connect Timeout = 30";
            //return str;
            return "Server=tcp:book-coffee-server.database.windows.net,1433;Initial Catalog=Book_Coffee_DB;Persist Security Info=False;User ID=bcmanager; Password=Newbee2014; MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
    }
}
