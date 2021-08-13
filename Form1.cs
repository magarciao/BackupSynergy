using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackupSynergy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            listFiles1.Items.Clear();

            if(FD1.ShowDialog() == DialogResult.OK)
            {
                //Muestra la caja de diálogo de directorios y lee el dierctorio seleccionado.
                //listFiles1.Items.Add(FD1.SelectedPath);

                LeerCarpetas(FD1.SelectedPath);
            }
        }

        void LeerCarpetas(string path)
        {
            //Lee todos los archivos de una carpeta.
            string[] files = Directory.GetFiles(path);
            foreach (var item in files)
            {
                listFiles1.Items.Add(item);
            }

            //Lee las subcarpetas
            string[] carpetas = Directory.GetDirectories(path);
            foreach (var item in carpetas)
            {
                LeerCarpetas(item);
            }
        }
    }
}
