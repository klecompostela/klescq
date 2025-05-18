using INIconfig;
namespace PESModSelector
{
    public partial class PESSelector : Form
    {

        ///// <summary>
        ///// NOMBRE DE LA CARPETA DONDE ESTA EL SAVE, obtenemos la información para determinar el PES ACTUAL
        ///// </summary>
        ///// public string PES_ACTUAL = string.Empty;
        ///// <summary>
        ///// Si el parche está en el disco P: SI|NO si está en C:
        ///// </summary>
        ///// public string DISCO_USB_ACTUAL = string.Empty;
        ///// <summary>
        ///// Si el parche usa los CPKs Originales: SI|NO si usa los modificados: Parches 2006
        ///// </summary>
        ///// public string CPK_ORIGINAL_ACTUAL = string.Empty;
        ///// <summary>
        ///// Si el parche usa el de 435MB | 442MB | 448MB
        ///// </summary>
        ///// public string VERSION_EXE_ACTUAL = string.Empty;

        public class proEvolutionSoccer
        {
            public string PES = string.Empty;
            public string DISCO_USB = string.Empty;
            public string CPK_DOWNLOAD_ORIGINAL = string.Empty;
            public string CPK_DATA_ORIGINAL = string.Empty;
            public string VERSION_EXE = string.Empty;
            public string DISCO_UNIDAD = string.Empty;
        }

        public proEvolutionSoccer pesEnUso = new proEvolutionSoccer();
        public proEvolutionSoccer pesSeleccionado = new proEvolutionSoccer();

