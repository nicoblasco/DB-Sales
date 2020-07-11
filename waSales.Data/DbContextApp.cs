using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using waSales.Data.Mapping.Configuration;
using waSales.Data.Mapping.Security;
using waSales.Data.Mapping.System;
using waSales.Data.Mapping.Tipification;
using waSales.Entities.Configuration;
using waSales.Entities.Security;
using waSales.Entities.System;
using waSales.Entities.Tipification;

namespace waSales.Data
{
    public class DbContextApp : DbContext
    {
        public DbSet<SecurityUser> SecurityUsers { get; set; }
        public DbSet<SecurityRole> SecurityRoles { get; set; }
        public DbSet<SecurityAction> SecurityActions { get; set; }
        public DbSet<SecurityRoleAction> SecurityRoleActions { get; set; }
        public DbSet<SecurityRoleScreen> SecurityRoleScreens { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<ConfigScreen> ConfigScreens { get; set; }
        public DbSet<ConfigScreenField> ConfigScreenFields { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<CompanySector> CompanySectors { get; set; }

        public DbSet<SystemAction> SystemAction { get; set; }
        public DbSet<SystemRole> SystemRole { get; set; }
        public DbSet<SystemRoleAction> SystemRoleAction { get; set; }
        public DbSet<SystemScreen> SystemScreen { get; set; }
        public DbSet<SystemScreenField> SystemScreenField { get; set; }
        public DbSet<SystemRoleScreen> SystemRoleScreen { get; set; }
        public DbSet<LogError> LogErrors { get; set; }


        /*Tipificaciones*/
        public DbSet<SalesState> SalesStates { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<ExchangeCurrency> ExchangeCurrencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<SalesUnit> SalesUnits { get; set; }




        public DbContextApp(DbContextOptions<DbContextApp> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new SecurityRoleMap());
            modelBuilder.ApplyConfiguration(new SecurityUserMap());
            modelBuilder.ApplyConfiguration(new SecurityActionMap());
            modelBuilder.ApplyConfiguration(new SecurityRoleActionMap());
            modelBuilder.ApplyConfiguration(new SecurityRoleScreenMap());
            modelBuilder.ApplyConfiguration(new CompanyMap());
            modelBuilder.ApplyConfiguration(new ConfigScreenMap());
            modelBuilder.ApplyConfiguration(new ConfigScreenFieldMap());
            modelBuilder.ApplyConfiguration(new SectorMap());
            modelBuilder.ApplyConfiguration(new CompanySectorMap());
            modelBuilder.ApplyConfiguration(new SystemActionMap());
            modelBuilder.ApplyConfiguration(new SystemRoleMap());
            modelBuilder.ApplyConfiguration(new SystemRoleActionMap());
            modelBuilder.ApplyConfiguration(new SystemScreenMap());
            modelBuilder.ApplyConfiguration(new SystemScreenFieldMap());
            modelBuilder.ApplyConfiguration(new SystemRoleScreenMap());
            modelBuilder.ApplyConfiguration(new LogErrorMap());

            /*Tipificaciones*/
            modelBuilder.ApplyConfiguration(new SalesStateMap());
            modelBuilder.ApplyConfiguration(new PriceListMap());
            modelBuilder.ApplyConfiguration(new CityMap());
            modelBuilder.ApplyConfiguration(new BrandMap());
            modelBuilder.ApplyConfiguration(new PaymentMethodMap());
            modelBuilder.ApplyConfiguration(new ExchangeCurrencyMap());
            modelBuilder.ApplyConfiguration(new CountryMap());
            modelBuilder.ApplyConfiguration(new StateMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new SubCategoryMap());
            modelBuilder.ApplyConfiguration(new ContactTypeMap());
            modelBuilder.ApplyConfiguration(new DocumentTypeMap());
            modelBuilder.ApplyConfiguration(new LocationMap());
            modelBuilder.ApplyConfiguration(new SalesUnitMap());

        }
    }
}
