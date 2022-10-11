using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesEntidades;

namespace Obligatorio.LogicaNegocio.ValueObjects
{
    public class NombrePais : IValidacion
    {
        public string Nombre { get; set; }
        

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
