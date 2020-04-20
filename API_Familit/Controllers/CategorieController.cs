using API_Familit.Models.Products_API;
using API_Familit.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace API_Familit.Controllers
{
  [RoutePrefix("api")]
  public class CategorieController : ApiController
    {
    private CategorieService _service = new CategorieService();
    [AcceptVerbs("PUT")]
    [Route("Secure/Categorie/Activer/{id}")]
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
    [Route("Secure/Categorie/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("PUT", "POST")]
    [Route("Secure/Categorie/Desactiver/{id}")]
    public void Desactiver(int id)
    {
      _service.Desactiver(id);
    }
    [AcceptVerbs("GET")]
    [Route("Categorie")]
    public IEnumerable<Categorie_API> Get()
    {
      return _service.Get();
    }
    [AcceptVerbs("GET")]
    [Route("Categorie/{id}")]
    public Categorie_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("GET")]
    [Route("Categorie/GetByName/{name}")]
    public IEnumerable<Categorie_API> GetCategorieByName(string name)
    {
      return _service.GetCategorieByName(name);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Categorie/{id}")]
    public void Update(Categorie_API entity)
    {
      _service.Update(entity);
    }
  }
}
