using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Wallmart
{
    public partial class Venta :Form
         
    {
        SqlConnection conexion = new SqlConnection("integrated security=SSPI;data source=SAUL\\SQLEXPRESS;" + "persist security info = False;initial catalog=wallmartBD");
        public Venta()
        {
            InitializeComponent();
        }
        private void Llenargrinventas()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            SqlDataAdapter adapter = new SqlDataAdapter("Ventas2", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(data);
            dataGridView1.DataSource = data;

          
        }
        private void Limpiar()
        {
            textBox3.Clear();
            
            textBox6.Clear();
            textBox7.Clear();
            textBox13.Clear();
            textBox12.Clear();
            textBox11.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox8.Clear();
            Guadar.Enabled = true;
        }

        private void Venta_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'wallmartBDDataSet.compradetalles' Puede moverla o quitarla según sea necesario.
            this.compradetallesTableAdapter.Fill(this.wallmartBDDataSet.compradetalles);
            Llenargrinventas();

            SqlCommand command = new SqlCommand("Get4", conexion);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Get4");
            adapter.Fill(dt);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "IDventa";
            this.comboBox1.ValueMember = "IDventa";

       


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["iDventaDataGridViewTextBoxColumn"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells["fechaventaDataGridViewTextBoxColumn"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["iDclienteDataGridViewTextBoxColumn"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["totalventaDataGridViewTextBoxColumn"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["vendedorDataGridViewTextBoxColumn"].Value.ToString();
            textBox13.Text = dataGridView1.CurrentRow.Cells["iDproductoDataGridViewTextBoxColumn"].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells["cantidadDataGridViewTextBoxColumn"].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells["precioDataGridViewTextBoxColumn"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["iTBISDataGridViewTextBoxColumn"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["descuentoDataGridViewTextBoxColumn"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["subtotalDataGridViewTextBoxColumn"].Value.ToString();




            comboBox1.Visible = true;
            label1.Visible = true;

            dateTimePicker1.Visible = true;
            label2.Visible = true;

            textBox3.Visible = true;
            label3.Visible = true;

           
            textBox7.Visible = true;
            label7.Visible = true;
            textBox6.Visible = true;
            label6.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
            Guadar.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandText = "InsertVentas";
            command.CommandType = CommandType.StoredProcedure;

            
            command.Parameters.Add(new SqlParameter("@Fechaventa", SqlDbType.Date));
            command.Parameters["@Fechaventa"].Value = dateTimePicker1.Value;
            command.Parameters.Add(new SqlParameter("@IDcliente", SqlDbType.Int));
            command.Parameters["@IDcliente"].Value = textBox3.Text;
            command.Parameters.Add(new SqlParameter("@Totalventa", SqlDbType.VarChar));
            command.Parameters["@Totalventa"].Value = textBox7.Text;
            command.Parameters.Add(new SqlParameter("@Vendedor", SqlDbType.VarChar));
            command.Parameters["@Vendedor"].Value = textBox6.Text;
           command.Parameters.Add(new SqlParameter("@IDproducto", SqlDbType.Int));
            command.Parameters["@IDproducto"].Value = textBox13.Text;
            command.Parameters.Add(new SqlParameter("@Cantidad", SqlDbType.Int));
            command.Parameters["@Cantidad"].Value = textBox12.Text;
            command.Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal));
            command.Parameters["@Precio"].Value = textBox11.Text;
            command.Parameters.Add(new SqlParameter("@ITBIS", SqlDbType.Decimal));
            command.Parameters["@ITBIS"].Value = textBox10.Text;
            command.Parameters.Add(new SqlParameter("@Descuento", SqlDbType.Decimal));
            command.Parameters["@Descuento"].Value = textBox9.Text;
            command.Parameters.Add(new SqlParameter("@Subtotal", SqlDbType.Decimal));
            command.Parameters["@Subtotal"].Value = textBox8.Text;
            conexion.Open();

            command.ExecuteNonQuery();
            MessageBox.Show("guardado correctamente");


            conexion.Close();
            Guadar.Enabled = false;
            Llenargrinventas();
            Limpiar();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
        
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }
        private void button5_Click(object sender, EventArgs e)
        {
    
            textBox13.Text = dataGridView1.CurrentRow.Cells["iDproductoDataGridViewTextBoxColumn"].Value.ToString();
            textBox12.Text = dataGridView1.CurrentRow.Cells["cantidadDataGridViewTextBoxColumn"].Value.ToString();
            textBox11.Text = dataGridView1.CurrentRow.Cells["precioDataGridViewTextBoxColumn"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["itibisDataGridViewTextBoxColumn"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["descuentoDataGridViewTextBoxColumn"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["subtotalDataGridViewTextBoxColumn"].Value.ToString();





            textBox13.Visible = true;
            label13.Visible = true;

            textBox12.Visible = true;
            label12.Visible = true;

            label11.Visible = true;
            label11.Visible = true;

            textBox10.Visible = true;
            label10.Visible = true;
            textBox9.Visible = true;
            label9.Visible = true;
            textBox8.Visible = true;
            label8.Visible = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {
            
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vScrollBar1_ChangeUICues(object sender, UICuesEventArgs e)
        {

        }

        private void vScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
           

              

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
