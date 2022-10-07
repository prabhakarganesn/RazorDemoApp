using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DempApp.Models.DB;

namespace DempApp.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly DemoClientContext _context;

        public DetailsModel(DemoClientContext context)
        {
            _context = context;
        }

      public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Employees == null)
            {
                return RedirectToPage("./Error");
            }

            var employee = await _context.Employees.Include(e => e.EmployeeTypeNavigation).FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return RedirectToPage("./Error");
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }
    }
}
