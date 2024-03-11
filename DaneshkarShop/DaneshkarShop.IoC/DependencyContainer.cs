using DaneshkarShop.Application.Services.Implementation;
using DaneshkarShop.Application.Services.Interface;
using DaneshkarShop.Data.Repositories;
using DaneshkarShop.Domain.IRepositories;
using Microsoft.Extensions.DependencyInjection;

namespace DaneshkarShop.IoC;

public class DependencyContainer
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Add services to the container.
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IRoleService, RoleService>();

        services.AddScoped<IContactUsRepository, ContactUsRepository>();
        services.AddScoped<IContactUsService, ContactUsService>();

        //Product Categories
        services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
    }
}
