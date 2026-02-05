using Microsoft.EntityFrameworkCore;
using MiniBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniBanking.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<TestUser> TestUsers { get; set; }

        /*
         OnModelCreating, veritabanında tablolar oluşturulurken 1 kere çağırılır ve
        tablonun hangi kurallara sahip olacağını belirtir.
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TestUser>(b =>
            {
                /*
                 * HasKey => Id'nin primary key olduğunu belirtiyor. 
                 * IsRequired   => Email alanının zorunlu property olduğunu belirtiyor
                 * HasIndex => Email için benzersiz bir index oluşturuyor. Bu sayede aynı email
                 *  2 kez eklenmez. ayrıca get işlemleri de daha hızlı yapılır.
                 */

                b.HasKey(x => x.Id);
                b.Property(x => x.Email).IsRequired().HasMaxLength(200);
                b.HasIndex(x => x.Email).IsUnique();
            });
        }
    }
}
