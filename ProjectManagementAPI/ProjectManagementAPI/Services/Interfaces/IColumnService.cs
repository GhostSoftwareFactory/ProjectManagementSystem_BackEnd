using ProjectManagementAPI.Models.Requests.Column;

namespace ProjectManagementAPI.Services.Interfaces
{
    public interface IColumnService
    {
        public Task<(object?, bool, string)> GetColumnById(Guid Id);
        public Task<(object?, bool, string)> GetColumnByBoardId(Guid boardId);
        public Task<(object?, bool, string)> CreateNewColumn(CreateColumnRequest request);
        public Task<(object?, bool, string)> UpdateColumn(UpdateColumnRequest updateRequest);
        public Task<(object?, bool, string)> DeleteColumn(Guid id);
    }
}
