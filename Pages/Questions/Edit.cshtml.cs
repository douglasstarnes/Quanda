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
    public class EditModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        [BindProperty]
        public Question Question { get; set; }

        public EditModel(QuandaIdentityDbContext context)
        {
            this.context = context;
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

        public IActionResult OnPost(int questionId)
        {
            Question.Edited = DateTime.Now;

            context.Questions.Update(Question);
            context.SaveChanges();

            return RedirectToPage("./Details", new { questionId = questionId });
        }
    }
}