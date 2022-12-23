using FoodRecipeApi.Models;
using System.Reflection;

namespace FoodRecipeApi.Interface
{
    public interface IUsers
    {
        public List<Users> GetUsersDetails();
        public Users GetUserDetail(int id);

        public Users GetUserDetailName(string name);

        Task<IEnumerable<Users>> Search(string name);
        public void AddUser(Users user);
        public void UpdateUser(Users user);
        public Users DeleteUser(int id);

        public bool CheckUser(int id);

    }
}
