using System;
using System.ComponentModel.DataAnnotations;

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
    }
}