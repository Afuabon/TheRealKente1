using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheRealKente.Models;

namespace TheRealKente.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public ApplicationDbContext()
        //{

        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
             public DbSet<Kente> Kentes { get; set; }
        
           
    }
            
        
    
}
