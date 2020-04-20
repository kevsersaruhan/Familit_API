using API_Familit.Models.User_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.Products_API
{
  public class Product_API
  {
    public Product_API()
    {
      ListeCaracteristiques = new List<Caracteristique_API>();
    }
    public int ID { get; set; }
    public string Nom { get; set; }
    public IEnumerable<Caracteristique_API> ListeCaracteristiques { get; set; }
    public double Prix { get; set; }
    public double PrixDAchatTHTVA { get; set; }
    public double TVA { get; set; }
    public int NbPiece { get; set; }
    public string Details { get; set; }
    public int ClientId { get; set; }
    public int CatId { get; set; }
    public bool IsActif { get; set; }
  }
}
