using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Models.Requests.Board
{
    public class CreateBoardRequest : IRequest
    {
        public string? BoardName { get; set; }
        public string? Description { get; set; }
    }
}
