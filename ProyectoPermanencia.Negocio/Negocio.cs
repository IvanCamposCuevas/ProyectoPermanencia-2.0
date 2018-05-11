﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    /// <summary>
    /// Clase que servira para consultar y devolver los datos pedidos por la pagina VisionGlobal.aspx,
    /// esta traera todo los alumnos de la base de datos, previo filtro, y los llenara en una grilla.
    /// </summary>
    public class Negocio
    {       
            /// <summary>
            /// Este metodo servira para consultar a todos los Alumnos de la base de datos, previo filtro, con
            /// los scores sacados de sus Notas, Asistencia y Pagos.
            /// </summary>
            /// <param name="rut"></param>
            /// <param name="jornada"></param>
            /// <returns></returns>
            public System.Data.DataSet consultaScore(String rut, String jornada, String carrera)
            {
                NegocioConexionBD con = new NegocioConexionBD(); //Instancia la Clase NegocioConexionBD.
                con.configuraConexion(); //Se inicianalizan los parametros que me permitiran conectarme a la base de datos
                //Se crean una variable de texto, que permitira establecer las uniones con las tablas de la base datos
                String auxSQL = " WHERE "
           + "AL.Id_Alumno = SC.Id_Alumno"
           + " AND "
           + "AL.Id_Carrera = CA.Id_Carrera"
           + " AND "
           + "AL.Id_Sede = SE.Id_Sede"
           + " AND "
           + "AL.Id_Jornada = JO.Id_Jornada";

                //Aplicar Filtros
                if (!String.IsNullOrEmpty(rut))
                    auxSQL = auxSQL + " AND AL.Desc_Rut_Alumno = '" + rut + "';";
                if (!String.IsNullOrEmpty(jornada))
                    auxSQL = auxSQL + " AND AL.Id_Jornada = '" + jornada + "';";
                if (!String.IsNullOrEmpty(carrera))
                    auxSQL = auxSQL + " AND CA.Desc_Carrera = '" + carrera + "';";

            /*
             * Se crea y se reesguardan las intrucciones SQL dentro de la Clase Conexion.cs, 
             * tambien se agrega la variable auxiliar creada anteriormente
            */
            con.Conec1.IntruccioneSQL = "SELECT AL.Desc_Rut_Alumno AS Rut,"
                                               + "AL.Desc_Alumno AS Nombre,"
                                               + "CA.Desc_Carrera AS Carrera,"
                                               + "SE.Desc_Sede AS Sede,"
                                               + "JO.Desc_Jornada AS Jornada,"
                                               + "SC.Score AS Score "+ "\n"

                                               + " FROM "
                                               + "Permanencia_2.dbo.Score_Alumnos SC,"
                                               + "Permanencia_2.dbo.LK_Alumno AL,"
                                               + "Permanencia_2.dbo.LK_Carrera CA,"
                                               + "Permanencia_2.dbo.LK_Sede SE,"
                                               + "Permanencia_2.dbo.LK_Jornada JO"+ "\n"
                                               + auxSQL;

                con.Conec1.EsSelect = true; //Si la query es de consulta (SELECT...) se ingresa como True.
                con.Conec1.conectar(); //Se inicia la conexion con la query anteriormente ingresada.

                return con.Conec1.DbDat; //Se retornan los datos en un DataSet.
            } // Fin metodo entrega


            /**
             * Ni idea si se usara estas funciones, las comento eso si por si algun día se
             * usan.
             * */
            

            //public bool validarRut(string rut)
            //{

            //    bool validacion = false;
            //    try
            //    {
            //        rut = rut.ToUpper();
            //        rut = rut.Replace(".", "");
            //        rut = rut.Replace("-", "");
            //        int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

            //        char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

            //        int m = 0, s = 1;
            //        for (; rutAux != 0; rutAux /= 10)
            //        {
            //            s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
            //        }
            //        if (dv == (char)(s != 0 ? s + 47 : 75))
            //        {
            //            validacion = true;
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    return validacion;
            //}

            //public string formatearRut(string rut)
            //{
            //    int cont = 0;
            //    string format;
            //    if (rut.Length == 0)
            //    {
            //        return "";
            //    }
            //    else
            //    {
            //        rut = rut.Replace(".", "");
            //        rut = rut.Replace("-", "");
            //        format = "-" + rut.Substring(rut.Length - 1);
            //        for (int i = rut.Length - 2; i >= 0; i--)
            //        {
            //            format = rut.Substring(i, 1) + format;
            //            cont++;
            //            if (cont == 3 && i != 0)
            //            {
            //                format = "." + format;
            //                cont = 0;
            //            }
            //        }
            //        return format;
            //    }
            //}
    }
}
