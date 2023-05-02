using Microsoft.EntityFrameworkCore;
using SchoolManagement.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    {        
    }
    public virtual DbSet<Teacher> Teacher { get; set; }
    public virtual DbSet<Management> Management { get; set; }
    public virtual DbSet<Student> Student { get; set; }
    public virtual DbSet<Course> Course { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Management>()
        .HasMany(t => t.Teacher)
        .WithOne(m => m.Managements)
        .HasForeignKey(fk => fk.ManagementId);
      modelBuilder.Entity<Teacher>()
        .HasMany(c => c.Courses)
        .WithOne(t => t.Teacher)
        .HasForeignKey(fk => fk.TeacherId);

      
    }
  }
}
