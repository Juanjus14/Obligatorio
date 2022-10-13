using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Enums;
using static Obligatorio.LogicaNegocio.Enums.EnumeradosObligatorio;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using System.Linq;
using Obligatorio.LogicaNegocio.ValueObjects;

namespace Obligatorio.LogicaAccesoDatos.RepositorioEntityFramework
{
    public class RepositorioPartidos : IRepositorioPartido
    {
        ObligatorioContext _db { get; set; }

        public RepositorioPartidos(ObligatorioContext db)
        {
            _db = db;
        }
        public bool Add(Partido nuevoPartido)
        {
            if (nuevoPartido == null)
                throw new PartidoException("El partido es nulo");
            nuevoPartido.Validar();
            try
            {
                if (TieneMasTresPartidos(nuevoPartido.Infoselpar[0].Seleccion) && TieneMasTresPartidos(nuevoPartido.Infoselpar[1].Seleccion) && !ExistePartidoEnFechaHora(nuevoPartido.Fecha, nuevoPartido.Hora) && !ExistePartidoMismasSelecciones(nuevoPartido.Infoselpar[0].Seleccion, nuevoPartido.Infoselpar[1].Seleccion))
                {
                    AsignarPuntosPartido(nuevoPartido.Infoselpar[0], nuevoPartido.Infoselpar[1]);
                    _db.Partidos.Add(nuevoPartido);
                    _db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new PartidoException
                    ($"El partido no se pudo agregar. Más info: {ex.Message}");
            }
        }

        private void AsignarPuntosPartido(InfoSeleccionPartido selUno, InfoSeleccionPartido selDos)
        {
            if(selUno.Goles > selDos.Goles)
            {
                selUno.Seleccion.Puntuacion += 3;
            }else if(selDos.Goles > selUno.Goles)
            {
                selDos.Seleccion.Puntuacion += 3;
            }else if(selUno.Goles == selDos.Goles)
            {
                selUno.Seleccion.Puntuacion += 1;
                selDos.Seleccion.Puntuacion += 1;
            }
        }

        private bool TieneMasTresPartidos(Seleccion seleccion)
        {
            int contador = 0;
            foreach (Partido p in _db.Partidos)
            {
                if (p.Infoselpar[0].Seleccion == seleccion || p.Infoselpar[1].Seleccion == seleccion)
                {
                    contador++;
                }
            }
            if (contador > 3)
            {
                return true;
            }
            return false;
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

        public bool Remove(int id)
        {
            try
            {
                Partido partido = _db.Partidos.Find(id);
                if (partido == null)
                    throw new PartidoException($"No existe el partido con Id={id}");
                _db.Partidos.Remove(partido);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new PartidoException($"No se puede eliminar el partido {id}", ex);
            }
        }

        public bool Update(Partido obj)
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
                return true;
            }
            catch (Exception ex)
            {

                throw new PartidoException($"No se puede  actualizar el partido {obj.Id}", ex);
            }
        }

        
    }
}
