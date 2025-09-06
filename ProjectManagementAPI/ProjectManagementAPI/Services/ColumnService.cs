using Microsoft.EntityFrameworkCore;
using ProjectManagementAPI.Infra;
using ProjectManagementAPI.Models.Requests.Column;
using ProjectManagementAPI.Models.Response.Column;
using ProjectManagementAPI.Models.Schema;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services
{
    public class ColumnService(DbSetConfig dbContext) : IColumnService
    {
        private readonly DbSetConfig _dbContext = dbContext;
        public async Task<(object?, bool, string)> GetColumnById(Guid Id)
        {
            try
            {
                Guid guidResult;
                if (!Guid.TryParse(Id.ToString(), out guidResult))
                    return (null, false, "invalid guid");


                var card = await _dbContext.Columns.Where(x => x.ColumnID == Id).FirstOrDefaultAsync();

                if (card is null)
                    return (null, false, "not found with this id");

                return (card, true, "success to get a column");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to get a column with this id. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> GetCardByBoardId(Guid boardId)
        {
            try
            {
                var columns = await _dbContext.Columns
                    .Where(x => x.BoardID == boardId)
                    .ToListAsync();

                if (columns.Count <= 0)
                    return (null, false, "not found any column");

                return (columns, true, $"success to get all the columns for this board");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to get the column with this board id. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> CreateNewColumn(CreateColumnRequest request)
        {
            try
            {
                var newColumn = new Column()
                {
                    ColumnID = Guid.NewGuid(),
                    BoardID = request.BoardId,
                    CreateDate = DateTime.UtcNow,
                    ColumnName = request.ColumnName,
                };

                var response = await _dbContext.Columns.AddAsync(newColumn);
                await _dbContext.SaveChangesAsync();

                var returnObject = new CreateColumnResponse()
                {
                    ColumnName = request.ColumnName,
                };

                return (returnObject, true, "success to create a new column.");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to create a new column. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> UpdateColumn(Guid Id, UpdateColumnRequest updateRequest)
        {
            try
            {
                var column = await _dbContext.Columns.FindAsync(Id);

                if (column == null)
                    return (null, false, "not found this column");

                if (updateRequest.ColumnName != null)
                    column.ColumnName = updateRequest.ColumnName;

                column.UpdateDate = DateTime.UtcNow;

                _dbContext.Columns.Update(column);
                await _dbContext.SaveChangesAsync();

                var responseObject = new ColumnUpdateResponse()
                {
                    ColumnId = column.ColumnID,
                    ColumnName = updateRequest.ColumnName,
                };

                return (responseObject, true, "success to udpate this column");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to update this column. Error: {ex.Message}");
            }
        }

        public async Task<(object?, bool, string)> DeleteColumn(Guid id)
        {
            try
            {
                var column = await _dbContext.Columns.FindAsync(id);

                if (column == null)
                    return (null, false, "not found this column");

                _dbContext.Columns.Remove(column);
                await _dbContext.SaveChangesAsync();

                return (column, true, "success to delete this column");
            }
            catch (Exception ex)
            {
                return (null, false, $"failed to delete this column. Error: {ex.Message}");
            }
        }
    }
}
