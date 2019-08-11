using Challenge.Domain.Entities;
using Challenge.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Domain.IServices
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();

        User GetUserById(int id);

        User GetUserByEmail(string email);

        void InsertUser(UserViewModel userViewModel);

        void UpdateUser(User user);

        void DeleteUser(int id);
    }
}
