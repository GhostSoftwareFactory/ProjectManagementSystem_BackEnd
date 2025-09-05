using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class BoardController(IBoardService boardService) : BaseController
    {
        private readonly IBoardService _boardService = boardService;

        [HttpGet(Name = "GetBoard")]
        public async Task<IActionResult> GetBoardById([FromQuery] Guid id)
        {
            var response = await _boardService.GetBoardServiceById(id);
            return CustomResponse(response.Item1, response.Item2, response.Item3);
        }
    }
}
