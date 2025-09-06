namespace ProjectManagementAPI.Models.DTO
{
    public class BoardDTO
    {
        public Guid? Id { get; set; }
        public string? BoardName { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
