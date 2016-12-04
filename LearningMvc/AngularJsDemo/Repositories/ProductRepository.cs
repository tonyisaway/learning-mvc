using AngularJsDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJsDemo.Models;

namespace AngularJsDemo.Repositories
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        readonly DataStoreEntities db = new DataStoreEntities();

        public ProductList Add(ProductList item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            db.ProductLists.Add(item);
            db.SaveChanges();

            return item;
        }

        public bool Delete(int id)
        {
            var product = Get(id);

            if (product != null)
            {
                db.ProductLists.Remove(product);
                db.SaveChanges();
            }

            return true;
        }

        public ProductList Get(int id)
        {
            var product = db.ProductLists.Find(id);
            return product;
        }

        public IEnumerable<ProductList> GetAll()
        {
            var products = db.ProductLists;
            return products;
        }

        public bool Update(ProductList item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            var original = Get(item.Id);
            if (original == null)
            {
                throw new InvalidOperationException(string.Format("A ProductList does not exist with Id: {0}", item.Id));
            }

            // original.Id = item.Id;
            original.Name = item.Name;
            original.Price = item.Price;
            original.Category = item.Category;

            //db.ProductLists.Attach(item);
            //var entry = db.Entry(item);
            //// entry.Property(e => e.Id).IsModified = true;
            //entry.Property(e => e.Name).IsModified = true;
            //entry.Property(e => e.Price).IsModified = true;
            db.SaveChanges();

            return true;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}