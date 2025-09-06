namespace ProjectManagementAPI.Models.DTO
{
    public class CardDTO
    {
        public Guid? CardID { get; set; }
        public Guid? ColumnID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CardTitle { get; set; }
        public string? CardContent { get; set; }
    }
}
