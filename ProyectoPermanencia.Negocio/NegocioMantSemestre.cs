using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    public class NegocioMantSemestre
    {
        //Cargar DDL de los semestres existentes
        public DataSet CargarddlSemestres()
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();

            //Consulta
            conexion.Conec1.IntruccioneSQL = "SELECT DISTINCT Id_Semestre, Desc_Semestre FROM LK_Semestre;";

            conexion.Conec1.EsSelect = true;
            conexion.Conec1.conectar();
            return conexion.Conec1.DbDat;
        }

        public bool CreaSemestre(string semestre)
        {
            NegocioConexionBD conexion = new NegocioConexionBD();
            conexion.configuraConexion();


            if (!string.IsNullOrEmpty(semestre))
            {
                //Consulta/Inserción
                conexion.Conec1.IntruccioneSQL = String.Format("INSERT INTO LK_Semestre (Desc_Semestre) VALUES ('{0}');", semestre);
                conexion.Conec1.EsSelect = false;
                conexion.Conec1.conectar();
                return true;

            }
            else
            {
                throw new ArgumentNullException(nameof(semestre));
            }
        }

    }
}
