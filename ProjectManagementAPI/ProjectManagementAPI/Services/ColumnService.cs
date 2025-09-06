using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services
{
    public class ColumnService : IColumnService
    {
        public async Task<(object?, bool, string)> GetColumnById(Guid Id)
        {
            Guid guidResult;
            if (!Guid.TryParse(Id.ToString(), out guidResult))
            {
                return (null, false, "invalid guid");
            }

            return (null, true, "validation works");
        }
    }
}
