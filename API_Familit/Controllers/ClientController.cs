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
    public class ClientController : ApiController
    {
    private ClientService _service = new ClientService();
    private ClientProductService _servicefav = new ClientProductService();
    [AcceptVerbs("PUT")]
    [Route("Secure/Client/Activer/{id}")]
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
    [Route("Secure/Client/ChangePassword/{id}")]
    public void ChangePassword(int id, ChangePassword password)
    {
      _service.ChangePassword(id, password.Password);
    }
    [AcceptVerbs("POST")]
    [Route("Secure/Client/Check")]
    public int CheckClient(LoginModel model)
    {
      return _service.CheckClient(model.Login, model.MDP);
    }
    [AcceptVerbs("DELETE")]
    [Route("Secure/Client/{id}")]
    public void Delete(int id)
    {
      _service.Delete(id);
    }
    [AcceptVerbs("PUT", "POST")]
    [Route("Secure/Client/Desactiver/{id}")]
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
    [Route("Client/GetByName/{name:alpha}")]
    public IEnumerable<Client_API> GetByName(string name)
    {
      return _service.GetByName(name);
    }

    [AcceptVerbs("GET")]
    [Route("Client/GetFournisseur")]
    public IEnumerable<Client_API> GetFournisseur()
    {
      return _service.GetFournisseur();
    }

    [AcceptVerbs("PUT")]
    [Route("Secure/Client/{id}")]
    public void Update( Client_API entity)
    {
      _service.Update(entity);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Client/AddToFav/{idProduct}/{idClient}")]
    public void AddProductToFav(int idProduct, int idClient)
    {
      _servicefav.AddProductToFav(idProduct, idClient);
    }
    [AcceptVerbs("PUT")]
    [Route("Secure/Client/RemoveFromFav/{id}")]
    public void DeleteProductFav(int id)
    {
      _servicefav.DeleteProductFav(id);
    }
  }
}
