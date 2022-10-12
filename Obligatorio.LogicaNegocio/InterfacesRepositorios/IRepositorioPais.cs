using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Enums;


namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPais: IRepositorio<Pais>
    {
        public abstract bool NombreEsUnico(string nombre);
        public abstract bool CodigoEsUnico(string codigo);
        //public abstract bool NombreEsValido(string nombre);
        //public abstract bool CodigoEsValido(string codigo);
        public abstract Pais BuscarPaisPorCodigo(string codigo);
        public abstract IEnumerable<Pais> ObtenerPaisesXRegion(EnumeradosObligatorio.Regiones region);
        public abstract bool PaisTieneRegistro(int idPais);
    }
}
