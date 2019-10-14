using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MvcLocalization.Models
{
    public class MvcLocalizationContext : DbContext
    {
        public MvcLocalizationContext (DbContextOptions<MvcLocalizationContext> options)
            : base(options)
        {
        }

        public DbSet<MvcLocalization.Models.User> User { get; set; }
    }
}
