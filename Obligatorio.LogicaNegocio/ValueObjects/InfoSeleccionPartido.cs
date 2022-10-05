using Obligatorio.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;


namespace Obligatorio.LogicaNegocio.ValueObjects
{
    public class InfoSeleccionPartido
    {
        public static int UltimoId { get; set; }
        [Key] public int Id { get; set; }
        public Partido Partido { get; set; }
        /*[ForeignKey("IdPartido")] public int PartidoId { get; set; }*/
        public Seleccion Seleccion { get; set; }
        public int Goles { get; set; }
        public int RojasDirectas { get; set; }
        public int RojasAcumuladas { get; set; }
        public int Amarillas { get; set; }

        public InfoSeleccionPartido() { }

        public InfoSeleccionPartido(Seleccion seleccion, int goles, int rojasD, int rojasA, int amarillas)
        {
            this.Id =UltimoId++;
            this.Seleccion = seleccion;
            this.Goles = goles;
            this.RojasDirectas = rojasD;
            this.RojasAcumuladas = rojasA;
            this.Amarillas = amarillas;
        }
    }
}
