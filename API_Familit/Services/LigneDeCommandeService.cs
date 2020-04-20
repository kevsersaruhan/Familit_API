using API_Familit.Models.Commande_API;
using API_Familit.Services.Mapper;
using DAL.Model.Commande;
using DAL.Repository.CommandesRepository.LignesDeCommandeRepository;
using DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Services
{
  public class LigneDeCommandeService : IRepository<int, LigneDeCommande_API>
  {
    private LigneDeCommandeRepository _repo = new LigneDeCommandeRepository();
    public void Add(LigneDeCommande_API entity)
    {
     _repo.Add(entity.ToDAL());
    }

    public void Delete(int id)
    {
      _repo.Delete(id);
    }

    public IEnumerable<LigneDeCommande_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI());
    }

    public LigneDeCommande_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public void Update(LigneDeCommande_API entity)
    {
      _repo.Update(entity.ToDAL());
    }
    public IEnumerable<LigneDeCommande_API> GetByCommandeId(int idCommande)
    {
     return _repo.GetByCommandeId(idCommande).Select(e => e.ToAPI());
    }
    public IEnumerable<LigneDeCommande_API> GetByProductId(int idProduct)
    {
      return _repo.GetByProductId(idProduct).Select(e => e.ToAPI());
    }
  }
}
