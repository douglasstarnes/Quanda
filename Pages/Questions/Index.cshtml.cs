using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Quanda.Models;

namespace Quanda.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly QuandaDbContext context;
        public IList<Question> Questions { get; set; }

        public IndexModel(QuandaDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Questions = context.Questions.ToList();
        }
    }
}