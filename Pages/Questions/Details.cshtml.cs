using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quanda.Areas.Identity.Data;
using Quanda.Models;

namespace Quanda.Pages_Questions
{
    public class DetailsModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        public Question Question { get; set; }

        public DetailsModel(QuandaIdentityDbContext context)
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
    }
}