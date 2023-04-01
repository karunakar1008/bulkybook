using BulkyBookWeb.Data;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext applicationDbContext)
        {
            _db = applicationDbContext;
        }
        public IActionResult Index()
        {
            var categories = _db.Categories.ToList();
            return View();
        }
    }
}
