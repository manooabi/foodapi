using FoodRecipeApi.Interface;
using FoodRecipeApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;

namespace FoodRecipeApi.Repository
{
    public class UsersRepository : IUsers
    {
        readonly DatabaseContext _dbContext = new();

        public UsersRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Users> GetUsersDetails()
        {
            try
            {
                return _dbContext.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Users GetUserDetail(int id)
        {
            try
            {
                Users? user = _dbContext.Users.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        public Users GetUserDetailName(string name)
        {
            try
            {
                Users? user = _dbContext.Users.Find(name);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Users>> Search(string name)
        {
            IQueryable<Users> query = _dbContext.Users;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.UserName.Contains(name)
                            );
            }

           

            return await query.ToListAsync();
        }
        public void AddUser(Users users)
        {
            try
            {
                _dbContext.Users.Add(users);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUser(Users users)
        {
            try
            {
                _dbContext.Entry(users).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Users DeleteUser(int id)
        {
            try
            {
                Users? users = _dbContext.Users.Find(id);

                if (users != null)
                {
                    _dbContext.Users.Remove(users);
                    _dbContext.SaveChanges();
                    return users;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool CheckUser(int id)
        {
            return _dbContext.Users.Any(e => e.UserId == id);
        }
    }
}
