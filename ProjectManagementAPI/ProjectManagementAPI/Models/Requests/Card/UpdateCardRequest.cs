namespace ProjectManagementAPI.Models.Requests.Card
{
    public class UpdateCardRequest
    {
        public Guid CardId { get; set; }
        public Guid? ColumnID { get; set; }
        public string? CardTitle { get; set; }
        public string? CardContent { get; set; }
    }
}
