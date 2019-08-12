using Challenge.Domain.Entities;
using Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.IServices
{
    public interface IAuthService
    {
        (UserViewModel userViewModel, string accessToken) CreateToken(UserViewModel user);

        UserViewModel Authenticate(AuthViewModel authViewModel);

        bool ValidateTokenClaims(string accessToken, string username);
    }
}
