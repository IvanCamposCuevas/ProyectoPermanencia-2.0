using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    //Clase que interactúa con la pagina que registra las interacciones. CRUD.
    public class NegocioRegistroInteraccion
    {
        //Cargar DDL curso en los que está inscrito el alumno
        public DataSet cargarddlCurso(string rutAlumno)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            if (!String.IsNullOrEmpty(rutAlumno))
            {
                conexion.Conec1.IntruccioneSQL = String.Format("SELECT DISTINCT CONCAT('Ramo: ', [CODIGO ASIGNATURA],' - Sección: ', SECCION) AS CURSO FROM Curso_STG WHERE [RUT ALUMNO] = '{0}';", rutAlumno);
            }
            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }

    }
}
