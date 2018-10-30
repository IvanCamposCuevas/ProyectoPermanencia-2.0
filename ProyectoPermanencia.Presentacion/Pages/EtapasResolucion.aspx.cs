using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoPermanencia.Negocio;
namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class EtapasResolucion : System.Web.UI.Page, IMensajeAlerta
    {
        static NegocioResolucion negocio = new NegocioResolucion();

        protected void Page_Load(object sender, EventArgs e)
        {
            string boton = "pendientes";
            estadoBotones(boton);
        }


        /// <summary>
        /// Evento que buscara una lista de casos sin criterios de busquedas avanzados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnBuscarCasoSinFiltro_Click(object sender, EventArgs e)
        {
            try
            {
                //Si el ingreso de busqueda no es nula...
                if (!String.IsNullOrEmpty(txtIngresoBusqueda.Text))
                {
                    //El resultado de la busqueda se convierte en un DataView.
                    DataView dv = negocio.buscarCasoSinFiltro(ddlTipoBusqueda.SelectedValue, txtIngresoBusqueda.Text).Tables[negocio.Conexion.NombreTabla].AsDataView();
                    //El resultado se guarda en una variable de Sesion.
                    Session["dvGeneral"] = dv;
                    //Se filtra el rsultado por el estado del caso.
                    dv.RowFilter = "Estado = 'Pendiente'";
                    //Se ingresa el resultado de la consulta filtrada en el Grid View.
                    grvIntervenciones.DataSource = dv;
                    grvIntervenciones.DataBind();

                }
            }
            catch (Exception ex)
            {

                mostrarAlerta(ex.Message + " , " + ex.InnerException);
            }
        }

        private void estadoBotones(string boton)
        {
            btnPendientes.CssClass = "btn btn-secondary";
            btnEnCurso.CssClass = "btn btn-secondary";
            btnFinalizadas.CssClass = "btn btn-secondary";

            if (boton == "pendientes")
            {
                btnPendientes.CssClass = "btn btn-primary";
            }
            else if (boton == "encurso")
            {
                btnEnCurso.CssClass = "btn btn-primary";
            }
            else if (boton == "finalizadas")
            {
                btnFinalizadas.CssClass = "btn btn-primary";
            }
        }

        /// <summary>
        /// Boton que mostrara los casos con resultados pendientes en la grilla.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnPendientes_Click(object sender, EventArgs e)
        {
            if (Session["dvGeneral"] != null) //Si la sesion indicada no es nula...
            {
                //Se obtien DataView resguardado en la Sesion, y se filtran por pendiente.
                DataView dv = (DataView)Session["dvGeneral"];
                dv.RowFilter = "Estado = 'Pendiente'";
                grvIntervenciones.DataSource = dv;
                grvIntervenciones.DataBind();

                string boton = "pendientes";
                estadoBotones(boton);
            }

        }
        /**
         Los siguientes dos eventos son el mismo como el anterior, solo que filtran si el estado
          de los casos estan 'En Curso' o si estan finalizados*/
        protected void btnEnCurso_Click(object sender, EventArgs e)
        {
            if (Session["dvGeneral"] != null)
            { 
                DataView dv = (DataView)Session["dvGeneral"];
                dv.RowFilter = "Estado = 'En Curso'";
                grvIntervenciones.DataSource = dv;
                grvIntervenciones.DataBind();

                string boton = "encurso";
                estadoBotones(boton);
            }
        }

        protected void btnFinalizadas_Click(object sender, EventArgs e)
        {
            if (Session["dvGeneral"] != null)
            {
                DataView dv = (DataView)Session["dvGeneral"];
                dv.RowFilter = "Estado = 'Finalizado'";
                grvIntervenciones.DataSource = dv;
                grvIntervenciones.DataBind();

                string boton = "finalizadas";
                estadoBotones(boton);
            }
        }
        /// <summary>
        /// Este evento busca y filtras todos los casos, por medio de criterios de busquedas
        /// avanzado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se inicializan las Listas tipeadas.
                List<string> listaCasos = new List<string>();
                List<string> listaIntervenciones = new List<string>();

                //Ciclo For que resguardara una lista de casos, si los checkboxs de TipoCaso 
                //estan seleccionados.
                foreach (ListItem item in ckblTipoCaso.Items)
                {
                    if (item.Selected == true)
                    {
                        listaCasos.Add(item.Text);
                    }
                }
                //Ciclo for que resguarda que llenara una lista de los tipos de intervenciones seleccionados
                //en un checkbox.
                foreach (ListItem item in ckblTipoIntervención.Items)
                {
                    if (item.Selected == true)
                    {
                        listaIntervenciones.Add(item.Text);
                    }
                }
                //Obtiene la fecha de inicio del elemento HTML "Fecha_Inicio" de la pagína Web.
                string fechaInicio = string.Format("{0}", Request.Form["Fecha_Inicio"]);
                //Se transforma la fecha anterior que estaba en formato String, en un array.
                string[] arrayFechaInicio = fechaInicio.Split('-');
                //Obtiene la fehca de termino del elemento HTML "Fecha_Termino" de la pagína Web.
                string fechaTermino = string.Format("{0}", Request.Form["Fecha_Termino"]);
                //Se transforma la fehca anterior que estaba en formato String, en un array.
                string[] arrayFechaTermino = fechaTermino.Split('-');

                /*Se crean nuevas variables de tipo DateTime,
                 * Si los array no estan vacíos, se procede a resguardar sus valores dentro de las instancias.**/

                DateTime dtFechaInicio = new DateTime();

                DateTime dtFechaTermino = new DateTime();

                if (arrayFechaTermino[0] != "" && arrayFechaInicio[0] != "")
                {
                    dtFechaInicio = new DateTime(int.Parse(arrayFechaInicio[0]), int.Parse(arrayFechaInicio[1]), int.Parse(arrayFechaInicio[2]));

                    dtFechaTermino = new DateTime(int.Parse(arrayFechaTermino[0]), int.Parse(arrayFechaTermino[1]), int.Parse(arrayFechaTermino[2]));
                }
                //Se envia, como parametro de entrada, las variables creadas anteriormente al metodo 'buscarCasoConFiltro', este se transformara en DataView y se guardara 
                //en una variable del mismo tipo.
                DataView dv = negocio.buscarCasoConFiltro(listaCasos, listaIntervenciones, dtFechaInicio, dtFechaTermino).Tables[negocio.Conexion.NombreTabla].AsDataView();
                Session["dvGeneral"] = dv; //Se resguarda el DataView e una variable de Session.
                dv.RowFilter = "Estado = 'Pendiente'"; //Se filtra el DataView por el Estado del Caso, en 'Pendiente' por defecto.
                //Se monta el DataView en la grilla
                grvIntervenciones.DataSource = dv; 
                grvIntervenciones.DataBind();
            }
            catch (Exception ex)
            {

                mostrarAlerta(ex.Message + " , " + ex.InnerException);
            }
            
        }
        /// <summary>
        /// Evento que guardara la mayor parte de la informacion de la tabla en un array, para luego resguardarla en
        /// una Sesion, y redireccionar la pagína señalada por el metodo 'Response.Redirect'.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvIntervenciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = this.grvIntervenciones.SelectedRow;
            string[] info_caso = new string[] {row.Cells[1].Text, row.Cells[2].Text, row.Cells[3].Text,
                                               row.Cells[4].Text, row.Cells[5].Text, row.Cells[6].Text,
                                               row.Cells[7].Text, row.Cells[8].Text, row.Cells[9].Text,
                                               row.Cells[10].Text, row.Cells[11].Text, row.Cells[15].Text};
            Session["info_caso"] = info_caso;
            Session["dvGeneral"] = null;
            Response.Redirect("DetalleCaso.aspx");
        }
        /// <summary>
        /// Evento que ocultara algunas filas de la grilla que no necesiten ser mostradas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grvIntervenciones_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1) //Si la grilla no esta vacia...
            {
                e.Row.Cells[5].Visible = false; //Oculta la fila "Nombre Alumno"
                e.Row.Cells[6].Visible = false; //Oculta la fila "Correo"
                e.Row.Cells[7].Visible = false; //Oculta la fila "Telefono"
                e.Row.Cells[8].Visible = false; //Oculta la fila "Carrera"
                e.Row.Cells[9].Visible = false; //Oculta la fila "Escuela"
                e.Row.Cells[10].Visible = false;//Oculta la fila "Jornada"
                e.Row.Cells[11].Visible = false;//Oculta la fila "Sede"
            }
        }

        //Metodo de la interfaz, que mostrara un mensaje de alerta por JavasCript.
        public void mostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", string.Format("alert('{0}');", mensaje), true);
        }
    }
}