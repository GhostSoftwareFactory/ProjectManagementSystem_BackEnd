namespace ProjectManagementAPI.Models.Response.Board
{
    public class UpdateBoardResponse
    {
        public Guid Id { get; set; }
        public string? BoardName { get; set; }
        public string? Description { get; set; }
    }
}
