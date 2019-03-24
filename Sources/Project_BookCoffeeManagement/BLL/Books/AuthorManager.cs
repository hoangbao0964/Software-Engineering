using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_BookCoffeeManagement.Entities.Books;

namespace Project_BookCoffeeManagement.BLL.Books
{
    class AuthorManager : Manager
    {
        #region Get Table 
        public Table<DAL.Author> GetAuthorTable()
        {
            return db.GetTable<DAL.Author>();
        }
        #endregion

        public int GetAuthorIDFromAuthorName(string name)
        {
            Table<DAL.Author> bookAuthorTable = this.GetAuthorTable();

            var res = (from bkAuthor in bookAuthorTable
                       where (bkAuthor.name == name)
                       select bkAuthor).FirstOrDefault();

            return res.authorID;
        }

        public string AddOrUpdateAuthor(Author author)
        {
            Table<DAL.Author> authorTable = this.GetAuthorTable();

            var matchedAuthor = (from bkAuthor in authorTable
                                 where (bkAuthor.name == author.Name)
                                 select bkAuthor).FirstOrDefault();

            if (matchedAuthor == null)
            {
                try
                {
                    Random data = new Random();

                    DAL.Author newData = new DAL.Author();
                    newData.authorID = data.Next();     // Dummy init
                    newData.name = author.Name;
                    newData.description = author.Description;

                    authorTable.InsertOnSubmit(newData);
                    authorTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedAuthor != null)
            {
                try
                {
                    matchedAuthor.name = author.Name;
                    matchedAuthor.description = author.Description;

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }

            return "";
        }

        public List<Author> GetAuthors()
        {
            Table<DAL.Author> bookAuthorTable = this.GetAuthorTable();

            var res = (from bkAuthor in bookAuthorTable
                       select new Author
                       {
                           Name = bkAuthor.name,
                           Description = bkAuthor.description
                       });

            return res.ToList();
        }

        public List<string> GetAuthorNames()
        {
            Table<DAL.Author> bookAuthorTable = this.GetAuthorTable();

            var res = (from bkAuthor in bookAuthorTable
                       select bkAuthor.name);

            return res.ToList();
        }
    }
}
