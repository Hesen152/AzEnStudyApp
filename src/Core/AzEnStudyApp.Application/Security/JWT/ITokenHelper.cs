using System.Collections.Generic;
using AzEnStudyApp.Domain.Entities;
using System;
using System.Text;

namespace AzEnStudyApp.Application.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user,List<OperationClaim> operationClaims);
        
    }
}