using Obligatorio.LogicaNegocio.Enums;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.ValueObjects;
using Obligatorio.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Seleccion : IEntity, IValidacion
    {

       
        [Key] public int Id { get; set; }
        public Pais Pais { get; set; }
        public int PaisId { get; set; }
        public PersonaContacto Contacto { get; set; }
        public int CantidadApostadores { get; set; }
        public EnumeradosObligatorio.LetrasGrupos Grupo { get; set; }
        public int Puntuacion { get; set; }

        public Seleccion()
        {
            
            this.Puntuacion = 0;
        }

        public Seleccion(Pais pais, PersonaContacto contacto, int cantApostadores, EnumeradosObligatorio.LetrasGrupos grupo)
        {
           
            this.Pais = pais;
            this.Contacto = contacto;
            this.CantidadApostadores = cantApostadores;
            this.Grupo = grupo;
            this.Puntuacion = 0;
        }

        public void Update(Seleccion seleccionConNuevosDatos)
        {
            Pais = seleccionConNuevosDatos.Pais;
            PaisId = seleccionConNuevosDatos.PaisId;
            Contacto.Nombre = seleccionConNuevosDatos.Contacto.Nombre;
            Contacto.Email = seleccionConNuevosDatos.Contacto.Email;
            Contacto.Telefono = seleccionConNuevosDatos.Contacto.Telefono;
            CantidadApostadores = seleccionConNuevosDatos.CantidadApostadores;
            Grupo = seleccionConNuevosDatos.Grupo;
            Puntuacion = seleccionConNuevosDatos.Puntuacion;
        }

        public bool Validar()
        {
            if (Pais.Validar() && Contacto.Validar() && CantidadApostadores >= 0 && ((int)Grupo) >= 0 && ((int)Grupo) <= 7 && Puntuacion >= 0)
            {
                return true;        
            }
            return false;
        }
    }
}
