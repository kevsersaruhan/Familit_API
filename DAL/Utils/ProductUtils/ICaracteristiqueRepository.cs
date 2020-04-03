using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils.ProductUtils
{
  public interface ICaracteristiqueRepository<TKey, T> : IRepository<TKey, T> where T : class
  {
    IEnumerable<T> GetCaracteristiqueByCategorie(int idcat);
    IEnumerable<T> GetCaracteristiqueByProduct(int idproduct);
  }
}
