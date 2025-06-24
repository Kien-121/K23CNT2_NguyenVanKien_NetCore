using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace nvklesson10.Models;

public partial class NvkK23cnt2lesson10CbContext : DbContext
{
    public NvkK23cnt2lesson10CbContext()
    {
    }

    public NvkK23cnt2lesson10CbContext(DbContextOptions<NvkK23cnt2lesson10CbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MSI;Database=NvkK23CNT2lesson10CB;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CateId);

            entity.ToTable("Company");

            entity.Property(e => e.CateId)
                .ValueGeneratedNever()
                .HasColumnName("CateID");
            entity.Property(e => e.CateName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
