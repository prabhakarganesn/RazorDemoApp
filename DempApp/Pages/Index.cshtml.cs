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
    public class IndexModel : PageModel
    {
        private readonly DemoClientContext _context;

        public IndexModel(DemoClientContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees
                .Include(e => e.EmployeeTypeNavigation).ToListAsync();
            }
        }
    }
}
