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
  public class CommandeService : ICommandeRepository<int, Commandes_API>
  {
    private ICommandeRepository<int, Commandes> _repo = new CommandeRepository();
    public void Add(Commandes_API entity)
    {
      _repo.Add(entity.ToDAL());
    }

    public void Delete(int id)
    {
      _repo.Delete(id);
    }

    public IEnumerable<Commandes_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI());
    }

    public Commandes_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public IEnumerable<Commandes_API> GetCommandeClient(int idclient)
    {
      return _repo.GetCommandeClient(idclient).Select(e => e.ToAPI());
    }

    public void Update(Commandes_API entity)
    {
      _repo.Update(entity.ToDAL());
    }
 
  }
}
