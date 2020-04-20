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
  public class CategorieService : ICategorieRepository<int, Categorie_API>
  {
    private ICategorieRepository<int, Categories> _repo = new CategorieRepository();
    public void Activer(int id)
    {
      _repo.Activer(id);
    }

    public void Add(Categorie_API entity)
    {
      _repo.Add(entity.ToDAL());
    }

    public void Delete(int id)
    {
      _repo.Delete(id);
    }

    public void Desactiver(int id)
    {
      _repo.Desactiver(id);
    }

    public IEnumerable<Categorie_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI());
    }

    public Categorie_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public IEnumerable<Categorie_API> GetCategorieByName(string s)
    {
      return _repo.GetCategorieByName(s).Select(e => e.ToAPI());
    }

    public void Update(Categorie_API entity)
    {
      _repo.Update(entity.ToDAL());
    }
  }
}
