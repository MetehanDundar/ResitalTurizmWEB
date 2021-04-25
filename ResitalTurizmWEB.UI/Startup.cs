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
            //AddDefaultTokenProviders() parola resetleme i�lemleri gibi i�lemler i�in.(benzersiz say� �retme)

            //A�a��daki identity ayarlamalar�n� yapmazsak varsay�lan olarak kullan�r�z.
            services.Configure<IdentityOptions>(options =>
            {
                //password
                options.Password.RequireDigit = true; //parolada say�sal deger olmak zorunda
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3; //�ifre minimum 3 karakter olmal�
                options.Password.RequireNonAlphanumeric = false;

                //Lockout
                options.Lockout.MaxFailedAccessAttempts = 5; //5 yanl�� giri�ten sonra hesap kilitlenebilir.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //5 dk sonra yeniden giri� yap�labilir.
                options.Lockout.AllowedForNewUsers = true; //Lockout aktif etme

                //options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true; //Her kullan�c�n�n farkl� mail adresi olmal�.
                options.SignIn.RequireConfirmedEmail = false; //Hesap onaylanmas� zorunlu mu
                options.SignIn.RequireConfirmedPhoneNumber = false; //Telefon ile onaylama
            });

            //cookie ile session birbirini tan�r ve iletisim halinde.(Cookie Based Authentication)
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/account/login"; //Cookie, session taraf�ndan tan�nm�yorsa "/account/login" y�nlendir.
                options.LogoutPath = "/account/logout";
                options.AccessDeniedPath = "/account/accessdenied"; //login olmu� fakat yetkisiz
                options.SlidingExpiration = true; //Cookie s�resi varsay�lan 20 dk. 'True' dedigimizde her istekte 20 dk resetlenir. 'False' yapsayd�m i�lem yap�lsa dahi 20 dk s�re olurdu.
                options.ExpireTimeSpan = TimeSpan.FromDays(30); //Cookie s�resi 30 g�n
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

        
        //appsettings.json icerisinden bir bilgiye ihtiyac�m oldugu icin IConfiguration parametresi ekledim
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

            app.UseAuthentication(); //identity i�lemleri i�in
            app.UseRouting();
            app.UseAuthorization();

            SeedIdentity.Seed(userManager, roleManager, configuration).Wait();//asenkron oldugu i�in Wait()
            SeedDatabase.Seed(app); // Buray� SeedDatabase'de IApplciationBuilder olarak ekledi�imiz i�in bu �ekilde kullanuyo�ruz Hangi uygulamada bu Seed metodunu kullanacak? Burada da diyoruz ki i�te bu execute edilen uygulamada.
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
