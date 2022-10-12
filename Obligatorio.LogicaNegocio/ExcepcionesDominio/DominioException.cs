using System;
using System.Collections.Generic;
using System.Text;

namespace Obligatorio.LogicaNegocio.ExcepcionesDominio
{
	public class DominioException:Exception
	{
		public DominioException() : base()
		{

		}
		public DominioException(string mensaje)
			: base(mensaje)
		{

		}
		public DominioException(string mensaje, Exception excepcionInterna)
			: base(mensaje, excepcionInterna)
		{

		}
	}
}
