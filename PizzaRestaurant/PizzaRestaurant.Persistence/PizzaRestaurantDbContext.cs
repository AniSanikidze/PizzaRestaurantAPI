using Microsoft.EntityFrameworkCore;
using PizzaRestaurnat.Domain;
using PizzaRestaurnat.Domain.Addresses;
using PizzaRestaurnat.Domain.Pizzas;
using PizzaRestaurnat.Domain.RankHistories;
using PizzaRestaurnat.Domain.Users;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaRestaurant.Persistence
{
    public class PizzaRestaurantDbContext : DbContext
    {
        public PizzaRestaurantDbContext(DbContextOptions<PizzaRestaurantDbContext> options) : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB; Database=PizzaRestaurant; Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>().HasQueryFilter(i => !i.IsDeleted);
            modelBuilder.Entity<Image>()
                .HasOne<Pizza>(i => i.Pizza)
                .WithOne(p => p.Image)
                .HasForeignKey<Image>(i => i.PizzaId);//

            modelBuilder.Entity<Order>()
                .HasOne<User>(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            //

            modelBuilder.Entity<User>()
                .HasMany<Address>(u => u.Addresses)
                .WithOne(a => a.User)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<Order>()
                .HasOne<Address>(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId);//

            modelBuilder.Entity<Order>()
                .HasOne<Pizza>(o => o.Pizza)
                .WithMany(p => p.Orders)
                .HasForeignKey(o => o.PizzaId);//

            modelBuilder.Entity<RankHistory>()
                .HasOne<User>(rh => rh.User)
                .WithMany()
                .HasForeignKey(rh => rh.UserId);

            modelBuilder.Entity<RankHistory>()
                .HasOne<Pizza>(rh => rh.Pizza)
                .WithMany(p => p.RankHistories)
                .HasForeignKey(rh => rh.PizzaId);


                        //modelBuilder.Entity<Entity>().ToTable("Entities")
                        //                .HasValue<Pizza>(1)
                        //.HasValue<>(2)
                        //.HasValue<BroadbandContract>(3);
                        //modelBuilder.Entity<Address>()
                        //    .HasOne<User>(s => s.User)
                        //    .WithMany(u => u.Addresses)
                        //    .HasForeignKey(s => s.UserId);//

            //modelBuilder.Entity<User>()
            //    .MapIn
            //modelBuilder.Entity<Pizza>().ToTable("Pizzas");
            //modelBuilder.Entity<User>().ToTable("Users");
            //modelBuilder.Entity<Image>().ToTable("Images");
            //modelBuilder.Entity<Order>().ToTable("Orders");
            //modelBuilder.Entity<RankHistory>().ToTable("RankHistories");
            //modelBuilder.Entity<Address>().ToTable("Addresses");
            //modelBuilder.Entity<Order>()
            //    .HasOne<Address>(o => o.Address)
            //    .WithMany(a => a.Orders)
            //    .HasForeignKey(o => o.AddressId);

            //modelBuilder.Entity<PizzaOrder>()
            //    .HasKey(po => new { po.PizzaId, po.OrderId });

            //modelBuilder.Entity<PizzaOrder>()
            //    .HasOne<Order>(po => po.Order)
            //    .WithMany(o => o.PizzaOrders)
            //    .HasForeignKey(po => po.OrderId);


            //modelBuilder.Entity<PizzaOrder>()
            //    .HasOne<Pizza>(po => po.Pizza)
            //    .WithMany(p => p.PizzaOrders)
            //    .HasForeignKey(po => po.PizzaId);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RankHistory> RankHistories { get; set; }

        //public DbSet<BaseEntity> BaseEntities { get; set; }

        //public DbSet<PizzaOrder> PizzaOrders { get; set; }  

    }
}
