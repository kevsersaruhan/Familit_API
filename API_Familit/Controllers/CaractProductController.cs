using API_Familit.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Familit.Controllers
{
  [RoutePrefix("api")]
  public class CaractProductController : ApiController
    {
    private ProductCaracteristiqueService _service = new ProductCaracteristiqueService();

    [AcceptVerbs ("PUT")]
    [Route("Secure/CaracteristiqueProduct/Add/{idCaract}/{idProduct}")]
      public void AddCaracteristiqueToProduct(int idCaract, int idProduct)
      {
      _service.AddCaracteristiqueToProduct(idCaract, idProduct);
      }

    [AcceptVerbs("DELETE")]
    [Route("Secure/CaracteristiqueProduct/Delete/{idCaract}/{idProduct}")]
    public void DeleteCaracteristiqueFromProduct(int idCaract, int idProduct)
      {
      _service.DeleteCaracteristiqueFromProduct(idCaract, idProduct);
      }
    }
}
