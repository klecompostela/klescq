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
                int i = 1;
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
                    MessageBox.Show("No hay ningún elemnto seleccionado.");
                    return;
                }

                if (string.IsNullOrEmpty(cbPesMod.SelectedItem.ToString()))
                {
                    MessageBox.Show("No hay ningún elemnto seleccionado.");
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
                //ya no se mueve el stadium server, se fijó en una carperta
                //bool error = moverStadiumServer(pesActual);
                //if (error){
                //    return;
                //}

                if (chkMoverStadiumServer.Checked)
                {
                    bool error = copiarConfigStadiumServer();
                    if (error)
                    {
                        return;
                    }
                }


                //DE LA RUTA SAVE a RUTA DEL MOD 
                if (Directory.Exists(sRutaBAK) == true)
                {
                    Directory.Delete(sRutaBAK);
                }
                //movemos el q está en uso, a la ruta de la copia
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
                    MessageBox.Show("SAVE actualizado a " + cbPesMod.SelectedItem.ToString() + "\nRevisa el exe.");
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

        /// <summary>
        /// 
        /// </summary>
        private bool moverStadiumServer(string pesActual)
        {
            try
            {
                string sTOTAL_CARPETAS = LeerINI("PES", "TOTAL_CARPETAS_STADIUM_SERVER");
                int i = 1;
                int iTOTAL_CARPETAS = int.Parse(sTOTAL_CARPETAS);
                List<string> listCarpetasStadiumServer = new List<string>();
                while (i < iTOTAL_CARPETAS)
                {
                    string s = LeerINI("PES", "CARPETAS_STADIUM_SERVER_" + i);
                    if (!string.IsNullOrEmpty(s))
                    {
                        listCarpetasStadiumServer.Add(s);
                    }
                    i++;
                }

                //nombre de la carpeta,content/stadium-server
                string sRutaStadiumServer = LeerINI("PES", "RUTA_STADIUM_SERVER");
                //Total de carpetas del stadiumserver a mover
                string sTotalCarpetasStadiumServer = LeerINI("PES", "TOTAL_CARPETAS_STADIUM_SERVER");
                string sRutaOrigenStadiumServer = string.Format(sRutaStadiumServer, pesActual);
                string sRutaDestinoStadiumServer = string.Format(sRutaStadiumServer, cbPesMod.SelectedItem.ToString());
                if (sRutaOrigenStadiumServer != sRutaDestinoStadiumServer)
                {
                    foreach (string sCarpeta in listCarpetasStadiumServer)
                    {
                        Directory.Move(sRutaOrigenStadiumServer + sCarpeta, sRutaDestinoStadiumServer + sCarpeta);
                    }
                    //MessageBox.Show(string.Format("Movemos de {0} a {1}",sRutaOrigenStadiumServer, sRutaDestinoStadiumServer));
                    //Directory.Move(sRutaOrigenStadiumServer + "Classic", sRutaDestinoStadiumServer + "Classic");
                    //Directory.Move(sRutaOrigenStadiumServer + "Galicia", sRutaDestinoStadiumServer + "Galicia");
                    //Directory.Move(sRutaOrigenStadiumServer + "Others", sRutaDestinoStadiumServer + "Others");
                    //Directory.Move(sRutaOrigenStadiumServer + "Spain", sRutaDestinoStadiumServer + "Spain");
                }
                else
                {
                    MessageBox.Show("Mover stadium server.El origen y el destino tiene que ser diferente");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mover stadium server." + Environment.NewLine + ex.Message);
                return true;
            }

        }
        private bool copiarConfigStadiumServer()
        {
            try
            {

                string sRutaStadiumServerDestino = LeerINI("PES", "RUTA_STADIUM_SERVER_DESTINO");
                //ELIMINAMOS LOS DEL DESTINO
                string sArchivoEliminarConfig = sRutaStadiumServerDestino + "config.ini";
                string sArchivoEliminarMapCompetitions = sRutaStadiumServerDestino + "map_competitions.txt";
                string sArchivoEliminarMapTeams = sRutaStadiumServerDestino + "map_teams.txt";
                //MessageBox.Show("sArchivoEliminarConfig" + sArchivoEliminarConfig);
                //MessageBox.Show("sArchivoEliminarMapCompetitions" + sArchivoEliminarMapCompetitions);
                //MessageBox.Show("sArchivoEliminarMapTeams" + sArchivoEliminarMapTeams);

                if (File.Exists(sArchivoEliminarConfig))
                {
                    File.Delete(sArchivoEliminarConfig);
                }
                
                if (File.Exists(sArchivoEliminarMapCompetitions))
                {
                    File.Delete(sArchivoEliminarMapCompetitions);
                }
                
                if (File.Exists(sArchivoEliminarMapTeams))
                {
                    File.Delete(sArchivoEliminarMapTeams);
                }

                //copiamos los nuevos, al destino, vemos si está en C o G
                string sRutaStadiumServerActual = LeerINI("PES", "RUTA_STADIUM_SERVER");
                if (chkDiscoExterno.Checked)
                {
                    sRutaStadiumServerActual = LeerINI("PES", "RUTA_STADIUM_SERVER_USB");
                }

                if (cbPesMod.SelectedItem != null)
                {
                    sRutaStadiumServerActual = string.Format(sRutaStadiumServerActual, cbPesMod.SelectedItem.ToString());
                }
                else {
                    MessageBox.Show("Selecciona un elemento");
                    return true;
                }

                //ACTUAL
                string sArchivoActualConfig = sRutaStadiumServerActual + "config.ini";
                string sArchivoActualMapCompetitions = sRutaStadiumServerActual + "map_competitions.txt";
                string sArchivoActualMapTeams = sRutaStadiumServerActual + "map_teams.txt";

                //MessageBox.Show("sArchivoActualConfig" + sArchivoActualConfig);
                //MessageBox.Show("sArchivoActualMapCompetitions" + sArchivoActualMapCompetitions);
                //MessageBox.Show("sArchivoActualMapTeams" + sArchivoActualMapTeams);

                if (File.Exists(sArchivoActualConfig))
                {
                    File.Copy(sArchivoActualConfig, sArchivoEliminarConfig);
                }
                
                if (File.Exists(sArchivoActualMapCompetitions))
                {
                    File.Copy(sArchivoActualMapCompetitions, sArchivoEliminarMapCompetitions);
                }
                
                if (File.Exists(sArchivoActualMapTeams))
                {
                    File.Copy(sArchivoActualMapTeams, sArchivoEliminarMapTeams);
                }
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copiando la configuración del stadium server." + Environment.NewLine + ex.Message);
                return true;
            }

        }
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