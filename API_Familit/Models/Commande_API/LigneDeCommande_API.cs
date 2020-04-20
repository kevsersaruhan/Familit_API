using API_Familit.Models.Products_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Models.Commande_API
{
  public class LigneDeCommande_API
  {
    public int ID { get; set; }
    public int IDCommande { get; set; }
    public Product_API Product { get; set; }
    public int Quantite { get; set; }
    public double TOTAL { get; set; }
    public double HTVA { get; set; }
    public double TVAC { get; set; }
    public string ProductName { get; set; }
    public int ProductID { get; set; }
  }
}
