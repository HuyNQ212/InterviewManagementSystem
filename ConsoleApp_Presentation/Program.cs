using DataAccess.Models;
using DataAccess.Repositories;
using DataAccess.Repositories.Implement;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.ConsoleApp
{
    public class Program
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly InterviewManagementContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IJobRepository jobRepository;
        private readonly ICandidateSkillRepository candidateSkillRepository;
        private readonly ICandidateRepository candidateRepository;
        private readonly ISkillRepository skillRepository;
        private readonly IUnitOfWork unitOfWork;
        public Program(
            IDepartmentRepository departmentRepository,
            InterviewManagementContext dbContext,
            IUserRepository userRepository,
            IJobRepository jobRepository,
            ICandidateSkillRepository candidateSkillRepository,
            ICandidateRepository candidateRepository,
            ISkillRepository skillRepository,
            IUnitOfWork unitOfWork)
        {
            this.departmentRepository = departmentRepository;
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.jobRepository = jobRepository;
            this.candidateSkillRepository = candidateSkillRepository;
            this.candidateRepository = candidateRepository;
            this.skillRepository = skillRepository;
            this.unitOfWork = unitOfWork;
        }

        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<Program>();
            services.AddSingleton<InterviewManagementContext>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IJobRepository, JobRepository>();
            services.AddSingleton<ISkillRepository, SkillRepository>();
            services.AddSingleton<ICandidateRepository, CandidateRepository>();
            services.AddSingleton<ICandidateSkillRepository, CandidateSkillRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            using (var scope = services.BuildServiceProvider())
            {
                Program app = scope.GetRequiredService<Program>();
                app.Run();

                //Read



                //var users = userRepository.GetAll();

                //foreach (var user in users)
                //{

                //}

                // Create

                // using repository

                //User newUser = new User() {
                //    Address = "Ha Noi",
                //    DateOfBirth = new DateTime(day: 12, month: 12, year: 1999),
                //    Email = "demo@email.com",
                //    FullName = "demoUser",
                //    Password = "demo",
                //    PhoneNumber = "1234567890",
                //    Role = dbContext.Roles.Find(1),
                //    Department = dbContext.Departments.Find(1),
                //    UserName = "demo-user",
                //    Status = "active"
                //};

                //userRepository.Insert(newUser);

                //Console.WriteLine("After created new user!");

                //users = userRepository.GetAll();

                //foreach (var user in users)
                //{
                //    Console.WriteLine(user.UserName);
                //}

                // using context

                //dbContext.Users.Add(new User
                //{
                //    Address = "Ha Noi",
                //    DateOfBirth = new DateTime(day: 12, month: 12, year: 1999),
                //    Email = "demo@email.com",
                //    FullName = "demoUser",
                //    Password = "demo",
                //    PhoneNumber = "1234567890",
                //    Role = dbContext.Roles.Find(1),
                //    Department = dbContext.Departments.Find(1),
                //    UserName = "demo-user",
                //    Status = "active"
                //});

                //dbContext.SaveChanges();

                // Update



                //var user = dbContext.Users.Find(1);
                //if (user != null)
                //{
                //    Console.WriteLine(dbContext.Entry(user).State.ToString());

                //    user.FullName = "Changed from Code 1";

                //    Console.WriteLine(dbContext.Entry(user).State.ToString());

                //    dbContext.SaveChanges();

                //    Console.WriteLine("save change completed!");
                //}

                // Delete

                // var userToDelete = userRepository.GetAll().FirstOrDefault(user => user.FullName.Contains("demo"));

                //if (userToDelete != null)
                //{
                //    Console.WriteLine(dbContext.Entry(userToDelete).State.ToString());

                //    userRepository.Delete(userToDelete);

                //    Console.WriteLine(dbContext.Entry(userToDelete).State.ToString());
                //}

                // var userToDelete = dbContext.Users.FirstOrDefault(user => user.FullName.Contains("demo"));

                //if (userToDelete != null)
                //{
                //    Console.WriteLine(dbContext.Entry(userToDelete).State.ToString());
                //    dbContext.Users.Remove(userToDelete);
                //    Console.WriteLine(dbContext.Entry(userToDelete).State.ToString());

                //    dbContext.SaveChanges();
                //    Console.WriteLine("save change completed!");
                //}
            }
        }

        private void Run()
        {
            var user = dbContext.Set<User>().FromSqlRaw("Select * From Users").ToList();

            user.ForEach(x =>
            {
                Console.WriteLine(x.FullName);
            });
            //departments1.ForEach(department =>
            //{
            //    department.Users.ToList().ForEach(user =>
            //    {
            //        Console.WriteLine(user.UserName);
            //    });
            //});

            //foreach (var department in departments1)
            //{
            //    dbContext.Entry(department).Collection(d => d.Users).Load();

            //    department.Users.ToList().ForEach(u => Console.WriteLine(u.UserName));

            //}



            //candidateSkillRepository.Insert(
            //    new CandidateSkill()
            //    {
            //        Candidate = candidateRepository.GetById(1),
            //        Skill = skillRepository.GetById(4),
            //    });

            //candidateSkillRepository.Save();

            //var userToUpdate = userRepository.GetById(1);

            //if (userToUpdate != null)
            //{
            //    Console.WriteLine(dbContext.Entry(userToUpdate).State.ToString());

            //    userToUpdate.FullName = "Changed from code 1234";

            //    Console.WriteLine(dbContext.Entry(userToUpdate).State.ToString());

            //    userRepository.Update(userToUpdate);

            //    userRepository.Save();

            //    Console.WriteLine(dbContext.Entry(userToUpdate).State.ToString());
            //}
        }
    }
}