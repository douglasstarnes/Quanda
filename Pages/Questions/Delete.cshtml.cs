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
    public class DeleteModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        public Question Question { get; set; }

        public DeleteModel(QuandaIdentityDbContext context)
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
            Question = context.Questions.FirstOrDefault(q => q.QuestionId == questionId);

            context.Questions.Remove(Question);
            context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}