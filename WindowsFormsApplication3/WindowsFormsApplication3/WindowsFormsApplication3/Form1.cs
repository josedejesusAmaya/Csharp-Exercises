using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll")]
        static extern bool CopyFile(string IpExistingFileName, string IpNewFileName, bool bFaillfExists);
        //depende del sistema operativo, utiliza la llamada al sistema. Por lo tanto pesa menos.
        [DllImport("User32.dll")] //utilizo la API de windows 
        public static extern int MessageBox(int h, string m, string c, int type); //llamada al sistema

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CopyFile(@"C:\configusb2ftp.txt", @"C:\configura_USB2.txt", true))
                MessageBox(0, "Terminado", "Mensaje de Sistema", 0);
            //MessageBox(0, "API Message Box", "API Demo", 0);
        }
    }
}
