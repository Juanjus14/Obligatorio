using System;
using System.Collections.Generic;
using System.Text;
using Obligatorio.LogicaNegocio.ValueObjects;
using Obligatorio.LogicaNegocio.InterfacesEntidades;
using Obligatorio.LogicaNegocio.Enums;
using System.ComponentModel.DataAnnotations;

namespace Obligatorio.LogicaNegocio.Entidades
{
    public class Pais : IEntity, IValidacion
    {
        
        [Key] public int Id { get; set; }
        public NombrePais Nombre { get; set; }
        public CodigoPais Codigo { get; set; }
        public double PBI { get; set; }
        public int Poblacion { get; set; }
        public ImagenPais Imagen { get; set; }
        public EnumeradosObligatorio.Regiones Region { get; set; }

        public Pais()
        {
            
        }
        
        public Pais(NombrePais nombre, CodigoPais codigo, double pbi, int poblacion, ImagenPais imagen, EnumeradosObligatorio.Regiones region)
        {
           
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.PBI = pbi;
            this.Poblacion = poblacion;
            this.Imagen = imagen;
            this.Region = region;
        }

        public bool Validar()
        {
            throw new NotImplementedException();
        }
    }
}
