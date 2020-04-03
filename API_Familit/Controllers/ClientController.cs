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
    public class ClientController : ApiController
    {
    private ClientService _service = new ClientService();
    private ClientProductService _servicefav = new ClientProductService();
    [AcceptVerbs("PUT")]
    [Route("Secure/Client/{id}/Activer")]
    public void Activer(int id)
    {
      _service.Activer(id);
    }
    [AcceptVerbs("POST")]
    [Route("Secure/Client")]
    public void Add(Client_API entity)
    {
      _service.Add(entity);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Client/{id}")]
    public void ChangePassword(int id, string password)
    {
      _service.ChangePassword(id, password);
    }
    [AcceptVerbs("POST")]
    [Route("Secure/Client/{id:int}/{login:alpha}/{password:alpha}")]
    public void CheckClient(int id, string login, string password)
    {
      _service.CheckClient(id, login, password);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/Client/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("PUT", "POST")]
    [Route("Secure/Client/{id}/Desactiver")]
    public void Desactiver(int id)
    {
      _service.Desactiver(id);
    }
    [AcceptVerbs("GET")]
    [Route("Client")]
    public IEnumerable<Client_API> Get()
    {
      return _service.Get();
    }
    [AcceptVerbs("GET")]
    [Route("Client/{id}")]
    public Client_API Get(int id)
    {
      return _service.Get(id);
    }
    [AcceptVerbs("GET")]
    [Route("Client/{name:alpha}/GetByName")]
    public IEnumerable<Client_API> GetByName(string name)
    {
      return _service.GetByName(name);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Client/{id}")]
    public void Update(int id, Client_API entity)
    {
      _service.Update(id, entity);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Client/{idproduct}/{idclient}/AddToFav")]
    public void AddProductToFav(int idProduct, int idClient)
    {
      _servicefav.AddProductToFav(idProduct, idClient);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Client/{id}/RemoveFromFav")]
    public void DeleteProductFav(int id)
    {
      _servicefav.DeleteProductFav(id);
    }
  }
}
