using PracticeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShop.Data.Services
{
    public class UserData : IUserData
    {
        PracticeShopDbContext db = null;
        public UserData()
        {
            this.db = new PracticeShopDbContext();
        }
        public User Login(string username, string password)
        {
            return db.Users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}
