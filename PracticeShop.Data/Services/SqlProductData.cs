using PracticeShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeShop.Data.Services
{
    public class SqlProductData : IProduct
    {
        PracticeShopDbContext db;
        public SqlProductData(PracticeShopDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<Product> GetAll()
        {
            return db.Database.SqlQuery<Product>("S_GetAllProduct");
        }
    }
}
