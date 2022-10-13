using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.LogicaNegocio.ExcepcionesDominio
{
	public class PaisException : DominioException
	{
		public PaisException():base()
		{

		}
		public PaisException(string mensaje) 
			: base(mensaje)
		{

		}
		public PaisException(string mensaje, Exception excepcionInterna) 
			: base(mensaje, excepcionInterna)
		{

		}
	}
}
