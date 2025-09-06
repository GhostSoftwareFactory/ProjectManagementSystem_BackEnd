using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Infra;
using ProjectManagementAPI.Models.Requests.Board;
using ProjectManagementAPI.Models.Response.Board;
using ProjectManagementAPI.Models.Schema;
using ProjectManagementAPI.Services.Interfaces;
using ProjectManagementAPI.Services.Validations;

namespace ProjectManagementAPI.Services
{
    public class BoardService(
        DbSetConfig dbContext,
        IValidations<BoardValidations> validations
        ) : IBoardService
    {
        private readonly DbSetConfig _dbContext = dbContext;
        private readonly IValidations<BoardValidations> _boardValidations = validations;
        public async Task<(object?, bool, string)> GetBoardServiceById(Guid Id)
        {
            try
            {
                var validation = _boardValidations.ValiateGuidParam(Id);
                if (!validation.Item1)
                    return (null, validation.Item1, validation.Item2);

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

        public async Task<(object?, bool, string)> CreateBoard(CreateBoardRequest newBoard)
        {
            var validationReturn = _boardValidations.ValidateRequest(newBoard);
            if (!validationReturn.Item1)
                return (null, validationReturn.Item1, validationReturn.Item2);

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
              
            var boardResponse = new CreateBoardResponse()
            {
                Id = boardEntity.Id,
                BoardName = boardEntity.BoardName,
                Description = boardEntity.Description,
                CreatedDate = boardEntity.CreatedDate
            };

            return (boardResponse, true, "success to create this board");
        }

        public async Task<(object?, bool, string)> UpdateBoard(UpdateBoardRequest request)
        {
            try
            {
                var validationReturn = _boardValidations.ValidateRequest(request);
                if (!validationReturn.Item1)
                    return (null, validationReturn.Item1, validationReturn.Item2);

                var board = await _dbContext.Boards.FindAsync(request.BoardId);

                if (board == null)
                    return (null, false, "not found this board");

                board.UpdateDate = DateTime.UtcNow;

                if (request.BoardName != null)
                    board.BoardName = request.BoardName;

                if (request.Description != null)
                    board.Description = request.Description;

                _dbContext.Boards.Update(board);
                await _dbContext.SaveChangesAsync();


                var responseObject = new UpdateBoardResponse()
                {
                    Id = board.Id,
                    BoardName = board.BoardName,
                    Description = board.Description,
                };

                return (responseObject, true, "success to udpate this board");
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
                var validation = _boardValidations.ValiateGuidParam(Id);
                if (!validation.Item1)
                    return (null, validation.Item1, validation.Item2);

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
