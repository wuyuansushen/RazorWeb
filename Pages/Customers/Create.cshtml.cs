using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWeb.Data;
using RazorWeb.Models;

namespace RazorWeb.Pages.Customers
{
    public class CreateModel : PageModel
    {
        private readonly CustomerDbContext _context;
        public CreateModel(CustomerDbContext context)
        {
            _context = context;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer ACustomer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!this.ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(ACustomer);
            await _context.SaveChangesAsync();
            return RedirectToPage("/index");
        }
    }
}
