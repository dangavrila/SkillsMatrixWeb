using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SkillsMatrixWeb.Models;
using SkillsMatrixWeb.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillsMatrixWeb.Controllers.Web
{
    public class AppController : Controller
    {
        private readonly IConfigurationRoot _config;
        private readonly ILogger<AppController> _logger;
        private readonly IProjectsRepository _projectsRepository;
        private readonly ITechnologyRepository _technologyRepository;

        public AppController(IConfigurationRoot config, IProjectsRepository projectsRepository, ITechnologyRepository technologyRepository, ILogger<AppController> logger)
        {
            _config = config;
            _logger = logger;
            _projectsRepository = projectsRepository;
            _technologyRepository = technologyRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult ProjectToEmployee()
        {
            ViewBag.inlineDefault = GetDemoSearchResults();

            var projects = this._projectsRepository.GetAllProjects();
            var projectEntity = projects.ElementAt(0);
            var projectsVM = new ProjectsViewModel()
            {
                ProjectId = projectEntity.Id,
                ProjectName = projectEntity.Name,
                ProjectsList = new List<SelectListItem>() { new SelectListItem() { Value = "0", Text = "-" } }
            };

            foreach (var p in projects)
            {
                projectsVM.ProjectsList.Add(new SelectListItem() { Value = p.Id.ToString(), Text = p.Name });
            }
            return View(projectsVM);
        }

        [Authorize]
        public IActionResult EmployeeToProject()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public IActionResult Technologies(TechnologiesViewModel techListModel)
        {
            if (ModelState.IsValid)
            {
                var newTechnology = new Technology() { Name = techListModel.ViewModel.Name, Version = techListModel.ViewModel.Version };

                this._technologyRepository.InsertNewTechnology(newTechnology);

                ModelState.Clear();
            }
            return Technologies();
        }

        [HttpPost]
        [Authorize]
        public IActionResult EditTechnology(TechnologiesViewModel techListModel)
        {
            if (ModelState.IsValid)
            {
                var newTechnology = new Technology() { Name = techListModel.ViewModel.Name, Version = techListModel.ViewModel.Version };

                //this._technologyRepository.dele(newTechnology);

                ModelState.Clear();
            }
            return Technologies();
        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteTechnology(string itemName)
        {
            

            //if (ModelState.IsValid)
            //{
            var technologyItem = new Technology() { Name = itemName };

            this._technologyRepository.DeleteTechnology(technologyItem);

            //    ModelState.Clear();
            //}
            return Technologies();
        }

        [Authorize]
        public IActionResult Technologies()
        {
            var technologies = this._technologyRepository.GetAllTechnologies();

            var technologyListModel = new List<TechnologyViewModel>();
            foreach (var technology in technologies)
            {
                technologyListModel.Add(new TechnologyViewModel() { Name = technology.Name, Version = technology.Version });
            }

            var technologiesListModel = new TechnologiesViewModel()
            {
                ViewModels = technologyListModel,
            };

            return View(technologiesListModel);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        private IEnumerable<TreeViewItemModel> GetDemoSearchResults()
        {
            return new List<TreeViewItemModel>()
            {
                new TreeViewItemModel()
                {
                    Text = "Bucharest"
                },
                new TreeViewItemModel()
                {
                    Text = "Hamburg",
                    Items = new List<TreeViewItemModel>()
                    {
                        new TreeViewItemModel(){
                            Text = "Availability 20 %"
                        },
                        new TreeViewItemModel()
                        {
                            Text = "Availability 30 %",
                            Items = new List<TreeViewItemModel>()
                            {
                                new TreeViewItemModel()
                                {
                                    Text = "Score 25"
                                },
                                new TreeViewItemModel()
                                {
                                    Text = "Score 40"
                                },
                                new TreeViewItemModel()
                                {
                                    Text = "Score 90",
                                    Items = new List<TreeViewItemModel>()
                                    {
                                        new TreeViewItemModel()
                                        {
                                            Text = "Violeta Radulescu, violeta.radulescu@ibm.com"
                                        },
                                        new TreeViewItemModel()
                                        {
                                            Text = "Max	Windfield, max.windfield@ibm.com"
                                        }
                                    }
                                }
                            }
                        },
                        new TreeViewItemModel()
                        {
                            Text = "Availability 100 %",
                            Items = new List<TreeViewItemModel>()
                            {
                                new TreeViewItemModel()
                                {
                                    Text ="Score 80",
                                    Items = new List<TreeViewItemModel>()
                                    {
                                        new TreeViewItemModel()
                                        {
                                            Text = "Mimi Branescu, Mimi.Branescu@ibm.com"
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}
