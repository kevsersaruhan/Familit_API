using DAL.Repository.UserRepository;
using DAL.Utils.UserUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Services
{
  public class ClientProductService : IClientProductFavRepository
  {
    private IClientProductFavRepository _repo = new ClientProductFavRepository();
    public void AddProductToFav(int idProduct, int idClient)
    {
      _repo.AddProductToFav(idProduct, idClient);
    }

    public void DeleteProductFav(int id)
    {
      _repo.DeleteProductFav(id);
    }
  }
}
