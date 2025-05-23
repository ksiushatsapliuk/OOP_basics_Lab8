using JobExchangeLibrary.Services;
using JobExchangeLibrary.Models;

namespace JobExchangeConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== БІРЖА ПРАЦІ: СИСТЕМА УПРАВЛІННЯ ===");
            Console.WriteLine();

            CategorySrv categorySrv = new CategorySrv();
            CompanySrv companySrv = new CompanySrv();
            UnemployedSrv unemployedSrv = new UnemployedSrv();
            VacancySrv vacancySrv = new VacancySrv();
            ResumeSrv resumeSrv = new ResumeSrv();

            Console.WriteLine("1. УПРАВЛІННЯ КАТЕГОРІЯМИ");
            Console.WriteLine("----------------------------------------");

            Category cat1 = new Category { Name = "ІТ та Програмування", Description = "Робота в сфері інформаційних технологій" };
            Category cat2 = new Category { Name = "Маркетинг", Description = "Маркетинг та реклама" };
            Category cat3 = new Category { Name = "Фінанси", Description = "Фінансова сфера та банківська справа" };

            categorySrv.Add(cat1);
            categorySrv.Add(cat2);
            categorySrv.Add(cat3);

            Console.WriteLine("Додано категорії:");
            List<Category> allCategories = categorySrv.GetAll();
            for (int i = 0; i < allCategories.Count; i++)
            {
                Console.WriteLine($"ID: {allCategories[i].Id}, Назва: {allCategories[i].Name}, Опис: {allCategories[i].Description}");
            }
            Console.WriteLine();

            Console.WriteLine("2. УПРАВЛІННЯ КОМПАНІЯМИ");
            Console.WriteLine("----------------------------------------");

            Company comp1 = new Company
            {
                Name = "ТехноСофт ЛТД",
                Description = "Розробка програмного забезпечення",
                Address = "м.Київ, вул.Хрещатик, 1",
                Phone = "+380501234567",
                Email = "info@technosoft.ua",
                ContactPersonFirstName = "Іван",
                ContactPersonLastName = "Петренко",
                Website = "www.technosoft.ua"
            };

            Company comp2 = new Company
            {
                Name = "МаркетингПро",
                Description = "Маркетингові послуги",
                Address = "м.Львів, пр.Свободи, 15",
                Phone = "+380679876543",
                Email = "contact@marketingpro.ua",
                ContactPersonFirstName = "Марія",
                ContactPersonLastName = "Іваненко",
                Website = "www.marketingpro.ua"
            };

            Company comp3 = new Company
            {
                Name = "ФінансГруп",
                Description = "Фінансові консультації",
                Address = "м.Одеса, вул.Дерибасівська, 10",
                Phone = "+380634567890",
                Email = "office@finansgroup.ua",
                ContactPersonFirstName = "Андрій",
                ContactPersonLastName = "Сидоренко",
                Website = "www.finansgroup.ua"
            };

            companySrv.Add(comp1);
            companySrv.Add(comp2);
            companySrv.Add(comp3);

            Console.WriteLine("Додано компанії:");
            List<Company> allCompanies = companySrv.GetAll();
            for (int i = 0; i < allCompanies.Count; i++)
            {
                Company c = allCompanies[i];
                Console.WriteLine($"ID: {c.Id}, Назва: {c.Name}, Контакт: {c.ContactPersonFirstName} {c.ContactPersonLastName}, Email: {c.Email}");
            }
            Console.WriteLine();

            Console.WriteLine("Компанії відсортовані по імені контактної особи:");
            List<Company> sortedByFirstName = companySrv.GetSortedByContactFirstName();
            for (int i = 0; i < sortedByFirstName.Count; i++)
            {
                Company c = sortedByFirstName[i];
                Console.WriteLine($"{c.ContactPersonFirstName} {c.ContactPersonLastName} - {c.Name}");
            }
            Console.WriteLine();

            Console.WriteLine("Компанії відсортовані по прізвищу контактної особи:");
            List<Company> sortedByLastName = companySrv.GetSortedByContactLastName();
            for (int i = 0; i < sortedByLastName.Count; i++)
            {
                Company c = sortedByLastName[i];
                Console.WriteLine($"{c.ContactPersonLastName} {c.ContactPersonFirstName} - {c.Name}");
            }
            Console.WriteLine();

            Console.WriteLine("3. УПРАВЛІННЯ БЕЗРОБІТНИМИ");
            Console.WriteLine("----------------------------------------");

            Unemployed unemp1 = new Unemployed
            {
                FirstName = "Олексій",
                LastName = "Коваленко",
                Phone = "+380501111111",
                Email = "oleksiy.kovalenko@gmail.com",
                DateOfBirth = new DateTime(1990, 5, 15),
                Address = "м.Київ, вул.Перемоги, 20",
                Education = "Вища, КНУ ім.Шевченка, спеціальність Інформатика",
                Skills = "C#, JavaScript, SQL, HTML/CSS",
                WorkExperience = "3 роки розробки веб-додатків",
                DesiredPosition = "Розробник ПЗ",
                DesiredSalary = 35000,
                RegistrationDate = DateTime.Now
            };

            Unemployed unemp2 = new Unemployed
            {
                FirstName = "Світлана",
                LastName = "Бондаренко",
                Phone = "+380502222222",
                Email = "svitlana.bondarenko@gmail.com",
                DateOfBirth = new DateTime(1985, 8, 22),
                Address = "м.Харків, вул.Сумська, 45",
                Education = "Вища, ХНУ ім.Каразіна, спеціальність Маркетинг",
                Skills = "SMM, Google Ads, Analytics, Photoshop",
                WorkExperience = "5 років у сфері цифрового маркетингу",
                DesiredPosition = "Маркетинг-менеджер",
                DesiredSalary = 25000,
                RegistrationDate = DateTime.Now
            };

            Unemployed unemp3 = new Unemployed
            {
                FirstName = "Дмитро",
                LastName = "Антоненко",
                Phone = "+380503333333",
                Email = "dmytro.antonenko@gmail.com",
                DateOfBirth = new DateTime(1992, 12, 3),
                Address = "м.Дніпро, пр.Гагаріна, 72",
                Education = "Вища, ДНУ, спеціальність Фінанси",
                Skills = "Фінансовий аналіз, Excel, 1С, SAP",
                WorkExperience = "4 роки аналітиком у банку",
                DesiredPosition = "Фінансовий аналітик",
                DesiredSalary = 30000,
                RegistrationDate = DateTime.Now
            };

            unemployedSrv.Add(unemp1);
            unemployedSrv.Add(unemp2);
            unemployedSrv.Add(unemp3);

            Console.WriteLine("Додано безробітних:");
            List<Unemployed> allUnemployed = unemployedSrv.GetAll();
            for (int i = 0; i < allUnemployed.Count; i++)
            {
                Unemployed u = allUnemployed[i];
                Console.WriteLine($"ID: {u.Id}, ПІБ: {u.FirstName} {u.LastName}, Бажана посада: {u.DesiredPosition}, Зарплата: {u.DesiredSalary} грн");
            }
            Console.WriteLine();

            Console.WriteLine("Безробітні відсортовані по імені:");
            List<Unemployed> sortedByName = unemployedSrv.GetSortedByFirstName();
            for (int i = 0; i < sortedByName.Count; i++)
            {
                Unemployed u = sortedByName[i];
                Console.WriteLine($"{u.FirstName} {u.LastName} - {u.DesiredPosition}");
            }
            Console.WriteLine();

            Console.WriteLine("Безробітні відсортовані по прізвищу:");
            List<Unemployed> sortedBySurname = unemployedSrv.GetSortedByLastName();
            for (int i = 0; i < sortedBySurname.Count; i++)
            {
                Unemployed u = sortedBySurname[i];
                Console.WriteLine($"{u.LastName} {u.FirstName} - {u.DesiredPosition}");
            }
            Console.WriteLine();

            Console.WriteLine("4. УПРАВЛІННЯ ВАКАНСІЯМИ");
            Console.WriteLine("----------------------------------------");

            Vacancy vac1 = new Vacancy
            {
                Title = "Senior C# Developer",
                Description = "Розробка корпоративних додатків на платформі .NET",
                Requirements = "Досвід роботи з C# не менше 3 років, знання ASP.NET Core, Entity Framework",
                Salary = 40000,
                WorkSchedule = "Повний робочий день",
                Location = "м.Київ",
                ExpirationDate = DateTime.Now.AddDays(30),
                CompanyId = comp1.Id,
                CategoryId = cat1.Id
            };

            Vacancy vac2 = new Vacancy
            {
                Title = "Digital Marketing Specialist",
                Description = "Просування товарів та послуг в цифровому середовищі",
                Requirements = "Досвід роботи в SMM, знання Google Ads, аналітичне мислення",
                Salary = 28000,
                WorkSchedule = "Повний робочий день",
                Location = "м.Львів",
                ExpirationDate = DateTime.Now.AddDays(45),
                CompanyId = comp2.Id,
                CategoryId = cat2.Id
            };

            Vacancy vac3 = new Vacancy
            {
                Title = "Financial Analyst",
                Description = "Аналіз фінансових показників та підготовка звітів",
                Requirements = "Вища освіта в галузі фінансів, знання Excel, досвід роботи від 2 років",
                Salary = 32000,
                WorkSchedule = "Повний робочий день",
                Location = "м.Одеса",
                ExpirationDate = DateTime.Now.AddDays(60),
                CompanyId = comp3.Id,
                CategoryId = cat3.Id
            };

            vacancySrv.Add(vac1);
            vacancySrv.Add(vac2);
            vacancySrv.Add(vac3);

            Console.WriteLine("Додано вакансії:");
            List<Vacancy> allVacancies = vacancySrv.GetAll();
            for (int i = 0; i < allVacancies.Count; i++)
            {
                Vacancy v = allVacancies[i];
                Console.WriteLine($"ID: {v.Id}, Посада: {v.Title}, Зарплата: {v.Salary} грн, Місто: {v.Location}");
            }
            Console.WriteLine();

            Console.WriteLine("Вакансії відсортовані по назві:");
            List<Vacancy> sortedVacByTitle = vacancySrv.GetSortedByTitle();
            for (int i = 0; i < sortedVacByTitle.Count; i++)
            {
                Vacancy v = sortedVacByTitle[i];
                Console.WriteLine($"{v.Title} - {v.Salary} грн");
            }
            Console.WriteLine();

            Console.WriteLine("Вакансії відсортовані по зарплаті (зростання):");
            List<Vacancy> sortedVacBySalary = vacancySrv.GetSortedBySalary();
            for (int i = 0; i < sortedVacBySalary.Count; i++)
            {
                Vacancy v = sortedVacBySalary[i];
                Console.WriteLine($"{v.Title} - {v.Salary} грн");
            }
            Console.WriteLine();

            Console.WriteLine("5. УПРАВЛІННЯ РЕЗЮМЕ");
            Console.WriteLine("----------------------------------------");

            Resume resume1 = new Resume
            {
                Title = "C# Developer",
                Summary = "Досвідчений розробник з 3-річним досвідом роботи",
                Skills = "C#, ASP.NET, SQL Server, JavaScript",
                Education = "КНУ ім.Шевченка, Інформатика",
                WorkExperience = "ТОВ 'СофтДев' - Junior Developer (2 роки), ПП 'ІнноТех' - Middle Developer (1 рік)",
                DesiredSalary = 35000,
                PreferredLocation = "м.Київ",
                UnemployedId = unemp1.Id,
                CategoryId = cat1.Id
            };

            Resume resume2 = new Resume
            {
                Title = "Marketing Manager",
                Summary = "Спеціаліст з цифрового маркетингу з 5-річним досвідом",
                Skills = "SMM, Google Ads, Facebook Ads, Analytics, Photoshop",
                Education = "ХНУ ім.Каразіна, Маркетинг",
                WorkExperience = "Агенція 'МаркетТоп' - SMM-менеджер (3 роки), 'ДіджиталПро' - маркетинг-менеджер (2 роки)",
                DesiredSalary = 25000,
                PreferredLocation = "м.Харків",
                UnemployedId = unemp2.Id,
                CategoryId = cat2.Id
            };

            Resume resume3 = new Resume
            {
                Title = "Financial Analyst",
                Summary = "Досвідчений фінансовий аналітик з банківським досвідом",
                Skills = "Фінансовий аналіз, Excel, 1С, SAP, IFRS",
                Education = "ДНУ, Фінанси",
                WorkExperience = "ПриватБанк - молодший аналітик (2 роки), УкрСибБанк - аналітик (2 роки)",
                DesiredSalary = 30000,
                PreferredLocation = "м.Дніпро",
                UnemployedId = unemp3.Id,
                CategoryId = cat3.Id
            };

            resumeSrv.Add(resume1);
            resumeSrv.Add(resume2);
            resumeSrv.Add(resume3);

            Console.WriteLine("Додано резюме:");
            List<Resume> allResumes = resumeSrv.GetAll();
            for (int i = 0; i < allResumes.Count; i++)
            {
                Resume r = allResumes[i];
                Console.WriteLine($"ID: {r.Id}, Посада: {r.Title}, Зарплата: {r.DesiredSalary} грн, Місто: {r.PreferredLocation}");
            }
            Console.WriteLine();

            Console.WriteLine("Резюме відсортовані по назві:");
            List<Resume> sortedResByTitle = resumeSrv.GetSortedByTitle();
            for (int i = 0; i < sortedResByTitle.Count; i++)
            {
                Resume r = sortedResByTitle[i];
                Console.WriteLine($"{r.Title} - {r.DesiredSalary} грн");
            }
            Console.WriteLine();

            Console.WriteLine("Резюме відсортовані по бажаній зарплаті (зростання):");
            List<Resume> sortedResBySalary = resumeSrv.GetSortedByDesiredSalary();
            for (int i = 0; i < sortedResBySalary.Count; i++)
            {
                Resume r = sortedResBySalary[i];
                Console.WriteLine($"{r.Title} - {r.DesiredSalary} грн");
            }
            Console.WriteLine();

            Console.WriteLine("6. УПРАВЛІННЯ КАТЕГОРІЯМИ - ДОДАВАННЯ ОБ'ЄКТІВ");
            Console.WriteLine("----------------------------------------");

            categorySrv.AddVacancyToCategory(cat1.Id, vac1);
            categorySrv.AddResumeToCategory(cat1.Id, resume1);

            categorySrv.AddVacancyToCategory(cat2.Id, vac2);
            categorySrv.AddResumeToCategory(cat2.Id, resume2);

            categorySrv.AddVacancyToCategory(cat3.Id, vac3);
            categorySrv.AddResumeToCategory(cat3.Id, resume3);

            Console.WriteLine("Вакансії та резюме додано до категорій:");
            for (int i = 0; i < allCategories.Count; i++)
            {
                Category cat = categorySrv.GetById(allCategories[i].Id);
                Console.WriteLine($"Категорія: {cat.Name}");
                Console.WriteLine($"  Вакансій: {cat.Vacancies.Count}");
                Console.WriteLine($"  Резюме: {cat.Resumes.Count}");
            }
            Console.WriteLine();

            Console.WriteLine("7. ФУНКЦІОНАЛЬНІСТЬ ПОШУКУ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine("Пошук вакансій по ключовому слову 'Developer':");
            List<Vacancy> foundVacancies = vacancySrv.Search("Developer");
            for (int i = 0; i < foundVacancies.Count; i++)
            {
                Vacancy v = foundVacancies[i];
                Console.WriteLine($"Знайдено: {v.Title} - {v.Salary} грн ({v.Location})");
            }
            Console.WriteLine();

            Console.WriteLine("Пошук безробітних по ключовому слову 'Олексій':");
            List<Unemployed> foundUnemployed = unemployedSrv.Search("Олексій");
            for (int i = 0; i < foundUnemployed.Count; i++)
            {
                Unemployed u = foundUnemployed[i];
                Console.WriteLine($"Знайдено: {u.FirstName} {u.LastName} - {u.DesiredPosition}");
            }
            Console.WriteLine();

            Console.WriteLine("Пошук компаній по ключовому слову 'Софт':");
            List<Company> foundCompanies = companySrv.Search("Софт");
            for (int i = 0; i < foundCompanies.Count; i++)
            {
                Company c = foundCompanies[i];
                Console.WriteLine($"Знайдено: {c.Name} - {c.ContactPersonFirstName} {c.ContactPersonLastName}");
            }
            Console.WriteLine();

            Console.WriteLine("8. ОПЕРАЦІЇ ОНОВЛЕННЯ ДАНИХ");
            Console.WriteLine("----------------------------------------");

            Unemployed unemployedToUpdate = unemployedSrv.GetById(1);
            if (unemployedToUpdate != null)
            {
                Console.WriteLine($"До оновлення: {unemployedToUpdate.FirstName} {unemployedToUpdate.LastName} - {unemployedToUpdate.DesiredSalary} грн");
                unemployedToUpdate.DesiredSalary = 40000;
                unemployedSrv.Update(unemployedToUpdate);
                Console.WriteLine($"Після оновлення: {unemployedToUpdate.FirstName} {unemployedToUpdate.LastName} - {unemployedToUpdate.DesiredSalary} грн");
            }
            Console.WriteLine();

            Vacancy vacancyToUpdate = vacancySrv.GetById(1);
            if (vacancyToUpdate != null)
            {
                Console.WriteLine($"До оновлення: {vacancyToUpdate.Title} - {vacancyToUpdate.Salary} грн");
                vacancyToUpdate.Salary = 45000;
                vacancySrv.Update(vacancyToUpdate);
                Console.WriteLine($"Після оновлення: {vacancyToUpdate.Title} - {vacancyToUpdate.Salary} грн");
            }
            Console.WriteLine();

            Console.WriteLine("9. ПЕРЕГЛЯД КОНКРЕТНИХ ЗАПИСІВ");
            Console.WriteLine("----------------------------------------");

            Unemployed specificUnemployed = unemployedSrv.GetById(2);
            if (specificUnemployed != null)
            {
                Console.WriteLine("Детальна інформація про безробітного:");
                Console.WriteLine($"ПІБ: {specificUnemployed.FirstName} {specificUnemployed.LastName}");
                Console.WriteLine($"Телефон: {specificUnemployed.Phone}");
                Console.WriteLine($"Email: {specificUnemployed.Email}");
                Console.WriteLine($"Освіта: {specificUnemployed.Education}");
                Console.WriteLine($"Навички: {specificUnemployed.Skills}");
                Console.WriteLine($"Бажана посада: {specificUnemployed.DesiredPosition}");
                Console.WriteLine($"Бажана зарплата: {specificUnemployed.DesiredSalary} грн");
            }
            Console.WriteLine();

            Vacancy specificVacancy = vacancySrv.GetById(2);
            if (specificVacancy != null)
            {
                Console.WriteLine("Детальна інформація про вакансію:");
                Console.WriteLine($"Назва: {specificVacancy.Title}");
                Console.WriteLine($"Опис: {specificVacancy.Description}");
                Console.WriteLine($"Вимоги: {specificVacancy.Requirements}");
                Console.WriteLine($"Зарплата: {specificVacancy.Salary} грн");
                Console.WriteLine($"Графік роботи: {specificVacancy.WorkSchedule}");
                Console.WriteLine($"Місцезнаходження: {specificVacancy.Location}");
            }
            Console.WriteLine();

            Console.WriteLine("10. ДЕМОНСТРАЦІЯ ВИДАЛЕННЯ");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine($"Кількість безробітних до видалення: {unemployedSrv.GetAll().Count}");
            unemployedSrv.Delete(3);
            resumeSrv.Delete(3);
            Console.WriteLine($"Кількість безробітних після видалення: {unemployedSrv.GetAll().Count}");

            Console.WriteLine("Список безробітних після видалення:");
            List<Unemployed> remainingUnemployed = unemployedSrv.GetAll();
            for (int i = 0; i < remainingUnemployed.Count; i++)
            {
                Unemployed u = remainingUnemployed[i];
                Console.WriteLine($"- {u.FirstName} {u.LastName}");
            }
            Console.WriteLine();

            Console.WriteLine("11. ПІДСУМКОВА СТАТИСТИКА");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Загальна кількість категорій: {categorySrv.GetAll().Count}");
            Console.WriteLine($"Загальна кількість компаній: {companySrv.GetAll().Count}");
            Console.WriteLine($"Загальна кількість безробітних: {unemployedSrv.GetAll().Count}");
            Console.WriteLine($"Загальна кількість вакансій: {vacancySrv.GetAll().Count}");
            Console.WriteLine($"Загальна кількість резюме: {resumeSrv.GetAll().Count}");
            Console.WriteLine();

            Console.WriteLine("=== ДЕМОНСТРАЦІЯ ЗАВЕРШЕНА ===");
            Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
            Console.ReadKey();
        }
    }
}