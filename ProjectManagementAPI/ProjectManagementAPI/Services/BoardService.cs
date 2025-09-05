using ProjectManagementAPI.Services.Interfaces;

namespace ProjectManagementAPI.Services
{
    public class BoardService : IBoardService
    {
        public async Task<(object?, bool, string)> GetBoardServiceById(Guid Id)
        {
            Guid guidResult;
            if(!Guid.TryParse(Id.ToString(), out guidResult))
            {
                return (null, false, "invalid guid");
            }

            return (null, true, "validation works");
        }
    }
}
