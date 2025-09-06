namespace ProjectManagementAPI.Models.Response.Card
{
    public class UpdateCardResponse
    {
        public Guid CardId { get; set; }
        public Guid? ColumnID { get; set; }
        public string? CardTitle { get; set; }
        public string? CardContent { get; set; }
    }
}
