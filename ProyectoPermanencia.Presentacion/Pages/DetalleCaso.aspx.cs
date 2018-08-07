using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class DetalleCaso : System.Web.UI.Page
    {
        static string paginaAnterior = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                paginaAnterior = Request.UrlReferrer.ToString();

                if (Session["info_caso"] != null)
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

                if (Session["Info Alumnos"] != null)
                {
                    string[] info = (string[])Session["Info Alumnos"];
                    this.lblRut.Text = info[0];
                    this.lblNombre.Text = info[1];
                    this.lblCarrera.Text = info[2];
                    this.lblJornada.Text = info[7];
                    this.lblEscuela.Text = info[5];
                    this.lblSede.Text = info[6];
                    this.lblTelefono.Text = info[3];
                    this.lblMail.Text = info[4];
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
            new Negocio.NegocioDetalleCaso().finalizaCaso(lblIdCaso.Text);
            //Response.Redirect("/Pages/Interacciones.aspx");
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
                Response.Clear();
                Response.ContentType = "application/octect-stream";
                Response.AppendHeader("content-disposition", "filename=" + e.CommandArgument);
                Response.TransmitFile(Server.MapPath("~/ArchivoInteraccion/") + e.CommandArgument);
                Response.End();
            }
        }
    }
}