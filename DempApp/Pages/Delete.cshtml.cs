﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DempApp.Models.DB;

namespace DempApp.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly DemoClientContext _context;

        public DeleteModel(DemoClientContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Employees == null)
            {
                return RedirectToPage("./Index");
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.Id == id);

            if (employee == null)
            {
                return RedirectToPage("./Index");
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Employees == null)
            {
                return RedirectToPage("./Error");
            }
            var employee = await _context.Employees.FindAsync(id);

            if (employee != null)
            {
                Employee = employee;
                _context.Employees.Remove(Employee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
