namespace JobExchangeLibrary.Models
{
    public class Resume
    {
        private int id;
        private string title;
        private string summary;
        private string skills;
        private string education;
        private string workExperience;
        private decimal desiredSalary;
        private string preferredLocation;
        private DateTime creationDate;
        private DateTime lastUpdateDate;
        private bool isActive;
        private int unemployedId;
        private Unemployed unemployed;
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

        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }

        public string Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        public string Education
        {
            get { return education; }
            set { education = value; }
        }

        public string WorkExperience
        {
            get { return workExperience; }
            set { workExperience = value; }
        }

        public decimal DesiredSalary
        {
            get { return desiredSalary; }
            set { desiredSalary = value; }
        }

        public string PreferredLocation
        {
            get { return preferredLocation; }
            set { preferredLocation = value; }
        }

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

        public DateTime LastUpdateDate
        {
            get { return lastUpdateDate; }
            set { lastUpdateDate = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public int UnemployedId
        {
            get { return unemployedId; }
            set { unemployedId = value; }
        }

        public Unemployed Unemployed
        {
            get { return unemployed; }
            set { unemployed = value; }
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

        public Resume()
        {
            creationDate = DateTime.Now;
            lastUpdateDate = DateTime.Now;
            isActive = true;
        }
    }
}