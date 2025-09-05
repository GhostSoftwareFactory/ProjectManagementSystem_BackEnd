using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Models.Schema;

namespace ProjectManagementAPI.Infra
{
    public class DbSetConfig : DbContext
    {
        public DbSetConfig(DbContextOptions<DbSetConfig> options) : base(options) { }

        public DbSet<Board> Boards { get; set; }
    }
}
