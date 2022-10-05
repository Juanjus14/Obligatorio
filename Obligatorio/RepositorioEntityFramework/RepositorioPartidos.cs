using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Enums;
using static Obligatorio.LogicaNegocio.Enums.EnumeradosObligatorio;

namespace Obligatorio.LogicaAccesoDatos.RepositorioEntityFramework
{
    public class RepositorioPartidos : IRepositorioPartido
    {
        public List<Partido> Partidos = new List<Partido>();
        public void Add(Partido obj)
        {
            throw new NotImplementedException();
        }

        public bool ExistePartidoEnFechaHora(DateTime fecha, Horas hora)
        {
            throw new NotImplementedException();
        }

        public bool ExistePartidoMismasSelecciones(Seleccion selUno, Seleccion selDos)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Partido> FindAll()
        {
            throw new NotImplementedException();
        }

        public Partido FindById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Partido> ObtenerPartidosXGrupo(LetrasGrupos grupo)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Partido obj)
        {
            throw new NotImplementedException();
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
