﻿using PracticeShop.Data.DAO;
using PracticeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public string Add(User user)
        {
            string erro_Mess = "";
            if (user != null)
            {
                if (GetUserByUserName(user.UserName) != null) return erro_Mess = "This username is exist !!!";

                try
                {
                    user.Password = Encryptor.MD5Hash(user.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch(DbEntityValidationException ex)
                {
                    return erro_Mess = ex.InnerException.Message;
                }
            }
            return erro_Mess;
        }

        public void Delete(string username)
        {
            var User = GetUserByUserName(username);
            if(User != null)
            {
                db.Users.Remove(User);
                db.SaveChanges();
            }
        }

        public void Edit(User user)
        {
            if(GetUserByUserName(user.UserName) != null)
            {
                //    var entry = db.Entry(User);
                //    entry.State = EntityState.Modified;
                User us = db.Users.FirstOrDefault(x => x.ID == user.ID);
                us.Name = user.Name;
                us.UserName = user.UserName;
                db.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.Database.SqlQuery<User>("S_GetAllUser");
            //return db.Users.OrderBy(x => x.UserName);
        }

        public User GetUserByUserName(string username)
        {
            return db.Database.SqlQuery<User>("S_GetUserByUserName @username", new object[] { new SqlParameter("@username", username) })
                    .ToList().SingleOrDefault();
            //return db.Users.FirstOrDefault(x => x.UserName == username);
        }

        public bool Login(string username, string password)
        {
            password = Encryptor.MD5Hash(password);
            object[] vs = new object[] { new SqlParameter("@username", username),
                                         new SqlParameter("@password", password)};
            return db.Database.SqlQuery<bool>("S_UserLogin @username,@password", vs).SingleOrDefault();
            //return (db.Users.FirstOrDefault(x => x.UserName == username && x.Password == password) != null);
        }

    }
}
