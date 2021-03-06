using API_Familit.Models.Products_API;
using API_Familit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Familit.Controllers
{
  
    [RoutePrefix("api")]
    public class ProductController : ApiController
    {
      private ProductService _service = new ProductService();
      [AcceptVerbs("PUT")]
      [Route("Secure/Product/Activer/{id}")]
      public void Activer(int id)
      {
        _service.Activer(id);
      }

      [AcceptVerbs("POST")]
      [Route("Secure/Product")]
      public void Add(Product_API entity)
      {
        _service.Add(entity);
      }

      [AcceptVerbs("DELETE")]
      [Route("Secure/Product/{id}")]
      public void Delete(int id)
      {
        _service.Delete(id);
      }

      [AcceptVerbs("PUT", "POST")]
      [Route("Secure/Product/Desactiver/{id}")]
      public void Desactiver(int id)
      {
        _service.Desactiver(id);
      }

      [AcceptVerbs("GET")]
      [Route("Product")]
      public IEnumerable<Product_API> Get()
      {
        return _service.Get();
      }

      [AcceptVerbs("GET")]
      [Route("Product/{id}")]
      public Product_API Get(int id)
      {
        return _service.Get(id);
      }

      [AcceptVerbs("GET")]
      [Route("Product/GetByFournisseur/{id}")]
      public IEnumerable<Product_API> GetProductByFournisseur(int id)
      {
        return _service.GetProductByFournisseur(id);
      }

      [AcceptVerbs("GET")]
      [Route("Product/GetByName/{nom}")]
      public IEnumerable<Product_API> GetProductByName(string nom)
      {
        return _service.GetProductByName(nom);
      }
      [AcceptVerbs("GET")]
      [Route("Product/GetProductFav/{id}")]
      public IEnumerable<Product_API> GetProductFav(int id)
      {
        return _service.GetProductFav(id);
      }
      [AcceptVerbs("GET")]
      [Route("Product/GetByCaracteristique/{id}")]
      public IEnumerable<Product_API> GetProductListByCaracteristique(int idcaract)
      {
        return _service.GetProductListByCaracteristique(idcaract);
      }
      [AcceptVerbs("PUT")]
      [Route("Secure/Product/{id}")]
      public void Update(Product_API entity)
      {
        _service.Update(entity);
      }
    }
}
