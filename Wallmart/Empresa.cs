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
    public partial class Empresa : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security=SSPI;data source=SAUL\\SQLEXPRESS;" + "persist security info = False;initial catalog=wallmartBD");
        public Empresa()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox10.Clear();
            textBox9.Clear();
            textBox7.Clear();
            textBox8.Clear();
            Guadar.Enabled = true;
        }
        private void Llenargridempresas()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            SqlDataAdapter adapter = new SqlDataAdapter("empresas1", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Empresa_Load(object sender, EventArgs e)
        {
            Llenargridempresas();

            SqlCommand command = new SqlCommand("Get7", conexion);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Get7");
            adapter.Fill(dt);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "IDempresa";
            this.comboBox1.ValueMember = "IDempresa";


            this.empresasTableAdapter.Fill(this.wallmartBDDataSet.empresas);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandText = "Insertempresas2";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@RNC", SqlDbType.VarChar));
            command.Parameters["@RNC"].Value = textBox2.Text;
            command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar));
            command.Parameters["@Nombre"].Value = textBox3.Text;
            command.Parameters.Add(new SqlParameter("@Logo", SqlDbType.VarChar));
            command.Parameters["@Logo"].Value = textBox4.Text;
            command.Parameters.Add(new SqlParameter("@Propietario", SqlDbType.VarChar));
            command.Parameters["@Propietario"].Value = textBox5.Text;
            command.Parameters.Add(new SqlParameter("@Direccion",SqlDbType.VarChar));
            command.Parameters["@Direccion"].Value = textBox10.Text;
            command.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.VarChar));
            command.Parameters["@Telefono"].Value = textBox9.Text;
            command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar));
            command.Parameters["@Email"].Value = textBox8.Text;
            command.Parameters.Add(new SqlParameter("@Website", SqlDbType.VarChar));
            command.Parameters["@Website"].Value = textBox7.Text;
            conexion.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("guardado correctamente");


            conexion.Close();
            Guadar.Enabled = false;
            Llenargridempresas();
            Limpiar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
           Guadar.Enabled=true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["iDempresaDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["rNCDataGridViewTextBoxColumn"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["nombreDataGridViewTextBoxColumn"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["logoDataGridViewTextBoxColumn"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["propietarioDataGridViewTextBoxColumn"].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells["direccionDataGridViewTextBoxColumn"].Value.ToString();
            textBox9.Text = dataGridView1.CurrentRow.Cells["telefonoDataGridViewTextBoxColumn"].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells["emailDataGridViewTextBoxColumn"].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells["websiteDataGridViewTextBoxColumn"].Value.ToString();


            comboBox1.Visible = true;
            label1.Visible = true;

            textBox2.Visible = true;
            label12.Visible = true;

            textBox3.Visible = true;
            label3.Visible = true;

            label4.Visible = true;
            label4.Visible = true;

            textBox5.Visible = true;
            label5.Visible = true;

            textBox10.Visible = true;
            label10.Visible = true;

            textBox9.Visible = true;
            label9.Visible = true;

            textBox8.Visible = true;
            label8.Visible = true;

            textBox7.Visible = true;
            label7.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
