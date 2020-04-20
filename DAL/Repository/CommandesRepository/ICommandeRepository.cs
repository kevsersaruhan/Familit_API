using DAL.Model.Commande;
using DAL.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository.CommandesRepository
{
  public interface ICommandeRepository<TKey,T> : IRepository<TKey,T> where T : class
  {
    IEnumerable<T> GetCommandeClient(int idclient);
  }
}
