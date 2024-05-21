using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;
using Iss.Entity;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using Backend.Models;
=======
using RestApi_ISS.Entity;
>>>>>>> 0c3f6aaea50b365d27407121d435afea6f07cc95

namespace Iss.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Ad> Ad { get; set; }
        public DbSet<AdAccount> AdAccount { get; set; }
        public DbSet<AdSet> AdSet { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Collaboration> Collaboration { get; set; }
        public DbSet<Influencer> Influencer { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }

        public DatabaseContext()
        {
        }
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Product { get; set; }

        public DbSet<ReviewClass> Review { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
<<<<<<< HEAD
            optionsBuilder.UseSqlServer("Data Source = DESKTOP-56RUGQC\\SQLEXPRESS; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;");
=======
            optionsBuilder.UseSqlServer("Data Source = .\\SQLEXPRESS; Initial Catalog = db_ISS; Integrated Security = True; TrustServerCertificate=True;");
>>>>>>> 0c3f6aaea50b365d27407121d435afea6f07cc95
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ad>()
                .Property(a => a.AdId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ad>()
                .Property(a => a.AdSetId)
                .IsRequired(false);

            modelBuilder.Entity<AdAccount>()
                .Property(a => a.AdAccountId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AdSet>()
                .Property(a => a.AdSetId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AdSet>()
                .Property(a => a.CampaignId)
                .IsRequired(false);

            modelBuilder.Entity<Campaign>()
                .Property(c => c.CampaignId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Collaboration>()
                .Property(c => c.CollaborationId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Influencer>()
                .Property(i => i.InfluencerId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Request>()
                .Property(r => r.RequestId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Campaign>()
                .HasOne(campaign => campaign.AdAccount)
                .WithMany(adAccount => adAccount.Campaigns)
                .HasForeignKey(campaign => campaign.AdAccountId)
                .OnDelete(DeleteBehavior.Restrict);

<<<<<<< HEAD
            modelBuilder.Entity<ReviewClass>()
                .HasNoKey();

            modelBuilder.Entity<ReviewClass>()
                .Property(a => a.User)
=======
            modelBuilder.Entity<BankAccount>()
                .Property(i => i.Id)
>>>>>>> 0c3f6aaea50b365d27407121d435afea6f07cc95
                .ValueGeneratedOnAdd();
        }
    }
}