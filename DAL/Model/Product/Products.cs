
using DAL.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Product
{
  public class Products
  {
    public int ID { get; set; }
    public string Nom { get; set; }
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
