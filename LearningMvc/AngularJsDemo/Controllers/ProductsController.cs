using AngularJsDemo.Interfaces;
using AngularJsDemo.Repositories;
using System.Collections;
using System.Web.Http;

namespace AngularJsDemo.Controllers
{
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable Get()
        {
            return repository.GetAll();
        }

    }
}