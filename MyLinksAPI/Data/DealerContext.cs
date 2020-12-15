using Microsoft.EntityFrameworkCore;
using MyLinksAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLinksAPI.Data
{
    public class MyLinkDataContext : DbContext
    {
        public MyLinkDataContext(DbContextOptions<MyLinkDataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<MyLink>().ToTable("MyLink", "DealerPortal");

            //modelBuilder.Entity<MyLink>().ToTable("MyLink", "DealerPortal").Property(p => p.RowVersion).ValueGeneratedOnAddOrUpdate();
            modelBuilder.Entity<MyLink>(entity =>
            {
                entity.ToTable("MyLink", "DealerPortal");
                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedBy).HasMaxLength(50);

                entity.Property(e => e.LastModifiedTime).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(1024);

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.Sponsor).HasMaxLength(50);

                entity.Property(e => e.Url).HasMaxLength(1024);
            });

            modelBuilder.Entity<ExtranetUser>().ToTable("ExtranetUser", "DealerPortal");

        }
        public DbSet<MyLink> MyLinks { get; set; }
        public DbSet<ExtranetUser> ExtranetUsers { get; set; }
    }
}
