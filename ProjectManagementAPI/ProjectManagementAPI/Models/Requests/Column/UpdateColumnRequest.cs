namespace ProjectManagementAPI.Models.Requests.Column
{
    public class UpdateColumnRequest
    {
        public Guid ColumnId { get; set; }
        public string? ColumnName { get; set; }
    }
}
