using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using The_Powerpointer.Models;
using The_Powerpointer.Models.Joiners;

namespace The_Powerpointer.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<UserNews>().HasKey(t => new { t.ApplicationUserId, t.NewsId });
            builder.Entity<UserNews>()
                .HasOne(un => un.ApplicationUser)
                .WithMany(u => u.News)
                .HasForeignKey(un => un.ApplicationUserId);
            builder.Entity<UserNews>().HasOne(un => un.News).WithMany(n => n.Users).HasForeignKey(un => un.NewsId);

            builder.Entity<UserPicture>().HasKey(t => new {t.ApplicationUserId, t.PictureId});
            builder.Entity<UserPicture>()
                .HasOne(up => up.ApplicationUser)
                .WithMany(u => u.Pictures)
                .HasForeignKey(un => un.ApplicationUserId);
            builder.Entity<UserPicture>()
                .HasOne(up => up.Picture)
                .WithMany(p => p.Users)
                .HasForeignKey(up => up.PictureId);

            builder.Entity<UserSong>().HasKey(t => new { t.ApplicationUserId, t.SongId });
            builder.Entity<UserSong>()
                .HasOne(us => us.ApplicationUser)
                .WithMany(u => u.Songs)
                .HasForeignKey(us => us.ApplicationUserId);
            builder.Entity<UserSong>()
                .HasOne(us => us.Song)
                .WithMany(s => s.Users)
                .HasForeignKey(us => us.SongId);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Picture> Pictures { get; set; }

        public DbSet<UserPicture> UserPictures { get; set; }
        public DbSet<UserNews> UserNews { get; set; }
        public DbSet<UserSong> UserSongs { get; set; }
    }
}
