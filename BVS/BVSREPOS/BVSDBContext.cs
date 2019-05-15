using System;
using BVS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BVS.Data
{
    public class BVSDBContext : DbContext
    {
        public DbSet<Order> Orders;
        public DbSet<StorageWorker> StorageWorkers;
        public DbSet<Worker> Workers;
        public DbSet<User> Users;
        public DbSet<Subscription> Subscription;
        public DbSet<ATM> ATMs;
        public DbSet<ATM_Part> ATM_Parts;
        public DbSet<ATM_Transport> ATM_Transports;
        public DbSet<ATM_Message> atmMessages;
        public DbSet<InformationalMessage> InformationalMessages;
        public DbSet<AttentionNeededMessage> attentionNeededMessages;
        public DbSet<UserReport> UserReports;
        public DbSet<Report> Reports;
        public DbSet<Rack> Racks;
        public DbSet<Job> Jobs;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>();
            modelBuilder.Entity<ATM>();
            modelBuilder.Entity<ATM_Message>();
            modelBuilder.Entity<ATM_Part>();
            modelBuilder.Entity<ATM_Transport>();
            modelBuilder.Entity<AttentionNeededMessage>();
            modelBuilder.Entity<Cartridge>();
            modelBuilder.Entity<EmptyCasseteMessage>();
            modelBuilder.Entity<InformationalMessage>();
            modelBuilder.Entity<Job>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<OrderedPart>().HasKey(x => new { x.PartId, x.OrderId });
            modelBuilder.Entity<PartBrokenMessage>();
            modelBuilder.Entity<PartInStorage>().HasKey(x => new {x.PartId, x.RackId});
            modelBuilder.Entity<Rack>();
            modelBuilder.Entity<Report>();
            modelBuilder.Entity<StorageWorker>();
            modelBuilder.Entity<Subscription>().HasKey(x => new {x.UserId, x.ATMId});
            modelBuilder.Entity<User>();
            modelBuilder.Entity<UserReport>();
            modelBuilder.Entity<Worker>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
