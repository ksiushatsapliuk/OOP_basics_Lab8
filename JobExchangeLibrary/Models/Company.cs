namespace JobExchangeLibrary.Models
{
    public class Company
    {
        private int id;
        private string name;
        private string description;
        private string address;
        private string phone;
        private string email;
        private string contactPersonFirstName;
        private string contactPersonLastName;
        private string website;
        private DateTime registrationDate;
        private List<Vacancy> vacancies;

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

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string ContactPersonFirstName
        {
            get { return contactPersonFirstName; }
            set { contactPersonFirstName = value; }
        }

        public string ContactPersonLastName
        {
            get { return contactPersonLastName; }
            set { contactPersonLastName = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }

        public DateTime RegistrationDate
        {
            get { return registrationDate; }
            set { registrationDate = value; }
        }

        public List<Vacancy> Vacancies
        {
            get { return vacancies; }
            set { vacancies = value; }
        }

        public Company()
        {
            vacancies = new List<Vacancy>();
            registrationDate = DateTime.Now;
        }
    }
}