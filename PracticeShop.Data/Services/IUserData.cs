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
        User Login(string username, string password);
    }
}
