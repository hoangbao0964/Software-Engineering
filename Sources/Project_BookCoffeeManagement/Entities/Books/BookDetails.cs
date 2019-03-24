using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Books
{
    public class BookDetails
    {
        #region Attributes
        protected string name;
        protected Author author;
        protected Publisher publisher;
        private double? price;
        private DateTime? publishDate;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public double? Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }
        public DateTime? PublishDate
        {
            get
            {
                return publishDate.Value.Date;
            }

            set
            {
                publishDate = value;
            }
        }
        protected Author Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }
        protected Publisher Publisher
        {
            get
            {
                return publisher;
            }

            set
            {
                publisher = value;
            }
        }
        public string AuthorName
        {
            get
            {
                return Author.Name;
            }

            set
            {
                Author.Name = value;
            }
        }
        public string PublisherName
        {
            get
            {
                return Publisher.Name;
            }

            set
            {
                Publisher.Name = value;
            }
        }
        #endregion


        #region Constructors & Initialize Methods

        public virtual bool Init(string name, double? price, DateTime? publishDate, Author author, Publisher publisher)
        {
            this.Name = name;
            this.Price = price;
            this.PublishDate = publishDate;
            if (author != null)
                this.Author = author;
            else
                this.Author = new Author();
            if (publisher != null)
                this.Publisher = publisher;
            else
                this.Publisher = new Publisher();

            return true;
        }

        public BookDetails()
        {
            Init("", 0, DateTime.Now, null, null);
        }
        #endregion

        public Author GetAuthor()
        {
            return this.Author;
        }

        public Publisher GetPublisher()
        {
            return this.Publisher;
        }

        internal string ValidateFields()
        {
            if (Name == "")
                return "Book name can't be empty";
            return "";
        }
    }
}
