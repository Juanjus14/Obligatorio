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
        public CodigoPais CodigoISO { get; set; }
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
            this.CodigoISO = codigo;
            this.PBI = pbi;
            this.Poblacion = poblacion;
            this.Imagen = imagen;
            this.Region = region;
        }

        public bool Validar()
        {
            return Nombre.Validar() && CodigoISO.Validar() && ValidarCodigoIso() && PBI > 0 && Poblacion > 0 && Imagen.Validar() && ValidarImagen() && ((int)Region) >= 0 && ((int)Region) <= 4;
        }

        public bool ValidarCodigoIso()
        {
            return Nombre.Nombre[0] == CodigoISO.CodigoISO_Alfa3[0];
        }

        public bool ValidarImagen()
        {
            if (!Imagen.URL.Contains(CodigoISO.CodigoISO_Alfa3) || !Imagen.URL.Contains("png"))
            {
                return false;
            }
            return true;
        }

        public void Update(Pais paisConNuevosDatos)
        {
            Nombre.Nombre = paisConNuevosDatos.Nombre.Nombre;
            CodigoISO.CodigoISO_Alfa3 = paisConNuevosDatos.CodigoISO.CodigoISO_Alfa3;
            PBI = paisConNuevosDatos.PBI;
            Poblacion = paisConNuevosDatos.Poblacion;
            Imagen.URL = paisConNuevosDatos.Imagen.URL;
            Region = paisConNuevosDatos.Region;
        }
    }
}
