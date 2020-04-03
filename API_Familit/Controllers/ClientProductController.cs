using API_Familit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Familit.Controllers
{
    public class ClientProductController : ApiController
    {
      private ClientProductService _service = new ClientProductService();

    public void AddProductToFav(int idProduct, int idClient)
    {
      _service.AddProductToFav(idProduct, idClient);
    }
    public void DeleteProductFav(int id)
    {
      _service.DeleteProductFav(id);
    }
  }
}
