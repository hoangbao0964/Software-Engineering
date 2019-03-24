using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_BookCoffeeManagement.Entities.Books
{
    public class Wishlist
    {
        #region Attributes
        protected List<BookDetails> recommendBooks;

        public List<BookDetails> RecommendBooks
        {
            get
            {
                return recommendBooks;
            }

            set
            {
                recommendBooks = value;
            }
        }
        #endregion

        #region Constructors & Init methods
        public Wishlist()
        {
            Init(null);
        }

        public Wishlist(List<BookDetails> details)
        {
            RecommendBooks = details;
        }

        public virtual bool Init(List<BookDetails> details)
        {
            if (details != null)
                RecommendBooks = details;
            else
                RecommendBooks = new List<BookDetails>();
            return true;
        }
        #endregion

        #region Methods
        public virtual bool addBook(BookDetails details)
        {
            RecommendBooks.Add(details);
            return true;
        }

        internal void InitDataFromDatabase()
        {
            
        }

        #endregion
    }
}
