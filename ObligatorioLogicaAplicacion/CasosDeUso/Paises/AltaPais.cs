using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Paises
{
    public class AltaPais
    {
		#region Dependencias inyectadas

		IRepositorioPais _repoPais;
		public AltaPais(IRepositorioPais repoPais)
		{
			_repoPais = repoPais;
		}
		#endregion
		public void Alta(Pais unPais)
		{
			if (unPais == null)
				throw new PaisException("No se puede dar de alta un país nulo");
			_repoPais.Add(unPais);

		}
	}
}
