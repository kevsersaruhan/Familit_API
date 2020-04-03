
using DAL.Model.Product;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils.ProductUtils
{
    public interface IProductCaracteristiqueRepository 
    {
      void AddCaracteristiqueToProduct(int idCaract, int idProduct);
      void DeleteCaracteristiqueFromProduct(int idCaract, int idProduct);
    }
}
