using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Suscriptor
    {
        private int idSuscriptor;
        private string nombre;
        private string apellido;
        private string numeroDocumento;
        private string tipoDocumento;
        private string direccion;
        private string telefono;
        private string email;
        private string nombreUsuario;
        private string password;
        public Suscriptor(int idSuscriptor, string nombre, string apellido, string numeroDocumento, string tipoDocumento,
                              string direccion, string telefono, string email, string nombreUsuario, string password)
        {
            this.IdSuscriptor = idSuscriptor;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.NumeroDocumento = numeroDocumento;
            this.TipoDocumento = tipoDocumento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Email = email;
            this.NombreUsuario = nombreUsuario;
            this.Password = password;
        }
        public Suscriptor()
        {

        }
        public int IdSuscriptor { get => idSuscriptor; set => idSuscriptor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string NumeroDocumento { get => numeroDocumento; set => numeroDocumento = value; }
        public string TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Password { get => password; set => password = value; }

        
    }
}
