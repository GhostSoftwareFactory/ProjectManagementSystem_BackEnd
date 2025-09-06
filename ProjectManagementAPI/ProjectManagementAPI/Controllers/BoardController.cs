using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Models.Requests.Board;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/board")]
    public class BoardController(IBoardService boardService) : BaseController
    {
        private readonly IBoardService _boardService = boardService;

        [HttpGet]
        public async Task<IActionResult> GetBoardById([FromQuery] Guid id)
        {
            try
            {
                var response = await _boardService.GetBoardServiceById(id);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpGet("/api/v1/boards")]
        public async Task<IActionResult> GetBoardsPaginated([FromQuery] int pageSize, [FromQuery] int pageNumber)
        {
            try
            {
                var response = await _boardService.GetBoardPaginated(pageNumber, pageSize);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostNewBoard([FromBody] BoardRequest request)
        {
            try
            {
                var response = await _boardService.CreateBoard(request);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> PatchBoard([FromQuery] Guid id, [FromBody] BoardRequest request)
        {
            try
            {
                var response = await _boardService.UpdateBoard(id, request);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBoard([FromQuery] Guid id)
        {
            try
            {
                var response = await _boardService.DeleteBoard(id);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }
    }
}
