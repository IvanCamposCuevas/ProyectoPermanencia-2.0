<%@ Page Title="Estapas de Resolucion" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EtapasResolucion.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.EtapasResolucion" %>

<asp:Content ID="ContentHeadEtapas" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Etapas de Resolución  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentEtapasResolucion" ContentPlaceHolderID="ContentPlaceHolderEtapasResolucion" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row jumbotron" style="margin-top: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px;">
                    <div class="col-md-4 panel-group" style="padding-left: 0px;">
                        <div class="panel panel-primary">
                            <div class="panel-heading" style="background-color: rgb(1,40,69);">Buscar Caso</div>
                            <div class="panel-body">
                                <div class="row input-group center-block" style="margin-bottom: 20px; height: 120px;">
                                    <h4>Buscar Caso:</h4>
                                    <asp:DropDownList ID="ddlTipoBusqueda" runat="server" Width="138px" Height="30px" CssClass="form-control">
                                        <asp:ListItem Value="1" Text="Id Caso">Id Caso</asp:ListItem>
                                        <asp:ListItem Value="2" Text="Sigla Curso">Sigla Curso</asp:ListItem>
                                        <asp:ListItem Value="3" Text="Rut Alumno">Rut Alumno</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" CssClass="”form-control”" Width="115px" Height="30px" ID="txtIngresoBusqueda"></asp:TextBox>
                                    <asp:Button runat="server" Text="Buscar" ID="btnBuscarCasoSinFiltro" CssClass="btn btn-info" OnClick="btnBuscarCasoSinFiltro_Click" />
                                </div>
                                <div class="row" style="align-content: center; margin-bottom: 0px;">
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-8 panel-group" style="padding-right: 0px">
                        <div class="panel panel-primary">
                            <div class="panel-heading" style="background-color: rgb(1,40,69);">Filtrar Casos</div>
                            <div class="panel-body" style="padding-top: 0px;">
                                <div class="row center-block" style="padding-top: 0px;">
                                    <div class="col-md-3" style="height: 150px;">
                                        <h4>Tipo de Caso</h4>
                                        <asp:CheckBoxList runat="server" ID="ckblTipoCaso" CssClass="checkbox">
                                            <asp:ListItem>Asistencia</asp:ListItem>
                                            <asp:ListItem>Finanzas</asp:ListItem>
                                            <asp:ListItem>Notas</asp:ListItem>
                                            <asp:ListItem>Otros</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                    <div class="col-md-4" style="height: 150px;">
                                        <h4>Tipo de Intervención</h4>
                                        <asp:CheckBoxList runat="server" ID="ckblTipoIntervención" CssClass="checkbox">
                                            <asp:ListItem>Correo</asp:ListItem>
                                            <asp:ListItem>Derivación</asp:ListItem>
                                            <asp:ListItem>Presencial</asp:ListItem>
                                            <asp:ListItem>Telefono</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                    <div class="col-md-5" style="height: 100px;">
                                        <h4>Rango de fechas</h4>
                                        <asp:Label runat="server" Font-Bold="true">Fecha Inicio:</asp:Label>
                                        <input type="date" id="fechainicio" name="Fecha_Inicio" class="glyphicon-calendar"/>
                                        <asp:Label runat="server" Font-Bold="true">Fecha Termino:</asp:Label>
                                        <input type="date" id="fechatermino" name="Fecha_Termino" class="glyphicon-calendar" />

                                    </div>
                                    <div style="float: right">
                                        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" CssClass="btn btn-info" BorderStyle="Solid" OnClick="btnFiltrar_Click"></asp:Button>

                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h3>Intervenciones</h3>
                <div style="float: right; padding:0px; margin:0px;">
                    <asp:Button runat="server" ID="btnPendientes" Text="Pendientes" CssClass="btn btn-warning" OnClick="btnPendientes_Click" />
                    <asp:Button runat="server" ID="btnEnCurso" Text="En Curso" CssClass="btn btn-success" OnClick="btnEnCurso_Click" />
                    <asp:Button runat="server" ID="btnFinalizadas" Text="Finalizadas" CssClass="btn btn-default" OnClick="btnFinalizadas_Click" />
                </div>


                <div class="row" style="margin: 0px">
                    <div id="ScoreGlobal" class="ScoreGlobal">
                        <asp:GridView ID="grvIntervenciones" CssClass="col-md-12 table table-bordered bs-table table-hover table-condensed table-responsive"
                            Font-Size="12px" runat="server" BorderStyle="Solid" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros">
                            <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" />
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" ItemStyle-Width="200px" ItemStyle-Wrap="true" ButtonType="Button" ControlStyle-CssClass="btn btn-info btn-sm" SelectText="Ver detalle">
                                    <ItemStyle Wrap="True" Width="100px"></ItemStyle>
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
                


            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
