using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using NLayer.Repository;
using NLayer.Service.Mapping;
using NLayer.Service.Validations;
using NLayer.Web;
using NLayer.Web.Modules;
using NLayer.Web.Services;
using System.Reflection;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllersWithViews().AddFluentValidation(x=> x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>());
//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddControllersWithViews()
    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ProductDtoValidator>())
    .AddRazorRuntimeCompilation();

builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Services.AddScoped(typeof(MapProfile));

builder.Services.AddDbContext<AppDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name);//Appdbcontext bulunan sýnýfýn ismini alýyoruz böylece ismi deðiþsede sorun yok
    });
});

builder.Services.AddHttpClient<ProductApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddHttpClient<CategoryApiService>(opt =>
{
    opt.BaseAddress = new Uri(builder.Configuration["BaseUrl"]);
});

builder.Services.AddScoped(typeof(NotFoundFilter<>));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));

builder.Services.AddMemoryCache();
var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
