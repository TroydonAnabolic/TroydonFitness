using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig.CustomUser;

namespace TroydonFitnessWebsite.Data
{
    public class TroydonFitnessIdentityContext : IdentityDbContext<
         TroydonFitnessWebsiteUser,
        ApplicationRole, string
        //, ApplicationRole, string,
        //ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        //ApplicationRoleClaim, ApplicationUserToken
        >
    {
        public TroydonFitnessIdentityContext(DbContextOptions<TroydonFitnessIdentityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //    // Customize the ASP.NET Identity model and override the defaults if needed.
            //    // For example, you can rename the ASP.NET Identity table names and more.
            //    // Add your customizations after calling base.OnModelCreating(builder);
            //    builder.Entity<TroydonFitnessWebsiteUser>(b =>
            //    {
            //        // Each User can have many UserClaims
            //        b.HasMany(e => e.Claims)
            //            .WithOne(e => e.User)
            //            .HasForeignKey(uc => uc.UserId)
            //            .IsRequired();

            //        // Each User can have many UserLogins
            //        b.HasMany(e => e.Logins)
            //            .WithOne(e => e.User)
            //            .HasForeignKey(ul => ul.UserId)
            //            .IsRequired();

            //        // Each User can have many UserTokens
            //        b.HasMany(e => e.Tokens)
            //            .WithOne(e => e.User)
            //            .HasForeignKey(ut => ut.UserId)
            //            .IsRequired();

            //        // Each User can have many entries in the UserRole join table
            //        b.HasMany(e => e.UserRoles)
            //            .WithOne(e => e.User)
            //            .HasForeignKey(ur => ur.UserId)
            //            .IsRequired();
            //    });

            //    builder.Entity<ApplicationRole>(b =>
            //    {
            //        // Each Role can have many entries in the UserRole join table
            //        b.HasMany(e => e.UserRoles)
            //            .WithOne(e => e.Role)
            //            .HasForeignKey(ur => ur.RoleId)
            //            .IsRequired();

            //        // Each Role can have many associated RoleClaims
            //        b.HasMany(e => e.RoleClaims)
            //            .WithOne(e => e.Role)
            //            .HasForeignKey(rc => rc.RoleId)
            //            .IsRequired();
            //    });
            // Change table names
            builder.Entity<IdentityUser>(b =>
            {
                b.ToTable("TFUsers");
            });

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.ToTable("TFUserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(b =>
            {
                b.ToTable("TFUserLogins");
            });

            builder.Entity<IdentityUserToken<string>>(b =>
            {
                b.ToTable("TFUserTokens");
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.ToTable("TFRoles");
            });

            builder.Entity<IdentityRoleClaim<string>>(b =>
            {
                b.ToTable("TFRoleClaims");
            });

            builder.Entity<IdentityUserRole<string>>(b =>
            {
                b.ToTable("TFUserRoles");
            });
            // Change column names

            builder.Entity<IdentityUserClaim<string>>(b =>
            {
                b.Property(e => e.ClaimType).HasColumnName("CType");
                b.Property(e => e.ClaimValue).HasColumnName("CValue");
            });
        }
    }
}

