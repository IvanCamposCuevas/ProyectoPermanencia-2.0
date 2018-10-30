<%@ Page Title="Estapas de Resolucion" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EtapasResolucion.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.EtapasResolucion" %>

<asp:Content ID="ContentHeadEtapas" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Etapas de Resolución  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentEtapasResolucion" ContentPlaceHolderID="ContentPlaceHolderEtapasResolucion" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="row jumbotron" style="margin-top: 0px; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px;">
                    <div class="col-md-4" style="padding: 2px">
                        <div class="card card-primary">
                            <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Buscar Caso</div>
                            <div class="card-body">
                                <div class="row container" style="margin-bottom: 10px;">
                                    <h5>Buscar por:</h5>
                                </div>
                                <div class="row container d-flex justify-content-center">
                                    <asp:DropDownList ID="ddlTipoBusqueda" runat="server" Width="130px" Height="30px" CssClass="form-control form-control-sm">
                                        <asp:ListItem Value="1" Text="Id Caso">Id Caso</asp:ListItem>
                                        <asp:ListItem Value="2" Text="Nombre Curso">Nombre Curso</asp:ListItem>
                                        <asp:ListItem Value="3" Text="Rut Alumno">Rut Alumno</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" CssClass="form-control" Width="140px" Height="30px" ID="txtIngresoBusqueda"></asp:TextBox>
                                </div>
                                <div class="row container d-flex justify-content-end">
                                    <asp:Button runat="server" Text="Buscar" ID="Button1" CssClass="btn btn-info btn-sm" OnClick="btnBuscarCasoSinFiltro_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="col-md-8 card-group" style="padding: 2px">
                        <div class="card card-primary">
                            <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Filtrar Casos</div>
                            <div class="card-body" style="padding-top: 10px; padding-left:0px">
                                <div class="d-flex container justify-content-center" style="padding-top: 0px; padding-bottom: 0px; font-size: small">
                                    <div class="col-md-3" style="">
                                        <h5>Tipo de Caso</h5>
                                        <div class="row d-flex justify-content-center" style="padding-top: 5px; padding-bottom: 0px">
                                            <asp:CheckBoxList runat="server" ID="ckblTipoCaso" CssClass="checkbox flex ">
                                                <asp:ListItem>Asistencia</asp:ListItem>
                                                <asp:ListItem>Finanzas</asp:ListItem>
                                                <asp:ListItem>Notas</asp:ListItem>
                                                <asp:ListItem>Otros</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>

                                    </div>
                                    <div class="col-md-4" style="">
                                        <h5>Tipo de Intervención</h5>
                                        <div class="d-flex justify-content-center" style="padding-top: 5px">
                                            <asp:CheckBoxList runat="server" ID="ckblTipoIntervención" CssClass="checkbox">
                                                <asp:ListItem>Correo</asp:ListItem>
                                                <asp:ListItem>Derivación</asp:ListItem>
                                                <asp:ListItem>Presencial</asp:ListItem>
                                                <asp:ListItem>Teléfono</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>

                                    </div>
                                    <div class="col-md-5" style="">
                                        <h5>Rango de fechas</h5>
                                        <div class="row container" style="padding:0px; padding-left:10px">
                                            <div class="col-md-6" style="padding-top: 3px; margin-left:20px">
                                                <asp:Label runat="server" CssClass="col-form-label-sm">Fecha Inicio:</asp:Label>
                                                <asp:Label runat="server" CssClass="col-form-label-sm">Fecha Término:</asp:Label>

                                            </div>
                                            <div class="col-md-5" style="padding-left: 0px">
                                                <input type="date" id="fechainicio" name="Fecha_Inicio" class="glyphicon-calendar" />
                                                <input type="date" id="fechatermino" name="Fecha_Termino" class="glyphicon-calendar" />

                                            </div>

                                        </div>
                                        <div class="row d-flex justify-content-end" style="margin-top:30px; margin-right:0px">
                                            <asp:Button runat="server" ID="btnFiltrar" Text="Filtrar" CssClass="btn btn-info" BorderStyle="Solid" OnClick="btnFiltrar_Click"></asp:Button>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <h3>Intervenciones</h3>
                <div class="row container-fluid" style="padding-right: 0px">
                    <div class="col-md-12 d-flex justify-content-end">
                        <!-- FALTA AGREGAR CANTIDAD DE CASOS A CADA BOTON -->
                        <asp:Button runat="server" ID="btnPendientes" Text="Pendientes" CssClass="btn btn-secondary" OnClick="btnPendientes_Click" />
                        <asp:Button runat="server" ID="btnEnCurso" Text="En Curso" CssClass="btn btn-secondary" OnClick="btnEnCurso_Click" />
                        <asp:Button runat="server" ID="btnFinalizadas" Text="Finalizadas" CssClass="btn btn-secondary" OnClick="btnFinalizadas_Click" />
                    </div>
                    <div class="col-md-12 d-flex justify-content-center" style="margin: 0px; width:1200px">
                        <div id="ScoreGlobal" class="ScoreGlobal">
                            <asp:GridView ID="grvIntervenciones" HorizontalAlign="Center" GridLines="none" HeaderStyle-Width="1200px" 
                                CssClass="col-md-12 table table-hover table-hover table-condensed table-responsive"
                                Font-Size="12px" runat="server" ShowHeaderWhenEmpty="True" EmptyDataText="No se encontraron registros" 
                                OnRowDataBound="grvIntervenciones_RowDataBound" OnSelectedIndexChanged="grvIntervenciones_SelectedIndexChanged">
                                <HeaderStyle BackColor="#092845" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"/>
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" ItemStyle-Width="200px" ItemStyle-Wrap="true" ButtonType="Button" ControlStyle-CssClass="btn btn-info btn-sm" SelectText="Ver detalle">
                                        <ItemStyle Wrap="True" Width="100px"></ItemStyle>
                                    </asp:CommandField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
