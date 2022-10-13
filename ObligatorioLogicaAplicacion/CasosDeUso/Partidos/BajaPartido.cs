using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Partidos
{
    public class BajaPartido
    {
		#region Dependencias inyectadas


		IRepositorioPartido _repoPartido;
		public BajaPartido(IRepositorioPartido repoPartido)
		{
			_repoPartido = repoPartido;
		}
		#endregion
		public void Eliminar(int? id)
		{
			if (id == null)
				throw new PartidoException("No se puede dar de baja el partido");
			_repoPartido.Remove(id.Value);
		}
	}
}
