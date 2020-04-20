using API_Familit.Models.Connexion;
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
    [Route("Secure/Personnel/Activer/{id}")]
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
    [Route("Secure/Personnel/ChangePassword/{id}")]
    public void ChangePassword(int id, ChangePassword s)
    {
      
      _service.ChangePassword(id, s.Password);
    }

    [AcceptVerbs("POST","PUT")]
    [Route("Secure/Personnel/Check")]
    public int CheckPersonnel(LoginModel model)
    {
      return _service.CheckPersonnel(model.Login,model.MDP);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/Personnel/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("PUT","POST")]
    [Route("Secure/Personnel/Desactiver/{id}")]
    public void Desactiver(int id)
    {
      _service.Desactiver(id);
    }
    [AcceptVerbs("PUT","POST")]
    [Route("Secure/Personnel/DoAdmin/{id}")]
    public void DoAdmin(int id)
    {
      _service.DoAdmin(id);
    }

    [AcceptVerbs("GET")]
    [Route("Personnel/{id}")]
    public Personnel_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("GET")]
    [Route("Personnel/GetByShowroom/{id}")] 
    public IEnumerable<Personnel_API> GetPersonnelByShowroom(int id)
    {
      return _service.GetPersonnelByShowroom(id);
    }
    [AcceptVerbs("PUT","POST")]
    [Route("Secure/Personnel/UnsetAdmin/{id}")]
    public void UnsetAdmin(int id)
    {
      _service.UnsetAdmin(id);
    }

    [AcceptVerbs("PUT")]
    [Route("Secure/Personnel/{id}")]
    public void Update( Personnel_API entity)
    {
      _service.Update(entity);
    }
  }
}
