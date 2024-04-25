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
using System.Drawing.Text;

namespace Wallmart
{
    public partial class Proveedore : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security=SSPI;data source=SAUL\\SQLEXPRESS;" + "persist security info = False;initial catalog=wallmartBD");
        public Proveedore()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Proveedore_Load(object sender, EventArgs e)

        {
            Llnargridproveedores();
            SqlCommand command = new SqlCommand("Get2",conexion);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Get2");
            adapter.Fill(dt);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "Codigo";
            this.comboBox1.ValueMember = "Codigo";


        }

        private void limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            Guadar.Enabled = true;
        }
        private void Llnargridproveedores()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            SqlDataAdapter adapter = new SqlDataAdapter("Proveedores", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }
        

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["codigoDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["rNCDataGridViewTextBoxColumn"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["nombresDataGridViewTextBoxColumn"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["direccionDataGridViewTextBoxColumn"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["telefonoDataGridViewTextBoxColumn"].Value.ToString();




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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandText = "InsertProveedores";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Nombres", SqlDbType.VarChar));
            command.Parameters["@Nombres"].Value = textBox3.Text;
            command.Parameters.Add(new SqlParameter("@Telefono", SqlDbType.Int));
            command.Parameters["@Telefono"].Value = textBox5.Text;
            command.Parameters.Add(new SqlParameter("@Rnc", SqlDbType.VarChar));
            command.Parameters["@Rnc"].Value = textBox2.Text;
            command.Parameters.Add(new SqlParameter("@Direccion", SqlDbType.VarChar));
            command.Parameters["@Direccion"].Value = textBox4.Text;


            conexion.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("guardado correctamente");


            conexion.Close();
            Guadar.Enabled = false;
            Llnargridproveedores();
            limpiar();
            
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpiar();
            Guadar.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
