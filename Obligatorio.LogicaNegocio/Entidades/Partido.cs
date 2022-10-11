using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.ValueObjects;
using Obligatorio.LogicaNegocio.InterfacesEntidades;
using Obligatorio.LogicaNegocio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Partido : IEntity, IValidacion
    {
        
      
        [Key] public int Id { get; set; }     

        public List<InfoSeleccionPartido> Infoselpar { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public EnumeradosObligatorio.Horas Hora { get; set; }
        public bool Validar()
        {
            throw new NotImplementedException();
        }

        public Partido() {
            
        }

        public Partido(InfoSeleccionPartido selUno, InfoSeleccionPartido selDos, DateTime fecha, EnumeradosObligatorio.Horas hora)
        {
                      
            this.Fecha = fecha;
            this.Hora = hora;
        }
        
    }
}
