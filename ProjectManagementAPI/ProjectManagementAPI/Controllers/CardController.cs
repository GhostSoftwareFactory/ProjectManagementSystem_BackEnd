using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/v1")]
    public class CardController(ICardService cardService) : BaseController
    {
        private readonly ICardService _cardService = cardService;

        [HttpGet("/card")]
        public async Task<IActionResult> GetCardById([FromQuery] Guid Id)
        {
            var response = await _cardService.GetCardById(Id);
            return CustomResponse(response.Item1, response.Item2, response.Item3);
        }
    }
}
