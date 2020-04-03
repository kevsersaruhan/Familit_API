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
  public class ProductService : IProductRepository<int, Product_API>
  {
    private IProductRepository<int, Products> _repo = new ProductRepository();
    public void Activer(int id)
    {
      _repo.Activer(id);
    }

    public void Add(Product_API entity)
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

    public IEnumerable<Product_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI());
    }

    public Product_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public IEnumerable<Product_API> GetProductByFournisseur(int id)
    {
      return _repo.GetProductByFournisseur(id).Select(e => e.ToAPI());
    }

    public IEnumerable<Product_API> GetProductByName(string s)
    {
      return _repo.GetProductByName(s).Select(e => e.ToAPI());
    }

    public IEnumerable<Product_API> GetProductFav(int id)
    {
      return _repo.GetProductFav(id).Select(e => e.ToAPI());
    }

    public IEnumerable<Product_API> GetProductListByCaracteristique(int idcaract)
    {
      return _repo.GetProductListByCaracteristique(idcaract).Select(e => e.ToAPI());
    }

    public void Update(int id, Product_API entity)
    {
      _repo.Update(id, entity.ToDAL());
    }
  }
}
