using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacturacionElectronica
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // abrir exel
            String path = @"";

            // abrir archivo
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.*)|*.*";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = true;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                string sFileName = choofdlog.FileName;
                path = path + sFileName;
                Console.WriteLine(sFileName);
            }

            // leer archivo
             int inicio = 2;
             SLDocument doc = new SLDocument(path);
             while (!string.IsNullOrEmpty(doc.GetCellValueAsString(inicio, 1)))
             {
                 int codigo = doc.GetCellValueAsInt32(inicio, 1);
                 String nombre = doc.GetCellValueAsString(inicio,2);
                 int edad = doc.GetCellValueAsInt32(inicio,3);
                 inicio++;
                 Console.WriteLine("Codigo: "+codigo.ToString()+"Nombre: "+ nombre+ "Edad: "+ edad.ToString());

             }
             //escribir en la base de datos
             
            
        }
    }
}
