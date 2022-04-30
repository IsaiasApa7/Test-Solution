using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Test_Solution.Models;
using Test_Solution.Models.dbModels;
using Test_Solution.ViewModels;

namespace Test_Solution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestSolutionContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;


        public HomeController(ILogger<HomeController> logger, TestSolutionContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            ViewData["SatisfactoryInspections"] = _dbContext.Inspections.FromSqlRaw("SELECT  A.ID, A.Description, A.Date, A.StatusID, A.InspectionTypeID, A.UserID FROM Inspections A INNER JOIN InspectionTypes B ON A.InspectionTypeID = B.ID INNER JOIN Statuses C ON A.StatusID = C.ID WHERE A.StatusID = 1").ToList();
            ViewData["UnsatisfactoryInspections"] = _dbContext.Inspections.FromSqlRaw("SELECT  A.ID, A.Description, A.Date, A.StatusID, A.InspectionTypeID, A.UserID FROM Inspections A INNER JOIN InspectionTypes B ON A.InspectionTypeID = B.ID INNER JOIN Statuses C ON A.StatusID = C.ID WHERE A.StatusID = 2").ToList();
            //ViewData["Top3Majors"] = _dbContext.Inspections.FromSqlRaw("SELECT TOP 3 B.UserName, COUNT(A.StatusID) InspectionsSatisfactory,A.ID, A.Description, A.Date, A.StatusID, A.InspectionTypeID, A.UserID FROM Inspections A INNER JOIN AspNetUsers B on A.UserID = B.Id WHERE A.StatusID = 1 GROUP BY B.UserName,A.ID, A.Description, A.Date, A.StatusID, A.InspectionTypeID, A.UserID ORDER BY InspectionsSatisfactory DESC").ToList();
            //ViewData["Top3Minors"] = _dbContext.Inspections.FromSqlRaw("SELECT TOP 3 B.UserName, COUNT(A.StatusID) InspectionsSatisfactory,A.ID, A.Description, A.Date, A.StatusID, A.InspectionTypeID, A.UserID FROM Inspections A INNER JOIN AspNetUsers B on A.UserID = B.Id WHERE A.StatusID = 2 GROUP BY B.UserName,A.ID, A.Description, A.Date, A.StatusID, A.InspectionTypeID, A.UserID ORDER BY InspectionsSatisfactory DESC").ToList();
            return View();
        }


        [Authorize]
        public IActionResult RecordInspection()
        {
            List<Status> typeStatus = _dbContext.Statuses.ToList();
            List<SelectListItem> lstStatus = new List<SelectListItem>();

            List<ApplicationUser> UserName = _dbContext.Users.ToList();
            List<SelectListItem> lstUsers = new List<SelectListItem>();

            List<InspectionType> inspectionType = _dbContext.InspectionTypes.ToList();
            List<SelectListItem> lstInspectionType = new List<SelectListItem>();

            DateTime date = DateTime.Now;

            foreach (Status typestatus in typeStatus)
            {
                lstStatus.Add(new SelectListItem { Value = typestatus.Id.ToString(), Text = typestatus.StatusName });
            }

            foreach (ApplicationUser username in UserName)
            {
                lstUsers.Add(new SelectListItem { Value = username.Id.ToString(), Text = username.UserName });
            }

            foreach (InspectionType inspectiontype in inspectionType)
            {
                lstInspectionType.Add(new SelectListItem { Value = inspectiontype.Id.ToString(), Text = inspectiontype.TypeName });
            }

            RecordInspectionsViewModel rivm = new RecordInspectionsViewModel
            {
                TypeStatus = lstStatus,
                Users = lstUsers,
                inspectiontype = lstInspectionType,
                Date = date
            };
            return View(rivm);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RecordInspection(RecordInspectionsViewModel rivm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        Inspection inspection = new Inspection
                        {
                            Description = rivm.Description,
                            InspectionTypeId = rivm.InspectionType,
                            StatusId = rivm.StatusID,
                            UserId = rivm.UserID,
                            Date = rivm.Date
                        };
                        _dbContext.Inspections.Add(inspection);
                        _dbContext.SaveChanges();
                    }
                }
                 catch (Exception ex)
                {
                     return StatusCode(500, ex.Message);
                }

            }
            return RecordInspection();
        }


        [Authorize]
        public IActionResult RecordBuilding()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RecordBuilding(RecordBuildingViewModel rbvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        Building building = new Building
                            {
                                BuildingName = rbvm.BuildingName,
                                Address = rbvm.Address
                            };
                            _dbContext.Buildings.Add(building);
                            _dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                     return StatusCode(500, ex.Message);

                }
            }
                return RecordBuilding();
        }

        [Authorize]
        public IActionResult RecordInspectionType()
        {
            List<Building> buildings = _dbContext.Buildings.ToList();
            List<SelectListItem> lstBuildings = new List<SelectListItem>();

            foreach (Building building in buildings)
            {
                lstBuildings.Add(new SelectListItem { Value = building.Id.ToString(), Text = building.BuildingName });
            }

            RecordInspectionTypeViewModel ritvm = new RecordInspectionTypeViewModel
            {
                Buildings = lstBuildings
            };
            return View(ritvm);

        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> RecordInspectionType(RecordInspectionTypeViewModel ritvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        InspectionType inspectionType = new InspectionType
                        {
                            TypeName = ritvm.TypeName,
                            BuildingId = ritvm.BuildingID
                        };
                        _dbContext.InspectionTypes.Add(inspectionType);
                        _dbContext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);

                }
            }
            return RecordInspectionType();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
