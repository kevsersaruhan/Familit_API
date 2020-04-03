using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils.UserUtils
{
  public interface IPersonnelRepository<TKey, T>: IRepository<TKey, T> where T: class
  {
    void ChangePassword(TKey id, string s);
    void CheckPersonnel(TKey id, string login, string password);
    void DoAdmin(TKey id);
    void UnsetAdmin(TKey id);
    IEnumerable<T> GetPersonnelByShowroom(int idShowroom);
    void Desactiver(TKey id);
    void Activer(TKey id);
  }
}
