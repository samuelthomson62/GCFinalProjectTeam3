using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using Microsoft.AspNetCore.Identity;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<IdentityUser> TimesDoneBefore { get; set; }
        public DbSet<IdentityUser> BodyBuild { get; set; }
        public DbSet<IdentityUser> PreExistingCondition { get; set; }
        public DbSet<IdentityUser> City { get; set; }
        public DbSet<IdentityUser> State { get; set; }
        public DbSet<IdentityUser> ZipCode { get; set; }
        public DbSet<IdentityUser> difficulty { get; set; }


    }
}
