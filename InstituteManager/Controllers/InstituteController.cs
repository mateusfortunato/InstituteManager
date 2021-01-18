using System.Collections.Generic;
using InstituteManager.Models;
using Microsoft.AspNetCore.Mvc;

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
                }
            };
            

            
        //Action called Index
        public IActionResult Index()
        {
            return View();
        }
        
    }
}