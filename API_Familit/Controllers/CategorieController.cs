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
    public class CategorieController : ApiController
    {
    private CategorieService _service = new CategorieService();
    [AcceptVerbs("PUT")]
    [Route("Secure/Caracteristique/{id}/Activer")]
    public void Activer(int id)
    {
      _service.Activer(id);
    }
    [AcceptVerbs("POST")]
    [Route("Secure/Categorie")]
    public void Add(Categorie_API entity)
    {
      _service.Add(entity);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/Caracteristique/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("PUT", "POST")]
    [Route("Secure/Caracteristique/{id}/Desactiver")]
    public void Desactiver(int id)
    {
      _service.Desactiver(id);
    }
    [AcceptVerbs("GET")]
    [Route("Caracteristique")]
    public IEnumerable<Categorie_API> Get()
    {
      return _service.Get();
    }
    [AcceptVerbs("GET")]
    [Route("Caracteristique/{id}")]
    public Categorie_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("GET")]
    [Route("Caracteristique/{name}/GetCategorieByName")]
    public IEnumerable<Categorie_API> GetCategorieByName(string s)
    {
      return _service.GetCategorieByName(s);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Caracteristique/{id}")]
    public void Update(int id, Categorie_API entity)
    {
      _service.Update(id, entity);
    }
  }
}
