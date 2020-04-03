using DAL.Repository.ProductsRepository;
using DAL.Utils.ProductUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Services
{
  public class ProductCaracteristiqueService : IProductCaracteristiqueRepository
  {
    private IProductCaracteristiqueRepository _repo = new ProductCaracteristiqueRepository();
    public void AddCaracteristiqueToProduct(int idCaract, int idProduct)
    {
      _repo.AddCaracteristiqueToProduct(idCaract, idProduct);
    }

    public void DeleteCaracteristiqueFromProduct(int idCaract, int idProduct)
    {
      _repo.DeleteCaracteristiqueFromProduct(idCaract, idProduct);
    }
  }
}
