using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{   
     public interface IRepositorio<T> where T : class
    {
        bool Add(T obj);
        bool Remove(int id);
        bool Update(T obj);
        T FindById(int id);
        IEnumerable<T> FindAll();


    }
}
