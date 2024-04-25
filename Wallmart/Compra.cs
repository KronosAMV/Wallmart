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
    public partial class Compra : Form
    {
        public Compra()
        {
            InitializeComponent();
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'wallmartBDDataSet.compradetalles' Puede moverla o quitarla según sea necesario.
            this.compradetallesTableAdapter.Fill(this.wallmartBDDataSet.compradetalles);
            // TODO: esta línea de código carga datos en la tabla 'wallmartBDDataSet.comprasmaster' Puede moverla o quitarla según sea necesario.
            this.comprasmasterTableAdapter.Fill(this.wallmartBDDataSet.comprasmaster);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
