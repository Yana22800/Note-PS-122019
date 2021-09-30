using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hi.Models;

namespace Hi.Contexts
{
    public class HiContext : DbContext
    {
        public HiContext (DbContextOptions<HiContext> options)
            : base(options)
        {
        }

        public DbSet<NoteY> NoteY { get; set; }
    }
}
