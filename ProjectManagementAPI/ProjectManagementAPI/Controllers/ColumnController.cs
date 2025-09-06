using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class ColumnController(IColumnService columnService) : BaseController
    {
        private readonly IColumnService _columnService = columnService;

        [HttpGet("/column")]
        public async Task<IActionResult> GetCardById([FromQuery] Guid Id)
        {
            var response = await _columnService.GetColumnById(Id);
            return CustomResponse(response.Item1, response.Item2, response.Item3);
        }
    }
}
