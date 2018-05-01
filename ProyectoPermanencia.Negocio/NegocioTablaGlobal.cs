using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPermanencia.DTO;
namespace ProyectoPermanencia.Negocio
{
    public class NegocioTablaGlobal
    {
        NegocioConexion nc = new NegocioConexion();

        private String ConsultaJoin() {
            string query = "SELECT a.Desc_Alumno, a.Desc_Rut_Alumno, c.Desc_Carrera, s.Desc_Sede, j.Desc_Jornada, p.Score FROM LK_Alumno a " +
                "JOIN LK_Jornada j ON a.Id_Jornada = j.Id_Jornada JOIN LK_Sede s ON a.Id_Sede = s.Id_Sede JOIN LK_Carrera c ON a.Id_Carrera = c.Id_Carrera " +
                "JOIN Score_Alumnos sa ON a.Id_Alumno = sa.Id_Alumno";
            return query;
        }

        private String ConcadenarJornada(string[] jornada) {
            string busquedaJornada= "";
            foreach (string i in jornada)
            {
                busquedaJornada += i+" , ";
            }
            return busquedaJornada;
        }

        //private String Concadenar

        public List<DTOGlobal> TablaGloabalTotal(string rut, string nombre) {
            string queryCompleta = ConsultaJoin() + " WHERE a.Desc_Rut_Alumno= " +rut+ " OR a.Desc_Alumno " + nombre;

        }
    }
}
