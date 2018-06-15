using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPermanencia.Negocio
{
    class NegocioConexionBD
    {
        private Conexion.Conexion conec1;
        
        /// <summary>
        /// Objeto de Clase Conexion que tiene los metodos GET Y SET incluidos.
        /// </summary>
        public Conexion.Conexion Conec1
        {
            get { return conec1; }
            set { conec1 = value; }
        }

        /// <summary>
        /// Clase que servira para instanciar la clase Conexion e incializar algunos de sus Objetos.
        /// </summary>
        public void configuraConexion()
        {
            this.Conec1 = new Conexion.Conexion();
            this.Conec1.NombreBaseDeDatos = "prueba";
            this.Conec1.NombreTabla = "clientes";
            /*
             * Cadena de conexion hacia la base de datos, notese que el DataSource segun la maquina que esta corriendo la aplicacion
             * (Hasta ahora no me funciona usar localhost, ni . , ni (local) :c
             */
            /* El profe agregò user and pwd pero no se si a todos les funcionará con eso si que lo comenté*/
            /* this.Conec1.CadenaConexion = "Data Source=LAPTOP-9N5AEVQ2;Initial Catalog=Permanencia_2;User=sa;pwd=sa;Integrated Security=False";*/

            //Del mismo modo, aqui se ingresaran las conexiones de cada uno, pa no estar cambiandolas a cada rato :S
            this.Conec1.CadenaConexion = "Data Source=LAPTOP-9N5AEVQ2;Initial Catalog=Permanencia_2;Integrated Security=True";
            //this.Conec1.CadenaConexion = @"Data Source=DESKTOP-L975CUE\SQLEXPRESS;Initial Catalog=Permanencia_2;Integrated Security=True";
            //this.Conec1.CadenaConexion = @"Data Source=HP-CATALINA;Initial Catalog=Permanencia_2;Integrated Security=True";
            //this.Conec1.CadenaConexion = Properties.Settings.Default.ConexionServer;
        }
    }
}
