using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BulkyBookWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var productList = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category,CoverType");
            return View(productList);
        }

        public IActionResult LoggingOrder()
        {
            _logger.LogTrace("Trace: Home page is loaded");
            _logger.LogDebug("Debug: Home page is loaded");
            _logger.LogInformation("Information: Home page is loaded");
            _logger.LogWarning("Warning: Home page is loaded");
            _logger.LogError("Error: Home page is loaded");
            _logger.LogCritical("Critical: Home page is loaded");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}