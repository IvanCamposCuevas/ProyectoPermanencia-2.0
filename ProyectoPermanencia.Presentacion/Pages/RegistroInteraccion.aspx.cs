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
        string[] detalleCaso = new string[3];
        string[] detalleInteraccion = new string[4];
        string rutalumno = string.Empty;
        int tipointer = new int();
        int idarea = new int();
        string comentarios = string.Empty;
        string rutaAbsoluta = string.Empty;
        string nombreArchivo = string.Empty;
        List<string> descParticipantes = new List<string>();
        DataTable participantes = new DataTable();
        DataTable intervencion = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] infoCaso = (string[])Session["info_caso"];
                if (infoCaso != null)
                {
                    this.lblRut.Text = infoCaso[3];
                    lblNombre.Text = infoCaso[4];
                    lblMail.Text = infoCaso[5];
                    lblTelefono.Text = infoCaso[6];
                    lblCarrera.Text = infoCaso[7];
                    lblEscuela.Text = infoCaso[8];
                    lblJornada.Text = infoCaso[9];
                    lblSede.Text = infoCaso[10];
                    lblTipoCaso.Text = infoCaso[1];
                    lblCurso.Text = infoCaso[2];
                }
                else
                {
                    string[] infoAlumno = (string[])Session["Info Alumnos"];
                    this.lblRut.Text = infoAlumno[0];
                    this.lblNombre.Text = infoAlumno[1];
                    this.lblCarrera.Text = infoAlumno[2];
                    this.lblJornada.Text = infoAlumno[7];
                    this.lblEscuela.Text = infoAlumno[5];
                    this.lblSede.Text = infoAlumno[6];
                    this.lblTelefono.Text = infoAlumno[3];
                    this.lblMail.Text = infoAlumno[4];
                }

                ddlCurso.DataSource = new Negocio.NegocioRegistroInteraccion().CargarddlCurso(lblRut.Text);
                ddlCurso.DataValueField = "Id_Asignatura";
                ddlCurso.DataTextField = "CURSO";
                ddlCurso.DataBind();

                ddlCasos.DataSource = new Negocio.NegocioRegistroInteraccion().CargarddlCasos(lblRut.Text);
                ddlCasos.DataValueField = "Id_Caso";
                ddlCasos.DataTextField = "CASO";
                ddlCasos.DataBind();

                if (ddlCasos.Items.Count == 0)
                {
                    fdsInteraccion.Disabled = true;
                }
            }


        }

        protected void rbtnExistentes_CheckedChanged(object sender, EventArgs e)
        {

            if (rbtnExistentes.Checked)
            {
                if (ddlCasos.Items.Count == 0)
                {
                    fdsInteraccion.Disabled = true;
                }
                ddlCasos.Enabled = true;
                ddlTipoCaso.Enabled = false;
                ddlCurso.Enabled = false;
            }
        }

        protected void rbtnNuevo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnNuevo.Checked)
            {
                if (ddlCasos.Items.Count == 0)
                {
                    fdsInteraccion.Disabled = false;
                }
                ddlCasos.Enabled = false;
                ddlTipoCaso.Enabled = true;
                ddlCurso.Enabled = true;
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

        protected void sqlAreaDerivacion_Selected(object sender, SqlDataSourceStatusEventArgs e)
        {
            ddlArederiv.Items.Add(new ListItem("Seleccione", "0"));
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

        protected void imbCalendario_Click(object sender, ImageClickEventArgs e)
        {
            calFecha.Visible = true;
            calFecha.Enabled = true;
        }

        private DataTable crearTablaIdParticipantes(out List<string> descParticipantes)
        {
            DataTable dt = new DataTable();
            descParticipantes = new List<string>();
            dt.Columns.Add("ID");

            foreach (ListItem item in ckblParticipan.Items)
            {
                if (item.Selected)
                {
                    dt.Rows.Add(item.Value);
                    descParticipantes.Add(item.Text);
                }
            }

            return dt;
        }

        private DataTable crearTablaDatosInteraccion(int estadoTerminarCaso,string rut, int idTipoInter, int idArea,
                                                     string comentario, string nombreArchivo, string idCaso)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("estadoTerminarCaso");
            dt.Columns.Add("rut");
            dt.Columns.Add("idCaso");
            dt.Columns.Add("idTipoInteraccion");
            dt.Columns.Add("idArea");
            dt.Columns.Add("comentario");
            dt.Columns.Add("rutaArchivo");
            dt.Rows.Add(estadoTerminarCaso,rut, (idCaso != null) ? int.Parse(idCaso) : 0, idTipoInter, idArea,
                        comentario, (nombreArchivo == "") ? "" : nombreArchivo);
            

            return dt;
        }

        protected void calFecha_SelectionChanged(object sender, EventArgs e)
        {
            calFecha.Visible = false;
            calFecha.Enabled = false;
        }



        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rbtnExistentes.Checked)
            {
                //Si el caso existe se le pasa el id directamente al metodo que crea las intervenciones
                string idcaso = ddlCasos.SelectedValue;
                creaInteraccion(idcaso);
            }
            if (rbtnNuevo.Checked)
            {
                
                casoNuevo(0);
            }

            Response.Redirect("/Pages/Interacciones.aspx");
        }


        private void cargarDatos()
        {
            rutalumno = lblRut.Text;
            tipointer = int.Parse(ddlTipoInteraccion.SelectedValue);
            idarea = (ddlArederiv.Enabled == true) ? int.Parse(ddlArederiv.SelectedValue) : 0;
            comentarios = tbComentarios.Text;
            rutaAbsoluta = string.Empty;
            nombreArchivo = string.Empty;
            participantes = crearTablaIdParticipantes(out descParticipantes);
            if (flInteraccion.HasFile)
            {
                rutaAbsoluta = string.Concat(Server.MapPath("~/ArchivoInteraccion/"), flInteraccion.FileName);
                nombreArchivo = flInteraccion.FileName;
            }
        }

        private void creaInteraccion(string idcaso)
        {
            cargarDatos();

            intervencion = crearTablaDatosInteraccion(0 ,rutalumno, tipointer, idarea, comentarios, nombreArchivo, idcaso);

            if (ddlArederiv.SelectedValue.Equals("0") || ddlTipoInteraccion.SelectedValue.Equals("0") || participantes.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una opcion o varias opciones de la pantalla");
            }
            else
            {
                try
                {
                    if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(idcaso)) || (!String.IsNullOrEmpty(ddlTipoInteraccion.SelectedValue)) || (!String.IsNullOrEmpty(ddlArederiv.SelectedValue)) || (!String.IsNullOrEmpty(comentarios)))
                    {
                        if (new Negocio.NegocioRegistroInteraccion().AgregaInteraccion(intervencion, participantes))
                        {
                            if (rutaAbsoluta != "")
                            {
                                flInteraccion.SaveAs(rutaAbsoluta);
                            }

                            string[] infoCaso = ddlCasos.SelectedItem.Text.Split('/');

                            string[] detalleInteraccion = new string[] { ddlTipoInteraccion.SelectedItem.ToString(),
                                                                        ddlArederiv.SelectedItem.ToString(), comentarios };
                            sendMail(detalleInteraccion, descParticipantes, infoCaso[1], infoCaso[2]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
        }

        protected void casoNuevo(int estadoFinalizarCaso)
        {
            cargarDatos();
            int tipoCaso = int.Parse(ddlTipoCaso.SelectedValue);
            int idcurso = (ddlCurso.Enabled == true) ? int.Parse(ddlCurso.SelectedValue) : 0;
            intervencion = crearTablaDatosInteraccion(estadoFinalizarCaso ,rutalumno, tipointer, idarea, comentarios, nombreArchivo, null);
            if (ddlArederiv.SelectedValue.Equals("0") || ddlTipoInteraccion.SelectedValue.Equals("0") || participantes.Rows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione una opcion o varias opciones de la pantalla");
            }
            else
            {
                if ((!String.IsNullOrEmpty(rutalumno)) || (!String.IsNullOrEmpty(ddlTipoCaso.SelectedValue)) || (!String.IsNullOrEmpty(ddlCurso.SelectedValue))
                    || (!String.IsNullOrEmpty(ddlTipoInteraccion.SelectedValue)) || (!String.IsNullOrEmpty(ddlArederiv.SelectedValue)) || (!String.IsNullOrEmpty(comentarios)))
                {
                    if (new Negocio.NegocioRegistroInteraccion().CreaCaso(intervencion, participantes, tipoCaso, idcurso))
                    {
                        if (rutaAbsoluta != "")
                        {
                            flInteraccion.SaveAs(rutaAbsoluta);
                        }
                        string[] detalleInteraccion = new string[] { ddlTipoInteraccion.SelectedItem.ToString(),
                                                                        ddlArederiv.SelectedItem.ToString(), comentarios };
                        sendMail(detalleInteraccion, descParticipantes, ddlTipoCaso.SelectedItem.Text, (ddlCurso.Enabled == true) ? ddlCurso.SelectedItem.Text : "No Aplica");
                    }
                }
            }
        }

        protected void sendMail(string[] detalleInteraccion, List<string> participantes , string tipoCaso, string curso)
        {
            MailMessage mensaje = new MailMessage("donotreply@permanencia.cl", "permanenciamail@gmail.com");
            mensaje.Body = string.Format("Se ha ingresado con éxito para el alumno {0} el caso N° xxx." +
                                         "\nDe tipo {1} y asociado al curso {2}." +
                                         "\n" +
                                         "\nHubo una intervención de tipo {3} . Se derivó al area {4}" +
                                         "\nDetalles: {5} \n", lblRut.Text, tipoCaso, curso, detalleInteraccion[0], detalleInteraccion[1], detalleInteraccion[2]);
            mensaje.Body += "Los participantes son: \n";

            foreach (string item in participantes)
            {
                mensaje.Body += item + "\n";
            }

            mensaje.Subject = "probando";
            new Negocio.NegocioRegistroInteraccion().EnviarMail(mensaje);
        }


        protected void lbtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Pages/Interacciones.aspx");

        }

        protected void btnFinalizarCaso_Click(object sender, EventArgs e)
        {
            if (rbtnExistentes.Checked)
            {
                string idcaso = ddlCasos.SelectedValue;
                if (new Negocio.NegocioDetalleCaso().finalizaCaso(idcaso))
                {
                    MessageBox.Show("CONGRATULATIONS!!!! te devolveremos a la pagina anterior :u");
                    
                }
            }
            if (rbtnNuevo.Checked)
            {
                casoNuevo(1);
            }

            Response.Redirect("/Pages/Interacciones.aspx");
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



    }
}