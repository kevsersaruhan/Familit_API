using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils.EtablissementUtils
{
  public interface IShowroomRepository<Tkey,T> : IRepository<Tkey,T> where T:class
  {
    IEnumerable<T> GetShowroomByName(string name);
    void Desactiver(Tkey id);
    void Activer(Tkey id);
  }
}
