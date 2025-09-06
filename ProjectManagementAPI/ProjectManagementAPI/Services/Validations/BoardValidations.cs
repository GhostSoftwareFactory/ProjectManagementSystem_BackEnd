using ProjectManagementAPI.Models.Requests.Board;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services.Validations
{
    public class BoardValidations : IValidations<BoardValidations>
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
                case CreateBoardRequest createrequest 
                    when string.IsNullOrWhiteSpace(createrequest.BoardName):
                    return (false, "board name is required");

                case UpdateBoardRequest update 
                    when update.BoardId == Guid.Empty:
                    return (false, "board id is required");

                default:
                    return (true, "valid request");
            }
        }
    }
}
