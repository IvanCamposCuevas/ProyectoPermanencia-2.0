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
                    <div class="col-md-4" style="padding: 5px">
                        <div class="card card-primary">
                            <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Buscar Caso</div>
                            <div class="card-body">
                                <div class="row container" style="margin-bottom: 10px;">
                                    <h5>Buscar por:</h5>
                                </div>
                                <div class="row container d-flex justify-content-center">
                                    <asp:DropDownList ID="ddlTipoBusqueda" runat="server" Width="140px" Height="30px" CssClass="form-control form-control-sm">
                                        <asp:ListItem Value="1" Text="Id Caso">Id Caso</asp:ListItem>
                                        <asp:ListItem Value="2" Text="Sigla Curso">Sigla Curso</asp:ListItem>
                                        <asp:ListItem Value="3" Text="Rut Alumno">Rut Alumno</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" CssClass="form-control" Width="150px" Height="30px" ID="txtIngresoBusqueda"></asp:TextBox>
                                </div>
                                <div class="row container d-flex justify-content-end">
                                    <asp:Button runat="server" Text="Buscar" ID="Button1" CssClass="btn btn-info btn-sm" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-8 card-group" style="padding: 5px">
                        <div class="card card-primary">
                            <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Filtrar Casos</div>
                            <div class="card-body">
                                <div class="d-flex container justify-content-center " style="padding-top: 0px;  font-size:small">
                                    <div class="col-md-3" style="height: 120px;">
                                        <h6>Tipo de Caso</h6>
                                        <asp:CheckBoxList runat="server" ID="ckblTipoCaso" CssClass="checkbox">
                                            <asp:ListItem>Asistencia</asp:ListItem>
                                            <asp:ListItem>Finanzas</asp:ListItem>
                                            <asp:ListItem>Notas</asp:ListItem>
                                            <asp:ListItem>Otros</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                    <div class="col-md-4" style="height: 120px;">
                                        <h6>Tipo de Intervención</h6>
                                        <asp:CheckBoxList runat="server" ID="ckblTipoIntervención" CssClass="checkbox">
                                            <asp:ListItem>Correo</asp:ListItem>
                                            <asp:ListItem>Derivación</asp:ListItem>
                                            <asp:ListItem>Presencial</asp:ListItem>
                                            <asp:ListItem>Telefono</asp:ListItem>
                                        </asp:CheckBoxList>
                                    </div>
                                    <div class="col-md-5" style="height: 100px;">
                                        <h6>Rango de fechas</h6>
                                        <asp:Label runat="server" Font-Bold="true">Fecha Inicio:</asp:Label>
                                        <input type="date" id="fechainicio" class="glyphicon-calendar" /></br>
                                        <asp:Label runat="server" Font-Bold="true">Fecha Termino:</asp:Label>
                                        <input type="date" id="fechatermino" class="glyphicon-calendar" />
                                    </div>
                                </div>

                                <div class="d-flex container justify-content-end" >
                                    <div style="float: right">
                                        <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" CssClass="btn btn-info" BorderStyle="Solid"></asp:Button>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h3>Intervenciones</h3>
                <div style="float: right; padding: 0px; margin: 0px;">
                    <asp:Button runat="server" ID="btnPendientes" Text="Pendientes" CssClass="btn btn-warning" />
                    <asp:Button runat="server" ID="btnEnCurso" Text="En Curso" CssClass="btn btn-success" />
                    <asp:Button runat="server" ID="btnFinalizadas" Text="Finalizadas" CssClass="btn btn-default" />
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
