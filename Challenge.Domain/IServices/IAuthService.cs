using Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.IServices
{
    public interface IAuthService
    {
        string CreateToken(User user);

        User Authenticate(string email, string password);
    }
}
