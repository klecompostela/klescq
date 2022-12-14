using INIconfig;
namespace PESModSelector
{
    public partial class PESSelector : Form
    {
        public PESSelector()
        {

            InitializeComponent();
            CenterToScreen();
            string sRuta = "";
            sRuta = Directory.GetCurrentDirectory() + "\\config.ini";
            CargaCombo(sRuta);
        }
        private void btSeleccionarINI_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogiAbrirFichero = new OpenFileDialog();
            dialogiAbrirFichero.InitialDirectory = Directory.GetCurrentDirectory();
            dialogiAbrirFichero.Filter = "Ficheros INI (*.ini)|*.ini|Todos los ficheros (*.*)|*.*";
            dialogiAbrirFichero.FilterIndex = 1;
            dialogiAbrirFichero.RestoreDirectory = true;
            dialogiAbrirFichero.CheckFileExists = false;

            if (dialogiAbrirFichero.ShowDialog() == DialogResult.OK)
                txtFicheroINI.Text = dialogiAbrirFichero.FileName;

            string sRuta = LeerINI("PES", "RUTA_INI");
            CargaCombo(sRuta);

            if (sRuta == "")
            {
                return;
            }

        }
        private void CargaCombo(string sRuta)
        {
            try
            {
                cbPesMod.Items.Clear();
                txtFicheroINI.Text = sRuta;
                sRuta = LeerINI("PES", "RUTA_INI");
                string sTOTAL_SAVES = LeerINI("PES", "TOTAL_SAVES");
                int i = 0;
                int iTOTAL_SAVES = int.Parse(sTOTAL_SAVES);
                while (i < iTOTAL_SAVES)
                {
                    string s = LeerINI("PES", "SAVE_" + i);
                    if (!string.IsNullOrEmpty(s))
                    {
                        cbPesMod.Items.Add(s);
                    }
                    i++;
                }
                lbPESActual.Text = lbPESActual.Text + " " + obtenerInfoPESActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando el combo." + Environment.NewLine + ex.Message);
                return;
            }

        }
        private string LeerINI(string seccion, string ruta)
        {
            string rutaFicheroINI = txtFicheroINI.Text;
            if (File.Exists(rutaFicheroINI))
            {
                INI fINI = new INI(rutaFicheroINI);
                return fINI.LeerINI(seccion, ruta);
            }
            return "";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbPesMod.SelectedItem == null)
                {
                    MessageBox.Show("No hay ning?n elemnto seleccionado.");
                    return;
                }

                if (string.IsNullOrEmpty(cbPesMod.SelectedItem.ToString()))
                {
                    MessageBox.Show("No hay ning?n elemnto seleccionado.");
                    return;
                }
                //RENOMBRAR LA QUE EXISTE
                string pesActual = obtenerInfoPESActual();

                if (pesActual == "")
                {
                    MessageBox.Show("No hay archivo Info.txt");
                    return;
                }

                string sRutaBAK = LeerINI("PES", "RUTA_MOD_BAK") + pesActual;
                string sRutaSave = LeerINI("PES", "RUTA_SAVE");
                //nombre de la carpeta,content/stadium-server
                string sRutaStadiumServer = LeerINI("PES", "RUTA_STADIUM_SERVER");
                string sRutaOrigenStadiumServer = string.Format(sRutaStadiumServer, pesActual);
                string sRutaDestinoStadiumServer = string.Format(sRutaStadiumServer, cbPesMod.SelectedItem.ToString());
                if (sRutaOrigenStadiumServer != sRutaDestinoStadiumServer)
                {
                    //MessageBox.Show(string.Format("Movemos de {0} a {1}",sRutaOrigenStadiumServer, sRutaDestinoStadiumServer));
                    Directory.Move(sRutaOrigenStadiumServer + "Classic", sRutaDestinoStadiumServer + "Classic");
                    Directory.Move(sRutaOrigenStadiumServer + "Galicia", sRutaDestinoStadiumServer + "Galicia");
                    Directory.Move(sRutaOrigenStadiumServer + "Others", sRutaDestinoStadiumServer + "Others");
                    Directory.Move(sRutaOrigenStadiumServer + "Spain", sRutaDestinoStadiumServer + "Spain");
                }
                else
                {
                    MessageBox.Show("El origen y el destino tiene que ser diferente");
                    return;
                }
                //DE LA RUTA SAVE a RUTA DEL MOD 
                if (Directory.Exists(sRutaBAK) == true)
                {
                    Directory.Delete(sRutaBAK);
                }
                //movemos el q est? en uso, a la ruta de la copia
                if (sRutaBAK != sRutaSave)
                {
                    Directory.Move(sRutaSave, sRutaBAK);
                    //MessageBox.Show(string.Format("Movemos de sRutaSave:{0} a sRutaBAK:{1}", sRutaSave, sRutaBAK));
                }
                //siempre es la misma ruta de destino.
                string sRutaDestino = LeerINI("PES", "RUTA_SAVE");
                string sRutaOrigenNuevoMOD = LeerINI("PES", "RUTA_MOD_BAK") + cbPesMod.SelectedItem.ToString();
                if (sRutaOrigenNuevoMOD != sRutaDestino)
                {
                    Directory.Move(sRutaOrigenNuevoMOD, sRutaDestino);
                    MessageBox.Show("SAVE actualizado a " + cbPesMod.SelectedItem.ToString());
                }
                else
                {
                    MessageBox.Show("El origen y el destino tiene que ser diferente");
                    return;
                }
                //MessageBox.Show(string.Format("Movemos de sRutaOrigenNuevoMOD:{0} a sRutaDestino:{1}", sRutaOrigenNuevoMOD, sRutaDestino));


            }
            catch (Exception ex)
            {
                throw new Exception("Error actualizando el SAVE." + ex.Message);
            }
            this.Close();
        }
        /// <summary>
        /// PES EN USO ACTUALMENTE: VAMOS A QUITARLO A SU CARPETA ORIGEN "INFO"
        /// </summary>
        /// <returns></returns>
        private string obtenerInfoPESActual()
        {
            try
            {
                int counter = 0;
                string sRutaInfo = LeerINI("PES", "RUTA_INFO");
                string pesEnUso = string.Empty;
                if (!File.Exists(sRutaInfo))
                {
                    return "";
                }

                foreach (string line in System.IO.File.ReadLines(sRutaInfo))
                {
                    pesEnUso = line;
                    //MessageBox.Show(line);
                    counter++;
                }
                return pesEnUso;
            }
            catch (Exception ex)
            {
                //return "eFootball PES 2021 SEASON UPDATE";
                throw new Exception("No hay PES en uso" + ex.Message);
            }


        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}