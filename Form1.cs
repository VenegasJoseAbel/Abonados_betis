namespace Abonados_betis2
{
    public partial class Form1 : Form
    {
        List<Abonados> Socio; //declaro una lista que guardara los registros.
        int posicion = 0; //declaro un entero para recorrer la lista.


        public Form1()
        {
            InitializeComponent();
            Socio = new List<Abonados>();
            leerFichero(); //llamo al metodo para leer.
            comprobarbotones(); //llamo a un metodo para activar/desactivar los botones anterior y siguiente.
        }

        public void MostrarSiguienteElemento()
        {
            if (posicion < Socio.Count - 1) //siempre que la posicion sea menor al tamaño actualiza los valores a mostrar.
            {
                txtNum.Text = Socio[posicion + 1].numeroSocio.ToString();
                txtNombre.Text = Socio[posicion + 1].nombreSocio;
                txtApellido.Text = Socio[posicion + 1].apellidoSocio;
                txtEdad.Text = Socio[posicion + 1].edadSocio.ToString();
                txtGrada.Text = Socio[posicion + 1].gradaSocio.ToString();
                txtPago.Text = Socio[posicion + 1].costoSocio.ToString();
                ckRealizoElPago.Checked = Socio[posicion + 1].pagoSocio;
                txtImagen.Text = Socio[posicion + 1].rutaImagenSocio.ToString();
                posicion++;
                cargarImagen(); //llamo a un metodo para cargar la imagen de este registro.
                comprobarbotones(); //llamo a un metodo para activar/desactivar los botones anterior y siguiente.
            }
        }

        public void TxtBlancos() //actualizo todos los objetos del mi formilario para pornerlo en blanco.
        {
            txtNum.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtGrada.Text = "";
            txtPago.Text = "";
            txtImagen.Text = "";
            imagen.Image = null;
            ckRealizoElPago.Checked = false;
        }

        public void MostrarActual() //muestro el elemento en el que se encuentre mi Lista.
        {
            txtNum.Text = Socio[posicion].numeroSocio.ToString();
            txtNombre.Text = Socio[posicion].nombreSocio;
            txtApellido.Text = Socio[posicion].apellidoSocio;
            txtEdad.Text = Socio[posicion].edadSocio.ToString();
            txtGrada.Text = Socio[posicion].gradaSocio.ToString();
            txtPago.Text = Socio[posicion].costoSocio.ToString();
            ckRealizoElPago.Checked = Socio[posicion].pagoSocio;
            txtImagen.Text = Socio[posicion].rutaImagenSocio.ToString();
            cargarImagen(); //llamo a un metodo para cargar la imagen de este registro.
            comprobarbotones(); //llamo a un metodo para activar/desactivar los botones anterior y siguiente.
        }

        private void butCrear_Click(object sender, EventArgs e) //Cuando se hace click en el boton.
        {
            TxtBlancos(); //llamo al metodo para dejar todos los elemtos vacios.
            lblNumeroTotalSocio.Text = Socio.Count.ToString(); //Actualizo el contador al numero de registros que haya.
        }

        private void butEliminar_Click(object sender, EventArgs e)
        {
            Socio.Remove(Socio[posicion]); //Elimino el que se esta mostrando actualmente.
            lblNumeroTotalSocio.Text = Socio.Count.ToString(); //Actualizo el contador al numero de registros que haya.
            if (Socio.Count > 0 && posicion > 0) //Si mi lista tiene mas de 0 registros y no esta en la primera posicion.
            {
                posicion--; //Muevo la posicion uno atras.
                MostrarActual(); //LLamo al metodo para actualizar los valores al actual.
                butEliminar.Enabled = true; //Activo el boton.
            }
            else
            {
                if (posicion == 0 && Socio.Count > 0) //sai esta en la primear posicion y no es el unico en mi lista.
                {
                    MostrarActual(); //Muestro el actual.
                    butEliminar.Enabled = true; //Activo el boton.
                }
                else //Por el contrario si es el ultimo registro exixtente.
                {
                    butModificar.Enabled = false; //Desactivo el boton modificar (ya que no hay mas registros).
                    butEliminar.Enabled = false; //Desactivo el boton eliminar.
                    TxtBlancos(); //llamo al metodo para dejar todos los elemtos vacios.
                }
            }

            comprobarbotones(); //llamo a un metodo para activar/desactivar los botones anterior y siguiente.
        }

        private void butSiguiente_Click(object sender, EventArgs e)
        {
            MostrarSiguienteElemento(); //Llamo al metodo para mostrar el siguiente elemento de mi lista.
            lblNumeroTotalSocio.Text = Socio.Count.ToString(); //Actualizo el contador al numero de registros que haya.
        }

        private void butConfirmar_Click(object sender, EventArgs e) //Este boton lo uso para crear el nuevo registro.
        {
            butModificar.Enabled = true; //Activo el boton de modificar (ya que añado un nuevo reguistro)
            butEliminar.Enabled = true;  //Activo el boton de eliminar (ya que añado un nuevo reguistro)
            Abonados abonados = new Abonados(); //creo y le doy los valores necesarios que se leen de los TextBox
            abonados.numeroSocio = int.Parse(txtNum.Text);
            abonados.nombreSocio = txtNombre.Text;
            abonados.apellidoSocio = txtApellido.Text;
            abonados.edadSocio = int.Parse(txtEdad.Text);
            abonados.gradaSocio = char.Parse(txtGrada.Text);
            abonados.costoSocio = float.Parse(txtPago.Text);
            abonados.pagoSocio = ckRealizoElPago.Checked;
            abonados.rutaImagenSocio = txtImagen.Text;
            abonados.imagenSocio = imageToByteArray(Image.FromFile(txtImagen.Text));

            Socio.Add(abonados); //Añado mi nuevo registro.
            MostrarActual(); //Muestro el actual.
            lblNumeroTotalSocio.Text = Socio.Count.ToString(); //Actualizo el contador al numero de registros que haya.
        }

        private void butCancelar_Click(object sender, EventArgs e)
        {
            MostrarActual(); //Muestro el actual.
            lblNumeroTotalSocio.Text = Socio.Count.ToString();//Actualizo el contador al numero de registros que haya.
        }

        private void butAnterior_Click(object sender, EventArgs e)
        {
            if (posicion > 0) //siempre que la posicion sea mayor que 0 actualiza los valores a mostrar.
            {
                txtNum.Text = Socio[posicion - 1].numeroSocio.ToString();
                txtNombre.Text = Socio[posicion - 1].nombreSocio;
                txtApellido.Text = Socio[posicion - 1].apellidoSocio;
                txtEdad.Text = Socio[posicion - 1].edadSocio.ToString();
                txtGrada.Text = Socio[posicion - 1].gradaSocio.ToString();
                txtPago.Text = Socio[posicion - 1].costoSocio.ToString();
                ckRealizoElPago.Checked = Socio[posicion - 1].pagoSocio;
                txtImagen.Text = Socio[posicion - 1].rutaImagenSocio.ToString();
                posicion--;
                cargarImagen(); //llamo a un metodo para cargar la imagen de este registro.
                comprobarbotones(); //llamo a un metodo para activar/desactivar los botones anterior y siguiente.
            }
            lblNumeroTotalSocio.Text = Socio.Count.ToString(); //Actualizo el contador al numero de registros que haya.
        }

        private void butCargarImg_Click(object sender, EventArgs e)
        {
            cargarImagen(); //llamo a un metodo para cargar la imagen de este registro.
        }

        private void butModificar_Click(object sender, EventArgs e) //Modifico el registro actual.
        {   
            Socio[posicion].numeroSocio = int.Parse(txtNum.Text);
            Socio[posicion].nombreSocio = txtNombre.Text;
            Socio[posicion].apellidoSocio = txtApellido.Text;
            Socio[posicion].edadSocio = int.Parse(txtEdad.Text);
            Socio[posicion].gradaSocio = char.Parse(txtGrada.Text);
            Socio[posicion].costoSocio = float.Parse(txtPago.Text);
            Socio[posicion].pagoSocio = ckRealizoElPago.Checked;
            Socio[posicion].rutaImagenSocio = txtImagen.Text;
            Socio[posicion].imagenSocio = imageToByteArray(Image.FromFile(txtImagen.Text));
            cargarImagen(); //llamo a un metodo para cargar la imagen de este registro.
            MostrarActual(); //llamo a un metodo para activar/desactivar los botones anterior y siguiente.
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn) //Se convierte una imagen a un Array de Byte.
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        public Image byteArrayToImage(byte[] byteArrayIn) //Se convierte una Array de Byte a una imagen.
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public void cargarImagen()
        {
            try
            {
                imagen.Image = (byteArrayToImage(Socio[posicion].imagenSocio)); //Convierto el Array de Byte y se muestra.
            }
            catch (Exception ex) { }
        }

        public void gardarEnFichero()
        {
            BinaryWriter fichero; //Se crea un fichero para escribir.
            try
            {
                fichero = new BinaryWriter(File.Open("databank.data", FileMode.Create)); //Abrimos el fichero si exite, sino lo crea. Si ya existe lo sobre escribe.
                fichero.Write(Socio.Count); //Guardo el numero de resgitros de mi lista.

                for (int i = 0; i < Socio.Count; i++) //Escribo en el fichero todo lo que vayas a usar.
                {
                    fichero.Write(Socio[i].numeroSocio);
                    fichero.Write(Socio[i].nombreSocio);
                    fichero.Write(Socio[i].apellidoSocio);
                    fichero.Write(Socio[i].edadSocio);
                    fichero.Write(Socio[i].gradaSocio);
                    fichero.Write(Socio[i].costoSocio);
                    fichero.Write(Socio[i].pagoSocio);
                    fichero.Write(Socio[i].rutaImagenSocio);
                    fichero.Write(Socio[i].tam); //guarda el tamaño de byte que tiene la imagen.
                    fichero.Write(Socio[i].imagenSocio);
                }

                fichero.Close(); //Cerramos el fichero.
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puedo guardar"); //Un mensaje en caso de error.
            }
        }

        public void leerFichero()
        {
            int NumeroSocioAux; //Declaro una variables auxiliares para leer el fichero.
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
                BinaryReader Fichero2; //Se crea un fichero para leer.
                Fichero2 = new BinaryReader(File.OpenRead("databank.data")); //Se abre el fichero para leer su contenido.
                int count = Fichero2.ReadInt32(); //leeo el numero total de registros guardados.
                lblNumeroTotalSocio.Text = count.ToString(); //Actualizo el contador al numero de registros que haya.
                for (int i = 0; i < count; i++) //Leemos los valores del fichero. Una vez termina creamos un abonado con las variables auxiliares.
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
                    ImagenSocioAux = Fichero2.ReadBytes(TamAux); //Leemos los bytes que me indica el tamaño.

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

                    Socio.Add(abonados); //Añado mi nuevo registro.
                    MostrarActual();  //Muestro el actual.
                }
                Fichero2.Close(); //Cierro el Fichero.
            }
            catch (Exception ex)
            {
                MessageBox.Show("No hay valores que leer en el fichero \no no se pudo abrir el fichero"); //Un mensaje en caso de error.
            }
        }

        private void butGuardar_Click(object sender, EventArgs e)
        {
            gardarEnFichero(); //llamo al metodo para guardar el fichero.
        }

        private void butCargar_Click(object sender, EventArgs e)
        {
            leerFichero(); //llamo al metodo para leer el fichero.
        }

        private void comprobarbotones()
        {
            if (posicion == 0) //Si es la primera posicion desactivo el boton atras.
            {
                butAnterior.Enabled = false;
            }
            else //Si no se activa.
            {
                butAnterior.Enabled = true;
            }
            if (posicion + 1 == Socio.Count) //Si la posicion +1 es igual al total de registros desactivo el boton siguiente.
            {
                butSiguiente.Enabled = false;
            }
            else //Si no se activa el boton
            {
                butSiguiente.Enabled = true;
            }
            if (Socio.Count == 0) //si solo hay un reguistro o ninguno, ambos botones se desactivan.
            {
                butAnterior.Enabled = false;
                butSiguiente.Enabled = false;
            }
        }

    }
}