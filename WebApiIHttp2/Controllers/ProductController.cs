using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiIHttp2.Models;

namespace WebApiIHttp2.Controllers
{
    public class ProductController : ApiController
    {
        DatabaseConnection db;
        public ProductController()
        {
            db = new DatabaseConnection();
        }
        [Route ("Product/GetAll")]
        [AcceptVerbs("Get")]
        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }
        [Route ("Product/Get-id/{id:int}")]
        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }
        [Route("Product/Get-name/{name:maxlength(20)}")]
        public Product GetName(string name)
        {
            return db.Products.Where(p => p.ProductName == name).FirstOrDefault();
        }
        [HttpPost]
        public void AddProduct(Product value)
        {
            db.Products.Add(value);
            db.SaveChanges();
        }
    }
}
