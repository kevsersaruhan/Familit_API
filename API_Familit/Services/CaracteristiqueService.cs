using API_Familit.Models.Products_API;
using API_Familit.Services.Mapper;
using DAL.Model.Product;
using DAL.Repository.ProductsRepository;
using DAL.Utils.ProductUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Services
{
  public class CaracteristiqueService : ICaracteristiqueRepository<int, Caracteristique_API>
  {
    private ICaracteristiqueRepository<int, Caracteristique> _repo = new CaracteristiqueRepository();
    public void Add(Caracteristique_API entity)
    {
      _repo.Add(entity.ToDAL());
    }

    public void Delete(int id)
    {
      _repo.Delete(id);
    }

    public IEnumerable<Caracteristique_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI());
    }

    public Caracteristique_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public IEnumerable<Caracteristique_API> GetCaracteristiqueByCategorie(int idcat)
    {
      return _repo.GetCaracteristiqueByCategorie(idcat).Select(e => e.ToAPI());
    }

    public IEnumerable<Caracteristique_API> GetCaracteristiqueByProduct(int idproduct)
    {
      return _repo.GetCaracteristiqueByProduct(idproduct).Select(e => e.ToAPI());
    }

    public void Update(Caracteristique_API entity)
    {
      _repo.Update(entity.ToDAL());
    }
  }
}
