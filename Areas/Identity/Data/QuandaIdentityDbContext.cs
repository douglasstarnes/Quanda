using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quanda.Areas.Identity.Data;
using Quanda.Models;

namespace Quanda.Areas.Identity.Data
{
    public class QuandaIdentityDbContext : IdentityDbContext<Author>
    {
        public QuandaIdentityDbContext(DbContextOptions<QuandaIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Rating>()
                .HasKey(r => new { r.AnswerId, r.AuthorId });
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}
