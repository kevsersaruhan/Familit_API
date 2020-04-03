using API_Familit.Models.User_API;
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
  public class PersonnelController : ApiController
  {
    private PersonnelService _service = new PersonnelService();

    [AcceptVerbs("GET")]
    [Route("Personnel")]
    public IEnumerable<Personnel_API> RetrieveAll()
    {
      return _service.Get();
    }

    [AcceptVerbs("PUT")]
    [Route("Secure/Personnel/{id}/Activer")]
    public void Activer(int id)
    {
      _service.Activer(id);
    }

    [AcceptVerbs("POST")]
    [Route("Secure/Personnel")]
    public void Add(Personnel_API entity)
    {
      _service.Add(entity);
    }

    [AcceptVerbs("PUT")]
    [Route("Secure/Personnel/{id}")]
    public void ChangePassword(int id, string s)
    {
      _service.ChangePassword(id, s);
    }

    [AcceptVerbs("POST")]
    [Route("Secure/Personnel/{id:int}/{login:alpha}/{password:alpha}")]
    public void CheckPersonnel(int id, string login, string password)
    {
      _service.CheckPersonnel(id, login, password);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/Personnel/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("PUT","POST")]
    [Route("Secure/Personnel/{id}/Desactiver")]
    public void Desactiver(int id)
    {
      _service.Desactiver(id);
    }
    [AcceptVerbs("PUT","POST")]
    [Route("Secure/Personnel/{id}/DoAdmin")]
    public void DoAdmin(int id)
    {
      _service.DoAdmin(id);
    }

    [AcceptVerbs("GET")]
    [Route("Personnel")]
    public Personnel_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("GET")]
    [Route("Personnel/{id}/GetByShowroom")] //Comment dissocier ????
    public IEnumerable<Personnel_API> GetPersonnelByShowroom(int idShowroom)
    {
      return _service.GetPersonnelByShowroom(idShowroom);
    }
    [AcceptVerbs("PUT","POST")]
    [Route("Secure/Personnel/{id}/UnsetAdmin")]
    public void UnsetAdmin(int id)
    {
      _service.UnsetAdmin(id);
    }

    [AcceptVerbs("PUT")]
    [Route("Secure/Personnel/{id}")]
    public void Update(int id, Personnel_API entity)
    {
      _service.Update(id, entity);
    }
  }
}
