using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abonados_betis2
{
    public class Abonados
    {
        private int NumeroSocio;
        private String NombreSocio;
        private String ApellidoSocio;
        private int EdadSocio;
        private char GradaSocio;
        private float CostoSocio;
        private Boolean PagoSocio;
        private String RutaImagenSocio;
        private int Tam;
        private byte[] ImagenSocio;

        public int tam
        {
            get { return Tam; }
        }

        public byte[] imagenSocio
        {
            get
            {
                return ImagenSocio;
            }
            set
            {
                ImagenSocio = value;
                tamaño();
            }
        }

        public int numeroSocio
        {
            get
            {
                return NumeroSocio;
            }

            set
            {
                NumeroSocio = value;
            }
        }

        public String nombreSocio
        {
            get
            {
                return NombreSocio;
            }
            set
            {
                NombreSocio = value;
            }
        }

        public String apellidoSocio
        {
            get
            {
                return ApellidoSocio;
            }
            set
            {
                ApellidoSocio = value;
            }
        }

        public int edadSocio
        {
            get
            {
                return EdadSocio;
            }
            set
            {
                EdadSocio = value;
            }
        }

        public char gradaSocio
        {
            get
            {
                return GradaSocio;
            }
            set
            {
                GradaSocio = value;
            }
        }

        public float costoSocio
        {
            get
            {
                return CostoSocio;
            }
            set
            {
                CostoSocio = value;
            }
        }

        public Boolean pagoSocio
        {
            get
            {
                return PagoSocio;
            }
            set
            {
                PagoSocio = value;
            }
        }

        public String rutaImagenSocio
        {
             get
             {
                 return RutaImagenSocio;
             }
             set
             {
                     RutaImagenSocio = value;
             }
        }
        public void tamaño()
        {
            Tam = imagenSocio.Length;
        }
    }
}
