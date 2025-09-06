namespace ProjectManagementAPI.Models.Response.Board
{
    public class CreateBoardResponse
    {
        public Guid Id { get; set; }
        public string? BoardName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
