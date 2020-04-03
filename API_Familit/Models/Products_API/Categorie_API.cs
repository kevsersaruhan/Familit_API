using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.Products_API
{
  public class Categorie_API
  {
    public Categorie_API()
    {
      ListeCaracteristique = new List<Caracteristique_API>();
    }
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Details { get; set; }
    public IEnumerable<Caracteristique_API> ListeCaracteristique { get; set; }
    public bool IsActif { get; set; }
  }
}
