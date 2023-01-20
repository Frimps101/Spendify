using Microsoft.AspNetCore.Mvc;
using Spendify.Data;
using Spendify.Models;

namespace Spendify.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductCategoriesController : Controller
    {
        private ApplicationDbContext _db;
        public ProductCategoriesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
           // var data = _db.ProductCategories.ToList();
            return View(_db.ProductCategories.ToList());
        }

        // Create Get Action Method
        public ActionResult Create()
        {
            return View();
        }

        // Create Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategories productCategories)
        {
            if (ModelState.IsValid)
            {
                _db.ProductCategories.Add(productCategories);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productCategories);
        }

        // Edit Get Action Method
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = _db.ProductCategories.Find(id);
            if (productCategory == null) 
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // Edit Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductCategories productCategories)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productCategories);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productCategories);
        }

        // Details Get Action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productCategory = _db.ProductCategories.Find(id);
            if (productCategory == null)
            {
                return NotFound();
            }

            return View(productCategory);
        }

        // Details Post Action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ProductCategories productCategories)
        {
            return RedirectToAction(nameof(Index));
        }

        //GET Delete Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _db.ProductCategories.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        //POST Delete Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductCategories productCategories)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (id != productCategories.Id)
            {
                return NotFound();
            }

            var productType = _db.ProductCategories.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();
                TempData["delete"] = "Product type has been deleted";
                return RedirectToAction(nameof(Index));
            }

            return View(productCategories);
        }

    }
}
