using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAccesoDatos.RepositorioEntityFramework
{
    public class RepositorioSelecciones : IRepositorioSeleccion
    {
        ObligatorioContext _db { get; set; }

        public RepositorioSelecciones(ObligatorioContext db)
        {
            _db = db;
        }
        public void Add(Seleccion obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seleccion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Seleccion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool PaisTieneSeleccion(int idPais)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public bool SeleccionTieneRegistro(int idSeleccion)
        {
            throw new NotImplementedException();
        }

        public void Update(Seleccion obj)
        {
            throw new NotImplementedException();
        }

        public bool ValidarEmailContacto(string email)
        {
            throw new NotImplementedException();
        }

        public bool ValidarNombreContacto(string nombre)
        {
            throw new NotImplementedException();
        }

        public bool ValidarTelefonoContacto(string telefono)
        {
            throw new NotImplementedException();
        }
    }
}
