using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace News.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
               : base(options)
        { }
    }
}
