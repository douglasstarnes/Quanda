using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Quanda.Models;

namespace Quanda.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the Author class
    public class Author : IdentityUser
    {
        public IList<Question> Questions { get; set; }
        public IList<Answer> Answers { get; set; }
    }
}
