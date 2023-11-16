namespace Abonados_betis2
{
    public partial class Form1 : Form
    {
        List<Abonados> Socio;
        int posicion = 0;

        public Form1()
        {
            InitializeComponent();
            Socio = new List<Abonados>();

            MostrarSiguienteElemento();
        }

        public void MostrarSiguienteElemento()
        {
            if (posicion < Socio.Count)
            {
                txtNum.Text = Socio[posicion].numeroSocio.ToString();
                txtNombre.Text = Socio[posicion].nombreSocio;
                txtApellido.Text = Socio[posicion].apellidoSocio;
                txtEdad.Text = Socio[posicion].edadSocio.ToString();
                txtGrada.Text = Socio[posicion].gradaSocio.ToString();
                ckRealizoElPago.Checked = Socio[posicion].pagoSocio;
                txtImagen.Text = Socio[posicion].rutaImagenSocio.ToString();
                posicion++;
            }

        }

        public void TxtBlancos()
        {
            txtNum.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtGrada.Text = "";
            txtPago.Text = "";
            txtImagen.Text = "";
            ckRealizoElPago.Checked = false;
        }

        public void MostrarActual()
        {
            txtNum.Text = Socio[posicion].numeroSocio.ToString();
            txtNombre.Text = Socio[posicion].nombreSocio;
            txtApellido.Text = Socio[posicion].apellidoSocio;
            txtEdad.Text = Socio[posicion].edadSocio.ToString();
            txtGrada.Text = Socio[posicion].gradaSocio.ToString();
            txtPago.Text = Socio[posicion].costoSocio.ToString();
            ckRealizoElPago.Checked = Socio[posicion].pagoSocio;
            txtImagen.Text = Socio[posicion].rutaImagenSocio.ToString();
        }

        private void butCrear_Click(object sender, EventArgs e)
        {
            TxtBlancos();
        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            Abonados abonados = new Abonados();

            Socio.Remove(abonados);
        }

        private void butSiguiente_Click(object sender, EventArgs e)
        {
            MostrarSiguienteElemento();
        }

        private void butConfirmar_Click(object sender, EventArgs e)
        {
            Abonados abonados = new Abonados();
            abonados.numeroSocio = int.Parse(txtNum.Text);
            abonados.nombreSocio = txtNombre.Text;
            abonados.apellidoSocio = txtApellido.Text;
            abonados.edadSocio = int.Parse(txtEdad.Text);
            abonados.gradaSocio = char.Parse(txtGrada.Text);
            abonados.costoSocio = float.Parse(txtPago.Text);
            abonados.pagoSocio = ckRealizoElPago.Checked;
            abonados.rutaImagenSocio = txtImagen.Text;

            Socio.Add(abonados);
            MostrarActual();
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            MostrarActual();
        }

        private void butAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                txtNum.Text = Socio[posicion-1].numeroSocio.ToString();
                txtNombre.Text = Socio[posicion-1].nombreSocio;
                txtApellido.Text = Socio[posicion-1].apellidoSocio;
                txtEdad.Text = Socio[posicion-1].edadSocio.ToString();
                txtGrada.Text = Socio[posicion-1].gradaSocio.ToString();
                ckRealizoElPago.Checked = Socio[posicion-1].pagoSocio;
                txtImagen.Text = Socio[posicion-1].rutaImagenSocio.ToString();
                posicion--;
            }
        }
    }
}