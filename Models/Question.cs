using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Quanda.Areas.Identity.Data;

namespace Quanda.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        [Display(Name="Title")]
        [Required]
        public string QuestionTitle { get; set; }
        [Display(Name="Description")]
        [Required]
        public string QuestionText { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}