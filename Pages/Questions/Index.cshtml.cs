using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Quanda.Areas.Identity.Data;
using Quanda.Models;

namespace Quanda.Pages.Questions
{
    public class IndexModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        public IList<Question> Questions { get; set; }

        public IndexModel(QuandaIdentityDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Questions = context.Questions.Include(q => q.Answers).Include(q => q.Ratings).ToList();
        }
    }
}