using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.LogicaNegocio.ValueObjects
{
    public class ImagenPais : IValidacion
    {
        public string URL { get; set; }
     

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
