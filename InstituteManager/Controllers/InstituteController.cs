using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using InstituteManager.Models;
using InstituteManager.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InstituteManager.Controllers
{
    public class InstituteController : Controller
    {

        private readonly IMContext _context;

        public InstituteController(IMContext context)
        {
            _context = context;
        }

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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Institutes.OrderBy(
            o => o.Name).ToListAsync());
        }
        
        // GET: Institute
        public ActionResult Create()
        {
            return View();
        }
        
                [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Institute institute)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Add(institute);
                    
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Was not possible insert the data");
            }

            return View(institute);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Institute institute)
        {
            if(institute != null)
            {
                institutes.Remove(institutes.Where(w =>	w.InstituteID == institute.InstituteID).First());
		        institutes.Add(institute);
            }

			return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Institute institute)
        {
            institutes.Remove(institutes.Where(w => w.InstituteID == institute.InstituteID).First());
            return RedirectToAction("Index");
        }
    }
}
