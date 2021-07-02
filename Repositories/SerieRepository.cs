using System.Collections.Generic;
using simple_crud_console_app.Classes;
using simple_crud_console_app.Interfaces;

namespace simple_crud_console_app.Repositories
{
  public class SerieRepository : IRepository<Serie>
  {
    private List<Serie> listaSerie = new List<Serie>();
    public void Delete(int id)
    {
      listaSerie[id].SetDelete();
    }

    public Serie GetByID(int id)
    {
      return listaSerie[id];
    }

    public void Insert(Serie entity)
    {
      listaSerie.Add(entity);
    }

    public List<Serie> ListNotDeleted()
    {
      List<Serie> list = new List<Serie>();
      foreach(Serie serie in listaSerie)
      {
        if (!serie.GetDelete())
        {
          list.Add(serie);
        }
      }
      return list;
    }

    public List<Serie> List()
    {
      return listaSerie;
    }

    public int NextID()
    {
      return listaSerie.Count;
    }

    public void Update(int id, Serie entity)
    {
      listaSerie[id] = entity;
    }
  }
}