using API_Familit.Models.Commande_API;
using API_Familit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Familit.Controllers
{
  [RoutePrefix("api'")]
    public class LigneDeCommandeController : ApiController
    {
      private LigneDeCommandeService _service = new LigneDeCommandeService();

    [AcceptVerbs("POST")]
    [Route("Secure/LigneDeCommande")]
    public void Add(LigneDeCommande_API entity)
    {
      _service.Add(entity);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/LigneDeCommande/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("GET")]
    [Route("LigneDeCommande")]
    public IEnumerable<LigneDeCommande_API> Get()
    {
      return _service.Get();
    }
    [AcceptVerbs("GET")]
    [Route("LigneDeCommande/{id}")]
    public LigneDeCommande_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/LigneDeCommande/{id}")]
    public void Update(int id, LigneDeCommande_API entity)
    {
      _service.Update(id, entity);
    }
    [AcceptVerbs("GET")]
    [Route("LigneDeCommande/{id}/GetByCommande")]
    public IEnumerable<LigneDeCommande_API> GetByCommandeId(int idCommande)
    {
      return _service.GetByCommandeId(idCommande);
    }
    [AcceptVerbs("GET")]
    [Route("LigneDeCommande/{id}/GetByProduct")]
    public IEnumerable<LigneDeCommande_API> GetByProductId(int idProduct)
    {
      return _service.GetByProductId(idProduct);
    }
  }
}
