using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Product
{
  public class Caracteristique
  {
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Details { get; set; }
    public int? CatId { get; set; }
  }
}
