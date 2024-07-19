
using ApiBookTest.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
namespace ApiBookTest.Models;

public partial class BDBookTestContext : DbContext
{
    public BDBookTestContext()
    {
    }

    public BDBookTestContext(DbContextOptions<BDBookTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<authors> authors { get; set; }

    public virtual DbSet<books> books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Persist Security Info=True;Username=postgres;Password=enter12345;Database=BDBookTest;Host=localhost");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.authorsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.booksConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
