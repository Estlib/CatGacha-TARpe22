using CatGacha.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CatGacha.Data
{
    public class CatGachaContext : IdentityDbContext<ApplicationUser>
    {
        public CatGachaContext(DbContextOptions<CatGachaContext> options) : base(options)
        { }
            public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}

