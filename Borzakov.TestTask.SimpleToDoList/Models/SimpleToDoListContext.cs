using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Borzakov.TestTask.SimpleToDoList.Models
{
    public partial class SimpleToDoListContext : DbContext
    {
        public virtual DbSet<TaskToDo> TaskToDo { get; set; }

        public SimpleToDoListContext(DbContextOptions<SimpleToDoListContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskToDo>(entity =>
            {
                entity.HasKey(e => e.TaskId)
                    .HasName("PK_TaskToDo");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("nchar(50)");
            });
        }
    }
}