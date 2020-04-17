using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quanda.Areas.Identity.Data;

namespace Quanda.Models
{
    public class Answer
    {
        public int AnswerId { get; set; }
        [Display(Name = "Answer")]
        [Required]
        public string AnswerText { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public IList<Rating> Ratings { get; set; }
    }
}