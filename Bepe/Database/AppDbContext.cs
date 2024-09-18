using IhandCashier.Bepe.Configs;
using IhandCashier.Bepe.Constants;
using IhandCashier.Bepe.Entities;
using IhandCashier.Bepe.Types;
using Microsoft.EntityFrameworkCore;

namespace IhandCashier.Bepe.Database;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<BasicUnit> BasicUnits { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<ProductPrice> ProductPrices { get; set; }
    public DbSet<ProductReceipt> ProductReceipts { get; set; }
    public DbSet<ProductReceiptDetail> ProductReceiptDetails { get; set; }
    public DbSet<ProductStock> ProductStocks { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>().ToTable("products");
        modelBuilder.Entity<User>().ToTable("users");
        modelBuilder.Entity<Unit>().ToTable("units");
        modelBuilder.Entity<BasicUnit>().ToTable("basic_units");
        modelBuilder.Entity<Customer>().ToTable("customers");
        modelBuilder.Entity<ProductPrice>().ToTable("product_prices");
        modelBuilder.Entity<ProductReceipt>().ToTable("product_receipts");
        modelBuilder.Entity<ProductReceiptDetail>().ToTable("product_receipt_details");
        modelBuilder.Entity<ProductStock>().ToTable("product_stocks");
        modelBuilder.Entity<Supplier>().ToTable("suppliers");

        base.OnModelCreating(modelBuilder);
        
        // BasicUnit Configuration
        modelBuilder.Entity<BasicUnit>()
            .HasIndex(bu => bu.nama)
            .IsUnique();

        // Customer Configuration
        modelBuilder.Entity<Customer>()
            .Property(c => c.nama)
            .IsRequired();

        // Product Configuration
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.kode)
            .IsUnique();

        // ProductPrice Configuration
        modelBuilder.Entity<ProductPrice>()
            .HasIndex(pp => pp.product_id);

        modelBuilder.Entity<ProductPrice>()
            .HasIndex(pp => pp.unit_id);

        // ProductReceipt Configuration
        modelBuilder.Entity<ProductReceipt>()
            .HasIndex(pr => pr.kode_transaksi)
            .IsUnique();

        modelBuilder.Entity<ProductReceipt>()
            .HasIndex(pr => pr.supplier_id);
        modelBuilder.Entity<ProductReceipt>()
            .HasMany(d => d.Details)
            .WithOne(prd => prd.ProductReceipt)
            .HasForeignKey(prd => prd.product_receipt_id);
        modelBuilder.Entity<ProductReceipt>()
            .HasQueryFilter(pr => !pr.deleted_at.HasValue);
        
        // ProductReceiptDetail Configuration
        modelBuilder.Entity<ProductReceiptDetail>()
            .HasIndex(prd => prd.product_receipt_id);

        modelBuilder.Entity<ProductReceiptDetail>()
            .HasIndex(prd => prd.product_id);

        modelBuilder.Entity<ProductReceiptDetail>()
            .HasIndex(prd => prd.unit_id);
        
        modelBuilder.Entity<ProductReceiptDetail>()
            .HasOne(d => d.ProductReceipt) // Menentukan relasi ke ProductReceipt
            .WithMany(pr => pr.Details) // Menentukan bahwa ProductReceipt memiliki banyak Detail
            .HasForeignKey(d => d.product_receipt_id); // Menentukan foreign key

        // ProductStock Configuration
        modelBuilder.Entity<ProductStock>()
            .HasIndex(ps => ps.product_id);

        modelBuilder.Entity<ProductStock>()
            .HasIndex(ps => ps.unit_id);

        // Supplier Configuration
        modelBuilder.Entity<Supplier>()
            .Property(s => s.nama)
            .IsRequired();

        // Unit Configuration
        modelBuilder.Entity<Unit>()
            .HasIndex(u => new { u.kode_satuan, u.basic_unit_id })
            .IsUnique();
        modelBuilder.Entity<Unit>()
            .HasOne(u => u.BasicUnit)
            .WithMany(b => b.Units)
            .HasForeignKey(u => u.basic_unit_id);

        // User Configuration
        modelBuilder.Entity<User>()
            .HasIndex(u => u.username)
            .IsUnique();

        modelBuilder.Entity<User>()
            .Property(u => u.nama)
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(u => u.username)
            .HasMaxLength(50);

        modelBuilder.Entity<User>()
            .Property(u => u.email)
            .HasMaxLength(100);

        modelBuilder.Entity<User>()
            .Property(u => u.avatar)
            .HasMaxLength(255);
    }
    
    public AppDbContext(){}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        AppSetting _setting = AppSettingConfig.LoadSettings();
        if (_setting.Database.DbType == AppEnumeration.GetDbTypes[DbTypes.SqLite])
        {
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite($"Data Source={DatabaseConfig.DatabasePath()}");
        } 
        else if (_setting.Database.DbType == AppEnumeration.GetDbTypes[DbTypes.MySql])
        {
            IcMySql db = _setting.Database.MySql;
            var connectionString = $"server={db.DbServer};database={db.Database};user={db.Username};password={db.Password};port={db.Port};";
            if (!optionsBuilder.IsConfigured) optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        optionsBuilder.EnableSensitiveDataLogging();

    }


}