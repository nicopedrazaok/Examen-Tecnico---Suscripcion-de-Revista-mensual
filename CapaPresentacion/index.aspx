<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CapaPresentacion.index" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Suscripcion de la revista mensual</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server" class="row g-3">
         
        <h2>Buscar Suscriptor</h2>
       <div class="col-md-6">
            <asp:Label ID="Label2" runat="server" Text="Tipo de Documento:"></asp:Label>         
            
            
                 <asp:DropDownList ID="dllTipoDocBuscar" runat="server" CssClass="form-select">
                 <asp:ListItem>Documento Unico</asp:ListItem>
                 <asp:ListItem>Pasaporte</asp:ListItem>
                 <asp:ListItem>Libreta Civica</asp:ListItem>
                 </asp:DropDownList>
                    
       </div>
        <div class="col-md-6">
            <asp:Label ID="Label3" runat="server" Text="Numero de documento: "></asp:Label>    
            <asp:TextBox ID="txtNroDocBuscar" runat="server" CssClass="form-control"></asp:TextBox>
             <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" Css="btn btn-success"/>
        </div>
        
            <h2>Datos del Suscriptor</h2>
            
        
       <asp:TextBox runat="server" ID="txtIdSuscriptor" Visible="false" TextMode="Number"></asp:TextBox>
         <div class="col-md-6">
             <asp:Label ID="lblNombre" runat="server" Text="Nombre: " CssClass="form-label"></asp:Label>
             
             <asp:TextBox ID="txtNombre" runat="server"  CssClass="form-control"></asp:TextBox>    
         </div>
        <div class="col-md-6">
             <asp:Label ID="lblApellido" runat="server" Text="Apellido: " CssClass="form-label"></asp:Label>
             
             <asp:TextBox ID="txtApellido" runat="server"  CssClass="form-control"></asp:TextBox>
              
         </div>
        <div class="col-md-6">
             <asp:Label ID="lblNroDocumento" runat="server" Text="Numero de Documento: " CssClass="form-label"></asp:Label>
             
             <asp:TextBox ID="txtNumeroDocumento" runat="server"  CssClass="form-control"></asp:TextBox>
              
         </div>
         <div class="col-md-6">
             <asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo de Documento: " CssClass="form-label"></asp:Label>
             
               <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-select">
                 <asp:ListItem>Documento Unico</asp:ListItem>
                 <asp:ListItem>Pasaporte</asp:ListItem>
                 <asp:ListItem>Libreta Civica</asp:ListItem>
                 </asp:DropDownList>
              
         </div>
        <div class="col-md-6">
             <asp:Label ID="lblDireccion" runat="server" Text="Direccion: " CssClass ="form-label"></asp:Label>
           
             <asp:TextBox ID="txtDireccion" runat="server"  CssClass="form-control"></asp:TextBox>
              
         </div>
        <div class="col-md-6">
             <asp:Label ID="lblTelefono" runat="server" Text="Telefono: " CssClass="form-label"></asp:Label>
            
             <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>       
       </div>
       <div class="col-12">
             <asp:Label ID="lblEmail" runat="server" Text="Email: " CssClass="form-label"></asp:Label>
             
             <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
             
       </div>
        <div class="col-md-6">
             <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario: " CssClass="form-label"></asp:Label>
             
             <asp:TextBox ID="txtNombreUsuario" runat="server"  CssClass="form-control"></asp:TextBox>
              
         </div>
        <div class="col-md-6">
             <asp:Label ID="lblPassword" runat="server" Text="Password: " CssClass="form-label"></asp:Label>
                 
             <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>  
         </div>
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Click="btnAceptar_Click" OnClick="btnAceptar_Click1" OnClientClick="return confirm('Deseas dar de alta la suscripcion ?');" CssClass=" btn btn-success"/>
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" CssClass="btn btn-primary" />
            <asp:Button ID="Modificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass=" btn btn-info" />
        </div>
    </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta1/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>
