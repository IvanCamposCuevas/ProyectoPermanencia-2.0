﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoPermanencia.Conexion;
namespace ProyectoPermanencia.Negocio
{
    public class NegocioConexionBD
    {
        public NegocioConexionBD()
        {
            configuraConexion();
        }

        private ConexionBD conexion;
       

        /// <summary>
        /// Objeto de Clase Conexion que tiene los metodos GET Y SET incluidos.
        /// </summary>
        public ConexionBD Conexion
        {
            get { return conexion; }
            set { conexion = value; }
        }

        /// <summary>
        /// Clase que servira para instanciar la clase Conexion e incializar algunos de sus Objetos.
        /// </summary>
        private void configuraConexion()
        {
            this.Conexion = new ConexionBD();
            this.Conexion.NombreBaseDeDatos = "prueba";
            this.Conexion.NombreTabla = "clientes";
            /*
             * Cadena de conexion hacia la base de datos, notese que el DataSource segun la maquina que esta corriendo la aplicacion
             * (Hasta ahora no me funciona usar localhost, ni . , ni (local) :c
             */
            /* El profe agregò user and pwd pero no se si a todos les funcionará con eso si que lo comenté*/
           // this.Conec1.CadenaConexion = "Data Source=LAPTOP-9N5AEVQ2;Initial Catalog=Permanencia_2;User=sa;pwd=sa;Integrated Security=False";

            this.Conexion.CadenaConexion = Properties.Settings.Default.ConexionGeneral;
        }
    }
}
