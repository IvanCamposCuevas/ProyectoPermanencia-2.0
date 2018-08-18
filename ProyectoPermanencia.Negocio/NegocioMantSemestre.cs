using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    public class NegocioMantSemestre : NegocioConexionBD
    {
        //Cargar DDL de los semestres existentes
        public DataSet CargarddlSemestres()
        {

            //Consulta
            Conexion.IntruccioneSQL = "SELECT DISTINCT Id_Semestre, Desc_Semestre FROM LK_Semestre;";

            Conexion.EsSelect = true;
            Conexion.conectar();
            return Conexion.DbDat;
        }

        public bool CreaSemestre(string semestre)
        {


            if (!string.IsNullOrEmpty(semestre))
            {
                //Consulta/Inserción
                Conexion.IntruccioneSQL = String.Format("INSERT INTO LK_Semestre (Desc_Semestre) VALUES ('{0}');", semestre);
                Conexion.EsSelect = false;
                Conexion.conectar();
                return true;

            }
            else
            {
                throw new ArgumentNullException(nameof(semestre));
            }
        }

    }
}
