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
    public class IndexModel : PageModel
    {
        private readonly CustomerDbContext _dbContext;
        public IndexModel(CustomerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Viewable Data
        public List<Customer> Customers { get; set; }

        public async Task OnGetAsync()
        {
            Customers = await _dbContext.Customers.ToListAsync();
        }
        
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var contact = await _dbContext.Customers.FindAsync(id);
            if(contact!=null)
            {
                _dbContext.Customers.Remove(contact);
                await _dbContext.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }
}
