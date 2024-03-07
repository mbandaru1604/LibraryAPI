using LibraryAPI.Services;

namespace LibraryAPI
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {

            services.AddDistributedMemoryCache();
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(policy => { policy.WithOrigins("http://localhost:4200"); });
            });
            services.AddScoped<IBooksService, Bookservice>();
            services.AddScoped<ILibraryService, LibraryService>();
            return services;
        }
    }
}
