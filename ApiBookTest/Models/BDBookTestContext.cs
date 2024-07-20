
using ApiBookTest.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace ApiBookTest.Models;

public partial class BDBookTestContext : DbContext
{
    public BDBookTestContext(DbContextOptions<BDBookTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<authors> authors { get; set; }

    public virtual DbSet<books> books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.authorsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.booksConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
