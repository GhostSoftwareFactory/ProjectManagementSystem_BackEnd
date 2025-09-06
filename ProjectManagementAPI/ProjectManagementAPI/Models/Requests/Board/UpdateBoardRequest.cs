using ProjectManagementAPI.Models.DTO;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Models.Requests.Board
{
    public class UpdateBoardRequest : IRequest
    {
        public Guid BoardId { get; set; }
        public string? BoardName { get; set; }
        public string? Description { get; set; }
    }
}
