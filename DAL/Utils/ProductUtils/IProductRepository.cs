using DAL.Model.Product;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils.ProductUtils
{
  public interface IProductRepository<TKey, T> : IRepository<TKey, T> where T: class
  {
    IEnumerable<T> GetProductByName(string s);
    IEnumerable<T> GetProductByFournisseur(int id);
    IEnumerable<T> GetProductFav(int id);
    IEnumerable<T> GetProductListByCaracteristique(int idcaract);
    void Desactiver(TKey id);
    void Activer(TKey id);
  }
}
