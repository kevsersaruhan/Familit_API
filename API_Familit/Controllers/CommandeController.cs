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
  [RoutePrefix("api")]
    public class CommandeController : ApiController
    {
    private CommandeService _service = new CommandeService();
    [AcceptVerbs("POST")]
    [Route("Secure/Commande")]
    public void Add(Commandes_API entity)
    {
      _service.Add(entity);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/Commande/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("GET")]
    [Route("Commande")]
    public IEnumerable<Commandes_API> Get()
    {
      return _service.Get();
    }
    [AcceptVerbs("GET")]
    [Route("Commande/{id}")]
    public Commandes_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Commande/{id}")]
    public void Update(Commandes_API entity)
    {
      _service.Update(entity);
    }
  }
}
