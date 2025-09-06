namespace ProjectManagementAPI.Models.Schema
{
    public class Card
    {
        public Guid CardID { get; set; }
        public Guid? ColumnID { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CardTitle { get; set; }
        public string? CardContent { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
