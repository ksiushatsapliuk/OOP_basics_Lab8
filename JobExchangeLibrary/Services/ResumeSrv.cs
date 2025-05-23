using JobExchangeLibrary.Models;

namespace JobExchangeLibrary.Services
{
    public class ResumeSrv : IDataService<Resume>
    {
        private List<Resume> resumeList;
        private int nextId;

        public ResumeSrv()
        {
            resumeList = new List<Resume>();
            nextId = 1;
        }

        public void Add(Resume item)
        {
            item.Id = nextId;
            nextId = nextId + 1;
            resumeList.Add(item);
        }

        public void Delete(int id)
        {
            Resume resume = null;
            for (int i = 0; i < resumeList.Count; i++)
            {
                if (resumeList[i].Id == id)
                {
                    resume = resumeList[i];
                    break;
                }
            }

            if (resume != null)
            {
                resumeList.Remove(resume);
            }
        }

        public void Update(Resume item)
        {
            Resume existing = null;
            for (int i = 0; i < resumeList.Count; i++)
            {
                if (resumeList[i].Id == item.Id)
                {
                    existing = resumeList[i];
                    break;
                }
            }

            if (existing != null)
            {
                existing.Title = item.Title;
                existing.Summary = item.Summary;
                existing.Skills = item.Skills;
                existing.Education = item.Education;
                existing.WorkExperience = item.WorkExperience;
                existing.DesiredSalary = item.DesiredSalary;
                existing.PreferredLocation = item.PreferredLocation;
                existing.LastUpdateDate = DateTime.Now;
                existing.IsActive = item.IsActive;
                existing.CategoryId = item.CategoryId;
            }
        }

        public Resume GetById(int id)
        {
            for (int i = 0; i < resumeList.Count; i++)
            {
                if (resumeList[i].Id == id)
                {
                    return resumeList[i];
                }
            }
            return null;
        }

        public List<Resume> GetAll()
        {
            List<Resume> result = new List<Resume>();
            for (int i = 0; i < resumeList.Count; i++)
            {
                result.Add(resumeList[i]);
            }
            return result;
        }

        public List<Resume> Search(string keyword)
        {
            List<Resume> result = new List<Resume>();
            for (int i = 0; i < resumeList.Count; i++)
            {
                Resume r = resumeList[i];
                if (r.Title.Contains(keyword) ||
                    r.Summary.Contains(keyword) ||
                    r.Skills.Contains(keyword) ||
                    r.Education.Contains(keyword) ||
                    r.WorkExperience.Contains(keyword))
                {
                    result.Add(r);
                }
            }
            return result;
        }

        public List<Resume> GetSortedByTitle()
        {
            List<Resume> result = new List<Resume>();
            for (int i = 0; i < resumeList.Count; i++)
            {
                result.Add(resumeList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (string.Compare(result[j].Title, result[j + 1].Title) > 0)
                    {
                        Resume temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public List<Resume> GetSortedByLastUpdate()
        {
            List<Resume> result = new List<Resume>();
            for (int i = 0; i < resumeList.Count; i++)
            {
                result.Add(resumeList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (DateTime.Compare(result[j].LastUpdateDate, result[j + 1].LastUpdateDate) > 0)
                    {
                        Resume temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public List<Resume> GetSortedByDesiredSalary()
        {
            List<Resume> result = new List<Resume>();
            for (int i = 0; i < resumeList.Count; i++)
            {
                result.Add(resumeList[i]);
            }

            for (int i = 0; i < result.Count - 1; i++)
            {
                for (int j = 0; j < result.Count - 1 - i; j++)
                {
                    if (result[j].DesiredSalary > result[j + 1].DesiredSalary)
                    {
                        Resume temp = result[j];
                        result[j] = result[j + 1];
                        result[j + 1] = temp;
                    }
                }
            }

            return result;
        }

        public List<Resume> GetByCategory(int categoryId)
        {
            List<Resume> result = new List<Resume>();
            for (int i = 0; i < resumeList.Count; i++)
            {
                if (resumeList[i].CategoryId == categoryId)
                {
                    result.Add(resumeList[i]);
                }
            }
            return result;
        }

        public void AddToCategory(int resumeId, int categoryId)
        {
            Resume resume = GetById(resumeId);
            if (resume != null)
            {
                resume.CategoryId = categoryId;
            }
        }

        public void RemoveFromCategory(int resumeId)
        {
            Resume resume = GetById(resumeId);
            if (resume != null)
            {
                resume.CategoryId = 0;
            }
        }
    }
}