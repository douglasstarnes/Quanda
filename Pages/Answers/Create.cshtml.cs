using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quanda.Areas.Identity.Data;
using Quanda.Models;

namespace Quanda.Pages.Answers
{
    public class CreateModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        private readonly UserManager<Author> userManager;

        public Question Question { get; set; }
        [BindProperty]
        public Answer Answer { get; set; }

        public CreateModel(QuandaIdentityDbContext context, UserManager<Author> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public IActionResult OnGet(int questionId)
        {
            Question = context.Questions.FirstOrDefault(q => q.QuestionId == questionId);

            if (Question == null)
            {
                return RedirectToPage("../Shared/ErrorNotFound");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int questionId)
        {
            var author = await userManager.GetUserAsync(User);

            Answer.Created = DateTime.Now;
            Answer.Edited = DateTime.Now;

            Answer.QuestionId = questionId;
            Answer.Author = author;

            context.Answers.Add(Answer);
            context.SaveChanges();

            return RedirectToPage("../Questions/Details", new { questionId = questionId });
        }
    }
}