namespace ProjectManagementAPI.Models.Requests.Column
{
    public class CreateColumnRequest
    {
        public Guid BoardId { get; set; }
        public string? ColumnName { get; set; }
    }
}
