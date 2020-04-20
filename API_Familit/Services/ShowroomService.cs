using A = API_Familit.Models.Etablissement_API;
using D = DAL.Model.Etablissement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DAL.Utils.EtablissementUtils;
using DAL.Repository.EtablissementRepository;
using API_Familit.Models.Etablissement_API;
using API_Familit.Services.Mapper;

namespace API_Familit.Services
{
  public class ShowroomService : IShowroomRepository<int, A.Showroom_API>
  {
    private IShowroomRepository<int, D.Showrooms> _repo = new ShowroomRepository();

    public void Activer(int id)
    {
      _repo.Activer(id);
    }

    public void Add(Showroom_API entity)
    {
      _repo.Add(entity.ToDAL());
    }

    public void Delete(int id)
    {
      _repo.Delete(id);
    }

    public void Desactiver(int id)
    {
      _repo.Desactiver(id);
    }

    public IEnumerable<Showroom_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI());
    }

    public Showroom_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public IEnumerable<Showroom_API> GetShowroomByName(string name)
    {
      return _repo.GetShowroomByName(name).Select(e => e.ToAPI());
    }

    public void Update(Showroom_API entity)
    {
      _repo.Update(entity.ToDAL());
    }
  }
}
