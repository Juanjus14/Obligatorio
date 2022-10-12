using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Paises
{
    public class BajaPais
    {
		#region Dependencias inyectadas


		IRepositorioPais _repoPais;
		public BajaPais(IRepositorioPais repoPais)
		{
			_repoPais = repoPais;
		}
		#endregion
		public void Eliminar(int? id)
		{
			if (id == null)
				throw new PaisException("No se puede dar de baja el país");
			_repoPais.Remove(id.Value);
		}
	}
}
