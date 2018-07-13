<%@ Page Title="Interacciones" Language="C#" MasterPageFile="~/FichaMaster.master" AutoEventWireup="true" CodeBehind="Interacciones.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.Interacciones" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure" > Interacciones </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentInteracciones" ContentPlaceHolderID="ContentPlaceHolderInteracciones" runat="server">
    <div class="Tabs col-md-6" style="float: left;">
        <ul class="nav nav-tabs">
            <li><a href="/Pages/FichaAlumno.aspx">Ficha</a></li>
            <li><a href="/Pages/Historico.aspx">Historico</a></li>
            <li class="active"><a href="/Pages/Interacciones.aspx">Interacciones</a></li>

        </ul>
        <br>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-sm-8" style="margin-left: 30px;">
                <div class="row" style="float: right;">
                    <asp:Button ID="btnNuevaInteraccion" runat="server" Text="Registrar Nueva Interaccion" CssClass="btn btn-info center-block" OnClick="btnNuevaInteraccion_Click" />
                </div>
                <!-- Grilla con historial de intervenciones -->

                    <div class="row" style="padding-left: 30px">
                        <div id="HistorialCasos" class="ScoreAsistencia">
                            <h3>Historial de Casos </h3>
                            <h4>Grilla</h4>
                            <asp:GridView ID="grvCasos" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                                EmptyDataText="No se encontraron registros" Width="800px"
                                CssClass="table table-bordered bs-table table-condensed table-responsive" Font-Size="12px">
                                <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                                <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>
                        
                <div>
                    <br />
                </div>
                <hr />
                <div class="row">
                    <asp:Button runat="server" Text="Ver Detaller" />
                    <div ID="panelDetalle" class="panel panel-primary " >
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
                            <div class="row" style="margin: 10px; padding-top: 20px; padding-bottom:20px; padding-left:0px; border-top-width: 2px; border-top-style: solid;">
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
