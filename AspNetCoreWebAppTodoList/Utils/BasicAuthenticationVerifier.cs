using System.Threading.Tasks;
using Bazinga.AspNetCore.Authentication.Basic;

namespace AspNetCoreWebAppTodoList.Utils
{
    public class BasicAuthenticationVerifier : IBasicCredentialVerifier
    {
        public Task<bool> Authenticate(string username, string password)
        {
            var result =  username == "username" && password == "password";

            return Task.FromResult(result);
        }
    }
}