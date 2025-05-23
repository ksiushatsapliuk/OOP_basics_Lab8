using JobExchangeLibrary.Models;

namespace JobExchangeLibrary.Services
{
    public class CategorySrv : IDataService<Category>
    {
        private List<Category> categoryList;
        private int nextId;

        public CategorySrv()
        {
            categoryList = new List<Category>();
            nextId = 1;
        }

        public void Add(Category item)
        {
            item.Id = nextId;
            nextId = nextId + 1;
            categoryList.Add(item);
        }

        public void Delete(int id)
        {
            Category category = null;
            for (int i = 0; i < categoryList.Count; i++)
            {
                if (categoryList[i].Id == id)
                {
                    category = categoryList[i];
                    break;
                }
            }

            if (category != null)
            {
                categoryList.Remove(category);
            }
        }

        public void Update(Category item)
        {
            Category existing = null;
            for (int i = 0; i < categoryList.Count; i++)
            {
                if (categoryList[i].Id == item.Id)
                {
                    existing = categoryList[i];
                    break;
                }
            }

            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Description = item.Description;
            }
        }

        public Category GetById(int id)
        {
            for (int i = 0; i < categoryList.Count; i++)
            {
                if (categoryList[i].Id == id)
                {
                    return categoryList[i];
                }
            }
            return null;
        }

        public List<Category> GetAll()
        {
            List<Category> result = new List<Category>();
            for (int i = 0; i < categoryList.Count; i++)
            {
                result.Add(categoryList[i]);
            }
            return result;
        }

        public List<Category> Search(string keyword)
        {
            List<Category> result = new List<Category>();
            for (int i = 0; i < categoryList.Count; i++)
            {
                Category c = categoryList[i];
                if (c.Name.Contains(keyword) || c.Description.Contains(keyword))
                {
                    result.Add(c);
                }
            }
            return result;
        }

        public void AddVacancyToCategory(int categoryId, Vacancy vacancy)
        {
            Category category = GetById(categoryId);
            if (category != null)
            {
                bool contains = false;
                for (int i = 0; i < category.Vacancies.Count; i++)
                {
                    if (category.Vacancies[i] == vacancy)
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    category.Vacancies.Add(vacancy);
                    vacancy.CategoryId = categoryId;
                }
            }
        }

        public void RemoveVacancyFromCategory(int categoryId, int vacancyId)
        {
            Category category = GetById(categoryId);
            if (category != null)
            {
                Vacancy vacancy = null;
                for (int i = 0; i < category.Vacancies.Count; i++)
                {
                    if (category.Vacancies[i].Id == vacancyId)
                    {
                        vacancy = category.Vacancies[i];
                        break;
                    }
                }

                if (vacancy != null)
                {
                    category.Vacancies.Remove(vacancy);
                    vacancy.CategoryId = 0;
                }
            }
        }

        public void AddResumeToCategory(int categoryId, Resume resume)
        {
            Category category = GetById(categoryId);
            if (category != null)
            {
                bool contains = false;
                for (int i = 0; i < category.Resumes.Count; i++)
                {
                    if (category.Resumes[i] == resume)
                    {
                        contains = true;
                        break;
                    }
                }

                if (!contains)
                {
                    category.Resumes.Add(resume);
                    resume.CategoryId = categoryId;
                }
            }
        }

        public void RemoveResumeFromCategory(int categoryId, int resumeId)
        {
            Category category = GetById(categoryId);
            if (category != null)
            {
                Resume resume = null;
                for (int i = 0; i < category.Resumes.Count; i++)
                {
                    if (category.Resumes[i].Id == resumeId)
                    {
                        resume = category.Resumes[i];
                        break;
                    }
                }

                if (resume != null)
                {
                    category.Resumes.Remove(resume);
                    resume.CategoryId = 0;
                }
            }
        }
    }
}