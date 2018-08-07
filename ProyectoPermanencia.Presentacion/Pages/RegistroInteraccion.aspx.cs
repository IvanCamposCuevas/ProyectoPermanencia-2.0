using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
namespace ProyectoPermanencia.Presentacion.Pages
{
    public partial class RegistroInteraccion : System.Web.UI.Page
    {
        public string[] detalleCaso = new string[3];
        public string[] detalleInteraccion = new string[4];


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                lblTipoCaso.Text = info[1];
                lblCurso.Text = info[2];

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



        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    string rutalumno = lblRut.Text;
        //    string idcaso = ddlCasos.SelectedValue.ToString();
        //    string tipointer = ddlTipoInteraccion.SelectedValue.ToString();
        //    string idarea = null;
        //    string comentarios = tbComentarios.Text;
        //    string participantes = null;

        //    foreach (ListItem item in ckblParticipan.Items)
        //    {
        //        if (item.Selected)
        //        {
        //            participantes += item.Text + ", ";
        //        }
        //    }

        //    if (ddlTipoInteraccion.SelectedItem.Value.Equals("2"))
        //    {
        //        idarea = ddlArederiv.SelectedValue.ToString();
        //        if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(idcaso)) || (!String.IsNullOrEmpty(tipointer)) || (!String.IsNullOrEmpty(idarea)) || (!String.IsNullOrEmpty(comentarios)))
        //        {
        //            new Negocio.NegocioRegistroInteraccion().AgregaInteraccion(rutalumno, idcaso, tipointer, idarea, comentarios, participantes);
        //        }
        //    }
        //    else
        //    {
        //        if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(idcaso)) || (!String.IsNullOrEmpty(tipointer)) || (!String.IsNullOrEmpty(comentarios)))
        //        {
        //            new Negocio.NegocioRegistroInteraccion().AgregaInteraccion(rutalumno, idcaso, tipointer, idarea, comentarios, participantes);
        //        }
        //    }

        //    string[] detalleInteraccion = new string[] {ddlTipoInteraccion.SelectedItem.ToString(), participantes, ddlArederiv.SelectedItem.ToString(), comentarios };
        //    sendMail(detalleCaso, detalleInteraccion);
        //    Response.Redirect("/Pages/Interacciones.aspx");

        //}


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

                detalleCaso = new string[] { rutalumno, ddlTipoCaso.SelectedItem.ToString(), ddlCurso.SelectedItem.ToString() };
                //sendMailCaso(detalleCaso);
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

        //metodo de prueba para envio de mails solo al crear el caso por ahora
        //FUNCIONANDO.
        /*
        protected MailMessage sendMailCaso(string[] detalleCaso)
        {
            MailMessage mensaje = new MailMessage("donotreply@permanencia.cl", "permanenciamail@gmail.com");
            mensaje.Body = string.Format("Se ha ingresado con éxito para el alumno {0} el caso N° xxx."+
                                         "\nDe tipo {1} y asociado al curso {2}.", detalleCaso[0], detalleCaso[1], detalleCaso[2]);

            mensaje.Subject = "probando";
            new Negocio.NegocioRegistroInteraccion().EnviarMail(mensaje);

            return mensaje;
        }
        */

        protected MailMessage sendMail(string[] detalleCaso, string[] detalleInteraccion)
        {
            MailMessage mensaje = new MailMessage("donotreply@permanencia.cl", "permanenciamail@gmail.com");
            mensaje.Body = string.Format("Se ha ingresado con éxito para el alumno {0} el caso N° xxx." +
                                         "\nDe tipo {1} y asociado al curso {2}." +
                                         "\n" +
                                         "\nHubo una intervención de tipo {3} en la cual participó: {4}. Se derivó al area {5}" +
                                         "\nDetalles: {6}", detalleCaso[0], detalleCaso[1], detalleCaso[2], detalleInteraccion[0], detalleInteraccion[1], detalleInteraccion[2], detalleInteraccion[3]);

            mensaje.Subject = "probando";
            new Negocio.NegocioRegistroInteraccion().EnviarMail(mensaje);

            return mensaje;
        }


    }
}