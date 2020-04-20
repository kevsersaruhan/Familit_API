using API_Familit.Models.Etablissement_API;
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
    public class ShowroomController : ApiController
    {
      private ShowroomService _service = new ShowroomService();

    //Vérifié
    [AcceptVerbs("PUT")]
    [Route("Secure/Showroom/Activer/{id}")]
    
    public void Activer(int id)
    {
      _service.Activer(id);
    }

    //Vérifié
    [AcceptVerbs("POST")]
    [Route("Secure/Showroom")]
    public void Add(Showroom_API entity)
    {
      _service.Add(entity);
    }

    [AcceptVerbs("DELETE")]
    [Route("Secure/Showroom/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }

    [AcceptVerbs("PUT","POST")]
    [Route("Secure/Showroom/Desactiver/{id}")]
    public void Desactiver(int id)
    {
      _service.Desactiver(id);
    }

    [AcceptVerbs("GET")]
    [Route("Showroom")]
    public IEnumerable<Showroom_API> Get()
    {
      return _service.Get();
    }

    [AcceptVerbs("GET")]
    [Route("Showroom/GetById/{id}")]
    public Showroom_API Get(int id)
    {
      return _service.Get(id);
    }

    [AcceptVerbs("GET")]
    [Route("Showroom/GetByName/{name}")]
    public IEnumerable<Showroom_API> GetShowroomByName(string name)
    {
      return _service.GetShowroomByName(name);
    }

    [AcceptVerbs("PUT")]
    [Route("Secure/Showroom/{id}")]
    public void Update(Showroom_API entity)
    {
      _service.Update(entity);
    }
  }
}
