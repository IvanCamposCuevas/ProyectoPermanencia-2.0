using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.DTO
{
    public class DTOInteraccion
    {
        public string rutAlumno { get; set; }
        public int idCaso { get; set; }
        public int tipoInteraccion { get; set; }
        public int idArea { get; set; }
        public string comentarios { get; set; }
        public DataTable participantes { get; set; }
        public DateTime fechaInteraccion { get; set; }
        public string rutaArchivo { get; set; }
    }
}
