using Project_BookCoffeeManagement.Entities.Books;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.BLL.Books
{
    public class BookManager : Manager
    {
        private AuthorManager authorManager;
        private PublisherManager publisherManager;

        public BookManager()
        {
            authorManager = new AuthorManager();
            publisherManager = new PublisherManager();
        }

        #region Get Table
        private Table<DAL.Book> GetBookTable()
        {
            return db.GetTable<DAL.Book>();
        }

        private Table<DAL.BookDetail> GetBookDetailsTable()
        {
            return db.GetTable<DAL.BookDetail>();
        }

        private Table<DAL.BookStatus> GetBookStatusTable()
        {
            return db.GetTable<DAL.BookStatus>();
        }

        private Table<DAL.BookWishlist> GetBookWishlistTable()
        {
            return db.GetTable<DAL.BookWishlist>();
        }
        #endregion

        #region Get Data
        public List<Book> GetBooks()
        {
            Table<DAL.Book> bookTable = this.GetBookTable();
            Table<DAL.BookDetail> bookDetailTable = this.GetBookDetailsTable();
            Table<DAL.BookStatus> bookStatusTable = this.GetBookStatusTable();
            Table<DAL.Author> bookAuthor = authorManager.GetAuthorTable();
            Table<DAL.Publisher> bookPublisher = publisherManager.GetPublisherTable();
            var res = from bk in bookTable
                      join bkDetails in bookDetailTable on bk.bookDetailsID equals bkDetails.bookDetailsID
                      join bkStatus in bookStatusTable on bk.bookStatusCode equals bkStatus.bookStatusCode
                      join bkAuthor in bookAuthor on bkDetails.authorID equals bkAuthor.authorID
                      join bkPublisher in bookPublisher on bkDetails.publisherID equals bkPublisher.publisherID
                      orderby bkDetails.bookDetailsID ascending
                      select new Book
                      {
                          BookID = bk.bookID,
                          BookName = bkDetails.name,
                          Location = bk.location,
                          Status = bkStatus.name,
                          Price = bkDetails.price,
                          PublishDate = bkDetails.publishDate,
                          AuthorName = bkAuthor.name,
                          PublisherName = bkPublisher.name
                      };
            return res.ToList();
        }

        public List<Book> GetAvailableBooks()
        {
            List<Book> res = GetBooks();
            return res.Where(s => s.Status == "Available").ToList();
        }

        public List<BookDetails> GetBooksInWishlist()
        {
            Table<DAL.BookWishlist> bookWishlistTable = this.GetBookWishlistTable();
            Table<DAL.BookDetail> bookDetailTable = this.GetBookDetailsTable();
            Table<DAL.Author> bookAuthor = authorManager.GetAuthorTable();
            Table<DAL.Publisher> bookPublisher = publisherManager.GetPublisherTable();
            var res = from bk in bookWishlistTable
                      join bkDetails in bookDetailTable on bk.recommendBookDetailsID equals bkDetails.bookDetailsID
                      join bkAuthor in bookAuthor on bkDetails.authorID equals bkAuthor.authorID
                      join bkPublisher in bookPublisher on bkDetails.publisherID equals bkPublisher.publisherID
                      orderby bkDetails.bookDetailsID ascending
                      select new BookDetails
                      {
                          Name = bkDetails.name,
                          Price = bkDetails.price,
                          PublishDate = bkDetails.publishDate,
                          AuthorName = bkAuthor.name,
                          PublisherName = bkPublisher.name
                      };
            return res.ToList();
        }

        internal List<Book> Filter(string keyword, List<Book> availableBooks)
        {
            double temp = double.MinValue;
            Double.TryParse(keyword, out temp);
            keyword = keyword.ToLower();
            return availableBooks.Where(s => s.BookID.ToLower().Contains(keyword) || s.BookName.ToLower().Contains(keyword) || s.AuthorName.ToLower().Contains(keyword) || s.Price <= temp).ToList();
        }

        public Book GetBooks(string bookID)
        {
            List<Book> res = GetBooks();
            return res.Where(s => s.BookID == bookID).FirstOrDefault();
        }

        public List<object> SearchBook(string searchPharse1, string type1, string searchPharse2, string type2, string searchPharse3, string type3, string searchConstraint1, string searchConstraint2)
        {
            throw new NotImplementedException();
        }

        public List<object> SearchWishList(string searchPharse1, string type1, string searchPharse2, string type2, string searchPharse3, string type3, string searchConstraint1, string searchConstraint2)
        {
            throw new NotImplementedException();
        }

        internal List<Book> SearchBook(string keyword)
        {
            List<Book> res = GetBooks();
            return Filter(keyword, res);
        }

        internal List<BookDetails> SearchWishList(string keyword)
        {
            List<BookDetails> res = GetBooksInWishlist();
            double temp = double.MinValue;
            Double.TryParse(keyword, out temp);
            keyword = keyword.ToLower();
            return res.Where(s => s.Name.ToLower().Contains(keyword) || s.AuthorName.ToLower().Contains(keyword) || s.Price <= temp).ToList();
        }

        private int GetBookStatusCodeFromStatusName(string status)
        {
            Table<DAL.BookStatus> bookStatusTable = this.GetBookStatusTable();

            var res = (from bkStatus in bookStatusTable
                       where (bkStatus.name == status)
                       select bkStatus).FirstOrDefault();
            return res.bookStatusCode;
        }

        private int GetBookDetailsIDFromBookName(string name)
        {
            Table<DAL.BookDetail> bookDetailsTable = this.GetBookDetailsTable();

            var res = (from bkDetails in bookDetailsTable
                       where (bkDetails.name == name)
                       select bkDetails).FirstOrDefault();

            return res.bookDetailsID;
        }

        public List<string> GetBookStatuses()
        {
            Table<DAL.BookStatus> bookStatusTable = GetBookStatusTable();

            var res = (from bkStatus in bookStatusTable
                       select bkStatus.name);

            return res.ToList();
        }

        public List<BookDetails> GetBookDetails()
        {
            Table<DAL.BookDetail> bookDetailTable = this.GetBookDetailsTable();
            Table<DAL.BookStatus> bookStatusTable = this.GetBookStatusTable();
            Table<DAL.Author> bookAuthor = authorManager.GetAuthorTable();
            Table<DAL.Publisher> bookPublisher = publisherManager.GetPublisherTable();
            var res = from bkDetails in bookDetailTable
                      join bkAuthor in bookAuthor on bkDetails.authorID equals bkAuthor.authorID
                      join bkPublisher in bookPublisher on bkDetails.publisherID equals bkPublisher.publisherID
                      orderby bkDetails.name ascending
                      select new BookDetails
                      {
                          Name = bkDetails.name,
                          Price = bkDetails.price,
                          PublishDate = bkDetails.publishDate,
                          AuthorName = bkAuthor.name,
                          PublisherName = bkPublisher.name
                      };
            return res.ToList();
        }

        #endregion

        #region Update data
        public string DeleteBookFromDatabase(string bookCode)
        {
            Table<DAL.Book> bookTable = this.GetBookTable();

            var matchedBook = (from bk in bookTable
                               where bk.bookID == bookCode
                               select bk).SingleOrDefault();
            int bkDetailsID = matchedBook.bookDetailsID;

            try
            {
                bookTable.DeleteOnSubmit(matchedBook);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            DeleteBookDetails(bkDetailsID);
            return "";
        }

        public string AddOrUpdateBookToDatabase(Book newBook)
        {
            string res;
            Table<DAL.Book> bookTable = GetBookTable();

            var matchedBook = (from bk in bookTable
                               where bk.bookID == newBook.BookID
                               select bk).SingleOrDefault();

            if (matchedBook == null)    // Add
            {
                try
                {
                    res = AddOrUpdateBookDetails(newBook.GetBookDetails());
                    if (res != "")
                        return res;
                    DAL.Book addData = new DAL.Book();

                    Random data = new Random();
                    addData.bookID = data.Next().ToString();       // Dummy id init
                    addData.location = newBook.Location;
                    addData.bookStatusCode = GetBookStatusCodeFromStatusName(newBook.Status);
                    addData.bookDetailsID = GetBookDetailsIDFromBookName(newBook.GetBookDetails().Name);

                    bookTable.InsertOnSubmit(addData);
                    bookTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedBook != null)   // Update
            {
                try
                {
                    res = AddOrUpdateBookDetails(newBook.GetBookDetails());
                    if (res != "")
                        return res;

                    matchedBook.location = newBook.Location;
                    matchedBook.bookStatusCode = GetBookStatusCodeFromStatusName(newBook.Status);
                    matchedBook.bookDetailsID = GetBookDetailsIDFromBookName(newBook.GetBookDetails().Name);

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return "";
        }

        private string AddOrUpdateBookDetails(BookDetails bookDetails)
        {
            string res;
            Table<DAL.BookDetail> bookDetailsTable = db.GetTable<DAL.BookDetail>();

            var matchedBook = (from bkDetails in bookDetailsTable
                               where bkDetails.name == bookDetails.Name
                               select bkDetails).SingleOrDefault();

            res = authorManager.AddOrUpdateAuthor(bookDetails.GetAuthor());
            if (res != "")
                return res;
            res = publisherManager.AddOrUpdatePublisher(bookDetails.GetPublisher());
            if (res != "")
                return res;

            if (matchedBook == null)    // Add
            {
                try
                {
                    Random data = new Random();
                    DAL.BookDetail newData = new DAL.BookDetail();
                    newData.bookDetailsID = data.Next();    // Dummy init
                    newData.name = bookDetails.Name;
                    newData.price = bookDetails.Price;
                    newData.publishDate = bookDetails.PublishDate;             

                    newData.authorID = authorManager.GetAuthorIDFromAuthorName(bookDetails.GetAuthor().Name);
                    newData.publisherID = publisherManager.GetPublisherIDFromPublisherName(bookDetails.GetPublisher().Name);

                    bookDetailsTable.InsertOnSubmit(newData);
                    bookDetailsTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else if (matchedBook != null)   // Update
            {
                try
                {
                    matchedBook.name = bookDetails.Name;
                    matchedBook.price = bookDetails.Price;
                    matchedBook.publishDate = bookDetails.PublishDate;
                    matchedBook.authorID = authorManager.GetAuthorIDFromAuthorName(bookDetails.GetAuthor().Name);
                    matchedBook.publisherID = publisherManager.GetPublisherIDFromPublisherName(bookDetails.GetPublisher().Name);

                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                    
                }
            }
            return "";       
        }

        internal string SetBookStatus(string bookID, int statusCode)
        {
            Table<DAL.Book> bookTable = GetBookTable();

            var matchedBook = (from bk in bookTable
                               where bk.bookID == bookID
                               select bk).SingleOrDefault();

           if (matchedBook != null) 
            {
                try
                {
                    matchedBook.bookStatusCode = statusCode;
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }

            }
            return "";
        }

        public string DeleteBookFromWishlist(string text)
        {
            int bookDetailsID = GetBookDetailsIDFromBookName(text);

            Table<DAL.BookWishlist> bookWishlistTable = GetBookWishlistTable();
            var matchedResult = (from bkDetails in bookWishlistTable
                                 where bkDetails.recommendBookDetailsID == bookDetailsID
                                 select bkDetails).FirstOrDefault();

            if (matchedResult != null)
            {
                try
                {
                    bookWishlistTable.DeleteOnSubmit(matchedResult);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            else
                return "No data found in database";

            DeleteBookDetails(bookDetailsID);
            return "";
            
        }

        private string DeleteBookDetails(int bookDetailsID)
        {
            Table<DAL.BookDetail> bkDetailsTable = GetBookDetailsTable();
            var matchedDetails = (from bkDetails in bkDetailsTable
                                  where bkDetails.bookDetailsID == bookDetailsID
                                  select bkDetails).FirstOrDefault();

            if (matchedDetails != null)
            {
                try
                {
                    bkDetailsTable.DeleteOnSubmit(matchedDetails);
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return "";
        }

        public string AddOrUpdateBookToWishlist(BookDetails newWishlist)
        {
            string err = AddOrUpdateBookDetails(newWishlist);
            if (err != "")
                return err;

            int bookDetailsID = GetBookDetailsIDFromBookName(newWishlist.Name);

            Table<DAL.BookWishlist> bookWishlistTable = GetBookWishlistTable();
            var matchedResult = (from bkDetails in bookWishlistTable
                                 where bkDetails.recommendBookDetailsID == bookDetailsID
                                 select bkDetails).FirstOrDefault();

            if (matchedResult == null)
            {
                try
                {
                    DAL.BookWishlist newData = new DAL.BookWishlist();
                    newData.recommendBookDetailsID = bookDetailsID;

                    bookWishlistTable.InsertOnSubmit(newData);
                    bookWishlistTable.Context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
                
            }
            return "";
        }        
        #endregion
    }
}
