namespace ProjectManagementAPI.Services.Interfaces
{
    public interface IColumnService
    {
        public Task<(object?, bool, string)> GetColumnById(Guid Id);
    }
}
