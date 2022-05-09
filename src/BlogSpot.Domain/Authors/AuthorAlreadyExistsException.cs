
using Volo.Abp;

namespace BlogSpot.Authors
{
    public class AuthorAlreadyExistsException : BusinessException
    {
        public AuthorAlreadyExistsException(string name)
            : base(BlogSpotDomainErrorCodes.AuthorAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
