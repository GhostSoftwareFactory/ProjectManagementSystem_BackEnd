using ProjectManagementAPI.Services;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Config
{
    public static class ServiceCollection
    {
        public static void ApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IColumnService, ColumnService>();
        }
    }
}
