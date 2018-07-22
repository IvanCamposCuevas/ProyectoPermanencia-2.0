<%@ Page Title="" Language="C#" MasterPageFile="~/FichaMaster.master" AutoEventWireup="true" CodeBehind="FichaAlumno.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.FichaAlumno" %>


<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure" > Ficha Alumno  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTabs" runat="server">
    <div class="container">
        <ul class="nav nav-tabs">
            <li class="nav-item">
                <a class="nav-link active" href="#">Ficha</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="/Pages/Historico.aspx">Historico</a>
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
                    <h3>Score notas por asignatura </h3>
                    <asp:GridView ID="grvNotas" runat="server" BackColor="#EFF4F8" ShowHeaderWhenEmpty="True"
                        EmptyDataText="No se encontraron registros" Width="800px"
                        CssClass="table table-sm table-bordered bs-table table-responsive " Font-Size="12px">
                        <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </asp:GridView>
                    <!-- POP CLIENT SIDE -->
                    <asp:Button ID="ClientButton" runat="server" Text="Ver Detalle" CssClass="btn btn-sm btn-info" />
                    <asp:Panel ID="ModalPanel" runat="server" BackColor="White" CssClass="modal-content container-fluid" Width="800px">
                        <div class="row" style="padding: 20px; padding-top: 5px;">
                            <h3 style="font-family: 'Open Sans',sans-serif">Detalle de notas por asignatura </h3>
                            <div id="DetalleNotas" style="overflow: auto; width: 100%" class="ScoreNotas">
                                <asp:GridView ID="grvDetalleNotas" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                                    EmptyDataText="No se encontraron registros" Width="800px"
                                    CssClass="table table-bordered bs-table table-sm table-responsive" Font-Size="12px">
                                    <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                            <asp:Button ID="OKButton" CssClass="btn btn-sm btn-info justify-content-center" Height="30px" runat="server" Text="Cerrar" />


                        </div>

                    </asp:Panel>
                    <ajaxToolkit:ModalPopupExtender ID="mpe" BehaviorID="mpeID" runat="server" TargetControlID="ClientButton"
                        PopupControlID="ModalPanel" OkControlID="OKButton" />
                    <asp:ScriptManager ID="asm" runat="server" />
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
                    <h3>Score asistencia por asignatura </h3>
                    <asp:GridView ID="grvAsistencia" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                        EmptyDataText="No se encontraron registros" Width="100%"
                        CssClass="table table-bordered bs-table table-sm table-responsive" Font-Size="12px">
                        <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                        <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                    </asp:GridView>
                </div>
            </div>

            <div class="row container" style="padding-left: 30px; padding-top: 30px;">
                <div id="ScoreFinanzas" class="ScoreFinanzas">
                    <h3>Score situación financiera </h3>
                    <asp:GridView ID="grvFinanzas" runat="server" BackColor="#eff4f8" ShowHeaderWhenEmpty="True"
                        EmptyDataText="No se encontraron registros" Width="100%" OnRowDataBound="grvFinanzas_RowDataBound"
                        CssClass="table table-bordered bs-table table-sm table-responsive" Font-Size="12px">
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
