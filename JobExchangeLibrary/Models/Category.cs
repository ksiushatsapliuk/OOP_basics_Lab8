namespace JobExchangeLibrary.Models
{
    public class Category
    {
        private int id;
        private string name;
        private string description;
        private List<Vacancy> vacancies;
        private List<Resume> resumes;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public List<Vacancy> Vacancies
        {
            get { return vacancies; }
            set { vacancies = value; }
        }

        public List<Resume> Resumes
        {
            get { return resumes; }
            set { resumes = value; }
        }

        public Category()
        {
            vacancies = new List<Vacancy>();
            resumes = new List<Resume>();
        }
    }
}