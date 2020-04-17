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

namespace Quanda.Pages.Answers
{
    public class RateModel : PageModel
    {
        private readonly QuandaIdentityDbContext context;
        private readonly UserManager<Author> userManager;
        public Answer Answer { get; set; }

        public RateModel(QuandaIdentityDbContext context, UserManager<Author> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        public void OnGet(int answerId)
        {
            Answer = context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
        }

        public async Task<IActionResult> OnPost(int answerId)
        {
            var author = await userManager.GetUserAsync(User);
            var answer = context.Answers.Include(a => a.Question).FirstOrDefault(a => a.AnswerId == answerId);
            var existingRating = context.Ratings.Where(r => r.Author == author).FirstOrDefault(r => r.QuestionId == answer.QuestionId);

            if (existingRating != null)
            {
                context.Ratings.Remove(existingRating);
            }

            var newRating = new Rating{
                Created = DateTime.Now,
                Author = author,
                Answer = answer,
                Question = answer.Question
            };
            context.Ratings.Add(newRating);
            context.SaveChanges();
            return RedirectToPage("../Questions/Details", new { questionId = answer.Question.QuestionId });
        }
    }
}