using JobExchangeLibrary.Models;

namespace JobExchangeLibrary.Services
{
    public class CompanySrv : IDataService<Company>
    {
        private List<Company> companyList;
        private int nextId;

        public CompanySrv()
        {
            companyList = new List<Company>();
            nextId = 1;
        }

        public void Add(Company item)
        {
            item.Id = nextId;
            nextId = nextId + 1;
            companyList.Add(item);
        }

        public void Delete(int id)
        {
            Company company = null;
            for (int i = 0; i < companyList.Count; i++)
            {
                if (companyList[i].Id == id)
                {
                    company = companyList[i];
                    break;
                }
            }

            if (company != null)
            {
                company.Vacancies.Clear();
                companyList.Remove(company);
            }
        }

        public void Update(Company item)
        {
            Company existing = null;
            for (int i = 0; i < companyList.Count; i++)
            {
                if (companyList[i].Id == item.Id)
                {
                    existing = companyList[i];
                    break;
                }
            }

            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Description = item.Description;
                existing.Address = item.Address;
                existing.Phone = item.Phone;
                existing.Email = item.Email;
                existing.ContactPersonFirstName = item.ContactPersonFirstName;
                existing.ContactPersonLastName = item.ContactPersonLastName;
                existing.Website = item.Website;
            }
        }

        public Company GetById(int id)
        {
            for (int i = 0; i < companyList.Count; i++)
            {
                if (companyList[i].Id == id)
                {
                    return companyList[i];
                }
            }
            return null;
        }

        public List<Company> GetAll()
        {
            List<Company> result = new List<Company>();
            for (int i = 0; i < companyList.Count; i++)
            {
                result.Add(companyList[i]);
            }
            return result;
        }

        public List<Company> Search(string keyword)
        {
            List<Company> result = new List<Company>();
            for (int i = 0; i < companyList.Count; i++)
            {
                Company c = companyList[i];
                if (c.Name.Contains(keyword) ||
                    c.Description.Contains(keyword) ||
                    c.ContactPersonFirstName.Contains(keyword) ||
                    c.ContactPersonLastName.Contains(keyword))
                {
                    result.Add(c);
                }
            }
            return result;
        }

        public List<Company> GetSortedByContactFirstName()
        {
            List<Company> result = new List<Company>();
            for (int i = 0; i < companyList.Count; i++)
            {
                result.Add(companyList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (string.Compare(result[j].ContactPersonFirstName, result[j + 1].ContactPersonFirstName) > 0)
                    {
                        Company temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public List<Company> GetSortedByContactLastName()
        {
            List<Company> result = new List<Company>();
            for (int i = 0; i < companyList.Count; i++)
            {
                result.Add(companyList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (string.Compare(result[j].ContactPersonLastName, result[j + 1].ContactPersonLastName) > 0)
                    {
                        Company temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public void AddVacancyToCompany(int companyId, Vacancy vacancy)
        {
            Company company = GetById(companyId);
            if (company != null)
            {
                vacancy.CompanyId = companyId;
                vacancy.Company = company;
                company.Vacancies.Add(vacancy);
            }
        }

        public void RemoveVacancyFromCompany(int companyId, int vacancyId)
        {
            Company company = GetById(companyId);
            if (company != null)
            {
                Vacancy vacancy = null;
                for (int i = 0; i < company.Vacancies.Count; i++)
                {
                    if (company.Vacancies[i].Id == vacancyId)
                    {
                        vacancy = company.Vacancies[i];
                        break;
                    }
                }

                if (vacancy != null)
                {
                    company.Vacancies.Remove(vacancy);
                }
            }
        }

        public List<Vacancy> GetVacanciesByCompany(int companyId)
        {
            Company company = GetById(companyId);
            if (company != null)
            {
                return company.Vacancies;
            }
            return new List<Vacancy>();
        }
    }
}