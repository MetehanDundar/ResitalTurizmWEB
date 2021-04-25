using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ResitalTurizmWEB.BUSINESS;
using ResitalTurizmWEB.BUSINESS.Abstract;
using ResitalTurizmWEB.BUSINESS.Concrete;
using ResitalTurizmWEB.DATA;
using ResitalTurizmWEB.DATA.Abstract;
using ResitalTurizmWEB.DATA.Concrete;
using ResitalTurizmWEB.DATA.Concrete.EfCore;
using ResitalTurizmWEB.UI.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        
        public void ConfigureServices(IServiceCollection services)
        {
            //var sqlConfiguration = Configuration.GetConnectionString("DatabaseConnection");
            //services.AddDbContext<DbContext, ReservationContext>(o => o.UseSqlServer(sqlConfiguration));

            

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("server=.; database= ResitalDb; uid=sa; pwd=123;"));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
            //AddDefaultTokenProviders() parola resetleme iþlemleri gibi iþlemler için.(benzersiz sayý üretme)

            //Aþaðýdaki identity ayarlamalarýný yapmazsak varsayýlan olarak kullanýrýz.
            services.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = true; //parolada sayýsal deger olmak zorunda
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3; //þifre minimum 3 karakter olmalý
                options.Password.RequireNonAlphanumeric = false;

                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 5; //5 yanlýþ giriþten sonra hesap kilitlenebilir.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //5 dk sonra yeniden giriþ yapýlabilir.
                options.Lockout.AllowedForNewUsers = true; //Lockout aktif etme

                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true; //Her kullanýcýnýn farklý mail adresi olmalý.
                options.SignIn.RequireConfirmedEmail = false; //Hesap onaylanmasý zorunlu mu
                options.SignIn.RequireConfirmedPhoneNumber = false; //Telefon ile onaylama
            });

            //cookie ile session birbirini tanýr ve iletisim halinde.(Cookie Based Authentication)
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login"; //Cookie, session tarafýndan tanýnmýyorsa "/account/login" yönlendir.
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied"; //login olmuþ fakat yetkisiz
                options.SlidingExpiration = true; //Cookie süresi varsayýlan 20 dk. 'True' dedigimizde her istekte 20 dk resetlenir. 'False' yapsaydým iþlem yapýlsa dahi 20 dk süre olurdu.
                options.ExpireTimeSpan = TimeSpan.FromDays(30); //Cookie süresi 30 gün
                options.Cookie = new CookieBuilder
                {
                    HttpOnly = true, //cookie sadece http ile 
                    Name = ".Resital.Security.Cookie"
                };
            });



            services.AddScoped<IOtelRepository, EfCoreOtelRepository>();
            services.AddScoped<IRoomsRepository, RoomRepository>();
            services.AddScoped<ICategoryOtelRepository, EfCoreCategoryOtelRepository>();
            services.AddScoped<ICartRepository, EfCoreCartRepository>();
            services.AddScoped<IOrderRepository, EfCoreOrderRepository>();

            services.AddDbContext<ResitalContext>(option =>
            {
                option.UseSqlServer("server=.; database= ResitalDb; uid=sa; pwd=123;");
                option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IRoomService, RoomsManager>();
            services.AddScoped<IOtelService, OtelManager>();
            services.AddScoped<ICategoryOtelService, CategoryOtelManager>();
            services.AddScoped<ICartService, CartManager>();
            services.AddScoped<IOrderService, OrderManager>();
            services.AddControllersWithViews();
            services.AddHttpClient();

        }

        
        //appsettings.json icerisinden bir bilgiye ihtiyacým oldugu icin IConfiguration parametresi ekledim
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration, UserManager<User> userManager,RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                //SeedDatabase.Seed();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseAuthentication(); //identity iþlemleri için
            app.UseRouting();
            app.UseAuthorization();

            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();//asenkron oldugu için Wait()
            SeedDatabase.Seed(app); // Burayý SeedDatabase'de IApplciationBuilder olarak eklediðimiz için bu þekilde kullanuyoýruz Hangi uygulamada bu Seed metodunu kullanacak? Burada da diyoruz ki iþte bu execute edilen uygulamada.
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "orders",
                   pattern: "orders",
                   defaults: new { controller = "Cart", action = "GetOrders" }
               );

                endpoints.MapControllerRoute(
                   name: "checkout",
                   pattern: "checkout",
                   defaults: new { controller = "Cart", action = "Checkout" }
               );

                endpoints.MapControllerRoute(
                   name: "cart",
                   pattern: "cart",
                   defaults: new { controller = "Cart", action = "Index" }
               );

                endpoints.MapControllerRoute(
                   name: "bookinglist",
                   pattern: "booking/index/{id?}",
                   defaults: new { controller = "Booking", action = "Index" }
               );

                endpoints.MapControllerRoute(
                   name: "adminuseredit",
                   pattern: "admin/user/{id?}",
                   defaults: new { controller = "Admin", action = "UserEdit" }
               );

                endpoints.MapControllerRoute(
                  name: "adminusers",
                  pattern: "admin/user/list",
                  defaults: new { controller = "Admin", action = "userlist" }
              );

                endpoints.MapControllerRoute(
                  name: "adminroles",
                  pattern: "admin/role/list",
                  defaults: new { controller = "Admin", action = "rolelist" }
              );

                endpoints.MapControllerRoute(
                  name: "adminrolecreate",
                  pattern: "admin/role/create",
                  defaults: new { controller = "Admin", action = "rolecreate" }
              );

                endpoints.MapControllerRoute(
                   name: "adminroleedit",
                   pattern: "admin/role/{id?}",
                   defaults: new { controller = "Admin", action = "RoleEdit" }
               );

                endpoints.MapControllerRoute(
                   name: "adminotels",
                   pattern: "admin/otels",
                   defaults: new { controller = "Admin", action = "otellist" }
               );

                endpoints.MapControllerRoute(
                   name: "adminoteledit",
                   pattern: "admin/otels/{id?}",
                   defaults: new { controller = "Admin", action = "Edit" }
               );

                endpoints.MapControllerRoute(
                    name: "search",
                    pattern: "search",
                    defaults: new { controller = "Otel", action = "search" }
                );

                endpoints.MapControllerRoute(
                    name: "otels",
                    pattern: "otels/{categoryotel?}",
                    defaults: new { controller = "Otel", action = "list" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "rooms",
                    pattern: "rooms/{otel?}",
                    defaults: new { controller = "Room", action = "List" }
                );

            });
        }
    }
}
