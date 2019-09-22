using Challenge.Domain.Entities;
using Challenge.Domain.Models;
using Challenge.Infrastructure.CrossCutting.ActionResults;
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

        ActionResult InsertUser(UserViewModel userViewModel);

        void UpdateUser(User user);

        void UpdateInfoAccess(UserViewModel userViewModel);

        ActionResult<UserInfoViewModel> GetUserInfo(string email);

        void DeleteUser(int id);
    }
}
