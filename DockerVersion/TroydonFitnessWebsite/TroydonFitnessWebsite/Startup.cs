using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using Microsoft.Data.SqlClient;
using TroydonFitnessWebsite.CustomSettings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using TroydonFitnessWebsite.Settings.Mail;
using TroydonFitnessWebsite.Services;
using Microsoft.AspNetCore.HttpOverrides;
using System.Net;
using Microsoft.AspNetCore.Authentication.Certificate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Amazon.Extensions.Configuration.SystemsManager;


namespace TroydonFitnessWebsite
{
    public class Startup
    {
        // private string _troydonFitApiKey = null;
        private string _connection = null;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //  // Secret config
            //  var troyFitConfig = Configuration.GetSection("TroydonFitness")
            //                      .Get<TroydonFitnessSecretSettings>();
            ////  _troydonFitApiKey = troyFitConfig.ServiceApiKey;
            //  // set the connection string to use the secret
            //  var builder = new SqlConnectionStringBuilder(
            //      Configuration.GetConnectionString("ProductContextConnection"));
            //  builder.Password = Configuration["DbPassword"];
            //  _connection = builder.ConnectionString;

            // Configure AWS services
          //  var options = Configuration.GetAWSOptions("AWS"); // gets AWSService key value pair from secrets.json that holds username and region
         //   IAmazonSystemManager client = options.CreateServiceClient<IAmazonS3>();

            // config authentication options
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                //enables dynamic selection of schemes on a per request basis. 
                .AddCookie(options =>
                {
                    options.ForwardDefaultSelector = ctx =>
                   ctx.Request.Path.StartsWithSegments("/Google") ? "Google" : null;
                })
                // adds google auth api
                .AddGoogle(options =>
                {
                    IConfigurationSection googleAuthNSection =
                        Configuration.GetSection("Authentication:Google");
                    options.ClientId = googleAuthNSection["ClientId"];
                    options.ClientSecret = googleAuthNSection["ClientSecret"];

                    options.ClaimActions.MapJsonKey("urn:google:picture", "picture", "url");
                    options.ClaimActions.MapJsonKey("urn:google:locale", "locale", "string");
                    options.SaveTokens = true;
                    options.Events.OnCreatingTicket = ctx =>
                    {
                        List<AuthenticationToken> tokens = ctx.Properties.GetTokens().ToList();

                        tokens.Add(new AuthenticationToken()
                        {
                            Name = "TicketCreated",
                            Value = DateTime.UtcNow.ToString()
                        });

                        ctx.Properties.StoreTokens(tokens);

                        return Task.CompletedTask;
                    };
                    // reads profile and birthday data from google
                    options.Scope.Add("https://www.googleapis.com/auth/userinfo.profile");
                    options.Scope.Add("https://www.googleapis.com/auth/user.birthday.read");
                })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                })
            //.AddTwitter(twitterOptions => TODO: add twitter when access given
            // {
            //     twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
            //     twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
            //     twitterOptions.RetrieveUserDetails = true;
            // })
            ;
            services.AddAuthentication(
               CertificateAuthenticationDefaults.AuthenticationScheme)
               .AddCertificate();

            // confirm email settings
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();

            // add pages
            services.AddControllersWithViews();

            services.AddRazorPages()
                // configures authorization
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeFolder("/"); // ensures that all folders require authorization, we will manually apply allow anonymous access to pages we require to avoid forgetting a page
                    options.Conventions.AllowAnonymousToPage("/Index"); // ensures that all folders require authorization, we will manually apply allow anonymous access to pages we require
                    options.Conventions.AuthorizeFolder("/Products").AllowAnonymousToPage("/Products/MainProductPage");
                    //options.Conventions.AuthorizeAreaPage("Identity", "/Manage/Accounts");
                    //options.Conventions.AuthorizeAreaFolder("Identity", "/Manage");
                    // options.Conventions.AuthorizeAreaPage("Identity", "/Manage/Accounts", "MasterAdministrator");
                    // options.Conventions.AllowAnonymousToPage("/Private/PublicPage");
                    // options.Conventions.AllowAnonymousToFolder("/Private/PublicPages");
                });

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
                options.ForwardLimit = 2;
                options.KnownProxies.Add(IPAddress.Parse("127.0.10.1"));
            });

            services.AddDbContext<ProductContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ProductContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
