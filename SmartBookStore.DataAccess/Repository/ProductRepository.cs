using SmartBookStore.DataAccess.Data;
using SmartBookStore.DataAccess.Repository.IRepository;
using SmartBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartBookStore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db): base(db)
        {
            _db = db;   
        }

        public void Update(Models.Product obj)
        {
            var objFromDb= _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if (objFromDb != null) { 
                objFromDb.Title= obj.Title;
                objFromDb.ISBN= obj.ISBN ;
                objFromDb.Description= obj.Description;  
                objFromDb.Price= obj.Price; 
                objFromDb.CategoryId= obj.CategoryId;
                objFromDb.Price50= obj.Price50;
                objFromDb.Price100= obj.Price100;   
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Author = obj.Author;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl= obj.ImageUrl;
                }

            }
           // _db.Products.Update(obj);
        }
        
    }
}
