using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class RegistroInteraccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                ddlCurso.DataSource = new Negocio.NegocioRegistroInteraccion().CargarddlCurso(lblRut.Text);
                ddlCurso.DataValueField = "Id_Asignatura";
                ddlCurso.DataTextField = "CURSO";
                ddlCurso.DataBind();

                ddlCasos.DataSource = new Negocio.NegocioRegistroInteraccion().CargarddlCasos(lblRut.Text);
                ddlCasos.DataValueField = "Id_Caso";
                ddlCasos.DataTextField = "CASO";
                ddlCasos.DataBind();
            }


        }

        private DataTable crearTablaIdParticipantes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");

            foreach (ListItem item in ckblParticipan.Items)
            {
                if (item.Selected)
                {
                    dt.Rows.Add(item.Value);
                }
            }

            return dt;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string rutalumno = lblRut.Text;
            string idcaso = ddlCasos.SelectedValue;
            string tipointer = ddlTipoInteraccion.SelectedValue;
            string idarea = null;
            string comentarios = tbComentarios.Text;
            string rutaAbsoluta = string.Empty;
            string nombreArchivo = string.Empty;
            DateTime fecha = calFecha.SelectedDate;
            DataTable participantes = crearTablaIdParticipantes();
            if (flInteraccion.HasFile)
            {
                rutaAbsoluta = string.Concat(Server.MapPath("~/ArchivoInteraccion/"), flInteraccion.FileName);
                nombreArchivo = flInteraccion.FileName;
            }
            if (ddlArederiv.SelectedValue.Equals("0") || ddlTipoInteraccion.SelectedValue.Equals("0") || participantes.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una opcion o varias opciones de la pantalla");
            }
            else
            {
                if (ddlArederiv.Enabled == true)
                {
                    idarea = ddlArederiv.SelectedValue;
                    if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(idcaso)) || (!String.IsNullOrEmpty(tipointer)) || (!String.IsNullOrEmpty(idarea)) || (!String.IsNullOrEmpty(comentarios)))
                    {
                        new Negocio.NegocioRegistroInteraccion().AgregaInteraccion(rutalumno, idcaso, tipointer, idarea, comentarios, participantes, fecha, nombreArchivo);
                        flInteraccion.SaveAs(rutaAbsoluta);
                    }
                }
                else
                {
                    if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(idcaso)) || (!String.IsNullOrEmpty(tipointer)) || (!String.IsNullOrEmpty(comentarios)))
                    {
                        new Negocio.NegocioRegistroInteraccion().AgregaInteraccion(rutalumno, idcaso, tipointer, idarea, comentarios, participantes, fecha, nombreArchivo);
                        flInteraccion.SaveAs(rutaAbsoluta);
                    }
                }
            }
        }

        protected void rbtnExistentes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnExistentes.Checked)
            {
                ddlCasos.Enabled = true;
                ddlTipoCaso.Enabled = false;
                ddlCurso.Enabled = false;
            }
        }

        protected void rbtnNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNuevo.Checked)
            {
                ddlCasos.Enabled = false;
                ddlTipoCaso.Enabled = true;
                ddlCurso.Enabled = true;
            }
        }

        protected void ddlTipoInteraccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoInteraccion.SelectedItem.Value.Equals("2"))
            {
                ddlArederiv.Enabled = true;
            }
            else
            {
                ddlArederiv.Enabled = false;
            }

        }

        protected void ddlTipoCaso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoCaso.SelectedItem.Value.Equals("2"))
            {
                ddlCurso.Enabled = false;
            }
            else
            {
                ddlCurso.Enabled = true;
            }
        }

        protected void btnCreaCaso_Click(object sender, EventArgs e)
        {
            if (rbtnExistentes.Checked == true)
            {
                if (ddlCasos.Items.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar la opcion de crear un nuevo caso");
                }
            }
            if (rbtnNuevo.Checked == true)
            {
                string rutalumno = lblRut.Text;
                string tipo = ddlTipoCaso.SelectedValue;
                string idcurso = null;

                if (ddlTipoCaso.SelectedItem.Value.Equals("2"))
                {
                    if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(tipo)))
                    {
                        new Negocio.NegocioRegistroInteraccion().CreaCaso(rutalumno, tipo, idcurso);
                    }
                }
                else
                {
                    idcurso = ddlCurso.SelectedValue.ToString();
                    if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(tipo)) || (!String.IsNullOrEmpty(idcurso)))
                    {
                        new Negocio.NegocioRegistroInteraccion().CreaCaso(rutalumno, tipo, idcurso);
                    }
                }

                Response.Redirect(HttpContext.Current.Request.Url.ToString(), true);
            }
        }

        protected void sqlAreaDerivacion_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            ddlArederiv.Items.Add(new ListItem("Seleccione", "0"));
        }

        protected void ddlCasos_DataBound(object sender, EventArgs e)
        {
            if (ddlCasos.Items.Count == 0)
            {
                fdsInteraccion.Disabled = true;
            }
        }
    }
}