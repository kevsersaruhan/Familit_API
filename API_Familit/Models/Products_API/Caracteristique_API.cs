using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.Products_API
{
  public class Caracteristique_API
  {
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Details { get; set; }
    public Categorie_API Categorie { get; set; }
    public IEnumerable<Product_API> ListeProduits { get; set; }
    public int CatId { get; set; }

  }
}
