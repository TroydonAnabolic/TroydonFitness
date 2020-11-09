using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Areas.Identity.Data.Authorization;
using TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig;
using TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig.CustomUser;
using TroydonFitnessWebsite.Areas.Identity.Data.CustomIdentityConfig.IdentityModel;
using TroydonFitnessWebsite.Data;

[assembly: HostingStartup(typeof(TroydonFitnessWebsite.Areas.Identity.IdentityHostingStartup))]
namespace TroydonFitnessWebsite.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<TroydonFitnessIdentityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TroydonFitnessIdentityContextConnection")));

                services.AddIdentity<TroydonFitnessWebsiteUser, IdentityRole>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.SignIn.RequireConfirmedEmail = true;
                })
                // .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<TroydonFitnessIdentityContext>()
                 .AddClaimsPrincipalFactory<AdditionalUserClaimsPrincipalFactory>() // trial
                //.AddEntityFrameworkStores<ProductContext>() TODO: see if we need to connect to product db to interact with it using
                .AddDefaultTokenProviders();

                // config email verification
                services.AddScoped<IUserClaimsPrincipalFactory<TroydonFitnessWebsiteUser>,
                    AdditionalUserClaimsPrincipalFactory>();

                // add authorization
                services.AddAuthorization(config =>
                {
                    // this policy will apply to users that try to make an order without filling up their profile page with enough data
                    config.AddPolicy("OrderSuppsAndEquip", policyBuilder =>
                    {
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.GivenName);
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.FamilyName);
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.BirthDate);
                        policyBuilder.RequireCustomClaim("AddressLine2");
                        policyBuilder.RequireCustomClaim("City");
                        policyBuilder.RequireCustomClaim("State");
                        policyBuilder.RequireCustomClaim("Zip");
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.EmailVerified);
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.PhoneNumber);
                    });
                    // this policy will apply to users that try to make an order without filling up their profile page with enough data
                    config.AddPolicy("OrderPT", policyBuilder =>
                    {
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.GivenName);
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.FamilyName);
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.BirthDate);
                        policyBuilder.RequireCustomClaim("AddressLine2");
                        policyBuilder.RequireCustomClaim("City");
                        policyBuilder.RequireCustomClaim("State");
                        policyBuilder.RequireCustomClaim("Zip");
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.EmailVerified);
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.PhoneNumber);
                        policyBuilder.RequireCustomClaim("Bodyfat");
                        policyBuilder.RequireCustomClaim(JwtClaimTypes.Gender);
                        policyBuilder.RequireCustomClaim("Height");
                        policyBuilder.RequireCustomClaim("Weight");
                        policyBuilder.RequireCustomClaim("ActivityType");
                    });

                    // TODO: Test if this will allow both admin and master admin access to somefeatures
                    config.AddPolicy("ElevatedRights", policyBuilder =>
                    {
                        policyBuilder.RequireClaim(JwtClaimTypes.Role, "Master Admin", JwtClaimTypes.Role, "Admin");
                    });
                    // master admin policy allows admins access to full CRUD functionality
                    config.AddPolicy("RequireMasterAdministratorRole", policyBuilder =>
                        {
                            policyBuilder.RequireClaim(JwtClaimTypes.Role, "Master Admin");
                        });
                });

                services.AddScoped<IAuthorizationHandler, CustomRequireClaimHandler>();

                services.Configure<IdentityOptions>(options =>
                {
                    // Default SignIn settings.
                    options.SignIn.RequireConfirmedEmail = false;
                    options.SignIn.RequireConfirmedPhoneNumber = false;

                    // Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;

                    // Lockout settings.
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60);
                    options.Lockout.MaxFailedAccessAttempts = 5;
                    options.Lockout.AllowedForNewUsers = true;

                    // User settings.
                    options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    options.User.RequireUniqueEmail = true;
                });

                services.ConfigureApplicationCookie(options =>
                {
                    // Cookie settings
                    options.Cookie.HttpOnly = true;
                    options.ExpireTimeSpan = TimeSpan.FromDays(5);
                    options.Cookie.Name = "TroydonFitnessCookies";
                    options.LoginPath = "/Identity/Account/Login";
                    options.LogoutPath = $"/Identity/Account/Logout";
                    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                    options.SlidingExpiration = true;
                });

                services.Configure<PasswordHasherOptions>(option =>
                {
                    option.IterationCount = 12000;
                });
                services.Configure<DataProtectionTokenProviderOptions>(options =>
                    options.TokenLifespan = TimeSpan.FromHours(3));
            });
        }
    }
}