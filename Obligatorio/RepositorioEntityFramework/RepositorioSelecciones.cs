using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using System.Linq;

namespace Obligatorio.LogicaAccesoDatos.RepositorioEntityFramework
{
    public class RepositorioSelecciones : IRepositorioSeleccion
    {
        ObligatorioContext _db { get; set; }

        public RepositorioSelecciones(ObligatorioContext db)
        {
            _db = db;
        }
        public bool Add(Seleccion nuevoSeleccion)
        {
            if (nuevoSeleccion == null)
                throw new SeleccionException("El partido es nulo");
            nuevoSeleccion.Validar();
            try
            {
                foreach (Seleccion s in _db.Selecciones)
                {
                    if(s.Pais == nuevoSeleccion.Pais)
                    {
                        throw new SeleccionException("Ya hay una selección con ese país");
                    }
                }
                _db.Selecciones.Add(nuevoSeleccion);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new SeleccionException
                    ($"La seleccion no se pudo agregar. Más info: {ex.Message}");
            }
        }

        public IEnumerable<Seleccion> FindAll()
        {
            try
            {
                return _db.Selecciones.ToList();

            }
            catch (Exception ex)
            {

                throw new SeleccionException("No se pueden recuperar selecciones", ex);
            }
        }

        public Seleccion FindById(int id)
        {
            try
            {
                Seleccion unSeleccion = _db.Selecciones.Find(id);
                return unSeleccion;
            }
            catch (Exception ex)
            {
                throw new SeleccionException($"No se puede recuperar la selección {id}", ex);
            }
        }

        public bool PaisTieneSeleccion(int idPais)
        {
            foreach(Seleccion s in _db.Selecciones)
            {
                if(s.PaisId == idPais)
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(int id)
        {
            try
            {
                Seleccion seleccion = _db.Selecciones.Find(id);
                if (seleccion == null)
                    throw new SeleccionException($"No existe la selección con Id={id}");
                if (SeleccionTieneRegistro(id))
                    throw new SeleccionException($"La selección con Id={id} tiene registros, no se puede eliminar");
                _db.Selecciones.Remove(seleccion);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new SeleccionException($"No se puede eliminar la selección {id}", ex);
            }
        }

        public bool SeleccionTieneRegistro(int idSeleccion)
        {
            foreach (Partido p in _db.Partidos)
            {
                if (p.Infoselpar[0].SeleccionId == idSeleccion || p.Infoselpar[1].SeleccionId == idSeleccion)
                {
                return true;
                }            
            }

            return false;
        }

        public bool Update(Seleccion obj)
        {
            try
            {
                if (obj == null)
                    throw new SeleccionException("No hay selección para modificar");
                Seleccion viejoSeleccion = _db.Selecciones.Find(obj.Id);
                if (viejoSeleccion == null)
                    throw new SeleccionException($"No existe la selección con Id={obj.Id}");
                viejoSeleccion.Update(obj);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw new SeleccionException($"No se puede actualizar la selección {obj.Id}", ex);
            }
        }

        
    }
}
