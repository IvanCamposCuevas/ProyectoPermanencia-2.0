<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.Historico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Historico  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderFicha" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderGlobal" runat="server">
</asp:Content>
<asp:Content ID="ContentHistorico" ContentPlaceHolderID="ContentPlaceHolderHistorico" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-3 jumbotron modal-content" style="padding: 15px; border-radius: 5px; box-shadow: none">
                <!-- COLUMNA LATERAL CON INFORMACION DEL ALUMNO -->
                <div>
                    <div>
                        <img src="~/imgs/avatar.png" height="150" runat="server" style="padding-left: 50px; margin: 10px; position: center;" />
                    </div>
                    <div style="padding-left: 25px; padding-top: 0px; margin-top: 0px; position: center;">
                        <h4>Estado de riesgo: </h4>
                        <div class="progress" style="width: 200px">
                            <div class="progress-bar progress-bar-success progress-bar-striped" role="progressbar" style="width: 30%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>
                            <div class="progress-bar progress-bar-warning progress-bar-striped" role="progressbar" style="width: 40%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>
                            <div class="progress-bar progress-bar-danger progress-bar-striped" role="progressbar" style="width: 30%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                            </div>
                        </div>
                    </div>
                    <div id="InformacionAlumno" class="SideColumn" style="float: left; align-content: center; padding-left: 20px">
                        <h4 style="text-align: center">Información Personal</h4>
                        <asp:Label runat="server" Font-Bold="true">Rut:</asp:Label>
                        <asp:Label ID="lblRut" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Nombre:</asp:Label>
                        <asp:Label runat="server" ID="lblNombre"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Carrera:</asp:Label>
                        <asp:Label runat="server" ID="lblCarrera"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Escuela:</asp:Label>
                        <asp:Label runat="server" ID="lblEscuela"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Sede:</asp:Label>
                        <asp:Label runat="server" ID="lblSede"></asp:Label>
                        <br />
                        <br />
                        <h4 style="text-align: center">Situación Financiera</h4>
                        <asp:Label runat="server" Font-Bold="true">Tipo de beneficio:</asp:Label>
                        <asp:Label runat="server" ID="lblBeneficio"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">% cobertura:</asp:Label>
                        <asp:Label runat="server" ID="lblPorce"></asp:Label>
                        <h4 style="text-align: center">Contacto</h4>
                        <asp:Label runat="server" Font-Bold="true">Teléfono:</asp:Label>
                        <asp:Label runat="server" ID="lblTelefono"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Mail:</asp:Label>
                        <asp:Label runat="server" ID="lblMail"></asp:Label>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
            <div class="Tabs col-md-6" style="float: left;">
                <ul class="nav nav-tabs">
                    <li><a href="FichaAlumno.aspx">Ficha</a></li>
                    <li class="active"><a href="#">Historico</a></li>
                </ul>
                <br>
            </div>


            <div class="col-sm-9">
                <!-- Información Histórico-->
                <h2>Contenido histórico del alumno (Asignaturas con notas y asistencia. Situación Financiera)</h2>

                

                
                

            </div>

        </div>
    </div>


    <div>

        <br />
        <br />
        <br />
        <br />

    </div>

</asp:Content>