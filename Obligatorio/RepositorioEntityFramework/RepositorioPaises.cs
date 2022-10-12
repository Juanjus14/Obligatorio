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
    public class RepositorioPaises : IRepositorioPais
    {
        ObligatorioContext _db { get; set; }

        public RepositorioPaises(ObligatorioContext db)
        {
            _db = db;
        }

        public void Add(Pais nuevoPais)
        {
            if (nuevoPais == null)
                throw new PaisException("El país es nulo");
            nuevoPais.Validar();
            try
            {

                _db.Paises.Add(nuevoPais);
                _db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new PaisException
                    ($"El país no se pudo agregar. Más info: {ex.Message}");
            }
        }

        public Pais BuscarPaisPorCodigo(string codigo)
        {
            try
            {
                Pais unPais = _db.Paises.Find(codigo);
                return unPais;
            }
            catch (Exception ex)
            {
                throw new PaisException($"No se puede recuperar el país {codigo}", ex);
            }
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
            try
            {
                return _db.Paises.ToList();

            }
            catch (Exception ex)
            {

                throw new PaisException("No se pueden recuperar paises", ex);
            }
        }

        public Pais FindById(int id)
        {
            try
            {
                Pais unPais = _db.Paises.Find(id);
                return unPais;
            }
            catch (Exception ex)
            {
                throw new PaisException($"No se puede recuperar el país {id}", ex);
            }
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
            List<Pais> ret = new List<Pais>();
            foreach (Pais p in _db.Paises)
            {
                if (p.Region == region)
                {
                    ret.Add(p);
                }
            }
            return ret;
        }

        public bool PaisTieneRegistro(int idPais)
        {
            Seleccion sel = EncontrarSelPais(idPais);
            foreach (Partido p in _db.Partidos)
            {
                foreach (InfoSeleccionPartido isp in p.Infoselpar)
                {
                    if(isp.SeleccionId == sel.Id)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        private Seleccion EncontrarSelPais(int idPais)
        {
            foreach(Seleccion s in _db.Selecciones)
            {
                if(idPais == s.PaisId)
                {
                    return s;
                }
            }
            return null;
        }

        public void Remove(int id)
        {
            try
            {
                Pais pais = _db.Paises.Find(id);
                if (pais == null)
                    throw new PaisException($"No existe el país con Id={id}");
                if (PaisTieneRegistro(id))
                    throw new PaisException($"El país con Id={id} tiene registros, no se puede eliminar");
                _db.Paises.Remove(pais);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new PaisException($"No se puede eliminar el país {id}", ex);
            }
        }

        public void Update(Pais obj)
        {
            try
            {
                if (obj == null)
                    throw new PaisException("No hay país para modificar");
                Pais viejoPais = _db.Paises.Find(obj.Id);
                if (viejoPais == null)
                    throw new PaisException($"No existe el país con Id={obj.Id}");
                viejoPais.Update(obj);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new PaisException($"No se puede actualizar el país {obj.Id}", ex);
            }
        }
    }
}
