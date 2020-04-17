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
    public class DeleteModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        private readonly UserManager<Author> userManager;

        public Question Question { get; set; }

        public DeleteModel(QuandaIdentityDbContext context, UserManager<Author> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> OnGet(int questionId)
        {
            Question = context.Questions.FirstOrDefault(q => q.QuestionId == questionId);

            if (Question == null)
            {
                return RedirectToPage("../Shared/ErrorNotFound");
            }

            var author = await userManager.GetUserAsync(User);

            if (author.Id != Question.AuthorId)
            {
                return RedirectToPage("../Shared/ErrorNotAuthorized");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int questionId)
        {
            Question = context.Questions.FirstOrDefault(q => q.QuestionId == questionId);

            var author = await userManager.GetUserAsync(User);

            if (author.Id != Question.AuthorId)
            {
                return RedirectToPage("../Shared/ErrorNotAuthorized");
            }

            context.Questions.Remove(Question);
            context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}