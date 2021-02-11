using InstituteManager.Data;
using InstituteManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace InstituteManager.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMContext _context;

        public DepartmentController(IMContext context)
        {
            this._context = context;
        }

        public async Task<ActionResult> Index()
        {
            return View(await _context.Departments.OrderBy(o =>
            o.Name).ToListAsync());
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Department department)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _context.Add(department);
                    
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Was not possible insert the data");
            }

            return View(department);
        }

        // GET: Department/Edit/5
        public async Task<IActionResult> Edit (long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.SingleOrDefaultAsync(s => s.DepartmentID == id);

            if(department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("Department,Name")] Department department)
        {
            if(id != department.DepartmentID)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(department);

                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if(!DepartmentExists(department.DepartmentID))
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

            return View(department);
        }

        public async Task<ActionResult> Details(long? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var department = await _context.Departments.FirstOrDefaultAsync(f => f.DepartmentID == id);
            
            if(department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        private bool DepartmentExists(long? id)
        {
            return _context.Departments.Any(a => a.DepartmentID == id);
        }
    }
}