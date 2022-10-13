using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.LogicaNegocio.ExcepcionesDominio
{
	public class SeleccionException : DominioException
	{
		public SeleccionException():base()
		{

		}
		public SeleccionException(string mensaje) 
			: base(mensaje)
		{

		}
		public SeleccionException(string mensaje, Exception excepcionInterna) 
			: base(mensaje, excepcionInterna)
		{

		}
	}
}
