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
    public class CommandeClientController : ApiController
    {
       private CommandeClientService _service = new CommandeClientService();

    [AcceptVerbs("POST")]
    [Route("Secure/CommandeClient")]
    public void Add(CommandeClient_API entity)
    {
      _service.Add(entity);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/CommandeClient/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("GET")]
    [Route("CommandeClient")]
    public IEnumerable<CommandeClient_API> Get()
    {
      return _service.Get();
    }
    [AcceptVerbs("GET")]
    [Route("CommandeClient/{id}")]
    public CommandeClient_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/CommandeClient/{id}")]
    public void Update( CommandeClient_API entity)
    {
      _service.Update(entity);
    }
    [AcceptVerbs("GET")]
    [Route("CommandeClient/{id}/GetCommandeClient")]
    public IEnumerable<CommandeClient_API> GetCommandeClient(int idclient)
    {
      return _service.GetCommandeClient(idclient);
    }

  }
}
