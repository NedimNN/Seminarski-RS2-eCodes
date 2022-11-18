using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eCodes.Services.Database
{
    public partial class _210331Context : DbContext
    {
        public _210331Context(DbContextOptions<_210331Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyers { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<LoyaltyPoint> LoyaltyPoints { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Output> Outputs { get; set; } = null!;
        public virtual DbSet<OutputItem> OutputItems { get; set; } = null!;
        public virtual DbSet<Person> Persons { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductType> ProductTypes { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buyer>(entity =>
            {
                entity.HasIndex(e => e.PersonId, "IX_Buyers_PersonID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.PasswordSalt).HasMaxLength(50);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Buyers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Buyers_Persons");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "IX_Cities_CountryID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cities_Countries");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.Abbreviation).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.PersonId, "IX_Employees_PersonID");

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.DateOfEmployement).HasColumnType("datetime");

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.PasswordSalt).HasMaxLength(50);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Persons");
            });

            modelBuilder.Entity<LoyaltyPoint>(entity =>
            {
                entity.HasKey(e => e.LoyaltyPointsId);

                entity.HasIndex(e => e.BuyerId, "IX_LoyaltyPoints_BuyerID");

                entity.Property(e => e.LoyaltyPointsId).HasColumnName("LoyaltyPointsID");

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.LoyaltyPoints)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LoyaltyPoints_Buyers");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasIndex(e => e.BuyerId, "IX_Notifications_BuyerID");

                entity.Property(e => e.NotificationId).HasColumnName("NotificationID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.NotificationDateTime).HasColumnType("datetime");

                entity.Property(e => e.NotificationDesc).HasMaxLength(200);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notifications_Buyers");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasIndex(e => e.BuyerId, "IX_Orders_BuyerID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.OrderNumber).HasMaxLength(20);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Buyers");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasIndex(e => e.OrderId, "IX_OrderItems_OrderID");

                entity.HasIndex(e => e.ProductId, "IX_OrderItems_ProductID");

                entity.Property(e => e.OrderItemId).HasColumnName("OrderItemID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItems_Products");
            });

            modelBuilder.Entity<Output>(entity =>
            {
                entity.HasIndex(e => e.BuyerId, "IX_Outputs_BuyerID");

                entity.HasIndex(e => e.OrderId, "IX_Outputs_OrderID");

                entity.Property(e => e.OutputId).HasColumnName("OutputID");

                entity.Property(e => e.AmountWithTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.AmountWithoutTax).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PaymentMethod).HasMaxLength(50);

                entity.Property(e => e.ReceiptNumber).HasMaxLength(50);

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Outputs_Buyers");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Outputs_Orders");
            });

            modelBuilder.Entity<OutputItem>(entity =>
            {
                entity.HasKey(e => e.OutputItemsId);

                entity.HasIndex(e => e.OutputId, "IX_OutputItems_OutputID");

                entity.HasIndex(e => e.ProductId, "IX_OutputItems_ProductID");

                entity.HasIndex(e => e.SellerId, "IX_OutputItems_SellerID");

                entity.Property(e => e.OutputItemsId).HasColumnName("OutputItemsID");

                entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.OutputId).HasColumnName("OutputID");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.HasOne(d => d.Output)
                    .WithMany(p => p.OutputItems)
                    .HasForeignKey(d => d.OutputId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputItems_Outputs");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OutputItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputItems_Products");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.OutputItems)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OutputItems_Sellers");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.CityId, "IX_Persons_CityID");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(20);

                entity.Property(e => e.Jmbg)
                    .HasMaxLength(50)
                    .HasColumnName("JMBG");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persons_Cities");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProductTypeId, "IX_Products_ProductTypeID");

                entity.HasIndex(e => e.SellerId, "IX_Products_SellerID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.Code).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Duration).HasMaxLength(50);

                entity.Property(e => e.GiftCardKey).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Platform).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.StateMachine).HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(50);

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_ProductTypes");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK_Products_Sellers");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.HasIndex(e => e.CurrencyId, "IX_ProductTypes_CurrencyID");

                entity.Property(e => e.ProductTypeId).HasColumnName("ProductTypeID");

                entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Region).HasMaxLength(50);

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.ProductTypes)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductTypes_Currencies");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasIndex(e => e.BuyerId, "IX_Ratings_BuyerID");

                entity.HasIndex(e => e.ProductId, "IX_Ratings_ProductID");

                entity.HasIndex(e => e.SellerId, "IX_Ratings_SellerID");

                entity.Property(e => e.RatingId).HasColumnName("RatingID");

                entity.Property(e => e.BuyerId).HasColumnName("BuyerID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Mark).HasColumnType("decimal(18, 1)");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.HasOne(d => d.Buyer)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.BuyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ratings_Buyers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ratings_Products");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.SellerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ratings_Sellers");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasIndex(e => e.PersonId, "IX_Sellers_PersonID");

                entity.Property(e => e.SellerId).HasColumnName("SellerID");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.PasswordSalt).HasMaxLength(50);

                entity.Property(e => e.PayPalEmail).HasMaxLength(100);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Website).HasMaxLength(100);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sellers_Persons");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.PersonId, "IX_Users_PersonID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.PasswordHash).HasMaxLength(50);

                entity.Property(e => e.PasswordSalt).HasMaxLength(50);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Persons");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleID");

                entity.HasIndex(e => e.UserId, "IX_UserRoles_UserID");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Roles");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserRoles_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
