using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Infra;
using ProjectManagementAPI.Models.DTO;
using ProjectManagementAPI.Models.Requests.Board;
using ProjectManagementAPI.Models.Response.Board;
using ProjectManagementAPI.Models.Schema;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services
{
    public class BoardService(DbSetConfig dbContext) : IBoardService
    {
        private readonly DbSetConfig _dbContext = dbContext;
        public async Task<(object?, bool, string)> GetBoardServiceById(Guid Id)
        {
            try
            {
                Guid guidResult;
                if (!Guid.TryParse(Id.ToString(), out guidResult))
                    return (null, false, "invalid guid");


                var card = await _dbContext.Boards.Where(x => x.Id == Id).FirstOrDefaultAsync();

                if (card is null)
                    return (null, false, "not found with this id");

                return (card, true, "success to get a board");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to get a board with this id. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> GetBoardPaginated(int pageNumber, int pageSize)
        {
            try
            {
                var board = await _dbContext.Boards
               .OrderBy(c => c.Id)
               .Skip((pageNumber - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();

                if (board.Count <= 0)
                    return (null, false, "not found any board");

                return (board, true, $"success to get page {pageNumber} with {pageSize}");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to get the boards. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> CreateBoard(BoardRequest newBoard)
        {
            if (newBoard.BoardName is null || newBoard.BoardName == string.Empty)
                return (null, false, "boardname is required");

            var boardEntity = new Board()
            {
                Id = Guid.NewGuid(),
                BoardName = newBoard.BoardName,
                Description  = newBoard.Description is null ? string.Empty : newBoard.Description,
                CreatedDate = DateTime.UtcNow,
                UpdateDate = null
            };

            try
            {
                await _dbContext.Boards.AddAsync(boardEntity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to create this board. Error: {ex.Message}");
            }
              
            var boardResponse = new BoardResponse()
            {
                Id = boardEntity.Id,
                BoardName = boardEntity.BoardName,
                Description = boardEntity.Description,
                CreatedDate = boardEntity.CreatedDate
            };

            return (boardResponse, true, "success to create this board");
        }

        public async Task<(object?, bool, string)> UpdateBoard(Guid Id, BoardRequest newBoard)
        {
            try
            {
                var board = await _dbContext.Boards.FindAsync(Id);

                if (board == null)
                    return (null, false, "not found this board");

                board.UpdateDate = DateTime.UtcNow;

                if (newBoard.BoardName != null)
                    board.BoardName = newBoard.BoardName;

                if (newBoard.Description != null)
                    board.Description = newBoard.Description;

                _dbContext.Boards.Update(board);
                await _dbContext.SaveChangesAsync();
                return (board, true, "success to udpate this board");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to update this board. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> DeleteBoard(Guid Id)
        {
            try
            {
                var board = await _dbContext.Boards.FindAsync(Id);

                if (board == null)
                    return (null, false, "not found this board");

                _dbContext.Boards.Remove(board);
                await _dbContext.SaveChangesAsync();

                return (board, true, "success to delete this board");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to delete this board. Error: {ex.Message}");
            }
        }
    }
}
