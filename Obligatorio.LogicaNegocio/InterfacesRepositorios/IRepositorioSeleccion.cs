using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioSeleccion: IRepositorio<Seleccion>
    {
        public abstract bool PaisTieneSeleccion(int idPais);
        public abstract bool ValidarNombreContacto(string nombre);
        public abstract bool ValidarEmailContacto(string email);
        public abstract bool ValidarTelefonoContacto(string telefono);
        public abstract bool SeleccionTieneRegistro(int idSeleccion);
    }
}
