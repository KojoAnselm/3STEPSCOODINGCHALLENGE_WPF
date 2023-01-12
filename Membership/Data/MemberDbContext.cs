using Membership.Model;
using Microsoft.EntityFrameworkCore;

namespace Membership.Data
{
    public class MemberDbContext : DbContext
    {
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(
          DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=members.db");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasData(
            new Member {Id = 1, MemberId = "001f7563", Name = "Kesewaa Rebecca", Gender = "female", Town = "Boakyekrom ", GPS = "EQ-06874-3749" },
            new Member {Id = 2, MemberId = "1961451", Name = "SULLY KOFI ", Gender = "male", Town = "Konongo ", GPS = "EQ-05536-6642" },
            new Member {Id = 3, MemberId = "01ce3c70", Name = "SAMUEL OWARE IGNATUS", Gender = " male", Town = "Atebubu", GPS = "EQ-05539-4751" },
            new Member {Id = 4, MemberId = "060cf83d", Name = " KWASI ADEI", Gender = "male", Town = "TEPA", GPS = "EQ-05763-3963" },
            new Member {Id = 5, MemberId = "0a89996b", Name = "BERNICE DAAFOR", Gender = "female", Town = "Techiman", GPS = "EQ-05538-9090" },
            new Member {Id = 6, MemberId = "0c1383dd", Name = "DAVID KWAKU NAASI", Gender = "male", Town = "Techiman", GPS = "EQ-04451-9346" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
