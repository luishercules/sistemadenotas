using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeNotas.BL
{
    public class Contexto: DbContext
    {
        public Contexto(): base (@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDBFilename="+
            Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SistemaDeNotasDB.mdf")
        {

        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet <Alumno> Alumnos { get; set; }
        public DbSet<Carrera> Carreras { get; set; }
        public DbSet<Asignatura> Asignaturas { get; set; }

        public DbSet<Nota> Notas { get; set; }
        public DbSet<DetalleNota> DetalleNota { get; set; }

    }
}
 