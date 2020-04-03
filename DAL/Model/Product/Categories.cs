using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model.Product
{
  public  class Categories
  {
    public Categories()
    {
      ListeCaracteristique = new List<Caracteristique>();
    }
    public int ID { get; set; }
    public string Nom { get; set; }
    public string Details { get; set; }
    public IEnumerable<Caracteristique> ListeCaracteristique { get; set; }
    public bool IsActif { get; set; }
  }
}
