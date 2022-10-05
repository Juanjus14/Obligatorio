using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.LogicaNegocio.ValueObjects
{
    public class CodigoPais : IValidacion
    {
        public string CodigoISO_Alfa3 { get; set;}

    public bool Validar()
    {
        throw new NotImplementedException();
    }
    
}
}
