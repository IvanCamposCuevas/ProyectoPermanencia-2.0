using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class DetalleCaso : System.Web.UI.Page, IMensajeAlerta
    {
        static string paginaAnterior = string.Empty; //Variable estatica que servira para guardar la pagína anteriomente visitada.
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Se guarda la url de la ultíma pagína visitada por el usuarío.
                paginaAnterior = Request.UrlReferrer.ToString();

                if (Session["info_caso"] != null)//Si la sesion no esta vacia, se recuperan todos los datos de la sesion, 
                                                 //y se incluyen en los Label que estan en la pagína.
                {
                    string[] info = (string[])Session["info_caso"];
                    this.lblRut.Text = info[3];
                    lblNombre.Text = info[4];
                    lblMail.Text = info[5];
                    lblTelefono.Text = info[6];
                    lblCarrera.Text = info[7];
                    lblEscuela.Text = info[8];
                    lblJornada.Text = info[9];
                    lblSede.Text = info[10];
                    lblIdCaso.Text = info[0];
                    lblTipoCaso.Text = info[1];
                    lblCurso.Text = info[2];
                    lblEstado.Text = info[11];
                }

                if (lblEstado.Text == "Finalizado")
                {
                    btnAgregarInteraccion.Visible = false;
                    btnFinalizarCaso.Visible = false;
                }


                rpDetalle.DataSource = new Negocio.NegocioDetalleCaso().obtenerDetalleInteraccion(int.Parse(lblIdCaso.Text));
                rpDetalle.DataBind();
            }
        }

        protected void btnVolver_Click1(object sender, EventArgs e)
        {

            Response.Redirect(paginaAnterior);

        }

        protected void btnFinalizarCaso_Click(object sender, EventArgs e)
        {
            if (new Negocio.NegocioDetalleCaso().finalizaCaso(lblIdCaso.Text))
            {
                mostrarAlerta("Caso finalizado correctamente, presione 'aceptar' \n para volver a la pagina anterior");
                Response.Redirect(paginaAnterior);
            }

            
        }


        /// <summary>
        /// Metodo que sirve para descargar un archivo desde la carpeta indicada en el servidor
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rpDetalle_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                if (e.CommandArgument.ToString() != "")
                {
                    Response.Clear();
                    Response.ContentType = "application/octect-stream";
                    Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                    Response.TransmitFile(Server.MapPath("~/ArchivoInteraccion/") + e.CommandArgument);
                    Response.End();
                }
            }
        }

        /// <summary>
        /// Evento que reedirigira al usuario a la pagina de registro de interacciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnAgregarInteraccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroInteraccion.aspx");
        }

        
        public void mostrarAlerta(string mensaje)
        {
            ScriptManager.RegisterStartupScript(this.Page, typeof(string), "Alert", string.Format("alert('{0}');", mensaje), true);
        }
    }
}