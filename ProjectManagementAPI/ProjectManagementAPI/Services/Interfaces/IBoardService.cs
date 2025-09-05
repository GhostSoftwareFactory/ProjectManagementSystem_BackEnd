namespace ProjectManagementAPI.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<(object?, bool, string)> GetBoardServiceById(Guid Id);
    }
}
