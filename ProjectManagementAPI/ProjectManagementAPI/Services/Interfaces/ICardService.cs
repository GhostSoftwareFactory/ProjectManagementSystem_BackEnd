using ProjectManagementAPI.Models.Requests.Card;

namespace ProjectManagementAPI.Services.Interfaces
{
    public interface ICardService
    {
        public Task<(object?, bool, string)> GetCardById(Guid Id);
        public Task<(object?, bool, string)> GetCardByColumnId(Guid columnId);
        public Task<(object?, bool, string)> CreateNewCard(CreateCardRequest request);
        public Task<(object?, bool, string)> UpdateCard(UpdateCardRequest updateRequest);
        public Task<(object?, bool, string)> DeleteCard(Guid id);
    }
}
