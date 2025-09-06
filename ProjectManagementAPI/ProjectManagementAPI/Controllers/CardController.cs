using Microsoft.AspNetCore.Mvc;
using ProjectManagementAPI.Models.Requests.Card;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/card")]
    public class CardController(ICardService cardService) : BaseController
    {
        private readonly ICardService _cardService = cardService;

        [HttpGet]
        public async Task<IActionResult> GetColumnById([FromQuery] Guid Id)
        {
            try
            {
                var responseColumn = await _cardService.GetCardById(Id);
                return CustomResponse(responseColumn.Item1, responseColumn.Item2, responseColumn.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpGet("/api/b1/cardByColumn")]
        public async Task<IActionResult> GetCardByColumnId([FromQuery] Guid columnId)
        {
            try
            {
                var responseColumn = await _cardService.GetCardByColumnId(columnId);
                return CustomResponse(responseColumn.Item1, responseColumn.Item2, responseColumn.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostNewCard([FromBody] CreateCardRequest request)
        {
            try
            {
                var responseColumn = await _cardService.CreateNewCard(request);
                return PostCustomResponse(responseColumn.Item1, responseColumn.Item2, responseColumn.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpPatch]
        public async Task<IActionResult> PatchColumn([FromBody] UpdateCardRequest request)
        {
            try
            {
                var response = await _cardService.UpdateCard(request);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCard([FromQuery] Guid id)
        {
            try
            {
                var response = await _cardService.DeleteCard(id);
                return CustomResponse(response.Item1, response.Item2, response.Item3);
            }
            catch (Exception ex)
            {
                return InternalError(null, false, $"unhandled exception. Error: {ex.Message}");
            }
        }
    }
}
