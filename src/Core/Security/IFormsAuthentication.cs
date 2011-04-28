using System.Collections.Generic;

namespace Core.Security
{
    public interface IFormsAuthentication
    {
        void SignIn(string userName, bool createPersistentCookie, IEnumerable<string> roles);
        void SignOut();
    }
}
