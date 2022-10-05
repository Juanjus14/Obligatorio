using Obligatorio.LogicaNegocio.Enums;
using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.ValueObjects;
using Obligatorio.LogicaNegocio.InterfacesEntidades;
using System.ComponentModel.DataAnnotations;

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
               

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
