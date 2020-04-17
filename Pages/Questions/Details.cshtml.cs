using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Quanda.Areas.Identity.Data;
using Quanda.Models;

namespace Quanda.Pages_Questions
{
    public class DetailsModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        private readonly UserManager<Author> userManager;

        public Question Question { get; set; }
        public Author Author { get; set; }

        public DetailsModel(QuandaIdentityDbContext context, UserManager<Author> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> OnGet(int questionId)
        {
            Question = context.Questions.Include(q => q.Answers).Include(q => q.Author).FirstOrDefault(q => q.QuestionId == questionId);
            Author = await userManager.GetUserAsync(User);
            if (Question == null)
            {
                return RedirectToPage("../Shared/ErrorNotFound");
            }

            return Page();
        }
    }
}