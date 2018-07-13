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
            <li class="active"><a href="/Pages/Interacciones.aspx">Interacciónes</a></li>

        </ul>
        <br>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-sm-8" style="margin-left:30px; ">
                <div class="row" style="float: right;">
                    <asp:Button ID="btnNuevaInteraccion" runat="server" Text="Registrar Nueva Interaccion" CssClass="btn btn-info center-block" OnClick="btnNuevaInteraccion_Click"  />
                </div>
                <div class="row">
                    <!-- Grilla con historial de intervenciones -->

                    <div class="row" style="padding-left: 30px">
                        <div id="HistorialCasos" class="ScoreAsistencia">
                            <h3>Historial de Casos </h3>
                            <asp:GridView ID="grvCasos" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                                EmptyDataText="No se encontraron registros" Width="800px"
                                CssClass="table table-bordered bs-table table-condensed table-responsive" Font-Size="12px">
                                <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                                <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                            </asp:GridView>
                        </div>

                    </div>






                </div>
            </div>

        </div>
    </div>
</asp:Content>
