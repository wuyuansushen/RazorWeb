using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWeb.Data;
using RazorWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace RazorWeb.Pages.Customers
{
    public class EditModel : PageModel
    {
        private readonly CustomerDbContext _dbContext;
        
        public EditModel(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Customer Customer { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _dbContext.Customers.FindAsync(id);
            if (Customer == null)
                return RedirectToPage("./index");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
                return Page();
            _dbContext.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new Exception($"Customer {Customer.Id} not found! Details:{e.Message}");
            }
            return RedirectToPage("./index");
        }
    }
}
