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
            return ValidarFecha() && ValidarSelecciones(); 
        }

        public bool ValidarFecha()
        {
            DateTime f1 = new DateTime(2022, 11, 20, 0, 0, 0);
            DateTime f2 = new DateTime(2022, 12, 2, 23, 59, 59);
            if (Fecha >= f1 && Fecha <= f2)
            {
                return true;
            }
            return false;
        }

        public bool ValidarSelecciones()
        {
            if (Infoselpar[0].Seleccion != Infoselpar[1].Seleccion && Infoselpar[0].Seleccion.Grupo == Infoselpar[1].Seleccion.Grupo)
            {
                return true;
            }
            else
            {
                return false;
            }
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
