using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Books
{
    public class Book
    {
        #region Attributes
        protected string bookID;
        protected string location;
        protected string status;
        protected BookDetails details;

        public string BookID
        {
            get
            {
                return bookID;
            }

            set
            {
                bookID = value;
            }
        }
        public string BookName
        {
            get
            {
                return details.Name;
            }

            set
            {
                details.Name = value;
            }
        }
        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
        protected BookDetails Details
        {
            get
            {
                return details;
            }

            set
            {
                details = value;
            }
        }
        public double? Price
        {
            get
            {
                return details.Price;
            }

            set
            {
                details.Price = value;
            }
        }
        public DateTime? PublishDate
        {
            get
            {
                return details.PublishDate;
            }

            set
            {
                details.PublishDate = value;
            }
        }
        public string AuthorName
        {
            get
            {
                return details.GetAuthor().Name;
            }

            set
            {
                details.GetAuthor().Name = value;
            }
        }
        public string PublisherName
        {
            get
            {
                return details.GetPublisher().Name;
            }

            set
            {
                details.GetPublisher().Name = value;
            }
        }
        #endregion

        #region Constructors & Initialize functions
        public virtual bool Init(string bookID, string location, string status, BookDetails details)
        {
            this.bookID = bookID;
            this.location = location;
            this.status = status;
            if (details != null)
                this.details = details;
            else
                this.details = new BookDetails();

            return true;
        }
        public Book()
        {
            Init("", "", "", null);
        }
        #endregion

        public BookDetails GetBookDetails()
        {
            return this.Details;
        }

        internal string ValidateField()
        {
            if (details.ValidateFields() != "")
                return details.ValidateFields();
            if (this.Price <= 0)
                return "Book price can't be negative";

            return "";
        }
    }
}
