using BVS.Data.Models;
using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;

namespace BVS.Data
{
    public class BVSDBContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<StorageWorker> StorageWorkers { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscription { get; set; }
        public DbSet<ATM> ATMs { get; set; }
        public DbSet<ATM_Part> ATM_Parts { get; set; }
        public DbSet<ATM_Transport> ATM_Transports { get; set; }
        public DbSet<ATM_Message> atmMessages { get; set; }
        public DbSet<InformationalMessage> InformationalMessages { get; set; }
        public DbSet<AttentionNeededMessage> attentionNeededMessages { get; set; }
        public DbSet<UserReport> UserReports { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<Job> Jobs { get; set; }

        public BVSDBContext() : base()
        {

        }

        public BVSDBContext(DbContextOptions<BVSDBContext> context) : base(context)
        {
        }

        private void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator()
                {
                    Id = -1,
                    Name = "Karolis",
                    Surname = "Breidokas",
                    Email = "karolis.breidokas@ktu.edu",
                    Username = "Root",
                    Password = "$2a$10$wXKjdScgnoSGL6jFFDxSD.pngMcqRZZaPyRpUYFX7kdV/964qMMGe"
                }
            );
            modelBuilder.Entity<ATM_Part>().HasData(
            //Insert ATM_Part Here
            );
            modelBuilder.Entity<Cartridge>().HasData(
            //Insert Cartridge Here
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>();
            modelBuilder.Entity<ATM>()
                .HasMany(x => x.Transportations)
                .WithOne(x => x.Transported)
                .HasForeignKey(x => x.AtmId);
            modelBuilder.Entity<ATM_Message>()
                .HasOne(x=>x.Autor)
                .WithMany()
                .HasForeignKey(x=>x.AuthorId);
            modelBuilder.Entity<ATM_Part>();
            modelBuilder.Entity<ATM_Transport>();
            modelBuilder.Entity<AttentionNeededMessage>();
            modelBuilder.Entity<Cartridge>();
            modelBuilder.Entity<EmptyCasseteMessage>()
                .HasOne(x => x.Cartridge)
                .WithOne()
                .HasForeignKey<EmptyCasseteMessage>(x => x.CartridgeId);
            modelBuilder.Entity<InformationalMessage>();
            var jobEntity = modelBuilder.Entity<Job>();
            jobEntity.HasMany(x => x.Reports)
                .WithOne(x => x.Job)
                .HasForeignKey(x => x.JobId);
            jobEntity.HasOne(x => x.AssignedWorker)
                .WithMany(x => x.AssignedJobs)
                .HasForeignKey(x => x.WorkerId);
            jobEntity.HasOne(x => x.Reason)
                .WithOne()
                .HasForeignKey<Job>(x => x.MessageId);
            var orderEntity= modelBuilder.Entity<Order>();
            orderEntity.HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorId);
            orderEntity.HasMany(x => x.Parts)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.PartId);
            var orderedPartEntity= modelBuilder.Entity<OrderedPart>();
            orderedPartEntity.HasKey(x => new { x.PartId, x.OrderId });
            orderedPartEntity.HasOne(x => x.Order)
                .WithMany(x => x.Parts)
                .HasForeignKey(x => x.OrderId);
            orderedPartEntity.HasOne(x => x.Part)
                .WithMany()
                .HasForeignKey(x => x.PartId);
            modelBuilder.Entity<PartBrokenMessage>()
                .HasOne(x => x.Part)
                .WithOne().HasForeignKey<PartBrokenMessage>(x => x.PartId);
            var partStorageEntity=modelBuilder.Entity<PartInStorage>();
            partStorageEntity.HasKey(x => new {x.PartId, x.RackId});
            partStorageEntity.HasOne(x => x.parts)
                .WithMany()
                .HasForeignKey(x => x.PartId);
            partStorageEntity.HasOne(x => x.racks)
                .WithMany()
                .HasForeignKey(x => x.RackId);
            modelBuilder.Entity<Rack>();
            modelBuilder.Entity<Report>();
            modelBuilder.Entity<StorageWorker>();
            var subscriptionEntity = modelBuilder.Entity<Subscription>();
            subscriptionEntity.HasKey(x => new { x.UserId, x.ATMId });
            subscriptionEntity.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
            subscriptionEntity.HasOne(x => x.SubscribedATM)
                .WithMany()
                .HasForeignKey(x => x.ATMId);
            modelBuilder.Entity<User>();
            modelBuilder.Entity<UserReport>()
                .HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Worker>();
            Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
