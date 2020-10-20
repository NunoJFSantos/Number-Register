using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NumberRegister.Model;

namespace NumberRegister.Pages.NumberRegister
{
    public class Upsert : PageModel
    {
        private ApplicationDbContext _db;

        [BindProperty]
        public Number Number { get; set; }
        
        public Upsert(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(int? id)
        {
            Number = new Number();
            if (id == null)
            {
                return Page();
            }

            Number = await _db.Numbers.FindAsync(id);
            if (Number == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Number.Id == 0)
                {
                    _db.Numbers.Add(Number);
                }
                else
                {
                    _db.Numbers.Update(Number);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}