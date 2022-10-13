using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ExcepcionesDominio;
using Obligatorio.LogicaNegocio.InterfacesRepositorios;

namespace Obligatorio.LogicaAplicacion.CasosDeUso.Selecciones
{
    public class BajaSeleccion
    {
		#region Dependencias inyectadas


		IRepositorioSeleccion _repoSeleccion;
		public BajaSeleccion(IRepositorioSeleccion repoSeleccion)
		{
			_repoSeleccion = repoSeleccion;
		}
		#endregion
		public void Eliminar(int? id)
		{
			if (id == null)
				throw new SeleccionException("No se puede dar de baja la selección");
			_repoSeleccion.Remove(id.Value);
		}
	}
}
