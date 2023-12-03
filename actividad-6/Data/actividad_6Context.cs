using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using actividad_6.Models;

namespace actividad_6.Data
{
    public class actividad_6Context : DbContext
    {
        public actividad_6Context (DbContextOptions<actividad_6Context> options)
            : base(options)
        {
        }

        public DbSet<actividad_6.Models.Cursos> Cursos { get; set; } = default!;
        public DbSet<actividad_6.Models.Usuarios> Usuarios { get; set; } = default!;
    }
}
