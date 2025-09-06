using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Models.Requests.Card
{
    public class CreateCardRequest : IRequest
    {
        public Guid ColumnID { get; set; }
        public string? CardTitle { get; set; }
        public string? CardContent { get; set; }
    }
}
