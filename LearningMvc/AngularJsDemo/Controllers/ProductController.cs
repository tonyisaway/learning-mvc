using AngularJsDemo.Interfaces;
using AngularJsDemo.Models;
using AngularJsDemo.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJsDemo.Controllers
{
    public class ProductController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        [HttpGet]
        [Route("getall/")]
        public IEnumerable GetAll()
        {
            return repository.GetAll();
        }

        public ProductList Get(int id)
        {
            return repository.Get(id);
        }

        public ProductList Post(ProductList item)
        {
            return repository.Add(item);
        }

        public IEnumerable Put(int id, ProductList product)
        {
            product.Id = id;
            return repository.Update(product) ? repository.GetAll() : null;
        }

        public bool Delete(int id)
        {
            return repository.Delete(id);
        }
    }
}
