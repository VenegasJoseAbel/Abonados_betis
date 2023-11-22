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
            leerFichero();
        }

        public void MostrarSiguienteElemento()
        {
            if (posicion < Socio.Count - 1)
            {
                txtNum.Text = Socio[posicion + 1].numeroSocio.ToString();
                txtNombre.Text = Socio[posicion + 1].nombreSocio;
                txtApellido.Text = Socio[posicion + 1].apellidoSocio;
                txtEdad.Text = Socio[posicion + 1].edadSocio.ToString();
                txtGrada.Text = Socio[posicion + 1].gradaSocio.ToString();
                ckRealizoElPago.Checked = Socio[posicion + 1].pagoSocio;
                txtImagen.Text = Socio[posicion + 1].rutaImagenSocio.ToString();
                posicion++;
                cargarImagen();

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
            cargarImagen();
        }

        private void butCrear_Click(object sender, EventArgs e)
        {
            TxtBlancos();
            lblNumeroTotalSocio.Text = Socio.Count.ToString();
        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            Socio.Remove(Socio[posicion]);
        }

        private void butSiguiente_Click(object sender, EventArgs e)
        {
            MostrarSiguienteElemento();
        }

        private void butConfirmar_Click(object sender, EventArgs e)
        {
            lblNumeroTotalSocio.Text = Socio.Count.ToString();
            Abonados abonados = new Abonados();
            abonados.numeroSocio = int.Parse(txtNum.Text);
            abonados.nombreSocio = txtNombre.Text;
            abonados.apellidoSocio = txtApellido.Text;
            abonados.edadSocio = int.Parse(txtEdad.Text);
            abonados.gradaSocio = char.Parse(txtGrada.Text);
            abonados.costoSocio = float.Parse(txtPago.Text);
            abonados.pagoSocio = ckRealizoElPago.Checked;
            abonados.rutaImagenSocio = txtImagen.Text;
            abonados.imagenSocio = imageToByteArray(Image.FromFile(txtImagen.Text));

            Socio.Add(abonados);
            MostrarActual();
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            MostrarActual();
            lblNumeroTotalSocio.Text = Socio.Count.ToString();
        }

        private void butAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0)
            {
                txtNum.Text = Socio[posicion - 1].numeroSocio.ToString();
                txtNombre.Text = Socio[posicion - 1].nombreSocio;
                txtApellido.Text = Socio[posicion - 1].apellidoSocio;
                txtEdad.Text = Socio[posicion - 1].edadSocio.ToString();
                txtGrada.Text = Socio[posicion - 1].gradaSocio.ToString();
                ckRealizoElPago.Checked = Socio[posicion - 1].pagoSocio;
                txtImagen.Text = Socio[posicion - 1].rutaImagenSocio.ToString();
                posicion--;
                cargarImagen();

            }
        }

        private void butCargarImg_Click(object sender, EventArgs e)
        {
            cargarImagen();
        }

        private void butModificar_Click(object sender, EventArgs e)
        {
            Socio[posicion].numeroSocio = int.Parse(txtNum.Text);
            Socio[posicion].nombreSocio = txtNombre.Text;
            Socio[posicion].apellidoSocio = txtApellido.Text;
            Socio[posicion].edadSocio = int.Parse(txtEdad.Text);
            Socio[posicion].gradaSocio = char.Parse(txtGrada.Text);
            Socio[posicion].costoSocio = float.Parse(txtPago.Text);
            Socio[posicion].pagoSocio = ckRealizoElPago.Checked;
            Socio[posicion].rutaImagenSocio = txtImagen.Text;
            cargarImagen();
            MostrarActual();
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public void cargarImagen()
        {
            try
            {
                imagen.Image = (byteArrayToImage(Socio[posicion].imagenSocio));
            }
            catch (Exception ex) { }
        }

        public void gardarEnFichero()
        {
            BinaryWriter fichero;
            try
            {
                fichero = new BinaryWriter(File.Open("databank.data", FileMode.Create));
                fichero.Write(Socio.Count);

                for (int i = 0; i < Socio.Count; i++)
                {
                    fichero.Write(Socio[i].numeroSocio);
                    fichero.Write(Socio[i].nombreSocio);
                    fichero.Write(Socio[i].apellidoSocio);
                    fichero.Write(Socio[i].edadSocio);
                    fichero.Write(Socio[i].gradaSocio);
                    fichero.Write(Socio[i].costoSocio);
                    fichero.Write(Socio[i].pagoSocio);
                    fichero.Write(Socio[i].rutaImagenSocio);
                    fichero.Write(Socio[i].tam);
                    fichero.Write(Socio[i].imagenSocio);
                }

                fichero.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("no guarda");
            }
        }

        public void leerFichero()
        {
            int NumeroSocioAux;
            String NombreSocioAux;
            String ApellidoSocioAux;
            int EdadSocioAux;
            char GradaSocioAux;
            float CostoSocioAux;
            Boolean PagoSocioAux;
            String RutaImagenSocioAux;
            int TamAux;
            byte[] ImagenSocioAux;

            try
            {
                BinaryReader Fichero2;
                Fichero2 = new BinaryReader(File.OpenRead("databank.data"));
                int count = Fichero2.ReadInt32();
                lblNumeroTotalSocio.Text = count.ToString();
                for (int i = 0; i < count; i++)
                {
                    NumeroSocioAux = Fichero2.ReadInt32();
                    NombreSocioAux = Fichero2.ReadString();
                    ApellidoSocioAux = Fichero2.ReadString();
                    EdadSocioAux = Fichero2.ReadInt32();
                    GradaSocioAux = Fichero2.ReadChar();
                    CostoSocioAux = Fichero2.ReadSingle();
                    PagoSocioAux = Fichero2.ReadBoolean();
                    RutaImagenSocioAux = Fichero2.ReadString();
                    TamAux = Fichero2.ReadInt32();
                    ImagenSocioAux = Fichero2.ReadBytes(TamAux);

                    Abonados abonados = new Abonados();
                    abonados.numeroSocio = NumeroSocioAux;
                    abonados.nombreSocio = NombreSocioAux;
                    abonados.apellidoSocio = ApellidoSocioAux;
                    abonados.edadSocio = EdadSocioAux;
                    abonados.gradaSocio = GradaSocioAux;
                    abonados.costoSocio = CostoSocioAux;
                    abonados.pagoSocio = PagoSocioAux;
                    abonados.rutaImagenSocio = RutaImagenSocioAux;
                    abonados.imagenSocio = ImagenSocioAux;

                    Socio.Add(abonados);
                    MostrarActual();
                }
                Fichero2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mariano");
            }
        }

        private void butGuardar_Click(object sender, EventArgs e)
        {
            gardarEnFichero();
        }

        private void butCargar_Click(object sender, EventArgs e)
        {
            leerFichero();
        }
    }
}