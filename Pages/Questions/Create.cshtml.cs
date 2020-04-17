using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quanda.Areas.Identity.Data;
using Quanda.Models;

namespace Quanda.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        [BindProperty]
        public Question Question { get; set; }

        public CreateModel(QuandaIdentityDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            Question.Created = Question.Edited = DateTime.Now;
            context.Questions.Add(Question);
            context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}