using ProjectManagementAPI.Models.Requests.Board;

namespace ProjectManagementAPI.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<(object?, bool, string)> GetBoardServiceById(Guid Id);
        public Task<(object?, bool, string)> GetBoardPaginated(int pageNumber, int pageSize);
        public Task<(object?, bool, string)> CreateBoard(CreateBoardRequest newBoard);
        public Task<(object?, bool, string)> UpdateBoard(UpdateBoardRequest request);
        public Task<(object?, bool, string)> DeleteBoard(Guid Id);
    }
}
