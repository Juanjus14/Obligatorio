using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Enums;
using static Obligatorio.LogicaNegocio.Enums.EnumeradosObligatorio;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using System.Linq;

namespace Obligatorio.LogicaAccesoDatos.RepositorioEntityFramework
{
    public class RepositorioPartidos : IRepositorioPartido
    {
        ObligatorioContext _db { get; set; }

        public RepositorioPartidos(ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(Partido nuevoPartido)
        {
            if (nuevoPartido == null)
                throw new PartidoException("El partido es nulo");
            nuevoPartido.Validar();
            try
            {

                _db.Partidos.Add(nuevoPartido);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new PartidoException
                    ($"El partido no se pudo agregar. Más info: {ex.Message}");
            }
        }

        public bool ExistePartidoEnFechaHora(DateTime fecha, Horas hora)
        {
            foreach(Partido p in _db.Partidos)
            {
                if(p.Fecha == fecha && p.Hora == hora)
                {
                    return true;
                }
            }
            return false;
        }

        public bool ExistePartidoMismasSelecciones(Seleccion selUno, Seleccion selDos)
        {
            foreach (Partido p in _db.Partidos)
            {
                if (p.Infoselpar[0].Seleccion == selUno && p.Infoselpar[1].Seleccion == selDos)
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Partido> FindAll()
        {
            try
            {
                return _db.Partidos.ToList();

            }
            catch (Exception ex)
            {

                throw new PartidoException("No se pueden recuperar partidos", ex);
            }
        }

        public Partido FindById(int id)
        {
            try
            {
                Partido unPartido = _db.Partidos.Find(id);
                return unPartido;
            }
            catch (Exception ex)
            {
                throw new PartidoException($"No se puede recuperar el partido {id}", ex);
            }
        }

        public IEnumerable<Partido> ObtenerPartidosXGrupo(LetrasGrupos grupo)
        {
            List<Partido> ret = new List<Partido>();
            foreach (Partido p in _db.Partidos)
            {
                if (p.Infoselpar[0].Seleccion.Grupo == grupo)
                {
                    ret.Add(p);
                }
            }
            return ret;
        }

        public void Remove(int id)
        {
            try
            {
                Partido partido = _db.Partidos.Find(id);
                if (partido == null)
                    throw new PartidoException($"No existe el partido con Id={id}");
                _db.Partidos.Remove(partido);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new PartidoException($"No se puede eliminar el partido {id}", ex);
            }
        }

        public void Update(Partido obj)
        {
            try
            {
                if (obj == null)
                    throw new PartidoException("No hay partido para modificar");
                Partido viejoPartido = _db.Partidos.Find(obj.Id);
                if (viejoPartido == null)
                    throw new PartidoException($"No existe el partido con Id={obj.Id}");
                viejoPartido.Update(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new PartidoException($"No se puede  actualizar el partido {obj.Id}", ex);
            }
        }

        public bool ValidarFecha(DateTime fecha)
        {
            throw new NotImplementedException();
        }

        public bool ValidarSelecciones(Seleccion selUno, Seleccion selDos)
        {
            throw new NotImplementedException();
        }
    }
}
