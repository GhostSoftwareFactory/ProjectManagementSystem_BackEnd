namespace ProjectManagementAPI.Models.Schema
{
    public class Board
    {
        public Guid Id {  get; set; }
        public string? BoardName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
