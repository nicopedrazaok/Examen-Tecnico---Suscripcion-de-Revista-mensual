using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaDatos;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CapaPresentacion
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
        }
        private Suscriptor getEntity()
        {
            Suscriptor suscriptor = new Suscriptor();
            
            suscriptor.Nombre = txtNombre.Text;
            suscriptor.Apellido = txtApellido.Text;
            suscriptor.NumeroDocumento = txtNumeroDocumento.Text;
            suscriptor.TipoDocumento = ddlTipoDocumento.Text;
            suscriptor.Direccion = txtDireccion.Text;
            suscriptor.Telefono = txtTelefono.Text;
            suscriptor.Email = txtEmail.Text;
            suscriptor.NombreUsuario = txtNombreUsuario.Text;
            suscriptor.Password = txtPassword.Text;
            return suscriptor;
            
        }

        private void limpiarCampos()
        {

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNumeroDocumento.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtNombreUsuario.Text = "";
            txtPassword.Text = "";

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Suscriptor suscriptor = getEntity();
            Suscriptor suscriptor1 = DSuscriptor.buscarSuscriptor(txtNroDocBuscar.Text, dllTipoDocBuscar.Text);
            Suscriptor suscriptor2 = DSuscriptor.buscarSuscriptorNoVigente(txtNroDocBuscar.Text, dllTipoDocBuscar.Text);
            txtNumeroDocumento.Enabled = false;
            ddlTipoDocumento.Enabled = false;
            txtNombreUsuario.Enabled = false;
            if (suscriptor1 != null)
            {
                txtIdSuscriptor.Text = suscriptor1.IdSuscriptor.ToString();
                txtNombre.Text = suscriptor1.Nombre;
                txtApellido.Text = suscriptor1.Apellido;
                txtNumeroDocumento.Text = suscriptor1.NumeroDocumento;
                ddlTipoDocumento.Text = suscriptor1.TipoDocumento;
                txtDireccion.Text = suscriptor1.Direccion;
                txtTelefono.Text = suscriptor1.Telefono;
                txtEmail.Text = suscriptor1.Email;
                txtNombreUsuario.Text = suscriptor1.NombreUsuario;
                txtPassword.Text = suscriptor1.Password;


               
            }
            else if (suscriptor2 != null)
            {
                Response.Write("<script>alert('Suscriptor nunca estuvo vigente,  o se dio de baja')</script>");
            }
                
               
           
        }

        protected void btnAceptar_Click1(object sender, EventArgs e)
        {
           
            Suscriptor suscriptor = getEntity();
           
            string nroDoc = suscriptor.NumeroDocumento = txtNumeroDocumento.Text;
           string tipoDoc = suscriptor.TipoDocumento = ddlTipoDocumento.Text;
          
            int idSuscriptor = DSuscripcion.idSuscriptor(nroDoc, tipoDoc);

           
            bool vigente = DSuscripcion.buscarSuscriptorVigente(nroDoc, tipoDoc);
            if (vigente == false)
            {
                Response.Write("<script>alert('No tiene suscripcion vigente')</script>");
                Response.Write("<script>OnClientClick = return confirm ('¿ Desas poner vingente este suscriptor ?')</script>");
                bool respuesta = DSuscripcion.insertarSuscripcion(idSuscriptor);
                    if (respuesta == true)
                    {
                        Response.Write("<script>alert('SE REGISTRO CORRECTAMENTE')</script>");
                       limpiarCampos();
                    }
                    else
                    {
                        Response.Write("<script>alert('NO SE PUDO REGISTRAR')</script>");
                    }
            }else if (vigente == true)
            {
                Response.Write("<script>alert('El suscriptor ya esta vigente')</script>");
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Suscriptor suscriptor = getEntity();
            
            string nroDoc = suscriptor.NumeroDocumento = txtNumeroDocumento.Text;
            string tipoDoc = suscriptor.TipoDocumento = ddlTipoDocumento.Text;
            string nombreUsuario = suscriptor.NombreUsuario = txtNombreUsuario.Text;
            bool validarNroyTipoDoc = DSuscriptor.validarNroyTipoDoc(nroDoc, tipoDoc);
            bool validarNombreUsuario = DSuscriptor.validarNombreUsuario(nombreUsuario);
            if(validarNroyTipoDoc == true)
            {
                Response.Write("<script>alert('Ya hay un suscriptor registrado con el mismo Numero y tipo de Documento')</script>");
            }else if(validarNroyTipoDoc == false && validarNombreUsuario == true)
            {
                Response.Write("<script>alert('Ya esta registado ese nombre de usuario')</script>");
            }else if(validarNroyTipoDoc == false && validarNombreUsuario == false)
            { 
                 bool respuesta = DSuscriptor.insertarSuscripto(suscriptor);
                   if (respuesta == true)
                   {
                        Response.Write("<script>alert('SE REGISTRO CORRECTAMENTE')</script>");
                        limpiarCampos();
                    }
                    else
                    {
                        Response.Write("<script>alert('NO SE PUDO REGISTRAR')</script>");
                    }
            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Suscriptor suscriptor = getEntity();
            
            if (!txtNombre.Text.Equals("") || !txtApellido.Text.Equals("") || !txtNumeroDocumento.Text.Equals("") || !ddlTipoDocumento.Text.Equals("") 
             || !txtDireccion.Text.Equals("") || !txtTelefono.Text.Equals("") || !txtEmail.Text.Equals("") || !txtNombreUsuario.Text.Equals("") || !txtPassword.Text.Equals(""))
            {
                bool respuesta = DSuscriptor.actualizarSuscripto(suscriptor, Convert.ToInt32(this.txtIdSuscriptor.Text));
                if (respuesta == true)
                {
                    Response.Write("<script>alert('SE ACTUALIZO CORRECTAMENTE')</script>");
                    limpiarCampos();
                }
                else
                {
                    Response.Write("<script>alert('NO SE PUDO ACTUALIZAR')</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('REVISE HAY CAMPOS VACIOS')</script>");
            }
         
        }
    }
}