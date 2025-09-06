namespace ProjectManagementAPI.Models.Requests.Card
{
    public class CreateCardRequest
    {
        public Guid ColumnID { get; set; }
        public string? CardTitle { get; set; }
        public string? CardContent { get; set; }
    }
}
