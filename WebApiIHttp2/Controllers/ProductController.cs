﻿using System;
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
        public IEnumerable<Product> GetAll()
        {
            return db.Products.ToList();
        }
        public HttpResponseMessage GetById(int id)
        {
            var Product = db.Products.Find(id);
            if(Product == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK,Product);
            }
        }
        [HttpPost]
        public HttpResponseMessage AddProduct(Product value)
        {
            if (value != null)
            {
                db.Products.Add(value);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, value);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, value);
            }
        }
    }
}
