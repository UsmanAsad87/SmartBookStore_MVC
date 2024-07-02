using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SmartBookStoreRazor_Temp.Data;
using SmartBookStoreRazor_Temp.Models;

namespace SmartBookStoreRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
       
        public Category category { get; set; }
        public EditModel(ApplicationDbContext db)
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
            if(ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
          
        }
    }
}
