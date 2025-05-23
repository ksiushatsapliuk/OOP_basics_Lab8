namespace JobExchangeLibrary.Models
{
    public class Vacancy
    {
        private int id;
        private string title;
        private string description;
        private string requirements;
        private decimal salary;
        private string workSchedule;
        private string location;
        private DateTime creationDate;
        private DateTime expirationDate;
        private bool isActive;
        private int companyId;
        private Company company;
        private int categoryId;
        private Category category;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public string Requirements
        {
            get { return requirements; }
            set { requirements = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string WorkSchedule
        {
            get { return workSchedule; }
            set { workSchedule = value; }
        }

        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public DateTime ExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public int CompanyId
        {
            get { return companyId; }
            set { companyId = value; }
        }

        public Company Company
        {
            get { return company; }
            set { company = value; }
        }

        public int CategoryId
        {
            get { return categoryId; }
            set { categoryId = value; }
        }

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public Vacancy()
        {
            creationDate = DateTime.Now;
            isActive = true;
        }
    }
}