using ProjectManagementAPI.Models.Requests.Board;
using ProjectManagementAPI.Models.Requests.Card;
using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services.Validations
{
    public class CardValidations : IValidations<CardValidations>
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
                case CreateCardRequest createrequest
                    when string.IsNullOrWhiteSpace(createrequest.CardTitle):
                    return (false, "cardtitle name is required");

                case CreateCardRequest createrequest
                    when string.IsNullOrWhiteSpace(createrequest.CardContent):
                    return (false, "cardcontent name is required");

                default:
                    return (true, "valid request");
            }
        }
    }
}
