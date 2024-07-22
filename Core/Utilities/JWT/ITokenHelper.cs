using Core.Entities;

namespace Core.Utilities.JWT
{
    public interface ITokenHelper
    {
        public AccessToken CreateToken(BaseUser user, List<BaseOperationClaim> operationClaims);
    }
}
