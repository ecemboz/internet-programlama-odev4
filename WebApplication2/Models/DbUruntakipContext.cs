using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Models;

public partial class DbUruntakipContext : DbContext
{
    public DbUruntakipContext()
    {
    }

    public DbUruntakipContext(DbContextOptions<DbUruntakipContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9K4NS1H\\SQLEXPRESS;Database=db_uruntakip;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

public DbSet<WebApplication2.Models.TblUrun> TblUrun { get; set; } = default!;

public DbSet<WebApplication2.Models.TblKategoriler> TblKategoriler { get; set; } = default!;
}
