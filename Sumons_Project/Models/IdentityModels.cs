using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace BJProduction.Models
{
    // You will not likely need to customize there, but it is necessary/easier to create our own 
    // project-specific implementations, so here they are:
    public class ApplicationUserLogin : IdentityUserLogin<string> { }
    public class ApplicationUserClaim : IdentityUserClaim<string> { }
    public class ApplicationUserRole : IdentityUserRole<string> { }

    // Must be expressed in terms of our custom Role and other types:
    public class ApplicationUser 
        : IdentityUser<string, ApplicationUserLogin, 
        ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();

            // Add any custom User properties/code here
        }

        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public string PictureFile { get; internal set; }

        public async Task<ClaimsIdentity>
            GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var userIdentity = await manager
                .CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }





    // Must be expressed in terms of our custom UserRole:
    public class ApplicationRole : IdentityRole<string, ApplicationUserRole>
    {
        public ApplicationRole() 
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
        }

        // Add any custom Role properties/code here
    }


    // Must be expressed in terms of our custom types:
    public class ApplicationDbContext
        : IdentityDbContext<ApplicationUser, ApplicationRole,
        string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext()
            : base("BJ_Production")
        {
        }

        //static ApplicationDbContext()
        //{
        //    Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        // Add the ApplicationGroups property:
        public virtual IDbSet<ApplicationGroup> ApplicationGroups { get; set; }
        public virtual IDbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
       

        // Override OnModelsCreating:
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationUserGroup>((ApplicationGroup g) => g.ApplicationUsers)
                .WithRequired().HasForeignKey<string>((ApplicationUserGroup ag) => ag.ApplicationGroupId);
            modelBuilder.Entity<ApplicationUserGroup>()
                .HasKey((ApplicationUserGroup r) => 
                    new 
                    { 
                        ApplicationUserId = r.ApplicationUserId, 
                        ApplicationGroupId = r.ApplicationGroupId 
                    }).ToTable("ApplicationUserGroups");

            modelBuilder.Entity<ApplicationGroup>()
                .HasMany<ApplicationGroupRole>((ApplicationGroup g) => g.ApplicationRoles)
                .WithRequired().HasForeignKey<string>((ApplicationGroupRole ap) => ap.ApplicationGroupId);
            modelBuilder.Entity<ApplicationGroupRole>().HasKey((ApplicationGroupRole gr) => 
                new 
                { 
                    ApplicationRoleId = gr.ApplicationRoleId, 
                    ApplicationGroupId = gr.ApplicationGroupId 
                }).ToTable("ApplicationGroupRoles");




        }

        //public DbSet<AssignBranch> AssignBranches { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Location_Type> Location_Type { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Location> Locations { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Vendor> Vendors { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Machine> Machines { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Machine_Type> Machine_Type { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Transaction_Type> Transaction_Type { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Product_Type> Product_Type { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Feature> Features { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Feature_Type> Feature_Type { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Unit_Measurement> Unit_Measurement { get; set; }

      

        public System.Data.Entity.DbSet<BJProduction.Models.Machine_Product> Machine_Product { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Sales_Order> Sales_Order { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Sales_Ledger> Sales_Ledger { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Purchase_Order> Purchase_Order { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Purchase_Ledger> Purchase_Ledger { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Production_Indent> Production_Indent { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Shift> Shifts { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Shift_End> Shift_End { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Consumption_Ledger> Consumption_Ledger { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Production_Ledger> Production_Ledger { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Other_Type> Other_Type { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Other_Consumption> Other_Consumption { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Other_Consumption_Ledger> Other_Consumption_Ledger { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Transfer_Ledger> Transfer_Ledger { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.General_Ledger> General_Ledger { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.ProductType_FeatureType> ProductType_FeatureType { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Product_Feature> Product_Feature { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Transfer_Order> Transfer_Order { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Company_Location> Company_Location { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Feature_UnitMeasurement> Feature_UnitMeasurement { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Return_Order> Return_Order { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Return_Ledger> Return_Ledger { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Product_Indent_Feature> Product_Indent_Feature { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Temp_Feature> Temp_Feature { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.Residuals> Residuals { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.TransferProductFeatures> TransferProductFeatures { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.TransferOrderExt> TransferOrderExts { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.SalesProductFeatures> SalesProductFeatures { get; set; }

        public System.Data.Entity.DbSet<BJProduction.Models.SalesOrderProductFeature> SalesOrderProductFeatures { get; set; }
 public System.Data.Entity.DbSet<BJProduction.Models.SalesOrderExt> SalesOrderExts { get; set; }





        //public System.Data.Entity.DbSet<BJProduction.Models.Site> Sites { get; set; }

    }

    //public class ApplicationDbContextM
    //: IdentityDbContext<ApplicationUser, ApplicationRole,
    //string, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    //{
    //    public ApplicationDbContextM()
    //        : base("BJ_Production")
    //    {
    //    }

    //    //static ApplicationDbContext()
    //    //{
    //    //    Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
    //    //}

    //    public static ApplicationDbContextM Create()
    //    {
    //        return new ApplicationDbContextM();
    //    }

    //    public DbSet<AssignBranch> AssignBranches { get; set; }
    //    // Add the ApplicationGroups property:

    //    //public System.Data.Entity.DbSet<BJProduction.Models.Site> Sites { get; set; }

    //}






    // Most likely won't need to customize these either, but they were needed because we implemented
    // custom versions of all the other types:
    public class ApplicationUserStore 
        :UserStore<ApplicationUser, ApplicationRole, string,
            ApplicationUserLogin, ApplicationUserRole, 
            ApplicationUserClaim>, IUserStore<ApplicationUser, string>, 
        IDisposable
    {
        public ApplicationUserStore()
            : this(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationUserStore(DbContext context)
            : base(context)
        {
        }
    }


    public class ApplicationRoleStore
    : RoleStore<ApplicationRole, string, ApplicationUserRole>,
    IQueryableRoleStore<ApplicationRole, string>,
    IRoleStore<ApplicationRole, string>, IDisposable
    {
        public ApplicationRoleStore()
            : base(new IdentityDbContext())
        {
            base.DisposeContext = true;
        }

        public ApplicationRoleStore(DbContext context)
            : base(context)
        {
        }
    }


    public class ApplicationGroup
    {
        public ApplicationGroup()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ApplicationRoles = new List<ApplicationGroupRole>();
            this.ApplicationUsers = new List<ApplicationUserGroup>();
        }

        public ApplicationGroup(string name)
            : this()
        {
            this.Name = name;
        }

        public ApplicationGroup(string name, string description)
            : this(name)
        {
            this.Description = description;
        }

        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApplicationGroupRole> ApplicationRoles { get; set; }
        public virtual ICollection<ApplicationUserGroup> ApplicationUsers { get; set; }
    }


    public class ApplicationUserGroup
    {
        public string ApplicationUserId { get; set; }
        public string ApplicationGroupId { get; set; }
    }

    public class ApplicationGroupRole
    {
        public string ApplicationGroupId { get; set; }
        public string ApplicationRoleId { get; set; }
    }

}