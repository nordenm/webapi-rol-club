using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rolClubApi.Models
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Play> Plays { get; set; }
        public virtual DbSet<PlayerPlay> PlayerPlays { get; set; }
    }
}
