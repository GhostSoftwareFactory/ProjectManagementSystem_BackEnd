using ProjectManagementAPI.Models.Requests.Column;

namespace ProjectManagementAPI.Services.Interfaces
{
    public interface IColumnService
    {
        public Task<(object?, bool, string)> GetColumnById(Guid Id);
        public Task<(object?, bool, string)> GetCardByBoardId(Guid boardId);
        public Task<(object?, bool, string)> CreateNewColumn(CreateColumnRequest request);
        public Task<(object?, bool, string)> UpdateColumn(Guid Id, UpdateColumnRequest updateRequest);
        public Task<(object?, bool, string)> DeleteColumn(Guid id);
    }
}
