using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace raion.Models.DbModels
{
    public class DbAppContext : IdentityDbContext<User>
    {
        public DbAppContext(DbContextOptions<DbAppContext> options)
            : base(options)
        {
            
        }


    }
}
