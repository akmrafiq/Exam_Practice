using System;
using System.Collections.Generic;
using System.Text;
using Exam_Practice.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam_Practice.Core.Contexts
{
    public class ExamContext :DbContext, IExamContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;
        public ExamContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductImage>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductImages)
                .HasForeignKey(pi => pi.ProductId);
        }
        public DbSet<Product> Products { get ; set ; }
        public DbSet<ProductImage> ProductImages { get; set ; }
    }
}
