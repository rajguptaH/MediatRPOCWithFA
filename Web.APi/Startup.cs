using FluentValidation;
using MediatR;
using Microsoft.OpenApi.Models;
using Web.Buisness.Features.UiPageType.Commands;
using Web.Buisness.Features.UiPageType;
using Web.Buisness.Interface;
using Web.Buisness.PipelineBehaviors;
using WebBuisness;
using WebBuisness.Infrastructure;
using WebBuisness.Repository;
using WebBuisness.Repository.Interface;

namespace Web.APi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Pipeline Behavior 
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DemoApi", Version = "v1" });
            });
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();
            services.AddSingleton<IUiPageTypeRepository, UiPageTypeRepository>();

            services.AddAutoMapper(typeof(Startup));
            //services.AddMediatR(typeof(DemoLibraryMediatREntrypoint).Assembly);
            //services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddApplication();
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DemoApi v1"));
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
