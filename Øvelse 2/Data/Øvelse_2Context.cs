using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Øvelse_2.Models;

namespace Øvelse_2.Data
{
    public class Øvelse_2Context : DbContext
    {
        public Øvelse_2Context (DbContextOptions<Øvelse_2Context> options)
            : base(options)
        {
        }

        public DbSet<Øvelse_2.Models.Kage> Kage { get; set; }
    }
}
