using DAL.Model.User;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Utils.UserUtils
{
  public interface IClientRepository<TKey,T> : IRepository<TKey, T> where T : class
  {
    void ChangePassword(TKey id, string password);
    void CheckClient(TKey id, string login, string password);
    IEnumerable<T> GetByName(string name);
    void Desactiver(TKey id);
    void Activer(TKey id);
  }
}
