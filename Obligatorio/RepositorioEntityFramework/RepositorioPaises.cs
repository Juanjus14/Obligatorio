using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.Enums;
using static Obligatorio.LogicaNegocio.Enums.EnumeradosObligatorio;

namespace Obligatorio.LogicaAccesoDatos.RepositorioEntityFramework
{
    public class RepositorioPaises : IRepositorioPais
    {
        ObligatorioContext _db { get; set; }

        public RepositorioPaises(ObligatorioContext db)
        {
            _db = db;
        }

        public List<Pais> Paises = new List<Pais>();
        public void Add(Pais obj)
        {
            throw new NotImplementedException();
        }

        public Pais BuscarPaisPorCodigo(string codigo)
        {
            throw new NotImplementedException();
        }

        public bool CodigoEsUnico(string codigo)
        {
            foreach (Pais p in _db.Paises)
                if (p.CodigoISO.Equals(codigo))
                    return false;

            return true;
        }

        //public bool CodigoEsValido(string codigo)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Pais> FindAll()
        {
            throw new NotImplementedException();
        }

        public Pais FindById(int id)
        {
            throw new NotImplementedException();
        }

        public bool NombreEsUnico(string nombre)
        {
            foreach (Pais p in _db.Paises)
                if (p.Nombre.Nombre.Equals(nombre))
                    return false;

            return true;
        }

        //public bool NombreEsValido(string nombre)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<Pais> ObtenerPaisesXRegion(Regiones region)
        {
            throw new NotImplementedException();
        }

        public bool PaisTieneRegistro(int idPais)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }
    }
}
