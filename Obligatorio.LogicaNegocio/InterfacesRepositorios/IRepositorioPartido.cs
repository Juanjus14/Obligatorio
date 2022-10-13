using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Enums;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPartido: IRepositorio<Partido>
    {
        //public abstract bool ValidarSelecciones(Seleccion selUno, Seleccion selDos);
        public abstract bool ExistePartidoEnFechaHora(DateTime fecha, EnumeradosObligatorio.Horas hora);
        public abstract bool ExistePartidoMismasSelecciones(Seleccion selUno, Seleccion selDos);
        //public abstract bool ValidarFecha(DateTime fecha);
        public abstract IEnumerable<Partido> ObtenerPartidosXGrupo(EnumeradosObligatorio.LetrasGrupos grupo);

    }
}
