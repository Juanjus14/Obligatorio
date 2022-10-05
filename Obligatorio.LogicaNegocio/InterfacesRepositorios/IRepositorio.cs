using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{   
     public interface IRepositorio<T> where T : class
    {
        void Add(T obj);
        void Remove(int id);
        void Update(T obj);
        T FindById(int id);
        IEnumerable<T> FindAll();


    }
}
