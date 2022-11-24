using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiIHttp2.CustomActionResult;
using WebApiIHttp2.Models;

namespace WebApiIHttp2.Controllers
{
    public class ProductinfoController : ApiController
    {
        DatabaseConnection db;
        public ProductinfoController()
        {
            db = new DatabaseConnection();
        }
        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }
        public IHttpActionResult GetById(int id)
        {
            var Product = db.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Product);
            }
        }
        [HttpPost]
        public IHttpActionResult AddProduct(Product value)
        {
            if (value != null)
            {
                db.Products.Add(value);
                db.SaveChanges();
                return Created(Request.RequestUri, value);
            }
            else
            {
                return BadRequest();
            }
        }
        
        public IHttpActionResult GetNameById(int id)
        {
            var Product = db.Products.Find(id);
            if (Product == null)
            {
                return NotFound();
            }
            else
            {
                return new TestResult(Product.ProductName, Request);
            }
        }
    }
}
