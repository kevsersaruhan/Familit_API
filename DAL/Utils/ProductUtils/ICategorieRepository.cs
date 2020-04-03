using DAL.Model.Product;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils.ProductUtils
{
  public interface ICategorieRepository<TKey, T> : IRepository<TKey, T> where T : class
  {
    IEnumerable<T> GetCategorieByName(string s);
    void Desactiver(TKey id);
    void Activer(TKey id);
  }
}
