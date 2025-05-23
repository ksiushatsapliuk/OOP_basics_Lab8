using JobExchangeLibrary.Models;

namespace JobExchangeLibrary.Services
{
    public class VacancySrv : IDataService<Vacancy>
    {
        private List<Vacancy> vacancyList;
        private int nextId;

        public VacancySrv()
        {
            vacancyList = new List<Vacancy>();
            nextId = 1;
        }

        public void Add(Vacancy item)
        {
            item.Id = nextId;
            nextId = nextId + 1;
            vacancyList.Add(item);
        }

        public void Delete(int id)
        {
            Vacancy vacancy = null;
            for (int i = 0; i < vacancyList.Count; i++)
            {
                if (vacancyList[i].Id == id)
                {
                    vacancy = vacancyList[i];
                    break;
                }
            }

            if (vacancy != null)
            {
                vacancyList.Remove(vacancy);
            }
        }

        public void Update(Vacancy item)
        {
            Vacancy existing = null;
            for (int i = 0; i < vacancyList.Count; i++)
            {
                if (vacancyList[i].Id == item.Id)
                {
                    existing = vacancyList[i];
                    break;
                }
            }

            if (existing != null)
            {
                existing.Title = item.Title;
                existing.Description = item.Description;
                existing.Requirements = item.Requirements;
                existing.Salary = item.Salary;
                existing.WorkSchedule = item.WorkSchedule;
                existing.Location = item.Location;
                existing.ExpirationDate = item.ExpirationDate;
                existing.IsActive = item.IsActive;
                existing.CategoryId = item.CategoryId;
            }
        }

        public Vacancy GetById(int id)
        {
            for (int i = 0; i < vacancyList.Count; i++)
            {
                if (vacancyList[i].Id == id)
                {
                    return vacancyList[i];
                }
            }
            return null;
        }

        public List<Vacancy> GetAll()
        {
            List<Vacancy> result = new List<Vacancy>();
            for (int i = 0; i < vacancyList.Count; i++)
            {
                result.Add(vacancyList[i]);
            }
            return result;
        }

        public List<Vacancy> Search(string keyword)
        {
            List<Vacancy> result = new List<Vacancy>();
            for (int i = 0; i < vacancyList.Count; i++)
            {
                Vacancy v = vacancyList[i];
                if (v.Title.Contains(keyword) ||
                    v.Description.Contains(keyword) ||
                    v.Requirements.Contains(keyword) ||
                    v.Location.Contains(keyword))
                {
                    result.Add(v);
                }
            }
            return result;
        }

        public List<Vacancy> GetSortedByTitle()
        {
            List<Vacancy> result = new List<Vacancy>();
            for (int i = 0; i < vacancyList.Count; i++)
            {
                result.Add(vacancyList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (string.Compare(result[j].Title, result[j + 1].Title) > 0)
                    {
                        Vacancy temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public List<Vacancy> GetSortedBySalary()
        {
            List<Vacancy> result = new List<Vacancy>();
            for (int i = 0; i < vacancyList.Count; i++)
            {
                result.Add(vacancyList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (result[j].Salary > result[j + 1].Salary)
                    {
                        Vacancy temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public List<Vacancy> GetSortedByCreationDate()
        {
            List<Vacancy> result = new List<Vacancy>();
            for (int i = 0; i < vacancyList.Count; i++)
            {
                result.Add(vacancyList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (DateTime.Compare(result[j].CreationDate, result[j + 1].CreationDate) > 0)
                    {
                        Vacancy temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public List<Vacancy> GetByCategory(int categoryId)
        {
            List<Vacancy> result = new List<Vacancy>();
            for (int i = 0; i < vacancyList.Count; i++)
            {
                if (vacancyList[i].CategoryId == categoryId)
                {
                    result.Add(vacancyList[i]);
                }
            }
            return result;
        }

        public void AddToCategory(int vacancyId, int categoryId)
        {
            Vacancy vacancy = GetById(vacancyId);
            if (vacancy != null)
            {
                vacancy.CategoryId = categoryId;
            }
        }

        public void RemoveFromCategory(int vacancyId)
        {
            Vacancy vacancy = GetById(vacancyId);
            if (vacancy != null)
            {
                vacancy.CategoryId = 0;
            }
        }
    }
}