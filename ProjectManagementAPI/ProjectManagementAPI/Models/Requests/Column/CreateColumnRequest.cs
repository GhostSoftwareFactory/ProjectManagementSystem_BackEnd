using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Models.Requests.Column
{
    public class CreateColumnRequest : IRequest
    {
        public Guid BoardId { get; set; }
        public string? ColumnName { get; set; }
    }
}
