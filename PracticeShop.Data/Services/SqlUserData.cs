using PracticeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShop.Data.Services
{
    public class SqlUserData : IUserData
    {
        PracticeShopDbContext db;
        public SqlUserData(PracticeShopDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users.OrderBy(x => x.UserName);
        }

        public User GetUserByUserName(string username)
        {
            return db.Users.FirstOrDefault(x => x.UserName == username);
        }

        public bool Login(string username, string password)
        {
            password = Encryptor.MD5Hash(password);
            return (db.Users.FirstOrDefault(x => x.UserName == username && x.Password == password) != null);
        }
    }
}
