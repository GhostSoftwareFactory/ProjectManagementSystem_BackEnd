using ProjectManagementAPI.Infra;
using ProjectManagementAPI.Services;
using ProjectManagementAPI.Services.Interfaces;
using ProjectManagementAPI.Services.Validations;

namespace ProjectManagementAPI.Config
{
    public static class ServiceCollection
    {
        public static void ApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<RedisService>();
            services.AddScoped<IBoardService, BoardService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IColumnService, ColumnService>();
            services.AddScoped<IValidations<CardValidations>, CardValidations>();
            services.AddScoped<IValidations<ColumnValidations>, ColumnValidations>();
            services.AddScoped<IValidations<BoardValidations>, BoardValidations>();
        }
    }
}
