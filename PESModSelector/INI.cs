using System.Runtime.InteropServices;
using System.Text;

namespace INIconfig
{
    public class INI
    {
        public string ficheroINI { get; set; }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section,
            string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section,
            string key, string def, StringBuilder retVal, int size, string filePath);

        public INI(string INIPath)
        {
            ficheroINI = INIPath;
        }
        //public void EscribirINI(string Seccion, string Clave, string Valor)
        //{
        //    WritePrivateProfileString(Seccion, Clave, Valor, ficheroINI);
        //}

        public string LeerINI(string Seccion, string Clave)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Seccion, Clave, "", temp, 255, this.ficheroINI);
            return temp.ToString();
        }
        //public string LineasArchivoINI(string Seccion, string Clave)
        //{
            
        //    string[] files = Directory.GetFiles(this.ficheroINI);
        //    return File.ReadAllLines(files[0]).Lenght;
        //}
    }
}