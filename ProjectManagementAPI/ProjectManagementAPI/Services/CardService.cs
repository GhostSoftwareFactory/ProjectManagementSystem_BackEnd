using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services
{
    public class CardService : ICardService
    {
        public async Task<(object?, bool, string)> GetCardById(Guid Id)
        {
            Guid guidResult;
            if (!Guid.TryParse(Id.ToString(), out guidResult))
            {
                return (null, false, "invalid guid");
            }

            return (null, true, "validation works");
        }
    }
}
