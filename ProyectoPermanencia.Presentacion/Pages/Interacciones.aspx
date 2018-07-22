<%@ Page Title="Interacciones" Language="C#" MasterPageFile="~/FichaMaster.master" AutoEventWireup="true" CodeBehind="Interacciones.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.Interacciones" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure" > Interacciones </h3>
    </asp:Label>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTabs" runat="server">
    <div class="container">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link" href="/Pages/FichaAlumno.aspx">Ficha</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/Historico.aspx">Historico</a>
            </li>
            <li class="nav-item">
                <a class="nav-link active" href="/Pages/Interacciones.aspx">Interacciones</a>
            </li>
        </ul>
    </div>
</asp:Content>
<asp:Content ID="ContentInteracciones" ContentPlaceHolderID="ContentPlaceHolderInteracciones" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-8" style="margin-left: 30px;">
                <div class="row" style="float: right;">
                    <asp:Button ID="btnNuevaInteraccion" runat="server" Text="Registrar Nueva Interaccion" CssClass="btn btn-info center-block" OnClick="btnNuevaInteraccion_Click" />
                </div>
                <div class="row" style="float: left;">
                    <asp:Button ID="btnDetalle" runat="server" Text="Detalle Caso" CssClass="btn btn-info center-block" OnClientClick="window.open('/Pages/DetalleCaso.aspx');" />
                </div>

                <!-- Grilla con historial de intervenciones -->

                <div class="row container" style="padding-left: 30px">
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
                        <div id="panelDetalle" class="panel panel-primary ">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
