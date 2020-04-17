using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quanda.Areas.Identity.Data;
using Quanda.Models;

namespace Quanda.Pages.Questions
{
    public class CreateModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        private readonly UserManager<Author> userManager;

        [BindProperty]
        public Question Question { get; set; }

        public CreateModel(QuandaIdentityDbContext context, UserManager<Author> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            Question.Author = await userManager.GetUserAsync(User);
            Question.Created = Question.Edited = DateTime.Now;
            context.Questions.Add(Question);
            context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}