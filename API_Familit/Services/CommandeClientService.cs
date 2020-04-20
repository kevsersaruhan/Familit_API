using API_Familit.Models.Commande_API;
using API_Familit.Services.Mapper;
using DAL.Model.Commande;
using DAL.Repository.CommandesRepository;
using DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Services
{
  public class CommandeClientService : IRepository<int, CommandeClient_API>
  {
    private CommandeClientRepository _repo = new CommandeClientRepository();
    public void Add(CommandeClient_API entity)
    {
     _repo.Add(entity.ToDAL());
    }

    public void Delete(int id)
    {
      _repo.Delete(id);
    }

    public IEnumerable<CommandeClient_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI());
    }

    public CommandeClient_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public void Update(CommandeClient_API entity)
    {
      _repo.Update(entity.ToDAL());
    }

    public IEnumerable<CommandeClient_API> GetCommandeClient(int idclient)
    {
      return _repo.GetCommandeClient(idclient).Select(e => e.ToAPI());
    }
  }
}
