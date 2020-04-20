
using DAL.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Commande
{
  public class LigneDeCommande
  {
    public int ID { get; set; }
    public int IDCommande { get; set; }
    public int  Quantite { get; set; }
    public double TOTAL { get; set; }
    public double HTVA { get; set; }
    public double  TVAC { get; set; }
    public string ProductName { get; set; }
    public int ProductID { get; set; }
  }
}
