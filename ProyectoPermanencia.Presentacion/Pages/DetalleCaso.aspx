<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleCaso.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.DetalleCaso" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Detalle Caso  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentDetalleCaso" ContentPlaceHolderID="ContentPlaceHolderDetalleCaso" runat="server">
    <div class="container">
        <div class="row jumbotron" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px; margin-bottom: 0px;">
            <div class="panel panel-primary" style="margin: 0px">
                <div class="panel-heading" style="background-color: rgb(1,40,69);">Información del Alumno</div>
                <div class="col-md-12 panel panel-body" style="padding-left=100px">
                    <div class="col-md-4">
                        <asp:Label runat="server" Font-Bold="true">Rut:</asp:Label>
                        <asp:Label ID="lblRut" runat="server"></asp:Label>

                        <br />
                        <asp:Label runat="server" Font-Bold="true">Nombre:</asp:Label>
                        <asp:Label ID="lblNombre" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Carrera:</asp:Label>
                        <asp:Label ID="lblCarrera" runat="server"></asp:Label>
                        <br />
                    </div>
                    <div class="col-md-4">
                        <asp:Label runat="server" Font-Bold="true">Escuela:</asp:Label>
                        <asp:Label ID="lblEscuela" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Jornada:</asp:Label>
                        <asp:Label ID="lblJornada" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Sede:</asp:Label>
                        <asp:Label ID="lblSede" runat="server"></asp:Label>
                        <br />
                    </div>
                    <div class="col-md-4" style="border-left-style: solid; border-left-width: 1; border-left-color: rgb(7, 47, 115);">
                        <asp:Label runat="server" Font-Bold="true">_  Contacto</asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Telefono:</asp:Label>
                        <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                        <br />
                        <asp:Label runat="server" Font-Bold="true">Correo:</asp:Label>
                        <asp:Label ID="lblMail" runat="server"></asp:Label>
                        <br />
                    </div>

                </div>
            </div>
        </div>

        <div class="row jumbotron" style="margin-top: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px;">
            <div class="col-md-12 panel-group" style="padding-left: 0px;">
                <div class="panel panel-primary">
                    <div id="panelDetalle" class="panel panel-primary ">
                        <div class="panel-heading" style="background-color: rgb(1,40,69);">Detalles del Caso</div>
                        <div class="col-md-12 panel panel-body center-block">
                            <div class="jumbotron modal-content" style="height: 50px; padding: 5px; box-shadow: none; box-sizing: border-box; margin: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Id:</asp:Label>
                                    <asp:Label ID="lblIdCaso" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-4">
                                    <asp:Label runat="server" Font-Bold="true">Tipo:</asp:Label>
                                    <asp:Label ID="lblTipoCaso" runat="server"></asp:Label><br />
                                    <asp:Label runat="server" Font-Bold="true">Curso:</asp:Label>
                                    <asp:Label ID="lblCurso" runat="server"></asp:Label>

                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Estado:</asp:Label>
                                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row" style="margin: 10px; padding-top: 20px; padding-bottom: 20px; padding-left: 0px; border-top-width: 2px; border-top-style: solid;">
                                <div class="col-md-12 container">
                                    <div class="row" style="height: 80px">
                                        <div class="col-md-12">
                                            <div class="col-md-3">
                                                <asp:Label runat="server" Font-Bold="true">Tipo de Intervención:</asp:Label><br />
                                                <asp:Label ID="lblTipoIntervencion" runat="server">blabla</asp:Label>
                                            </div>
                                            <div class="col-md-3" style="padding-left: 40px">
                                                <asp:Label runat="server" Font-Bold="true">Participa:</asp:Label><br />
                                                <asp:Label ID="lblParticipa" runat="server">slañsñ</asp:Label>
                                            </div>

                                            <div class="col-md-3">
                                                <asp:Label runat="server" Font-Bold="true">Area de derivación:</asp:Label>
                                                <asp:Label ID="lblAreaDeriv" runat="server">blabla</asp:Label>
                                            </div>

                                            <div class="col-md-3">
                                                <asp:Label runat="server" Font-Bold="true">Fecha:</asp:Label>
                                                <asp:Label ID="lblFecha" runat="server">12/02/2018</asp:Label>
                                            </div>

                                        </div>

                                    </div>
                                    <div class="row center-block" style="padding-left: 20px">
                                        <asp:Label runat="server" Font-Bold="true">Comentarios:</asp:Label><br />
                                        <asp:TextBox runat="server" ID="tbComentarios" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        <asp:Button runat="server" ID="btnEditar" Text="Editar" CssClass="btn btn-warning center-block" />
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin: 10px; padding: 20px; border-top-width: 2px; border-top-style: solid;">
                                <div class="col-md-12 container">
                                    <div class="row" style="height: 80px">
                                        <div class="col-md-12">
                                            <div class="col-md-3">
                                                <asp:Label runat="server" Font-Bold="true">Tipo de Intervención:</asp:Label>
                                                <asp:Label ID="lblIntervencion2" runat="server">blabla</asp:Label>
                                            </div>
                                            <div class="col-md-3" style="padding-left: 40px">
                                                <asp:Label runat="server" Font-Bold="true">Participa:</asp:Label><br />
                                                <asp:Label ID="lblPartcipar2" runat="server">slañsñ</asp:Label>
                                            </div>

                                            <div class="col-md-3">
                                                <asp:Label runat="server" Font-Bold="true">Area de derivación:</asp:Label>
                                                <asp:Label ID="lblADerivacion" runat="server">blabla</asp:Label>
                                            </div>

                                            <div class="col-md-3">
                                                <asp:Label runat="server" Font-Bold="true">Fecha:</asp:Label>
                                                <asp:Label ID="lblFecha2" runat="server">12/02/2018</asp:Label>
                                            </div>

                                        </div>

                                    </div>
                                    <div class="row center-block" style="padding-left: 20px">
                                        <asp:Label runat="server" Font-Bold="true">Comentarios:</asp:Label><br />
                                        <asp:TextBox runat="server" ID="TextBox1" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                    </div>
                                    <div class="row">
                                        <asp:Button runat="server" ID="btnEditar2" Text="Editar" CssClass="btn btn-warning center-block" />
                                    </div>
                                </div>
                            </div>
                            <div class="row" style="margin: 10px; padding: 20px; border-top-width: 2px; border-top-style: solid;">
                                <div class="col-md-12 container">
                                    <div class="row center-block">
                                        <asp:Button runat="server" ID="Button2" Text="Finalizar Caso" CssClass="btn btn-danger center-block" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
