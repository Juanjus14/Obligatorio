using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Obligatorio.LogicaNegocio.InterfacesEntidades;

namespace Obligatorio.LogicaNegocio.ValueObjects
{
    public class PersonaContacto : IValidacion
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public bool Validar()
        {
            return ValidarNombre() && ValidarEmail() && ValidarTelefono();
        }

        public bool ValidarEmail()
        {
            if (Email.Contains("@") && !Email.StartsWith("@") && !Email.EndsWith("@"))
            {
                return true;
            }
            return false;
        }

        public bool ValidarNombre()
        {
            if (Nombre.All(char.IsDigit))
            {
                return false;
            }
            return true;
        }

        public bool ValidarTelefono()
        {
            if (Telefono.Length < 7)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
