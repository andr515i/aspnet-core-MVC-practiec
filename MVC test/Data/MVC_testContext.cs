using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_test.Models;

namespace MVC_test.Data
{
    public class MVC_testContext : DbContext
    {
        public MVC_testContext (DbContextOptions<MVC_testContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_test.Models.Mice> Mice { get; set; } = default!;
    }
}
