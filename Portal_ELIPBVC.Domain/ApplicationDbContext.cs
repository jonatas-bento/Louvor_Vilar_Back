using Microsoft.EntityFrameworkCore;
using Portal_ELIPBVC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal_ELIPBVC.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions options) :
            base(options)
        {
        }
        public DbSet<Ensaio> Ensaios { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Membro> Membros { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
    }
}
