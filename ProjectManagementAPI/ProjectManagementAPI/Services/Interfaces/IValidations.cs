namespace ProjectManagementAPI.Services.Interfaces
{
    public interface IValidations<T>
    {
        public (bool, string) ValiateGuidParam(Guid id);

        public (bool, string) ValidateRequest(IRequest request);
    }
}
