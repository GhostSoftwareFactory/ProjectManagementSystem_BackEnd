using ProjectManagementAPI.Models.DTO;

namespace ProjectManagementAPI.Models.Requests.Board
{
    public class BoardRequest
    {
        public string? BoardName { get; set; }
        public string? Description { get; set; }
    }
}
