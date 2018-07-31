<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalleCaso.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.Pages.DetalleCaso" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Detalle Caso  </h3>
    </asp:Label>
</asp:Content>
<asp:Content ID="ContentDetalleCaso" ContentPlaceHolderID="ContentPlaceHolderDetalleCaso" runat="server">
    <div class="container" style="font-size: small">
        <div class="row jumbotron" style="border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none; padding: 0px; margin-bottom: 0px;">
            <div class="container" style="padding: 5px">
                <div class="card card-primary">
                    <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Información del Alumno</div>
                    <div class="row card-body" style="padding-left: 100px">
                        <div class="col-md-4">
                            <asp:Label runat="server" Font-Bold="true">Rut:</asp:Label>
                            <asp:Label ID="lblRut" runat="server"></asp:Label>

                            <br />
                            <asp:Label runat="server" Font-Bold="true">Nombre:</asp:Label>
                            <asp:Label ID="lblNombre" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Carrera:</asp:Label>
                            <asp:Label ID="lblCarrera" runat="server"></asp:Label>
                            <br />
                        </div>
                        <div class="col-md-4">
                            <asp:Label runat="server" Font-Bold="true">Escuela:</asp:Label>
                            <asp:Label ID="lblEscuela" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Jornada:</asp:Label>
                            <asp:Label ID="lblJornada" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Sede:</asp:Label>
                            <asp:Label ID="lblSede" runat="server"></asp:Label>
                            <br />
                        </div>
                        <div class="col-md-4" style="border-left-style: solid; border-left-width: 1px; border-left-color: rgb(7, 47, 115);">
                            <asp:Label runat="server" Font-Bold="true">_  Contacto</asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Telefono:</asp:Label>
                            <asp:Label ID="lblTelefono" runat="server"></asp:Label>
                            <br />
                            <asp:Label runat="server" Font-Bold="true">Correo:</asp:Label>
                            <asp:Label ID="lblMail" runat="server"></asp:Label>
                            <br />
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row jumbotron detCasoContainer" style="padding: 0px">
            <div class="container" style="padding: 5px; padding-top: 0px">
                <div class="card card-primary">
                    <div id="cardDetalle" class="card card-primary ">
                        <div class="card-header" style="background-color: rgb(1,40,69); color: white;">Detalles del Caso</div>
                        <div class="card card-body ">
                            <div class="row align-content-center infocasoContainer">

                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Id:</asp:Label>
                                    <asp:Label ID="lblIdCaso" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Tipo:</asp:Label>
                                    <asp:Label ID="lblTipoCaso" runat="server"></asp:Label><br />
                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Curso:</asp:Label>
                                    <asp:Label ID="lblCurso" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-3">
                                    <asp:Label runat="server" Font-Bold="true">Estado:</asp:Label>
                                    <asp:Label ID="lblEstado" runat="server"></asp:Label>
                                </div>
                            </div>
                            <div class="row container detInterContainer">
                                intento de DataList para traer la información de las interacciones con el formato de abajo para cada una
                                <asp:DataList ID="dlInteracciones" runat="server" RepeatDirection="Horizontal">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Font-Bold="true">Tipo de Intervención:</asp:Label>
                                        <asp:Label ID="lblTipoIntervencion" runat="server">blablablablabla</asp:Label><br />

                                        <asp:Label runat="server" Font-Bold="true">Participa:</asp:Label>
                                        <asp:Label ID="lblParticipa" runat="server">blablablabla, blablablabla</asp:Label><br />


                                        <asp:Label runat="server" Font-Bold="true">Area de derivación:</asp:Label>
                                        <asp:Label ID="lblAreaDeriv" runat="server">blablablablabla</asp:Label><br />

                                        <asp:Label runat="server" Font-Bold="true">Fecha:</asp:Label>
                                        <asp:Label ID="lblFecha" runat="server">12/02/2018</asp:Label><br />


                                        <asp:Label runat="server" Font-Bold="true">Comentarios:</asp:Label><br />
                                        <asp:TextBox runat="server" ID="tbComentarios" TextMode="MultiLine" Width="100%"></asp:TextBox>

                                        <asp:Button runat="server" ID="btnEditar" Text="Editar" CssClass="btn btn-warning btn-sm" />

                                    </ItemTemplate>



                                </asp:DataList>

                                <div class="col-md-8" style="padding-left: 20px">
                                    <div class="row">
                                    </div>
                                    <div class="row d-flex flex-row-reverse" style="margin-top: 5px">
                                    </div>
                                </div>

                            </div>

                            <div class="row container detInterContainer">
                                <asp:GridView ID="grvDetInteracciones" runat="server" BackColor="#EFF4F8" ShowHeaderWhenEmpty="True" Width="800px" Font-Size="15px"
                                    CssClass=" table table-bordered bs-table table-sm table-responsive" HorizontalAlign="Right" AutoGenerateColumns="false"
                                    EmptyDataText="No se han registrado interacciones para este caso" >
                                    <Columns>
                                        <asp:BoundField Visible="true" DataField="Id" HeaderText="Id" />
                                        <asp:BoundField DataField="Fecha Inicio" HeaderText="Fecha Inicio" />
                                        <asp:BoundField DataField="Tipo de Caso" HeaderText="Tipo de Caso" />
                                        <asp:BoundField DataField="Curso" HeaderText="Curso" />
                                        <asp:BoundField Visible="false" DataField="Id interaccion" HeaderText="Id interaccion" />
                                        <asp:BoundField DataField="Ultima Interaccion" HeaderText="Ultima Interaccion" />
                                        <asp:BoundField DataField="Estado del Caso" HeaderText="Estado del Caso" />
                                        <asp:BoundField DataField="Fecha Termino" HeaderText="Fecha Termino" />
                                        <asp:CommandField ButtonType="Button" ShowSelectButton="true" SelectText="Ver Detalle">
                                            <ControlStyle CssClass="btn btn-sm btn-success" />
                                        </asp:CommandField>
                                    </Columns>
                                    <HeaderStyle BackColor="#092845" Font-Bold="false" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                </asp:GridView>

                            </div>

                            <div class="row container detInterContainer">
                                <div class="col-md-4">
                                    <asp:Label runat="server" Font-Bold="true">Tipo de Intervención:</asp:Label>
                                    <asp:Label ID="lblTipoI" runat="server">blablablablabla</asp:Label><br />

                                    <asp:Label runat="server" Font-Bold="true">Participa:</asp:Label>
                                    <asp:Label ID="lblParti" runat="server">blablablabla, blablablabla</asp:Label><br />


                                    <asp:Label runat="server" Font-Bold="true">Area de derivación:</asp:Label>
                                    <asp:Label ID="lblArea" runat="server">blablablablabla</asp:Label><br />

                                    <asp:Label runat="server" Font-Bold="true">Fecha:</asp:Label>
                                    <asp:Label ID="lblFechaa" runat="server">12/02/2018</asp:Label><br />
                                </div>
                                <div class="col-md-8" style="padding-left: 20px">
                                    <div class="row">
                                        <asp:Label runat="server" Font-Bold="true">Comentarios:</asp:Label><br />
                                        <asp:TextBox runat="server" ID="TextBox1" TextMode="MultiLine" Width="100%"></asp:TextBox>

                                    </div>
                                    <div class="row d-flex flex-row-reverse" style="margin-top: 5px">
                                        <asp:Button runat="server" ID="btnEdd" Text="Editar" CssClass="btn btn-warning btn-sm" />

                                    </div>
                                </div>

                            </div>


                            <div class="row container" style="margin: 10px; padding: 20px; border-top-width: 2px; border-top-style: solid; border-color: rgb(1,40,69); justify-content: center;">
                                <div class="col-md-4 d-flex justify-content-start">
                                    <asp:Button runat="server" ID="btnVolver" Text="Volver" CssClass="btn btn-warning" OnClick="btnVolver_Click1" />

                                </div>
                                <div class="col-md-4 d-flex justify-content-center">
                                    <asp:Button runat="server" ID="btnAgregarInteraccion" Text="Agregar Interacción" CssClass="btn btn-success" />

                                </div>
                                <div class="col-md-4 d-flex justify-content-end">
                                    <asp:Button runat="server" ID="btnFinalizarCaso" Text="Finalizar Caso" CssClass="btn btn-danger" />

                                </div>


                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
