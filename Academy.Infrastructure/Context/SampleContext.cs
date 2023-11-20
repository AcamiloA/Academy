using System;
using System.Collections.Generic;
using Academy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Academy.Infrastructure.Context;

public partial class SampleContext : DbContext
{
    public SampleContext(DbContextOptions<SampleContext> options) : base(options) {}


    public virtual DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.HasIndex(e => e.Username, "IX_Student_Username").IsUnique();

            entity.Property(e => e.Career).HasColumnType("VARCHAR(50)");
            entity.Property(e => e.FirstName).HasColumnType("VARCHAR(20)");
            entity.Property(e => e.LastName).HasColumnType("VARCHAR(20)");
            entity.Property(e => e.Username).HasColumnType("VARCHAR(20)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
