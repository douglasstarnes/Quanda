using System;
using Quanda.Areas.Identity.Data;

namespace Quanda.Models
{
    public class Rating
    {
        public int AnswerId { get; set; }
        public Answer Answer { get; set; }
        public string AuthorId { get; set; }
        public Author Author { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public DateTime Created { get; set; }
    }
}