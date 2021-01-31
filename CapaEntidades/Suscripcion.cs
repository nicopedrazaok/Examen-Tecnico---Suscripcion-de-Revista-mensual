using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Suscripcion
    {
        private int idAsociacion;
        private int idSuscriptor;
        private DateTime fechaAlta;
        private DateTime fechaFin;
        private string motivoFin;

        public Suscripcion(int idAsociacion, int idSuscriptor, DateTime fechaAlta, DateTime fechaFin, string motivoFin)
        {
            this.idAsociacion = idAsociacion;
            this.idSuscriptor = idSuscriptor;
            this.fechaAlta = fechaAlta;
            this.fechaFin = fechaFin;
            this.motivoFin = motivoFin;
        }
        public Suscripcion()
        {
          
        }
        public int IdAsociacion { get => idAsociacion; set => idAsociacion = value; }
        public int IdSuscriptor { get => idSuscriptor; set => idSuscriptor = value; }
        public DateTime FechaAlta { get => fechaAlta; set => fechaAlta = value; }
        public DateTime FechaFin { get => fechaFin; set => fechaFin = value; }
        public string MotivoFin { get => motivoFin; set => motivoFin = value; }
    }
}
