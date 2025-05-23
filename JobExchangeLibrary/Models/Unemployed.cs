namespace JobExchangeLibrary.Models
{
    public class Unemployed : Person
    {
        private DateTime registrationDate;
        private string education;
        private string skills;
        private string workExperience;
        private string desiredPosition;
        private decimal desiredSalary;
        private bool isActive;
        private List<Resume> resumes;

        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        public string Education
        {
            get { return education; }
            set { education = value; }
        }

        public string Skills
        {
            get { return skills; }
            set { skills = value; }
        }

        public string WorkExperience
        {
            get { return workExperience; }
            set { workExperience = value; }
        }

        public string DesiredPosition
        {
            get { return desiredPosition; }
            set { desiredPosition = value; }
        }

        public decimal DesiredSalary
        {
            get { return desiredSalary; }
            set { desiredSalary = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public List<Resume> Resumes
        {
            get { return resumes; }
            set { resumes = value; }
        }

        public Unemployed()
        {
            resumes = new List<Resume>();
            isActive = true;
        }
    }
}