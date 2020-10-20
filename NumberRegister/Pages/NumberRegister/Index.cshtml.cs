using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NumberRegister.Model;

namespace NumberRegister.Pages.NumberRegister
{
    public class Index : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IEnumerable<Number> Numbers { get; set; }

        [BindProperty] 
        public Number Number { get; set; }

        [BindProperty]
        public Sum Sum { get; set; }

        public Index(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task OnGet()
        {
            Numbers = await _db.Numbers.ToListAsync();

            Sum ??= new Sum();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var number = await _db.Numbers.FindAsync(id);

            if (number == null)
            {
                return NotFound();
            }

            _db.Numbers.Remove(number);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }

        public async Task OnPostValueById()
        {
            var number = await _db.Numbers.FindAsync(Number.Id);

            if (number != null)
            {
                Sum.Result += number.InsertedNum;
            }

            Numbers ??= await _db.Numbers.ToListAsync();
            
            Page();
        }

        public async Task OnPostResetResult()
        {
            Sum.Result = 0;

            Numbers ??= await _db.Numbers.ToListAsync();

            Page();
        }
    }
}