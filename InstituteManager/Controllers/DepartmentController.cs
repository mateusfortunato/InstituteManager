using InstituteManager.Data;
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
    }
}