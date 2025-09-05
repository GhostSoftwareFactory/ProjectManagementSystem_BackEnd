using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Infra;

namespace ProjectManagementAPI.Config
{
    public static class EntityFrameWorkConfig
    {
        public static string? conectionString = SettingConfiguration.GetSectionValue("Db", "Dbstring");
        public static void EfInitializer(this IServiceCollection services)
        {
            // Configuring EF Core with PostgreSQL
            services.AddDbContext<DbSetConfig>(options =>
                options.UseNpgsql(conectionString));
        }
    }
}
