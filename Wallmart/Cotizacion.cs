using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallmart
{
    public partial class Cotizacion : Form
    {
        public Cotizacion()
        {
            InitializeComponent();
        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'wallmartBDDataSet.cotizaciondetalles' Puede moverla o quitarla según sea necesario.
            this.cotizaciondetallesTableAdapter.Fill(this.wallmartBDDataSet.cotizaciondetalles);
            // TODO: esta línea de código carga datos en la tabla 'wallmartBDDataSet.cotizacionmaster' Puede moverla o quitarla según sea necesario.
            this.cotizacionmasterTableAdapter.Fill(this.wallmartBDDataSet.cotizacionmaster);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
