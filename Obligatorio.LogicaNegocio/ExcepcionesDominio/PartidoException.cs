using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.LogicaNegocio.ExcepcionesDominio
{
	public class PartidoException : DominioException
	{
		public PartidoException():base()
		{

		}
		public PartidoException(string mensaje) 
			: base(mensaje)
		{

		}
		public PartidoException(string mensaje, Exception excepcionInterna) 
			: base(mensaje, excepcionInterna)
		{

		}
	}
}
