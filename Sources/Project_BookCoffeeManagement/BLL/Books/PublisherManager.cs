using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.Books;

namespace Project_BookCoffeeManagement.BLL.Books
{
    class PublisherManager : Manager
    {
        public Table<DAL.Publisher> GetPublisherTable()
        {
            return db.GetTable<DAL.Publisher>();
        }

        public int GetPublisherIDFromPublisherName(string name)
        {
            Table<DAL.Publisher> bookPublisherTable = this.GetPublisherTable();

            var res = (from bkPublisher in bookPublisherTable
                       where (bkPublisher.name == name)
                       select bkPublisher).FirstOrDefault();

            return res.publisherID;
        }

        public string AddOrUpdatePublisher(Publisher publisher)
        {
            Table<DAL.Publisher> publisherTable = this.GetPublisherTable();

            var matchedPublisher = (from bkPublisher in publisherTable
                                 where (bkPublisher.name == publisher.Name)
                                 select bkPublisher).FirstOrDefault();

            if (matchedPublisher == null)
            {
                try
                {
                    DAL.Publisher newData = new DAL.Publisher();
                    newData.name = publisher.Name;
                    newData.description = publisher.Description;

                    publisherTable.InsertOnSubmit(newData);
                    publisherTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedPublisher != null)
            {
                try
                {
                    matchedPublisher.name = publisher.Name;
                    matchedPublisher.description = publisher.Description;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return "";
        }

        public List<Publisher> GetPublishers()
        {
            Table<DAL.Publisher> bookPublisherTable = this.GetPublisherTable();

            var res = (from bkPublisher in bookPublisherTable
                       select new Publisher
                       {
                           Name = bkPublisher.name,
                           Description = bkPublisher.description                 
                       });

            return res.ToList();
        }

        public List<string> GetPublisherNames()
        {
            Table<DAL.Publisher> bookPublisherTable = this.GetPublisherTable();

            var res = (from bkPublisher in bookPublisherTable
                       select bkPublisher.name);
 
            return res.ToList();
        }
    }
}
