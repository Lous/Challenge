using Challenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);

        User GetByEmailAndPassword(string email, string password);
    }
}
