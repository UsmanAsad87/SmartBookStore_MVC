using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBookStoreRazor_Temp.Data;
using SmartBookStoreRazor_Temp.Models;

namespace SmartBookStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int? id)
        {
            if (id == null || id == 0)
            {
                return;
            }
            Category? cat = _db.Categories.Find(id);
            if (cat != null)
            {
                category = cat;
            }
        }

        public IActionResult OnPost()
        {
            Category? obj = _db.Categories.Find(category.Id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";

            return RedirectToPage("Index");
         
        }
    }
}
