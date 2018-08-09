<%@ Page Title="" Language="C#" MasterPageFile="~/FichaMaster.master" AutoEventWireup="true" CodeBehind="FichaAlumno.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.FichaAlumno" %>

<%@ MasterType VirtualPath="~/FichaMaster.master" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure" > Ficha Alumno  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTabs" runat="server">
    <div class="container" style="font-size: small">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" href="#">Ficha</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/Historico.aspx">Histórico</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/Interacciones.aspx">Interacciones</a>
            </li>
        </ul>
    </div>

</asp:Content>
<asp:Content ID="ContentFicha" ContentPlaceHolderID="ContentPlaceHolderFicha" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label runat="server" ID="lblRut" Visible="false"></asp:Label>
            <!-- GRILLAS-->
            <div class="row container" style="padding-left: 30px; padding-top: 10px;">
                <div id="ScoreNotas" class="ScoreNotas">
                    <h5>Score notas por asignatura </h5>
                    <asp:GridView ID="grvNotas" runat="server" BackColor="#EFF4F8" GridLines="none" ShowHeaderWhenEmpty="True"
                        EmptyDataText="No se encontraron registros" Width="800px"
                        CssClass="table table-sm table-responsive table-bordered" Font-Size="12px">
                        <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </asp:GridView>
                    <!-- POP CLIENT SIDE -->
                    <asp:Button ID="ClientButton" runat="server" Text="Ver Detalle" CssClass="btn btn-sm btn-info" />
                    <asp:Panel ID="ModalPanel" runat="server" BackColor="White" CssClass="modal-content container-fluid border-info" Width="800px">
                        <div class="row pt-2" >
                            <div class="col-md-10">
                                <h5>Detalle de notas por asignatura </h5>
                            </div>
                            <div class="col-md-2 d-flex justify-content-end">
                                <asp:Button runat="server" ID="OKButton" Text="X" CssClass="btn btn-sm btn-hover" />
                            </div>
                        </div>

                        <div class="row" style="padding: 20px; padding-top: 5px;">
                            <div id="DetalleNotas" style="overflow: auto; width: 100%" class="ScoreNotas">
                                <asp:GridView ID="grvDetalleNotas" runat="server" BackColor="#eff4f8" GridLines="None" BorderStyle="None" ShowHeaderWhenEmpty="True"
                                    EmptyDataText="No se encontraron registros" Width="800px"
                                    CssClass="table table-sm table-responsive table-bordered" Font-Size="12px">
                                    <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>


                        </div>

                    </asp:Panel>
                    <ajaxToolkit:ModalPopupExtender ID="mpe" BehaviorID="mpeID" runat="server" TargetControlID="ClientButton"
                        PopupControlID="ModalPanel" OkControlID="OKButton" />
                    <!-- FIN POP CLIENT-->
                    <!-- POP SERVER SIDE -->
                    <!--<asp:Button ID="ServerButton" runat="server" Text="Ver Detalle (Server)" OnClick="ServerButton_Click" />
                        <script runat="server">
                        protected void ServerButton_Click(object sender, EventArgs e)
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "key", "launchModal();", true);
                        }
                        </script>
                        <script type="text/javascript">
                            var launch = false;

                            function launchModal() {
                                launch = true;
                            }

                            function pageLoad() {
                                if (launch) {
                                    $find("mpeID").show();
                                }
                            }
                        </script>
                            -->
                    <!--FIN POP SERVER -->
                </div>
            </div>

            <div class="row container" style="padding-left: 30px; padding-top: 30px;">
                <div id="ScoreAsistencia" class="ScoreAsistencia">
                    <h5>Score asistencia por asignatura </h5>
                    <asp:GridView ID="grvAsistencia" runat="server" BackColor="#eff4f8" GridLines="None" ShowHeaderWhenEmpty="True"
                        EmptyDataText="No se encontraron registros" Width="100%"
                        CssClass="table table-sm table-responsive table-bordered" Font-Size="12px">
                        <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>

            <div class="row container" style="padding-left: 30px; padding-top: 30px;">
                <div id="ScoreFinanzas" class="ScoreFinanzas">
                    <h5>Score situación financiera </h5>
                    <asp:GridView ID="grvFinanzas" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True" GridLines="none"
                        EmptyDataText="No se encontraron registros" Width="100%" OnRowDataBound="grvFinanzas_RowDataBound"
                        CssClass="table table-sm table-responsive table-bordered" Font-Size="12px">
                        <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
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
