using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DempApp.Models.DB;

namespace DempApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly DemoClientContext _context;

        public CreateModel(DemoClientContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EmployeeType"] = new SelectList(_context.EmployeeTypes, "Id", "Type");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Employee.EmployeeTypeNavigation");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
