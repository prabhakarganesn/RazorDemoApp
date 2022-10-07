using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DempApp.Models.DB;

namespace DempApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly DemoClientContext _context;

        public EditModel(DemoClientContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Employees == null)
            {
                return RedirectToPage("./Error");
            }

            var employee =  await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return RedirectToPage("./Error");
            }
            Employee = employee;
           ViewData["EmployeeType"] = new SelectList(_context.EmployeeTypes, "Id", "Type");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Employee.EmployeeTypeNavigation");
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Employee).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.Id))
                {
                    return RedirectToPage("./Error");
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(long id)
        {
          return _context.Employees.Any(e => e.Id == id);
        }
    }
}
