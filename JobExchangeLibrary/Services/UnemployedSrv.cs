using JobExchangeLibrary.Models;

namespace JobExchangeLibrary.Services
{
    public class UnemployedSrv : IDataService<Unemployed>
    {
        private List<Unemployed> unemployedList;
        private int nextId;

        public UnemployedSrv()
        {
            unemployedList = new List<Unemployed>();
            nextId = 1;
        }

        public void Add(Unemployed item)
        {
            item.Id = nextId;
            nextId = nextId + 1;
            unemployedList.Add(item);
        }

        public void Delete(int id)
        {
            Unemployed unemployed = null;
            for (int i = 0; i < unemployedList.Count; i++)
            {
                if (unemployedList[i].Id == id)
                {
                    unemployed = unemployedList[i];
                    break;
                }
            }

            if (unemployed != null)
            {
                unemployedList.Remove(unemployed);
            }
        }

        public void Update(Unemployed item)
        {
            Unemployed existing = null;
            for (int i = 0; i < unemployedList.Count; i++)
            {
                if (unemployedList[i].Id == item.Id)
                {
                    existing = unemployedList[i];
                    break;
                }
            }

            if (existing != null)
            {
                existing.FirstName = item.FirstName;
                existing.LastName = item.LastName;
                existing.Phone = item.Phone;
                existing.Email = item.Email;
                existing.DateOfBirth = item.DateOfBirth;
                existing.Address = item.Address;
                existing.Education = item.Education;
                existing.Skills = item.Skills;
                existing.WorkExperience = item.WorkExperience;
                existing.DesiredPosition = item.DesiredPosition;
                existing.DesiredSalary = item.DesiredSalary;
                existing.IsActive = item.IsActive;
            }
        }

        public Unemployed GetById(int id)
        {
            for (int i = 0; i < unemployedList.Count; i++)
            {
                if (unemployedList[i].Id == id)
                {
                    return unemployedList[i];
                }
            }
            return null;
        }

        public List<Unemployed> GetAll()
        {
            List<Unemployed> result = new List<Unemployed>();
            for (int i = 0; i < unemployedList.Count; i++)
            {
                result.Add(unemployedList[i]);
            }
            return result;
        }

        public List<Unemployed> Search(string keyword)
        {
            List<Unemployed> result = new List<Unemployed>();
            for (int i = 0; i < unemployedList.Count; i++)
            {
                Unemployed u = unemployedList[i];
                if (u.FirstName.Contains(keyword) ||
                    u.LastName.Contains(keyword) ||
                    u.Skills.Contains(keyword) ||
                    u.DesiredPosition.Contains(keyword) ||
                    u.Education.Contains(keyword))
                {
                    result.Add(u);
                }
            }
            return result;
        }

        public List<Unemployed> GetSortedByFirstName()
        {
            List<Unemployed> result = new List<Unemployed>();
            for (int i = 0; i < unemployedList.Count; i++)
            {
                result.Add(unemployedList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (string.Compare(result[j].FirstName, result[j + 1].FirstName) > 0)
                    {
                        Unemployed temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public List<Unemployed> GetSortedByLastName()
        {
            List<Unemployed> result = new List<Unemployed>();
            for (int i = 0; i < unemployedList.Count; i++)
            {
                result.Add(unemployedList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (string.Compare(result[j].LastName, result[j + 1].LastName) > 0)
                    {
                        Unemployed temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }
    }
}