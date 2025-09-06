using ProjectManagementAPI.Models.DTO;

namespace ProjectManagementAPI.Models.Requests.Board
{
    public class UpdateBoardRequest
    {
        public Guid BoardId { get; set; }
        public string? BoardName { get; set; }
        public string? Description { get; set; }
    }
}
