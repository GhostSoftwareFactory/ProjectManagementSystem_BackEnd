using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Models.Requests.Column
{
    public class UpdateColumnRequest : IRequest
    {
        public Guid ColumnId { get; set; }
        public string? ColumnName { get; set; }
    }
}
