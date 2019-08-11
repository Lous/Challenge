using Challenge.Domain.Entities;
using Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Infrastructure.Service
{
    public interface IUserValidationService
    {
        IUserValidationService Validate(UserViewModel userViewModel);
    }
}
