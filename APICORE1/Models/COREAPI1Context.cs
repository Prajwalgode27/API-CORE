using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APICORE1.Models
{
    public partial class COREAPI1Context : DbContext
    {
        public COREAPI1Context()
        {
        }

        public COREAPI1Context(DbContextOptions<COREAPI1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TblRegistration> TblRegistration { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-SK681UQ\\SQLEXPRESS02;Database=COREAPI1;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblRegistration>(entity =>
            {
                entity.ToTable("tblRegistration");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        internal IEnumerable<object> GetAll()
        {
            throw new NotImplementedException();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
