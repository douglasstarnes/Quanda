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
    public class EditModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        private readonly UserManager<Author> userManager;

        [BindProperty]
        public Question Question { get; set; }

        public EditModel(QuandaIdentityDbContext context, UserManager<Author> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public async Task<IActionResult> OnGet(int questionId)
        {
            Question = context.Questions.FirstOrDefault(q => q.QuestionId == questionId);

            var author = await userManager.GetUserAsync(User);

            if (author.Id != Question.AuthorId)
            {
                return RedirectToPage("../Shared/ErrorNotAuthorized");
            }

            if (Question == null)
            {
                return RedirectToPage("../Shared/ErrorNotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int questionId)
        {
            Question.Edited = DateTime.Now;

            var author = await userManager.GetUserAsync(User);

            if (author.Id != Question.AuthorId)
            {
                return RedirectToPage("../Shared/ErrorNotAuthorized");
            }

            context.Questions.Update(Question);
            context.SaveChanges();

            return RedirectToPage("./Details", new { questionId = questionId });
        }
    }
}