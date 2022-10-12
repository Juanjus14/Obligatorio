using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Selecciones
{
    public class AltaSeleccion
    {
		#region Dependencias inyectadas


		IRepositorioSeleccion _repoSeleccion;
		public AltaSeleccion(IRepositorioSeleccion repoSeleccion)
		{
			_repoSeleccion = repoSeleccion;
		}
		#endregion
		public void Alta(Seleccion unSeleccion)
		{
			if (unSeleccion == null)
				throw new SeleccionException("No se puede dar de alta una selección nula");
			_repoSeleccion.Add(unSeleccion);

		}
	}
}
