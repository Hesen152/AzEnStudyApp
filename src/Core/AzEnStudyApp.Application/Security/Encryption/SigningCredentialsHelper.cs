using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace AzEnStudyApp.Application.Security.Encryption
{
    public class SigningCredentialsHelper
    {
        public static SigningCredentials  CreateSinSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        } 
    }
}