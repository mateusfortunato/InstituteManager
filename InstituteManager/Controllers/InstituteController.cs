using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InstituteManager.Models;

namespace InstituteManager.Controllers
{
    public class InstituteController : Controller
    {
        private static IList<Institute> institutes = new List<Institute>()
            {
                new Institute() 
                {
                    InstituteID = 1,
                    Name = "UniParana",
                    Adress = "Paraná"
                },

                new Institute() 
                {
                InstituteID = 2,
                Name = "UniSC",
                Adress = "Santa Catarina"
                },
                
                new Institute() 
                {
                    InstituteID = 3,
                    Name = "UniRS",
                    Adress = "Rio Grande do Sul"
                },

                new Institute()
                {
                    InstituteID = 4,
                    Name = "UniRJ",
                    Adress = "Rio de Janeiro"
                }
            };
            
        //Action called Index
        public IActionResult Index()
        {
            return View(institutes);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Institute institute)
        {
            institutes.Add(institute);
            institute.InstituteID = institutes.Select(s => s.InstituteID).Max() + 1;

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Institute institute)
        {
            if(institute != null)
            {
                institutes.Remove(institutes.Where(i =>	i.InstituteID == institute.InstituteID).First());
		        institutes.Add(institute);
            }

			return RedirectToAction("Index");
        }
    }
}