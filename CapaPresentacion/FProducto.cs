﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FProducto : Form
    {
        CN_Productos ProductosCN = new CN_Productos();
        public FProducto()
        {
            InitializeComponent();
        }

        private void FProducto_Load(object sender, EventArgs e)
        {
            MostrarProductos();
        }
        private void MostrarProductos() 
        {
            dgvListaProductos.DataSource = ProductosCN.Mostrar();
        }
    }
}
