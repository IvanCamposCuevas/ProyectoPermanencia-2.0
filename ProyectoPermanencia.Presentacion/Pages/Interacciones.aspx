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
            <div class="col-md-6">
                <asp:Button ID="btnDetalle" runat="server" Text="Detalle Caso" CssClass="btn btn-info center-block" OnClientClick="window.open('/Pages/DetalleCaso.aspx');" />
            </div>
            <div class="col-md-6 ">
                <asp:Button ID="btnNuevaInteraccion" runat="server" Text="Registrar Nueva Interaccion" CssClass="btn btn-info flex-row-reverse" OnClick="btnNuevaInteraccion_Click" />
            </div>
        </div>
        <div class="row">
            <!-- Grilla con historial de intervenciones -->
            <div id="HistorialCasos" class="ScoreAsistencia">
                <h5>Historial de Casos </h5>
                <h6>Grilla</h6>
                <asp:GridView ID="grvCasos" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                    EmptyDataText="No se encontraron registros" Width="800px"
                    CssClass="table table-bordered bs-table table-condensed table-responsive" Font-Size="12px">
                    <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                    <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    <Columns>
                        <asp:TemplateField></asp:TemplateField>
                    </Columns>
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

</asp:Content>
