using BuyList.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BuyList.Infra.Contexts
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ListBuy> ListBuy { get; set; }
        public DbSet<ListBuyItem> ListBuyItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<User>().Property(x => x.Id);
            modelBuilder.Entity<User>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<User>().Property(x => x.Email).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<User>().Property(x => x.Password).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<User>().HasMany(u => u.Items).WithOne(i => i.Owner);
            modelBuilder.Entity<User>().HasMany(u => u.BuyLists).WithOne(b => b.Owner);

            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Item>().Property(x => x.Id);
            modelBuilder.Entity<Item>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Item>().Property(x => x.Quantity).HasColumnType("int");
            modelBuilder.Entity<Item>().Property(x => x.TypeOfMeasure).HasColumnType("varchar(10)");
            modelBuilder.Entity<Item>().Property(x => x.Value).HasColumnType("decimal(5, 2)");
            modelBuilder.Entity<Item>().Property(x => x.Category).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<Item>().HasOne<User>(i => i.Owner).WithMany(u => u.Items);

            modelBuilder.Entity<ListBuy>().ToTable("BuyList");
            modelBuilder.Entity<ListBuy>().Property(x => x.Id);
            modelBuilder.Entity<ListBuy>().Property(x => x.Name).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<ListBuy>().Property(x => x.Date);
            modelBuilder.Entity<ListBuy>().Property(x => x.TotalValue).HasColumnType("decimal(12, 2)");
            modelBuilder.Entity<ListBuy>().HasOne<User>(b => b.Owner).WithMany(u => u.BuyLists);

            modelBuilder.Entity<ListBuyItem>().HasKey(i => new { i.ListBuyId, i.ItemId });
        }

        public string GetConnStr()
        {
            return _configuration["ConnectionStrings:connectionString"];
        }
    }
}