<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.Historico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderFicha" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderGlobal" runat="server">
</asp:Content>
<asp:Content ID="ContentHistorico" ContentPlaceHolderID="ContentPlaceHolderHistorico" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-3 jumbotron" style="border: 2px solid rgb(9,40,69)">
                <!-- COLUMNA LATERAL CON INFORMACION DEL ALUMNO -->
                <div>
                    <div>
                        <img src="~/imgs/avatar.png" width="100" runat="server" style="align-content: center" />
                    </div>
                    <div id="InformacionAlumno" class="SideColumn" style="float: left; align-content: center;">
                        <h3 style="text-align: center">Información Personal</h3>
                        <asp:Label runat="server">Rut:</asp:Label>
                        <asp:Label ID="lblRut" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server">Nombre:</asp:Label>
                        <asp:Label runat="server" ID="lblNombre"></asp:Label>
                        <br />
                        <asp:Label runat="server">Carrera:</asp:Label>
                        <asp:Label runat="server" ID="lblCarrera"></asp:Label>
                        <br />
                        <asp:Label runat="server">Escuela:</asp:Label>
                        <asp:Label runat="server" ID="lblEscuela"></asp:Label>
                        <h3 style="text-align: center">Contacto</h3>
                        <br />
                        <asp:Label runat="server">Teléfono:</asp:Label>
                        <asp:Label runat="server" ID="lblTelefono"></asp:Label>
                        <br />
                        <asp:Label runat="server">Mail:</asp:Label>
                        <asp:Label runat="server" ID="lblMail"></asp:Label>
                    </div>

                </div>
            </div>
            <!-- BODY FICHA -->
            <div class="col-sm-9 jumbotron" style="border: 2px solid rgb(9,40,69);">
                <!--  -->
                <div id="BodyHistorico" class="BodyHistorico" runat="server">
                    <!-- TABS DE NAVEGACION ENTRE GRILLAS E HISTORICO -->
                    <div class="Tabs-barra row" style="border: solid">
                        <div class="Tabs col-md-4" style="float: left">
                            <h3>Tabs</h3>
                            <ul class="nav nav-tabs">
                                <li class="active"><a href="#">Home</a></li>
                                <li><a href="FichaAlumno.aspx">Ficha</a></li>
                                <li><a href="Historico.aspx">Historico</a></li>
                            </ul>
                            <br>
                        </div>
                        <!-- CONTENEDOR DE BARRA Y PUNTAJE-->
                        <div id="Div1" runat="server" class="colmd-4" style="border: 1px solid rgb(9,40,69); background-color: aqua; width: 250px; float: right">
                            <h4>Estado de riesgo: </h4>
                            <asp:Label runat="server" ID="lblRiesgo"></asp:Label>
                            <div class="progress" style="width: 200px;">
                                <div class="progress-bar progress-bar-striped bg-warning" role="progressbar" style="width: 25%" aria-valuenow="25" aria-valuemin="0" aria-valuemax="100">
                                </div>
                            </div>
                        </div>
                    </div>



                </div>

            </div>



        </div>


        <div>


            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />


        </div>
    </div>
</asp:Content>
