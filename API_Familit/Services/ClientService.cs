using API_Familit.Models.User_API;
using API_Familit.Services.Mapper;
using DAL.Model.User;
using DAL.Repository.UserRepository;
using DAL.Utils.UserUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Services
{
  public class ClientService : IClientRepository<int, Client_API>
  {
    private IClientRepository<int, Client> _repo = new ClientRepository();
    public void Activer(int id)
    {
      _repo.Activer(id);
    }

    public void Add(Client_API entity)
    {
      _repo.Add(entity.ToDAL());
    }

    public void ChangePassword(int id, string password)
    {
      _repo.ChangePassword(id, password);
    }

    public void CheckClient(int id, string login, string password)
    {
      _repo.CheckClient(id, login, password);
    }

    public void Delete(int id)
    {
      _repo.Delete(id);
    }

    public void Desactiver(int id)
    {
      _repo.Desactiver(id);
    }

    public IEnumerable<Client_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI());
    }

    public Client_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public IEnumerable<Client_API> GetByName(string name)
    {
      return _repo.GetByName(name).Select(e => e.ToAPI());
    }

    public void Update(int id, Client_API entity)
    {
      _repo.Update(id, entity.ToDAL());
    }
  }
}
