using AtlanticProductDesing.Domain.Common;
using AtlanticProductDesing.Domain.Entities;
using AtlanticProductDesing.Infrastruture.Persistence.Sedders;
using Microsoft.EntityFrameworkCore;

namespace AtlanticProductDesing.Infrastruture.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // DbSet para cada entidad
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonContactMethod> PersonContactMethods { get; set; }
        public DbSet<CertificateConfiguration> CertificateConfiguration { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Coverage> Coverage { get; set; }
        public DbSet<Tariff> Tariff { get; set; }
        public DbSet<Deductible> Deductible { get; set; }
        public DbSet<Exclusion> Exclusion { get; set; }
        public DbSet<CoverageExclusion> CoverageExclusion { get; set; }
        public DbSet<ProductConfiguration> ProductConfiguration { get; set; }
        public DbSet<PolicyConfiguration> PolicyConfiguration { get; set; }
        public DbSet<QuotationConfiguration> QuotationConfiguration { get; set; }
        public DbSet<ProductDesign> ProductDesign { get; set; }
        public DbSet<ListValue> ListValues { get; set; }


        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=.; Initial Catalog=DoncDB; integrated security=True")
        //        .LogTo(Console.Write, new[] { DbLoggerCategory.Database.Command.Name }, Microsoft.Extensions.Logging.LogLevel.Information)
        //        .EnableSensitiveDataLogging();
        //}

        public override Task<int> SaveChangesAsync(CancellationToken cancellaionToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch (entry.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        entry.Entity.LastModifiedBy = entry.Entity.LastModifiedBy ?? "System";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreateDate = DateTime.Now;
                        entry.Entity.CreateBy = entry.Entity.CreateBy ?? "System";
                        break;

                }

            }

            return base.SaveChangesAsync(cancellaionToken);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación PersonContactMethod - Person
            modelBuilder.Entity<PersonContactMethod>()
                .HasOne(pcm => pcm.Person)
                .WithMany(p => p.ContactMethods)
                .HasForeignKey(pcm => pcm.PersonId)
                .OnDelete(DeleteBehavior.Restrict);


           

            modelBuilder.Entity<ValueListValue>(entity =>
            {
                entity.HasKey(e => new { e.Key, e.ListValueId });
            });

            // Configurar otras entidades y relaciones según sea necesario
        }


        public async Task SeedDataAsync()
        {
            //await DeliveryTypeSeeder.SeedAsync(this);
            //await GeographicalDivisionSeeder.SeedAsync(this);
            //await PaymentTypeSeeder.SeedAsync(this);
            // Añade aquí otros seeders si los tienes
        }
    }
}
