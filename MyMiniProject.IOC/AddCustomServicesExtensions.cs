using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyMiniProject.DataLayer.AppDbContext;
using MyMiniProject.DataLayer.MyAppDbContext;
using MyMiniProject.Models.ConnectionStrings;
using MyMiniProject.Services.Contracts;
using MyMiniProject.Services.EFServices;

namespace MyMiniProject.IOC;

public static class AddCustomServicesExtensions
{
    public static IServiceCollection AddCustomeServices(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var connectionStrings = provider.GetRequiredService<IOptionsMonitor<ConnectionStringModel>>().CurrentValue;
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(connectionStrings.MyMiniProjectContextConnection);
        });
        services.AddScoped<IUnitOfWork, ApplicationDbContext>();
        services.AddScoped<ICustomerService, CustomerService>();
        return services;
    }
}
