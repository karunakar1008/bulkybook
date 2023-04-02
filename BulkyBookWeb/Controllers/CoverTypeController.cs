using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CoverTypeController : Controller
    {
        public readonly IUnitOfWork _unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<CoverType> categories = _unitOfWork.CoverTypeRepository.GetAll();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverTypeRepository.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type created successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var category = _db.Categories.Find(id);
            var coverTypeFirst = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(u => u.Id == id);
            if (coverTypeFirst == null)
            {
                return NoContent();
            }
            return View(coverTypeFirst);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.CoverTypeRepository.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Cover Type updated successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var coverType = _unitOfWork.CoverTypeRepository.GetFirstOrDefault(c => c.Id == id);
            if (coverType == null)
            {
                return NotFound();
            }
            _unitOfWork.CoverTypeRepository.Remove(coverType);
            _unitOfWork.Save();
            TempData["success"] = "Cover Type deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
