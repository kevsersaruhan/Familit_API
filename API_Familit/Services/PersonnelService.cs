using API_Familit.Models.User_API;
using API_Familit.Services.Mapper;
using DAL.Model.User;
using DAL.Repository.UserRepository;
using DAL.Utils.UserUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_Familit.Services
{
  public class PersonnelService : IPersonnelRepository<int, Personnel_API>
  {
    private IPersonnelRepository<int, Personnel> _repo = new PersonnelRepository();
    public void Activer(int id)
    {
      _repo.Activer(id);
    }

    public void Add(Personnel_API entity)
    {
      _repo.Add(entity.ToDAL());
    }

    public void ChangePassword(int id, string s)
    {
     _repo.ChangePassword(id,s);
    }

    public void CheckPersonnel(int id, string login, string password)
    {
     _repo.CheckPersonnel(id,login,password);
    }

    public void Delete(int id)
    {
     _repo.Delete(id);
    }

    public void Desactiver(int id)
    {
      _repo.Desactiver(id);
    }

    public void DoAdmin(int id)
    {
     _repo.DoAdmin(id);
    }

    public IEnumerable<Personnel_API> Get()
    {
      return _repo.Get().Select(e => e.ToAPI()); ;
    }

    public Personnel_API Get(int id)
    {
      return _repo.Get(id).ToAPI();
    }

    public IEnumerable<Personnel_API> GetPersonnelByShowroom(int idShowroom)
    {
      return _repo.GetPersonnelByShowroom(idShowroom).Select(e => e.ToAPI());
    }

    public void UnsetAdmin(int id)
    {
      _repo.UnsetAdmin(id);
    }

    public void Update(int id, Personnel_API entity)
    {
      _repo.Update(id, entity.ToDAL());
    }
  }
}
