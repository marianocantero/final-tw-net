using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalTwitter.Models
{
    public class TweetCtx : DbContext
    {
        public TweetCtx(DbContextOptions<TweetCtx> options)
            : base(options)
        { }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Siguiendo> Siguiendo { get; set; }
        public DbSet<Like> Likes{get;set;}
    }
}
