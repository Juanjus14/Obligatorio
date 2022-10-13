using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Partidos
{
    public class AltaPartido
    {
		#region Dependencias inyectadas

		IRepositorioPartido _repoPartido;
		public AltaPartido(IRepositorioPartido repoPartido)
		{
			_repoPartido = repoPartido;
		}
		#endregion
		public void Alta(Partido unPartido)
		{
			if (unPartido == null)
				throw new PartidoException("No se puede dar de alta un partido nulo");
			_repoPartido.Add(unPartido);

		}
	}
}
