
using CriminalDB.Web.CriminalDBServiceReference;
using CriminalDB.Web.Helper;
using CriminalDB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;

namespace CriminalDB.Web.Controllers
{
    public class SearchController : Controller
    {
        private ICriminalDBService service;

        public SearchController(ICriminalDBService dbService)
        {
            service = dbService;
        }

        public ActionResult Index()
        {
            ViewBag.Gender = PopulateGenderDropdown();
            var emptyReq = new RequestViewModel();
            return View(emptyReq);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RequestViewModel model)
        {
            ViewBag.Gender = PopulateGenderDropdown();

            if (ModelState.IsValid)
            {

                var request = Mapper.MapRequestViewModelToServiceRequest(model);
                try
                {
                    string errorString = string.Empty;
                    SearchResponse response = service.Search(new SearchRequest(request));
                    if (response.SearchResult)
                        return RedirectToAction("Confirmation");
                    else
                        ModelState.AddModelError("", response.errorMessage);
                }
                catch (EndpointNotFoundException)
                {
                    ModelState.AddModelError("", "Criminal Database search service is currently unavailable. Please try again later.");
                }
            }
            else
            {
                ModelState.AddModelError("", "Invalid inputs prevent query from submitting to the crime database.");
            }

            return View(model);
        }

        public ActionResult Confirmation()
        {
            return View();
        }
        private List<System.Web.Mvc.SelectListItem> PopulateGenderDropdown()
        {
            List<System.Web.Mvc.SelectListItem> gender = new List<System.Web.Mvc.SelectListItem>()
            {
               new System.Web.Mvc.SelectListItem { Value = "", Text = "Unknown" },
               new System.Web.Mvc.SelectListItem { Value = "M", Text = "Male" },
               new System.Web.Mvc.SelectListItem { Value = "F", Text = "Female" }
            };

            return gender;
        }
    }
}