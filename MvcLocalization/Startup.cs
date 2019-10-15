using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using MvcLocalization.Validators;
using Microsoft.Extensions.Localization;
using MvcLocalization.Middleware;

namespace MvcLocalization
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
            services.AddScoped<ILanguage, Language>();
            services.AddScoped<IStringLocalizer, StringLocalizer>();
            services.AddMvc()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserValidator>());

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseDeveloperExceptionPage();
            app.UseExceptionHandler("/Home/Error");

            app.UseStaticFiles();
            app.UseLanguageMiddleware();
            app.UseCookiePolicy();

            app.UseAuthentication();

            //            var supportedCultures = new[]
            //            {
            //                new CultureInfo("en-US"),
            //                new CultureInfo("cs")
            //            };
            //​
            //            app.UseRequestLocalization(new RequestLocalizationOptions
            //            {
            //                DefaultRequestCulture = new RequestCulture("en-US"),
            //                // Formatting numbers, dates, etc.
            //                SupportedCultures = supportedCultures,
            //                // UI strings that we have localized.
            //                SupportedUICultures = supportedCultures
            //            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                //routes.MapRoute(
                //        name: "style",
                //        template: "style.css",
                //        defaults: new { controller = "Home", action = "Style" });
                //    routes.MapRoute(
                //        name: "categorymenu",
                //        template: "CategoryMenu/{categoryId}/{languageId}",
                //        defaults: new { controller = "CategoryMenu", action = "Index", categoryId = "" });

                //    routes.MapRoute(
                //        name: "files",
                //        template: "files/{requestedFileName}",
                //        defaults: new { controller = "File", action = "Index" });

                //    routes.MapRoute(
                //        name: "filters",
                //        template: "filters/{action}/{paramId}/{filterValue}",
                //        defaults: new { controller = "Filter", action = "{action}", paramId = "", filterValue = "" });

                //    routes.MapRoute(
                //        name: "ajaxForms",
                //        template: "forms/{controller}/{action}");

                //    routes.MapRoute(
                //        name: "productDetail",
                //        template: "{langIsoCode:alpha:minlength(2)}/{productCode:regex(---(.*))}",
                //        defaults: new { controller = "Home", action = "ProductDetail" });

                //    routes.MapRoute(
                //        name: "generatedPageUrl",
                //        template: "{langIsoCode:alpha:minlength(2)}/{generatedUrl:regex(pg_[0-9])}",
                //        defaults: new { controller = "Home", action = "GeneratedPageUrl" });

                //    // Catch-all route
                //    routes.MapRoute(
                //        name: "default",
                //        template: "{*url}",
                //        defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