        bool bEXEDiferente = false;
        bool bCPKs_DOWNLOAD_Diferente = false;
        bool bCPKs_DATA_Diferente = false;
        bool bMismoOrigenyDestino = false;
        public PESSelector()
        {

            InitializeComponent();
            CenterToScreen();
            string sRuta = "";
            sRuta = Directory.GetCurrentDirectory() + "\\config.ini";
            CargaComboUnidades(sRuta);
            CargaComboRutas(sRuta);

        }
        private void CargaComboUnidades(string sRuta)
        {
            try
            {
                cbUnidades.Items.Clear();
                txtFicheroINI.Text = sRuta;
                sRuta = LeerINI("PES", "RUTA_INI");
                string sUnidades = LeerINI("PES", "UNIDADES");
                string[] listUnidades = sUnidades.Split(";");
                foreach (string s in listUnidades)
                {
                    cbUnidades.Items.Add(s);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando el combo de unidades." + Environment.NewLine + ex.Message);
                return;
            }

        }
        private void CargaComboRutas(string sRuta)
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
                setInfoPESActual(pesEnUso, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando el combo de PES." + Environment.NewLine + ex.Message);
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

        /// <summary>
        /// Seteamos las variables para la información del PES Actual y Seleccionado
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private void setInfoPESActual(proEvolutionSoccer pes, bool bEnUso)
        {
            try
            {
                string sRutaInfoPES = string.Empty;
                if (bEnUso)
                {
                    string sRutaInfo = LeerINI("PES", "RUTA_INFO");
                    //string pesEnUso = string.Empty;
                    if (!File.Exists(sRutaInfo))
                    {
                        throw new Exception("No hay archivo INFO.txt");
                    }
                    sRutaInfoPES = sRutaInfo;
                }
                else
                {
                    if (cbPesMod.SelectedItem == null)
                    {
                        MessageBox.Show("Seleccione un elemento.");
                        return;
                    }
                    if (cbPesMod.SelectedItem.ToString() == pesEnUso.PES.ToString())
                    {
                        bMismoOrigenyDestino = true;
                        MessageBox.Show("El origen y destino tiene que ser diferente.");
                        return;
                    }
                    else
                    {
                        bMismoOrigenyDestino = false;
                    }

                    string sRutaInfo = LeerINI("PES", "RUTA_INFO_SELECCIONADO");
                    //string pesEnUso = string.Empty;
                    sRutaInfoPES = string.Format(sRutaInfo, cbPesMod.SelectedItem.ToString());
                    if (!File.Exists(sRutaInfoPES))
                    {
                        throw new Exception("No hay archivo INFO SELECCIONADO.txt");
                    }

                }
                //int counter = 0;


                foreach (string line in System.IO.File.ReadLines(sRutaInfoPES))
                {
                    if (line.Contains("PES_ACTUAL"))
                    {
                        pes.PES = line.Replace("PES_ACTUAL=", "");
                        if (bEnUso)
                        {
                            lbPESActual.Text = pes.PES;
                        }
                        else
                        {
                            lbPESSel.Text = line.Replace("PES_ACTUAL=", "");
                        }

                    }
                    else if (line.Contains("DISCO_USB"))
                    {
                        pes.DISCO_USB = line.Replace("DISCO_USB=", "");
                        if (bEnUso)
                        {
                            lbDISCO_USB.Text = line;
                        }
                        else
                        {
                            lbDISCO_USB_SEL.Text = line;
                            if (pes.DISCO_USB == "SI")
                            {
                                chkDiscoExterno.Checked = true;
                            }
                            else
                            {
                                chkDiscoExterno.Checked = false;
                            }
                        }
                    }
                    else if (line.Contains("CPK_DOWNLOAD_ORIGINAL"))
                    {
                        pes.CPK_DOWNLOAD_ORIGINAL = line.Replace("CPK_DOWNLOAD_ORIGINAL=", "");
                        if (bEnUso)
                        {

                            lbCPK_DOWNLOAD_ORIGINAL.Text = line;
                        }
                        else
                        {
                            lbCPK_DOWNLOAD_ORIGINAL_SEL.Text = line;
                        }
                    }
                    else if (line.Contains("CPK_DATA_ORIGINAL"))
                    {
                        pes.CPK_DATA_ORIGINAL = line.Replace("CPK_DATA_ORIGINAL=", "");
                        if (bEnUso)
                        {

                            lbCPK_DATA_ORIGINAL.Text = line;
                        }
                        else
                        {
                           lbCPK_DATA_ORIGINAL_SEL.Text = line;
                        }
                    }
                    else if (line.Contains("VERSION_EXE"))
                    {
                        pes.VERSION_EXE = line.Replace("VERSION_EXE=", "");
                        if (bEnUso)
                        {
                            lbVERSION_EXE.Text = line;
                        }
                        else
                        {
                            lbVERSION_EXE_SEL.Text = line;
                        }
                    }
                    else if (line.Contains("DISCO_UNIDAD"))
                    {
                        pes.DISCO_UNIDAD = line.Replace("DISCO_UNIDAD=", "");
                        if (bEnUso)
                        {
                            cbUnidades.SelectedItem = pes.DISCO_UNIDAD;
                        }
                        else
                        {
                            cbUnidades.SelectedItem = pes.DISCO_UNIDAD;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //return "eFootball PES 2021 SEASON UPDATE";
                throw new Exception("No hay PES en uso" + ex.Message);
            }


        }

        /// <summary>
        /// Copiar la configuración del stadium server al content
        /// </summary>
        /// <returns></returns>
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
                //TODAS LAS CONFIGURACIONES DEL STADIUM SERVER, ESTAN EN C
                //copiamos los nuevos, al destino, vemos si está en C o P
                string sRutaStadiumServerActual = LeerINI("PES", "RUTA_STADIUM_SERVER");
                //if (chkDiscoExterno.Checked)
                //{
                //    sRutaStadiumServerActual = LeerINI("PES", "RUTA_STADIUM_SERVER_USB");
                //}

                if (cbPesMod.SelectedItem != null)
                {
                    sRutaStadiumServerActual = string.Format(sRutaStadiumServerActual, cbPesMod.SelectedItem.ToString());
                }
                else
                {
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

        /// <summary>
        /// En funcion del pesSeleccionado, movemos el EXE
        /// </summary>
        /// <returns></returns>
        private bool copiarVersionEXE()
        {
            try
            {

                string sRutaEXE435MB = LeerINI("PES", "RUTA_EXE_ORIGEN_435MB");
                string sRutaEXE442MB = LeerINI("PES", "RUTA_EXE_ORIGEN_442MB");
                string sRutaEXE448MB = LeerINI("PES", "RUTA_EXE_ORIGEN_448MB");

                string sRutaEXEDestino = LeerINI("PES", "RUTA_EXE_DESTINO");

                //ELIMINAMOS LOS DEL DESTINO
                string sArchivoEliminarEXE = sRutaEXEDestino + "PES2021.exe";

                //Eliminamos el que hay actualmente
                if (File.Exists(sArchivoEliminarEXE))
                {
                    File.Delete(sArchivoEliminarEXE);
                }
                //Si el parche usa el de 435MB | 442MB | 448MB
                if (pesSeleccionado.VERSION_EXE == "435MB")
                {
                    string sVersionEXE435MB = sRutaEXE435MB + "PES2021.exe";
                    if (File.Exists(sVersionEXE435MB))
                    {
                        File.Copy(sVersionEXE435MB, sArchivoEliminarEXE);
                    }
                }
                else if (pesSeleccionado.VERSION_EXE == "442MB")
                {
                    string sVersionEXE442MB = sRutaEXE442MB + "PES2021.exe";
                    if (File.Exists(sVersionEXE442MB))
                    {
                        File.Copy(sVersionEXE442MB, sArchivoEliminarEXE);
                    }
                }
                else if (pesSeleccionado.VERSION_EXE == "448MB")
                {
                    string sVersionEXE448MB = sRutaEXE448MB + "PES2021.exe";
                    if (File.Exists(sVersionEXE448MB))
                    {
                        File.Copy(sVersionEXE448MB, sArchivoEliminarEXE);
                    }
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copiando la versión del EXE." + Environment.NewLine + ex.Message);
                return true;
            }

        }


        // Helper method to move directory contents
        static void MoveDirectoryContents(string sourcePath, string destinationPath)
        {
            // Create the destination directory if it doesn't exist
            if (!Directory.Exists(destinationPath))
            {
                Directory.CreateDirectory(destinationPath);
            }

            // Move each file from the source directory to the destination directory
            foreach (string filePath in Directory.GetFiles(sourcePath))
            {
                string fileName = Path.GetFileName(filePath);
                string destinationFilePath = Path.Combine(destinationPath, fileName);
                File.Move(filePath, destinationFilePath);
            }

            // Move each subdirectory from the source directory to the destination directory
            foreach (string subdirectoryPath in Directory.GetDirectories(sourcePath))
            {
                string subdirectoryName = Path.GetFileName(subdirectoryPath);
                string destinationSubdirectoryPath = Path.Combine(destinationPath, subdirectoryName);
                MoveDirectoryContents(subdirectoryPath, destinationSubdirectoryPath);
                Directory.Delete(subdirectoryPath);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool copiarCPK_DOWNLOAD()
        {
            try
            {
                string sRUTA_CPK_DONWLOAD_DESTINO = LeerINI("PES", "RUTA_CPK_DONWLOAD_DESTINO");
                string sRUTA_CPK_DONWLOAD_ORIGINAL = LeerINI("PES", "RUTA_CPK_DONWLOAD_ORIGINAL");
                string sRUTA_CPK_DONWLOAD_TEMPORADA1993 = LeerINI("PES", "RUTA_CPK_DONWLOAD_TEMPORADA1993");
                string sRUTA_CPK_DONWLOAD_TEMPORADA2006 = LeerINI("PES", "RUTA_CPK_DONWLOAD_TEMPORADA2006");
                //movemos lo que hay a su origen.... y el destino se queda vacio.
                if (pesEnUso.CPK_DOWNLOAD_ORIGINAL == "SI")
                {
                    MoveDirectoryContents(sRUTA_CPK_DONWLOAD_DESTINO, sRUTA_CPK_DONWLOAD_ORIGINAL);
                }
                if (pesEnUso.CPK_DOWNLOAD_ORIGINAL == "NO1993")
                {

                    MoveDirectoryContents(sRUTA_CPK_DONWLOAD_DESTINO, sRUTA_CPK_DONWLOAD_TEMPORADA1993);
                }
                if (pesEnUso.CPK_DOWNLOAD_ORIGINAL == "NO2006")
                {

                    MoveDirectoryContents(sRUTA_CPK_DONWLOAD_DESTINO, sRUTA_CPK_DONWLOAD_TEMPORADA2006);
                }


                //aquí ya tenemos las 2 carpeta download.Temporada2006 y download.original
                if (pesSeleccionado.CPK_DOWNLOAD_ORIGINAL == "SI")
                {
                    //movemos original a download
                    MoveDirectoryContents(sRUTA_CPK_DONWLOAD_ORIGINAL, sRUTA_CPK_DONWLOAD_DESTINO);
                }

                if (pesSeleccionado.CPK_DOWNLOAD_ORIGINAL == "NO1993")
                {
                    //movemos temporada1993 a download
                    MoveDirectoryContents(sRUTA_CPK_DONWLOAD_TEMPORADA1993, sRUTA_CPK_DONWLOAD_DESTINO);
                }

                if (pesSeleccionado.CPK_DOWNLOAD_ORIGINAL == "NO2006")
                {
                    //movemos temporada1993 a download
                    MoveDirectoryContents(sRUTA_CPK_DONWLOAD_TEMPORADA2006, sRUTA_CPK_DONWLOAD_DESTINO);
                }

                //download.original
                //download.Temporada2006
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copiando los CPK de DOWNLOAD." + Environment.NewLine + ex.Message);
                return true;
            }

        }

        private bool copiarCPK_DATA()
        {
            try
            {
                string sRUTA_CPK_DATA_DESTINO = LeerINI("PES", "RUTA_CPK_DATA_DESTINO");
                string sRUTA_CPK_DATA_ORIGINAL = LeerINI("PES", "RUTA_CPK_DATA_ORIGINAL");
                string sRUTA_CPK_DATA_TEMPORADA2004 = LeerINI("PES", "RUTA_CPK_DATA_TEMPORADA2004");

                //movemos lo que hay a su origen.... y el destino se queda vacio.
                if (pesEnUso.CPK_DATA_ORIGINAL == "SI")
                {
                    MoveDirectoryContents(sRUTA_CPK_DATA_DESTINO, sRUTA_CPK_DATA_ORIGINAL);
                }
                if (pesEnUso.CPK_DATA_ORIGINAL == "NO2004")
                {

                    MoveDirectoryContents(sRUTA_CPK_DATA_DESTINO, sRUTA_CPK_DATA_TEMPORADA2004);
                }

                //aquí ya tenemos las 2 carpeta download.Temporada2004 y data.original
                if (pesSeleccionado.CPK_DATA_ORIGINAL == "SI")
                {
                    //movemos original a data
                    MoveDirectoryContents(sRUTA_CPK_DATA_ORIGINAL, sRUTA_CPK_DATA_DESTINO);
                }

                if (pesSeleccionado.CPK_DATA_ORIGINAL == "NO2004")
                {
                    //movemos temporada2004 a data
                    MoveDirectoryContents(sRUTA_CPK_DATA_TEMPORADA2004, sRUTA_CPK_DATA_DESTINO);
                }

                //data.original
                //data.Temporada2004
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copiando los CPK de DATA." + Environment.NewLine + ex.Message);
                return true;
            }

        }

        /// <summary>
        /// Comparar el PES en uso y el seleccionado. Establecemos si hay q hacer algo con el EXE y CPK
        /// </summary>
        private void checkDiferencias()
        {

            if (pesEnUso.VERSION_EXE != pesSeleccionado.VERSION_EXE)
            {
                bEXEDiferente = true;
            }
            if (pesEnUso.CPK_DOWNLOAD_ORIGINAL != pesSeleccionado.CPK_DOWNLOAD_ORIGINAL)
            {
                bCPKs_DOWNLOAD_Diferente = true;
            }
            if (pesEnUso.CPK_DATA_ORIGINAL != pesSeleccionado.CPK_DATA_ORIGINAL)
            {
                bCPKs_DATA_Diferente = true;
            }
        }

        #region EVENTOS
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
            CargaComboRutas(sRuta);

            if (sRuta == "")
            {
                return;
            }

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
                if (bMismoOrigenyDestino)
                {
                    MessageBox.Show("El origen y destino no puede ser el mismo.");
                    return;
                }
                ////RENOMBRAR LA QUE EXISTE
                //setInfoPESActual();

                if (pesEnUso.PES == "")
                {
                    MessageBox.Show("No hay archivo Info.txt");
                    return;
                }

                string sRutaBAK = LeerINI("PES", "RUTA_MOD_BAK") + pesEnUso.PES;
                string sRutaSave = LeerINI("PES", "RUTA_SAVE");
                //ya no se mueve el stadium server, se fijó en una carperta
                //bool error = moverStadiumServer(pesActual);
                //if (error){
                //    return;
                //}

                checkDiferencias();

                if (chkMoverStadiumServer.Checked)
                {
                    bool error = copiarConfigStadiumServer();
                    if (error)
                    {
                        return;
                    }
                }


                if (bEXEDiferente)
                {
                    bool error = copiarVersionEXE();
                    if (error)
                    {
                        return;
                    }
                }


                if (bCPKs_DOWNLOAD_Diferente)
                {
                    bool error = copiarCPK_DOWNLOAD();
                    if (error)
                    {
                        return;
                    }
                }

                if (bCPKs_DATA_Diferente)
                {
                    bool error = copiarCPK_DATA();
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
                //al acabar el proceso, establecemos los parámetros del nuevo
                setInfoPESActual(pesEnUso, true);

            }
            catch (Exception ex)
            {
                throw new Exception("Error actualizando el SAVE." + ex.Message);
            }
            this.Close();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void cbPesMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            setInfoPESActual(pesSeleccionado, false);
            checkDiferencias();
        }
        #endregion

        #region OBSOLETO

        /// <summary>
        /// En funcion del pesSeleccionado, movemos el CPK
        /// </summary>
        /// <returns></returns>
        //private bool copiarCPK()
        //{
        //    try
        //    {
        //        #region archivos de DOWNLOAD
        //        //eliminamos los CPK afectados              
        //        string sRUTA_CPK_DONWLOAD_DESTINO = LeerINI("PES", "RUTA_CPK_DONWLOAD_DESTINO");

        //        string sdt80_100E_x64 = "dt80_100E_x64.cpk";
        //        string sdt80_700E_x64 = "dt80_700E_x64.cpk";
        //        string sDpFileListbin = "DpFileList.bin";

        //        //ELIMINAMOS LOS DEL DESTINO
        //        string sArchivoEliminar_dt80_100E_x64 = sRUTA_CPK_DONWLOAD_DESTINO + sdt80_100E_x64;
        //        string sArchivoEliminar_dt80_700E_x64 = sRUTA_CPK_DONWLOAD_DESTINO + sdt80_700E_x64;
        //        string sArchivoEliminar_sDpFileListbin = sRUTA_CPK_DONWLOAD_DESTINO + sDpFileListbin;

        //        if (File.Exists(sArchivoEliminar_dt80_100E_x64))
        //        {
        //            File.Delete(sArchivoEliminar_dt80_100E_x64);
        //        }

        //        if (File.Exists(sArchivoEliminar_dt80_700E_x64))
        //        {
        //            File.Delete(sArchivoEliminar_dt80_700E_x64);
        //        }

        //        if (File.Exists(sArchivoEliminar_sDpFileListbin))
        //        {
        //            File.Delete(sArchivoEliminar_sDpFileListbin);
        //        }

        //        //archivos afectados
        //        if (pesSeleccionado.CPK_ORIGINAL == "SI")
        //        {

        //            string sRUTA_CPK_ORIGINALsdt80_100E_x64 = LeerINI("PES", "RUTA_CPK_DONWLOAD_ORIGINAL") + sdt80_100E_x64;
        //            string sRUTA_CPK_ORIGINALsdt80_700E_x64 = LeerINI("PES", "RUTA_CPK_DONWLOAD_ORIGINAL") + sdt80_700E_x64;
        //            string sRUTA_CPK_ORIGINALsDpFileListbin = LeerINI("PES", "RUTA_CPK_DONWLOAD_ORIGINAL") + sDpFileListbin;

        //            if (File.Exists(sRUTA_CPK_ORIGINALsdt80_100E_x64))
        //            {
        //                File.Copy(sRUTA_CPK_ORIGINALsdt80_100E_x64, sArchivoEliminar_dt80_100E_x64);
        //            }
        //            if (File.Exists(sRUTA_CPK_ORIGINALsdt80_700E_x64))
        //            {
        //                File.Copy(sRUTA_CPK_ORIGINALsdt80_700E_x64, sArchivoEliminar_dt80_700E_x64);
        //            }
        //            if (File.Exists(sRUTA_CPK_ORIGINALsDpFileListbin))
        //            {
        //                File.Copy(sRUTA_CPK_ORIGINALsDpFileListbin, sArchivoEliminar_sDpFileListbin);
        //            }

        //        }
        //        else
        //        {
        //            string sRUTA_CPK_Temporada2006sdt80_100E_x64 = LeerINI("PES", "RUTA_CPK_DONWLOAD_Temporada2006") + sdt80_100E_x64;
        //            string sRUTA_CPK_Temporada2006sdt80_700E_x64 = LeerINI("PES", "RUTA_CPK_DONWLOAD_Temporada2006") + sdt80_700E_x64;
        //            string sRUTA_CPK_Temporada2006sDpFileListbin = LeerINI("PES", "RUTA_CPK_DONWLOAD_Temporada2006") + sDpFileListbin;

        //            if (File.Exists(sRUTA_CPK_Temporada2006sdt80_100E_x64))
        //            {
        //                File.Copy(sRUTA_CPK_Temporada2006sdt80_100E_x64, sArchivoEliminar_dt80_100E_x64);
        //            }
        //            if (File.Exists(sRUTA_CPK_Temporada2006sdt80_700E_x64))
        //            {
        //                File.Copy(sRUTA_CPK_Temporada2006sdt80_700E_x64, sArchivoEliminar_dt80_700E_x64);
        //            }
        //            if (File.Exists(sRUTA_CPK_Temporada2006sDpFileListbin))
        //            {
        //                File.Copy(sRUTA_CPK_Temporada2006sDpFileListbin, sArchivoEliminar_sDpFileListbin);
        //            }
        //        }

        //        #endregion

        //        #region archivos de DATA
        //        //eliminamos los CPK afectados              
        //        string sRUTA_CPK_DATA_DESTINO = LeerINI("PES", "RUTA_CPK_DATA_DESTINO");

        //        string sdt15_x64 = "dt15_x64.cpk";
        //        string sdt36_g4 = "dt36_g4.cpk";

        //        //ELIMINAMOS LOS DEL DESTINO
        //        string sArchivoEliminar_dt15_x64 = sRUTA_CPK_DATA_DESTINO + sdt15_x64;
        //        string sArchivoEliminar_dt36_g4 = sRUTA_CPK_DATA_DESTINO + sdt36_g4;

        //        if (File.Exists(sArchivoEliminar_dt15_x64))
        //        {
        //            File.Delete(sArchivoEliminar_dt15_x64);
        //        }

        //        if (File.Exists(sArchivoEliminar_dt36_g4))
        //        {
        //            File.Delete(sArchivoEliminar_dt36_g4);
        //        }

        //        //archivos afectados
        //        if (pesSeleccionado.CPK_ORIGINAL == "SI")
        //        {

        //            string sRUTA_CPK_ORIGINALsdt15_x64 = LeerINI("PES", "RUTA_CPK_DATA_ORIGINAL") + sdt15_x64;
        //            string sRUTA_CPK_ORIGINALsdt36_g4 = LeerINI("PES", "RUTA_CPK_DATA_ORIGINAL") + sdt36_g4;

        //            if (File.Exists(sRUTA_CPK_ORIGINALsdt15_x64))
        //            {
        //                File.Copy(sRUTA_CPK_ORIGINALsdt15_x64, sArchivoEliminar_dt15_x64);
        //            }
        //            if (File.Exists(sRUTA_CPK_ORIGINALsdt36_g4))
        //            {
        //                File.Copy(sRUTA_CPK_ORIGINALsdt36_g4, sArchivoEliminar_dt36_g4);
        //            }
        //        }
        //        else
        //        {
        //            string sRUTA_CPK_Temporada2006sdt15_x64 = LeerINI("PES", "RUTA_CPK_DATA_Temporada2006") + sdt15_x64;
        //            string sRUTA_CPK_Temporada2006sdt36_g4 = LeerINI("PES", "RUTA_CPK_DATA_Temporada2006") + sdt36_g4;

        //            if (File.Exists(sRUTA_CPK_Temporada2006sdt15_x64))
        //            {
        //                File.Copy(sRUTA_CPK_Temporada2006sdt15_x64, sArchivoEliminar_dt15_x64);
        //            }
        //            if (File.Exists(sRUTA_CPK_Temporada2006sdt36_g4))
        //            {
        //                File.Copy(sRUTA_CPK_Temporada2006sdt36_g4, sArchivoEliminar_dt36_g4);
        //            }
        //        }





        //        #region dt14_all está en DATA
        //        //volvemos a comprobar si es CPK original o no...
        //        if (pesSeleccionado.CPK_ORIGINAL == "SI")
        //        {
        //            //para los originales, si no existe el archivo, lo restauramos.
        //            string sdt14_all = "dt14_all.cpk";
        //            string sArchivoEliminar_sdt14_all = sRUTA_CPK_DATA_DESTINO + sdt14_all;
        //            //si no existe el archivo, lo restauramos de la ruta de los originales.
        //            if (!File.Exists(sArchivoEliminar_sdt14_all))
        //            {
        //                string sRUTA_CPK_ORIGINALsdt14_all = LeerINI("PES", "RUTA_CPK_DATA_ORIGINAL") + sdt14_all;
        //                if (File.Exists(sRUTA_CPK_ORIGINALsdt14_all))
        //                {
        //                    File.Copy(sRUTA_CPK_ORIGINALsdt14_all, sArchivoEliminar_sdt14_all);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            //para los CPK modificados,eliminamos el dt14_all
        //            string sdt14_all = "dt14_all.cpk";
        //            string sArchivoEliminar_sdt14_all = sRUTA_CPK_DATA_DESTINO + sdt14_all;
        //            if (File.Exists(sArchivoEliminar_sdt14_all))
        //            {
        //                File.Delete(sArchivoEliminar_sdt14_all);
        //            }
        //        }
        //        #endregion

        //        #endregion

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error copiando la versión del CPK." + Environment.NewLine + ex.Message);
        //        return true;
        //    }

        //}
        /// <summary>
        /// Obsoleto: Ahora solo se mueven los ini, stadium server está en carpeta común
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
        #endregion
    }
}