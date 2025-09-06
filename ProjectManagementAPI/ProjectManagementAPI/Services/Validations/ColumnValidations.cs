using ProjectManagementAPI.Models.Requests.Card;
using ProjectManagementAPI.Models.Requests.Column;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services.Validations
{
    public class ColumnValidations : IValidations<ColumnValidations>
    {
        public (bool, string) ValiateGuidParam(Guid id)
        {
            Guid guidResult;
            if (!Guid.TryParse(id.ToString(), out guidResult))
                return (false, "invalid guid");

            return (true, "the guid is valid");
        }


        public (bool, string) ValidateRequest(IRequest request)
        {
            switch (request)
            {
                case CreateColumnRequest createrequest
                    when createrequest.BoardId == Guid.Empty:
                    return (false, "boardId is required");

                default:
                    return (true, "valid request");
            }
        }

    }
}