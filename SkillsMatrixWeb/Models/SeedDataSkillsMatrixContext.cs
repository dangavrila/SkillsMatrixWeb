using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Models
{
    public class SeedDataSkillsMatrixContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private SkillsMatrixDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public SeedDataSkillsMatrixContext(SkillsMatrixDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("dan.gavrila@ibm.com") == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "dangavrila",
                    Email = "dan.gavrila@ibm.com",
                    EnrollDate = DateTime.Now
                };
                await _userManager.CreateAsync(user, "d@nPAS5!");
            }

            var technologies = new List<Technology>() {
                        new Technology() { Name = "ASP.NET MVC", Version = "5" }, //0
                        new Technology() { Name = "C#", Version = "6" }, //1
                        new Technology() { Name = "WCF", Version = "4" }, //2
                        new Technology() { Name = "SQL Server", Version = "2008 R2" }, //3
                        new Technology() { Name = "Entity Framework", Version = "6" }, //4
                        new Technology() { Name = "EF Core", Version = "6" }, //5
                        new Technology() { Name = "HTML", Version = "5" }, //6
                        new Technology() { Name = "Java", Version = "5" }, //7
                        new Technology() { Name = "Hibernate", Version = "2" }, //8
                        new Technology() { Name = "JavaScript", Version = "5" }, //9
                        new Technology() { Name = "Scala", Version = "3" }, //10
                        new Technology() { Name = "Ruby", Version = "3" }, //11
                        new Technology() { Name = "nHibernate", Version = "2" }, //12
                        new Technology() { Name = "OracleDB", Version = "2012" }, //13
                        new Technology() { Name = "Lua", Version = "5.4"}, //14
                        new Technology() { Name = "C++", Version = "12" } //15
                };

            if (!_context.Projects.Any())
            {
                var tStack1 = new TechnologyStack()
                {
                    Name = "ASP.NET MVC",
                    Details = "Web, db, cloud tools."
                };

                var jobHistory0101 = new JobHistory()
                {
                    Startdate = new DateTime(2016, 01, 03),
                    EndDate = new DateTime(2016, 09, 30),
                    Capacity = 1.0f
                };

                var jobHistory0102 = new JobHistory()
                {
                    Startdate = new DateTime(2016, 10, 01),
                    Capacity = .8f
                };

                var newSeat01 = new Seat()
                {
                    PositionName = ".NET Application Developer",
                    Description = "Develop web applications using .NET 4.5",
                    TechnologyStacks = new List<TechnologyStack>() { tStack1 },
                    JobHistories = new List<JobHistory>() { jobHistory0101, jobHistory0102 }
                };

                _context.JobHistories.AddRange(newSeat01.JobHistories);

                var tStack2 = new TechnologyStack()
                {
                    Name = "Web Dev Java",
                    Details = "With Scala Web API"
                };

                var jobHistory0201 = new JobHistory()
                {
                    Startdate = new DateTime(2015, 01, 01),
                    EndDate = new DateTime(2016, 01, 01),
                    Capacity = .5f
                };

                var jobHistory0202 = new JobHistory()
                {
                    Startdate = new DateTime(2016, 01, 02),
                    Capacity = 1.0f
                };

                var newSeat02 = new Seat()
                {
                    PositionName = "Java Developer",
                    Description = "Develop full stack web app using Scala",
                    TechnologyStacks = new List<TechnologyStack>() { tStack2 },
                    JobHistories = new List<JobHistory>() { jobHistory0201, jobHistory0202 }
                };

                _context.JobHistories.AddRange(newSeat02.JobHistories);

                var tStack3 = new TechnologyStack()
                {
                    Name = "Web Dev Ruby",
                    Details = "With Ruby back-end"
                };

                var jobHistory0301 = new JobHistory()
                {
                    Startdate = new DateTime(2015, 06, 21),
                    EndDate = new DateTime(2016, 01, 03),
                    Capacity = 1
                };

                var jobHistory0302 = new JobHistory()
                {
                    Startdate = new DateTime(2016, 01, 04),
                    Capacity = .7f
                };

                var newSeat03 = new Seat()
                {
                    PositionName = "Ruby Developer",
                    Description = "Develop Ruby on Rails back-end",
                    TechnologyStacks = new List<TechnologyStack>() { tStack3 },
                    JobHistories = new List<JobHistory>() { jobHistory0301, jobHistory0302 }
                };

                _context.JobHistories.AddRange(newSeat03.JobHistories);

                _context.TechnologyStacks.AddRange(new[] { tStack1, tStack2, tStack3 });
                _context.Seats.AddRange(new[] { newSeat01, newSeat02, newSeat03 });
                _context.Technologies.AddRange(technologies);

                var t1WithTstack1 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[0],
                    TechnologyStack = tStack1
                };

                var t2WithTstack1 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[1],
                    TechnologyStack = tStack1
                };

                var t3WithTstack1 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[2],
                    TechnologyStack = tStack1
                };

                var t4WithTstack1 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[3],
                    TechnologyStack = tStack1
                };

                _context.TechnologiesInTechnologiesStacks.AddRange(new[] { t1WithTstack1, t2WithTstack1, t3WithTstack1, t4WithTstack1 });

                var t5WithTstack2 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[7],
                    TechnologyStack = tStack2
                };

                var t6WithTstack2 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[8],
                    TechnologyStack = tStack2
                };

                var t7WithTstack2 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[9],
                    TechnologyStack = tStack2
                };

                var t8WithTstack2 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[10],
                    TechnologyStack = tStack2
                };

                var t9WithTstack2 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[11],
                    TechnologyStack = tStack2
                };

                _context.TechnologiesInTechnologiesStacks.AddRange(new[] { t5WithTstack2, t6WithTstack2, t7WithTstack2, t8WithTstack2, t9WithTstack2 });

                var t10WithTstack3 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[9],
                    TechnologyStack = tStack3
                };

                var t11WithTstack3 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[10],
                    TechnologyStack = tStack3
                };

                var t12WithTstack3 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[11],
                    TechnologyStack = tStack3
                };

                var t13WithTstack3 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[12],
                    TechnologyStack = tStack3
                };

                var t14WithTstack3 = new TechnologiesInTechnologiesStack()
                {
                    Technology = technologies[13],
                    TechnologyStack = tStack3
                };

                _context.TechnologiesInTechnologiesStacks.AddRange(new[] { t10WithTstack3, t11WithTstack3, t12WithTstack3, t13WithTstack3, t14WithTstack3 });


                var newProject01 = new Project()
                {
                    Name = "Web Commerce",
                    HoursNeed = 430,
                    Deadline = new DateTime(2017, 11, 15),
                    Location = "Bucharest",
                    MinimumSkillLevel = 3,
                    Seats = new List<Seat>() { newSeat01 },
                    UserName = "dangavrila"
                };

                var newProject02 = new Project()
                {
                    Name = "News and Media",
                    HoursNeed = 590,
                    Deadline = new DateTime(2018, 01, 12),
                    Location = "Hamburg",
                    MinimumSkillLevel = 2,
                    Seats = new List<Seat>() { newSeat02, newSeat03 },
                    UserName = "dangavrila"
                };

                _context.Projects.AddRange(new[] { newProject01, newProject02 });

                await _context.SaveChangesAsync();


            #region Skills and employees

                var skills = new List<Skill>()
                {
                    new Skill() { Name = "C# development", NoOfYears = 2, Level = 3, LastYearUsed = 2017, Remarks = "desktop and web projects", },
                    new Skill() { Name = "Java development", NoOfYears = 12, Level = 5, LastYearUsed = 2012, Remarks = "various project types for desktop and web", },
                    new Skill() { Name = "Ruby development", NoOfYears = 4, Level = 2, LastYearUsed = 2012, Remarks = "research and development", },
                    new Skill() { Name = "Lua development", NoOfYears = 4, Level = 3, LastYearUsed = 2017, Remarks = "research and developemnt", },
                    new Skill() { Name = "C++ development", NoOfYears = 1, Level = 1, LastYearUsed = 2013, Remarks = "desktop applications", },
                    new Skill() { Name = "Unity3D development", NoOfYears = 1, Level = 1, LastYearUsed = 2013, Remarks = "games and augmented reality apps for mobile", }
                };
                _context.Skills.AddRange(skills);

                #region Employees
                var newEmployee01 = new Employee()
                {
                    FirstName = "Adrian",
                    LastName = "Popescu",
                    Email = "adrian.popescu@ibm.com",
                    Telephone = "+40744332123",
                    Skills = new List<Skill>() { skills[0], skills[2] }

                };

                var newEmployee02 = new Employee()
                {
                    FirstName = "Violeta",
                    LastName = "Radulescu",
                    Email = "violeta.radulescu@ibm.com",
                    Telephone = "+40744334123",
                    Skills = new List<Skill>() { skills[1], skills[4], skills[3] }
                };

                var newEmployee03 = new Employee()
                {
                    FirstName = "Laura",
                    LastName = "Flutur",
                    Email = "laura.flutur@ibm.com",
                    Telephone = "+40744872123",
                    Skills = new List<Skill>() { skills[5] }
                };

                var newEmployee04 = new Employee()
                {
                    FirstName = "Constantin",
                    LastName = "Fagaras",
                    Email = "constantin.fagaras@ibm.com",
                    Telephone = "+407443322123",
                    Skills = new List<Skill>() { skills[2] }
                };

                var newEmployee05 = new Employee()
                {
                    FirstName = "Max",
                    LastName = "Windfield",
                    Email = "max.windfield@ibm.com",
                    Telephone = "+40765442123",
                    Skills = new List<Skill>() { skills[1], skills[2] }
                };

                var newEmployee06 = new Employee()
                {
                    FirstName = "Dan",
                    LastName = "Gav",
                    Email = "Dan.Gav@ibm.com",
                    Telephone = "+40765442123",
                    Skills = new List<Skill>() { skills[0] }
                };

                var newEmployee07 = new Employee()
                {
                    FirstName = "Mimi",
                    LastName = "Branescu",
                    Email = "Mimi.Branescu@ibm.com",
                    Telephone = "+40744332123",
                    Skills = new List<Skill>() { skills[2] }

                };

                _context.Employees.AddRange(new[] { newEmployee01, newEmployee02, newEmployee03, newEmployee04, newEmployee05, newEmployee06, newEmployee07 });
                #endregion

                #region C# development Skill
                var s0WithTech0 = new TechnologysInSkill()
                {
                    Skill = skills[0],
                    Technology = technologies[0]
                };

                var s0WithTech1 = new TechnologysInSkill()
                {
                    Skill = skills[0],
                    Technology = technologies[1]
                };

                var s0WithTech2 = new TechnologysInSkill()
                {
                    Skill = skills[0],
                    Technology = technologies[2]
                };

                var s0WithTech3 = new TechnologysInSkill()
                {
                    Skill = skills[0],
                    Technology = technologies[3]
                };

                var s0WithTech4 = new TechnologysInSkill()
                {
                    Skill = skills[0],
                    Technology = technologies[4]
                };

                var s0WithTech5 = new TechnologysInSkill()
                {
                    Skill = skills[0],
                    Technology = technologies[5]
                };

                _context.TechnologysInSkills.AddRange(new[] { s0WithTech0, s0WithTech1, s0WithTech2, s0WithTech3, s0WithTech4, s0WithTech5, });
                #endregion

                #region Java development Skill
                var s1WithTech7 = new TechnologysInSkill
                {
                    Skill = skills[1],
                    Technology = technologies[7]
                };

                var s1WithTech8 = new TechnologysInSkill
                {
                    Skill = skills[1],
                    Technology = technologies[8]
                };

                var s1WithTech10 = new TechnologysInSkill
                {
                    Skill = skills[1],
                    Technology = technologies[10]
                };

                var s1WithTech13 = new TechnologysInSkill
                {
                    Skill = skills[1],
                    Technology = technologies[13]
                };

                _context.TechnologysInSkills.AddRange(new[] { s1WithTech7, s1WithTech8, s1WithTech10, s1WithTech13 });
                #endregion

                #region Ruby development Skill
                var s2WithTech11 = new TechnologysInSkill()
                {
                    Skill = skills[2],
                    Technology = technologies[11]
                };

                var s2WithTech6 = new TechnologysInSkill()
                {
                    Skill = skills[2],
                    Technology = technologies[6]
                };

                var s2WithTech7 = new TechnologysInSkill()
                {
                    Skill = skills[2],
                    Technology = technologies[7]
                };

                _context.TechnologysInSkills.AddRange(new[] { s2WithTech11, s2WithTech6, s2WithTech7 });
                #endregion

                #region Lua development
                var s3WithTech14 = new TechnologysInSkill
                {
                    Skill = skills[3],
                    Technology = technologies[14]
                };

                var s3WithTech9 = new TechnologysInSkill
                {
                    Skill = skills[3],
                    Technology = technologies[9]
                };

                _context.TechnologysInSkills.AddRange(new[] { s3WithTech14, s3WithTech9 });
                #endregion

                #region C++ Development Skill
                var s4WithTech15 = new TechnologysInSkill()
                {
                    Skill = skills[4],
                    Technology = technologies[15]
                };

                var s4WithTech13 = new TechnologysInSkill()
                {
                    Skill = skills[4],
                    Technology = technologies[13]
                };

                var s4WithTech6 = new TechnologysInSkill()
                {
                    Skill = skills[4],
                    Technology = technologies[6]
                };

                _context.TechnologysInSkills.AddRange(new[] { s4WithTech15, s4WithTech13, s4WithTech6 });
                #endregion

                #region Unity3D development Skill
                var s5WithTech1 = new TechnologysInSkill()
                {
                    Skill = skills[5],
                    Technology = technologies[1]
                };

                var s5WithTech15 = new TechnologysInSkill()
                {
                    Skill = skills[5],
                    Technology = technologies[15]
                };

                _context.TechnologysInSkills.AddRange(new[] { s5WithTech1, s5WithTech15 });
                #endregion

                #region Emloyee Job Histories
                var e01jobHistory0101 = new EmployeeJobHistory()
                {
                    Employee = newEmployee01,
                    JobHistory = jobHistory0101
                };

                var e06jobHistory0102 = new EmployeeJobHistory()
                {
                    Employee = newEmployee06,
                    JobHistory = jobHistory0102
                };

                var e02jobHistory0201 = new EmployeeJobHistory()
                {
                    Employee = newEmployee02,
                    JobHistory = jobHistory0201
                };

                var e05jobHistory0202 = new EmployeeJobHistory()
                {
                    Employee = newEmployee05,
                    JobHistory = jobHistory0202
                };

                var e07jobHistory0301 = new EmployeeJobHistory()
                {
                    Employee = newEmployee07,
                    JobHistory = jobHistory0301
                };

                var e01jobHistory0302 = new EmployeeJobHistory()
                {
                    Employee = newEmployee01,
                    JobHistory = jobHistory0302
                };

                _context.EmployeeJobHistories.AddRange(new[] { e01jobHistory0101, e06jobHistory0102, e02jobHistory0201, e05jobHistory0202, e07jobHistory0301, e01jobHistory0302 });
                #endregion

            #endregion
                await _context.SaveChangesAsync();
            }
        }
    }
}
