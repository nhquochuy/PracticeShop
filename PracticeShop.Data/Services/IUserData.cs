using PracticeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShop.Data.Services
{
    public interface IUserData
    {
        bool Login(string username, string password);

        User GetUserByUserName(string username);
        IEnumerable<User> GetAll();

        string Add(User user);
        void Edit(User user);
        void Delete(string username);
    }
}
