using AngularJsDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJsDemo.Interfaces
{
    interface IProductRepository
    {
        IEnumerable<ProductList> GetAll();
        ProductList Get(int id);
        ProductList Add(ProductList item);
        bool Update(ProductList item);
        bool Delete(int id);
    }
}
