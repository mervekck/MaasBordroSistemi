using Microsoft.EntityFrameworkCore;
using PP.Entity.Concrete;

namespace PP.Context
{
    public class PayrollDbContext : DbContext
    {
        public PayrollDbContext(DbContextOptions<PayrollDbContext> options): base(options)
        {
        }
        public virtual DbSet<Memur> Memurlar { get; set; }
        public virtual DbSet<Yonetici> Yoneticiler { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=.;database=PayrollDb;uid=sa;pwd=123;trustservercertificate=true");
            }
        }
    }
}