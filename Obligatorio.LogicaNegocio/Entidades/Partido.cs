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

        DateTime fechaInicGrup = new DateTime(20, 11, 2022, 0, 0, 0);

        DateTime fechaFinGrup = new DateTime(2, 12, 2022, 23, 59, 59);

        public bool Validar()
        {
            return Fecha >= fechaInicGrup && Fecha <= fechaFinGrup  ; 
        }

        public Partido() {
            
        }

        public void Update(Partido partidoConNuevosDatos)
        {
            Infoselpar = partidoConNuevosDatos.Infoselpar;
            Fecha = partidoConNuevosDatos.Fecha;
            Hora = partidoConNuevosDatos.Hora;
        }

        public Partido(InfoSeleccionPartido selUno, InfoSeleccionPartido selDos, DateTime fecha, EnumeradosObligatorio.Horas hora)
        {        
            this.Fecha = fecha;
            this.Hora = hora;
        }
        
    }
}
