namespace ProjectManagementAPI.Services.Interfaces
{
    public interface ICardService
    {
        public Task<(object?, bool, string)> GetCardById(Guid Id);
    }
}
