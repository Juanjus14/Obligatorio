using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;
using Obligatorio.LogicaNegocio.ValueObjects;


namespace Obligatorio.LogicaAccesoDatos.RepositorioEntityFramework
{
    public class ObligatorioContext: DbContext
    {
        public DbSet<Pais> Paises { get; set;}        
        public DbSet<Partido> Partidos { get; set; }
        public DbSet<Seleccion> Selecciones { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder
        //        .UseSqlServer
        //        (@"SERVER = (localDb)\\MsSqlLocalDb; Database = BaseD; INTEGRATED SECURITY = True; MultipleActiveResultSets = true; ");
        //}
        public ObligatorioContext(DbContextOptions<ObligatorioContext> opt):base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>()
                .OwnsOne<NombrePais>(np => np.Nombre);

                 modelBuilder.Entity<Pais>()
                .OwnsOne<CodigoPais>(cp => cp.Codigo);

                 modelBuilder.Entity<Pais>()
                .OwnsOne<ImagenPais>(im => im.Imagen);

            modelBuilder.Entity<Seleccion>()
               .OwnsOne<PersonaContacto>(pc => pc.Contacto);
           
            modelBuilder.Entity<Seleccion>()
               .HasOne<Pais>(se => se.Pais)
               /*.WithOne()
               .HasForeignKey("PaisId")
               .OnDelete(DeleteBehavior.Cascade)
               .IsRequired()*/;

            modelBuilder.Entity<Partido>()
               .OwnsMany<InfoSeleccionPartido>(pa => pa.Infoselpar);



            //modelBuilder.Ignore<CodigoPais>();
            //modelBuilder.Ignore<ImagenPais>();
            //modelBuilder.Ignore<InfoSeleccionPartido>();
            //modelBuilder.Ignore<NombrePais>();
            //modelBuilder.Ignore<PersonaContacto>();


        }

    }
}
