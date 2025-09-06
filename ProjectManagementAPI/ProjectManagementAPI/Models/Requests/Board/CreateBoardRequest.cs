namespace ProjectManagementAPI.Models.Requests.Board
{
    public class CreateBoardRequest
    {
        public Guid BoardId { get; set; }
        public string? BoardName { get; set; }
        public string? Description { get; set; }
    }
}
