﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using ApiBookTest.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

#nullable disable

namespace ApiBookTest.Models.Configurations
{
    public partial class booksConfiguration : IEntityTypeConfiguration<books>
    {
        public void Configure(EntityTypeBuilder<books> entity)
        {
            entity.HasKey(e => e.id).HasName("books_pkey");

            entity.Property(e => e.title).HasMaxLength(200);

            entity.HasOne(d => d.author).WithMany(p => p.books)
                .HasForeignKey(d => d.author_id)
                .HasConstraintName("books_author_id_fkey");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<books> entity);
    }
}
