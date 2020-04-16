using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bootcamp02.Context;
using Bootcamp02.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Bootcamp02
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //Çalışma zamanında view'da yapılan değişiklikleri uygulamayı indirip-kaldırmaya gerek olmadan görmemizi sağlar.
            services.AddRazorPages().AddRazorRuntimeCompilation();
            
            //Dependency Injection ile hangi classlardan örneklerin nasıl yaratılması gerektiğini bu kısımda söylüyoruz.
            services.AddScoped<MessageService>();
            services.AddSingleton<BookContext>();
            services.AddTransient<BookService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //uygulamamızın default hangi controller ve hangi actiondan açılacağı burada belirleniyor
                    pattern: "{controller=Book}/{action=Index}/{id?}");
            });
        }
    }
}
