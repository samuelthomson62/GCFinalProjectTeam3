using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> TimesDoneBefore { get; set; }
        public DbSet<ApplicationUser> BodyBuild { get; set; }
        public DbSet<ApplicationUser> PreExistingCondition { get; set; }
    }
}
