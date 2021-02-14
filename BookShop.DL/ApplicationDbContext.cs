using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BookShop.DL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.DL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookModel> Book { get; set; }
        public DbSet<ReviewModel> Review { get; set; }
    }
}
