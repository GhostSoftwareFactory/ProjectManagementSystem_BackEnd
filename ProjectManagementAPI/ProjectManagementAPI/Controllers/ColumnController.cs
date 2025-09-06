using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Models.Requests.Board;
using ProjectManagementAPI.Models.Requests.Column;
using ProjectManagementAPI.Services;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/column")]
    public class ColumnController(IColumnService columnService) : BaseController
    {
        private readonly IColumnService _columnService = columnService;

        [HttpGet]
        public async Task<IActionResult> GetColumnById([FromQuery] Guid Id)
        {
            try
            {
                var responseColumn = await _columnService.GetColumnById(Id);
                return CustomResponse(responseColumn.Item1, responseColumn.Item2, responseColumn.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpGet("/api/b1/columnsByBoard")]
        public async Task<IActionResult> GetColumnsByBoard([FromQuery] Guid BoardId)
        {
            try
            {
                var responseColumn = await _columnService.GetColumnByBoardId(BoardId);
                return CustomResponse(responseColumn.Item1, responseColumn.Item2, responseColumn.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostNewColumn([FromBody] CreateColumnRequest request)
        {
            try
            {
                var responseColumn = await _columnService.CreateNewColumn(request);
                return PostCustomResponse(responseColumn.Item1, responseColumn.Item2, responseColumn.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> PatchColumn([FromBody] UpdateColumnRequest request)
        {
            try
            {
                var response = await _columnService.UpdateColumn(request);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteColumn([FromQuery] Guid id)
        {
            try
            {
                var response = await _columnService.DeleteColumn(id);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }
    }
}
