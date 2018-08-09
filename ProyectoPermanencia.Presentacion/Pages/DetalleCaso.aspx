<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleCaso.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.DetalleCaso" EnableEventValidation="false" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Detalle Caso  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentDetalleCaso" ContentPlaceHolderID="ContentPlaceHolderDetalleCaso" runat="server">
    <div class="container" style="font-size: small">
        <div class="row jumbotron" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px; margin-bottom: 0px;">
            <div class="container" style="padding: 5px">
                <div class="card card-primary">
                    <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Información del Alumno</div>
                    <div class="row card-body" style="padding-left: 100px">
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
                        <div class="col-md-4" style="border-left-style: solid; border-left-width: 1px; border-left-color: rgb(7, 47, 115);">
                            <asp:Label runat="server" Font-Bold="true">_  Contacto</asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Teléfono:</asp:Label>
                            <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Correo:</asp:Label>
                            <asp:Label ID="lblMail" runat="server"></asp:Label>
                            <br />
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row jumbotron detCasoContainer" style="padding:0px">
            <div class="container" style="padding: 5px; padding-top:0px">
                <div class="card card-primary">
                    <div id="cardDetalle" class="card card-primary ">
                        <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Detalles del Caso</div>
                        <div class="card card-body ">
                            <div class="row align-content-center infocasoContainer">

                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Id:</asp:Label>
                                    <asp:Label ID="lblIdCaso" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Tipo:</asp:Label>
                                    <asp:Label ID="lblTipoCaso" runat="server"></asp:Label><br />
                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Curso:</asp:Label>
                                    <asp:Label ID="lblCurso" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Estado:</asp:Label>
                                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                </div>
                            </div>
                            
                            <asp:Repeater ID="rpDetalle" runat="server" OnItemCommand="rpDetalle_ItemCommand">
                                <HeaderTemplate>
                                    <div class="row container detInterContainer">
                                </HeaderTemplate>
                                <ItemTemplate>
                                <div class="col-md-4">
                                    <asp:HiddenField runat="server" ID="hfID" Value='<%#Eval("ID") %>'/>    
                                    <asp:Label runat="server" Font-Bold="true">Tipo de Intervención:</asp:Label>
                                    <asp:Label ID="lblTipoI" runat="server" Text='<%#Eval("Tipo Interaccion")%>'></asp:Label><br />

                                    <asp:Label runat="server" Font-Bold="true">Participa:</asp:Label>
                                    <asp:Label ID="lblParti" runat="server" Text='<%#Eval("Participantes") %>'></asp:Label><br />


                                    <asp:Label runat="server" Font-Bold="true">Area de derivación:</asp:Label>
                                    <asp:Label ID="lblArea" runat="server" Text='<%#Eval("Área Derivacion") %>'></asp:Label><br />

                                    <asp:Label runat="server" Font-Bold="true">Fecha:</asp:Label>
                                    <asp:Label ID="lblFechaa" runat="server" Text='<%#Eval("Fecha Interaccion") %>'></asp:Label><br />
                                </div>
                                <div class="col-md-8" style="padding-left: 20px">
                                    <div class="row">
                                        <asp:Label runat="server" Font-Bold="true">Comentarios:</asp:Label><br />
                                        <asp:TextBox runat="server" ID="txbComentario" TextMode="MultiLine" Width="100%" Text='<%#Eval("Comentario") %>' Enabled="False"></asp:TextBox>

                                    </div>
                                    <div class="row d-flex flex-row-reverse" style="margin-top: 5px">
                                        <asp:Button runat="server" ID="btnDesc" Text="Descargar" CssClass="btn btn-warning btn-sm" CommandArgument='<%#Eval("Ruta Archivo") %>' CommandName="Download"/>

                                    </div>
                                </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
                                </FooterTemplate>
                            </asp:Repeater>
                            <div class="row container" style="margin: 10px; padding: 20px; border-top-width: 2px; border-top-style: solid; border-color: rgb(1,40,69); justify-content: center;">
                                <asp:Button runat="server" ID="btnAgregarInteraccion" Text="Agregar Interacción" CssClass="btn btn-success" OnClick="btnAgregarInteraccion_Click" />
                                <asp:Button runat="server" ID="btnVolver" Text="Volver" CssClass="btn btn-warning" OnClick="btnVolver_Click1"/>
                                <asp:Button runat="server" ID="btnFinalizarCaso" Text="Finalizar Caso" CssClass="btn btn-danger" OnClick="btnFinalizarCaso_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
