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
            <div class="col-md-8">
            </div>
            <div class="col-md-4 ">
                <asp:Button ID="btnNuevaInteraccion" runat="server" Text="Registrar Nueva Interacción" CssClass="btn btn-info flex-row-reverse" OnClick="btnNuevaInteraccion_Click" />
            </div>
        </div>

        <div class="row container" style="padding-left: 20px">
            <!-- Grilla con historial de intervenciones -->
            <div id="HistorialCasos" class="ScoreAsistencia">
                <h5>Historial de Casos </h5>
                <h6>Grilla</h6>
                <asp:GridView ID="grvCasos" runat="server" BackColor="#EFF4F8" ShowHeaderWhenEmpty="True" Width="600px" Font-Size="12px"
                    CssClass=" table table-hover table-bordered bs-table table-sm table-responsive" HorizontalAlign="Right"
                    EmptyDataText="No se han abierto casos para intervenir con el alumno" OnSelectedIndexChanged="grvCasos_SelectedIndexChanged" OnRowDataBound="grvCasos_RowDataBound">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Ver Detalle">
                            <ControlStyle CssClass="btn btn-sm btn-success" />
                        </asp:CommandField>
                    </Columns>
                    <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" />
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

</asp:Content>
