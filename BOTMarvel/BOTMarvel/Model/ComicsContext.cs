using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BOTMarvel.Model
{
    public partial class ComicsContext : DbContext
    {
        public ComicsContext()
        {
        }

        public ComicsContext(DbContextOptions<ComicsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FavouriteComic> FavouriteComics { get; set; } = null!;
        public virtual DbSet<ViewedComic> ViewedComics { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FavouriteComic>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ComicId })
                    .HasName("PK__Favourit__EC07C54A0C9DC069");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
