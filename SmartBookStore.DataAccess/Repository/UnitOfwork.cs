﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartBookStore.DataAccess.Data;
using SmartBookStore.DataAccess.Repository.IRepository;

namespace SmartBookStore.DataAccess.Repository
{
    public class UnitOfwork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfwork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }
    }
}
