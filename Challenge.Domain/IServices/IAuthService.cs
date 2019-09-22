using Challenge.Domain.Entities;
using Challenge.Domain.Models;
using Challenge.Infrastructure.CrossCutting.ActionResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.IServices
{
    public interface IAuthService
    {
        string CreateToken(UserViewModel user);

        ActionResult<UserViewModel> Authenticate(AuthViewModel authViewModel);

        bool ValidateTokenClaims(string accessToken, string username);
    }
}
