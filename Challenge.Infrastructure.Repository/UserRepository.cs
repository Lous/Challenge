using Challenge.Domain.Entities;
using Challenge.Domain.IRepositories;
using Challenge.Infrastructure.Repository.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _applicationContext;

        private readonly DbSet<User> entities;

        public UserRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;

            entities = applicationContext.Set<User>();
        }

        public User Get(int id)
        {
            return entities.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return entities.AsEnumerable();
        }

        public User GetByEmail(string email)
        {
            return entities.Include(u => u.Phones).SingleOrDefault(x => x.Email == email);
        }

        public void Insert(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            entities.Add(entity);

            _applicationContext.SaveChanges();
        }

        public void Update(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            _applicationContext.SaveChanges();
        }

        public void Remove(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            entities.Remove(entity);
        }

        public void Delete(User entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            entities.Remove(entity);

            _applicationContext.SaveChanges();
        }

        public void Commit()
        {
            _applicationContext.SaveChanges();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                throw new ArgumentException();

            return entities.SingleOrDefault(e => (e.Email == email && e.Password == password));
        }
    }
}
