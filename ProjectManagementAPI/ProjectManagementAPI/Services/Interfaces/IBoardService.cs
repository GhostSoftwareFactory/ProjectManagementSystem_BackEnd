using ProjectManagementAPI.Models.Requests.Board;

namespace ProjectManagementAPI.Services.Interfaces
{
    public interface IBoardService
    {
        public Task<(object?, bool, string)> GetBoardServiceById(Guid Id);
        public Task<(object?, bool, string)> GetBoardPaginated(int pageNumber, int pageSize);
        public Task<(object?, bool, string)> CreateBoard(BoardRequest newBoard);
        public Task<(object?, bool, string)> UpdateBoard(Guid Id, BoardRequest newBoard);
        public Task<(object?, bool, string)> DeleteBoard(Guid Id);
    }
}
