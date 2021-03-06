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
  public class CaracteristiqueController : ApiController
    {
       private CaracteristiqueService _service = new CaracteristiqueService();
    [AcceptVerbs("POST")]
    [Route("Secure/Caracteristique")]
    public void Add(Caracteristique_API entity)
    {
      _service.Add(entity);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/Caracteristique/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("GET")]
    [Route("Caracteristique")]
    public IEnumerable<Caracteristique_API> Get()
    {
      return _service.Get();
    }
    [AcceptVerbs("GET")]
    [Route("Caracteristique/{id}")]
    public Caracteristique_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("GET")]
    [Route("Caracteristique/GetByCategorie/{id}")]
    public IEnumerable<Caracteristique_API> GetCaracteristiqueByCategorie(int id)
    {
      return _service.GetCaracteristiqueByCategorie(id);
    }
    [AcceptVerbs("GET")]
    [Route("Caracteristique/GetByProduct/{id}")]
    public IEnumerable<Caracteristique_API> GetCaracteristiqueByProduct(int id)
    {
      return _service.GetCaracteristiqueByProduct(id);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Caracteristique/{id}")]
    public void Update(Caracteristique_API entity)
    {
      _service.Update(entity);
    }
  }
}
