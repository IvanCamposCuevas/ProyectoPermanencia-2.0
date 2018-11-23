<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="CargarArchivos.aspx.cs" Inherits="ProyectoPermanencia.Presentacion.CargarArchivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 140px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderTitle" runat="server">
    <asp:Label runat="server">
        <h3 style="color:azure"> Cargar Archivos  </h3>
    </asp:Label>
</asp:Content>

<asp:Content ID="ContentCargar" ContentPlaceHolderID="ContentPlaceHolderCargar" runat="server">
    <div class="container">
       <style>
           .columna {
                float: left;
                padding: 15px;
            }
            .clearfix::after {
                content: "";
                clear: both;
                display: table;
            }
            .fecha {
                width: 50%;
            }
            .espacio{
                width: 25%;
            }
            .archivo {
                width: 25%;
            }
            thead th{
                background-color:lightgray;
            }
       </style>

        <div class="row jumbotron" style="background-color: white; border-radius: 2px; border-left: 5px solid rgb(252,173,24); border-right: 5px solid rgb(252,173,24); box-shadow: none;">
            <div class="row container" style="border:solid; border-color:red; height: 40px; padding-top:50px; padding-bottom:100px;"  >
                <div class="col-md-3" style="height: 50px;">
                    <h4>Seleccione el tipo de archivo a subir:</h4>
                </div>
               

                <div class="col-md-4" style="height: 50px;">
                    <asp:DropDownList ID="ddlTipoArchivo" CssClass="form-control" runat="server">
                        <asp:ListItem Value="0"> Seleccione </asp:ListItem>
                                <asp:ListItem Value="1"> Asistencia </asp:ListItem>
                                <asp:ListItem Value="2"> Notas </asp:ListItem>
                                <asp:ListItem Value="3"> Situación Financiera </asp:ListItem>
                                <asp:ListItem Value="4"> Indice Alumno </asp:ListItem>
                                <asp:ListItem Value="5"> Deserción </asp:ListItem>
                    </asp:DropDownList>
                    <asp:FileUpload runat="server" Width="350px" CssClass="form-control" ID="fuSubirArchivo" accept=".xls , .xlsx" />
                    <br />
                </div>
                <div class="col-md-2" style="height: 50px; padding-left: 60px">
                    <asp:Button ID="btnCargarAr" runat="server" Text="Cargar" CssClass="btn btn-danger" OnClick="btnCargarAr_Click" OnClientClick="return confirm('¿Desea cargar la informacion dentro del archivo?');" Height="47px" Width="126px"/>
                </div>
            </div>
            <div class="row container" style="margin:20px;display:inline-block">
                <br />
                <asp:Label ID="Label1" runat="server" ForeColor="Red" style="font-size:13px;" Text="* Solo se pueden ingresar archivos Excels, con extension .xls o .xlsx"></asp:Label>
                <br />
                
            </div>
            &nbsp;
            &nbsp;
            &nbsp;
            &nbsp;
            &nbsp;
           
                
                
            </div>
            &nbsp;
            &nbsp;
            &nbsp;
            &nbsp;
            &nbsp;
            <div id="columna fecha" class="col-5">
                     <!--<asp:Label ID="lblFecha" runat="server" Text="Fecha de la última carga: "></asp:Label>-->



             <div class="col-11">
                <h5>Últimas Cargas al Sistema</h5>
                <table class="table" >
                    
                    
                    <thead class="thead" >
                        <tr>
                            
                            <th scope="col">Tipo Archivo</th>
                            <th scope="col">Fecha Carga</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="tableRepeater" runat="server">
                    <ItemTemplate>
                    
                        <tr>
                            <td>
                                <asp:Label ID="lblTipoArchivoNotas" runat="server" Text='<%# Eval("Tipo_Archivo") %>' />
                            </td>
                            <td>
                                <asp:Label ID="lblFechaNotas" runat="server" Text='<%# Eval("Fecha_Carga") %>' />
                            </td>
                        </tr>

                    </ItemTemplate>
                    </asp:Repeater>
                    </tbody>
                </table>
            
                </div>

        </div>

            <div id="espacio" class="col-2"></div>
             <div id="clearfix" class="align-self-md-center" style="height:auto; width:auto; float:right" >
                 
                 <div id="columna archivo" style="float:right">
                     <table style="width: 100%;">
                     <tr>
                         <td colspan="2">
                             <p class="text-muted">Ver Archivos de ejemplo</p>
                         </td>  
                     </tr>
                     <tr>
                         <td class="auto-style1" style="width:200px">
                             &nbsp;&nbsp;&nbsp;&nbsp;
                             <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTipoArchivoEjemplo" >
                                <asp:ListItem Value="0"> Seleccione </asp:ListItem>
                                <asp:ListItem Value="1"> Asistencia </asp:ListItem>
                                <asp:ListItem Value="2"> Notas </asp:ListItem>
                                <asp:ListItem Value="3"> Situación Financiera </asp:ListItem>
                                <asp:ListItem Value="4"> Indice Alumno </asp:ListItem>
                                <asp:ListItem Value="5"> Deserción </asp:ListItem>
                            </asp:DropDownList>

                         &nbsp;&nbsp;&nbsp;&nbsp;

                         </td>
                         <td>
                             <asp:Button ID="btnArchivo" runat="server" Text="Descargar" CssClass="btn btn-secondary; text-info; float-left"  OnClick="btnArchivo_Click" />
                         </td>
                         
                     </tr>
                    
                 </table>
                 </div>
                 
                 
                
             </div>
                


    </div>



    
</asp:Content>
