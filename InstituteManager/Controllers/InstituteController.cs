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
        public async Task<IActionResult> Create([Bind("Name, Adress")] Institute institute)
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

        // GET: Institute/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var institute = await _context.Institutes.FirstOrDefaultAsync(f => f.InstituteID == id);
            
            if(institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        // GET: Institute/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var department = await _context.Institutes.SingleOrDefaultAsync(s => s.InstituteID == id);

            if(department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("InstituteID,Name,Adress")] Institute institute)
        {
            if(id != institute.InstituteID)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(institute);

                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!InstituteExists(institute.InstituteID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(institute);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var institute = await _context.Institutes.SingleOrDefaultAsync(s => s.InstituteID == id);

            if(institute == null)
            {
                return NotFound();
            }

            return View(institute);
        }

        // POST: Institute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            var institute = await _context.Institutes.SingleOrDefaultAsync(s =>
            s.InstituteID == id);

            _context.Institutes.Remove(institute);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool InstituteExists(long? id)
        {
            return _context.Institutes.Any(a => a.InstituteID == id);
        }
    }
}
