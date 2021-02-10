using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mihai_Andreea_project.Models;

namespace Mihai_Andreea_project.Data
{
    public class Mihai_Andreea_projectContext : DbContext
    {
        public Mihai_Andreea_projectContext (DbContextOptions<Mihai_Andreea_projectContext> options)
            : base(options)
        {
        }

        public DbSet<Mihai_Andreea_project.Models.Song> Song { get; set; }

        public DbSet<Mihai_Andreea_project.Models.RecordLabel> RecordLabel { get; set; }

        public DbSet<Mihai_Andreea_project.Models.Genre> Genre { get; set; }
    }
}
