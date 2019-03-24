namespace Project_BookCoffeeManagement.Entities.Stocks
{
    public class Producer
    {
        #region Attributes
        protected string name;
        protected string description;

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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }
        #endregion

        #region Constructors & Initialize methods
        public virtual bool Init(string name, string description)
        {
            this.Name = name;
            this.Description = description;

            return true;
        }

        public Producer()
        {
            Init("", "");
        }

        public Producer(string name, string description)
        {
            Init(name, description);
        }
        #endregion
    }
}