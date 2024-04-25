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
    public partial class Usuario : Form
    {
        SqlConnection conexion = new SqlConnection("integrated security=SSPI;data source=SAUL\\SQLEXPRESS;" + "persist security info = False;initial catalog=wallmartBD");
        public Usuario()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
            guadar.Enabled = true;
        }
      private void Llenargridusuario()
        {
            DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            SqlDataAdapter adapter = new SqlDataAdapter("usuarios2", conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(data);
            dataGridView1.DataSource = data;
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

            Llenargridusuario();

            SqlCommand command = new SqlCommand("Get6", conexion);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Get6");
            adapter.Fill(dt);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "IDusuario";
            this.comboBox1.ValueMember = "IDusuario";



            this.usuariosTableAdapter.Fill(this.wallmartBDDataSet.usuarios);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Limpiar();
            guadar.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandText = "Insertusuarios";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar));
            command.Parameters["@Nombre"].Value = textBox2.Text;
            command.Parameters.Add(new SqlParameter("@Username", SqlDbType.VarChar));
            command.Parameters["@Username"].Value = textBox3.Text;
            command.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar));
            command.Parameters["@Password"].Value = textBox4.Text;
            command.Parameters.Add(new SqlParameter("@Tipousuario", SqlDbType.VarChar));
            command.Parameters["@Tipousuario"].Value = comboBox2.Text;

            conexion.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("guardado correctamente");


            conexion.Close();
            guadar.Enabled = false;
            Llenargridusuario();
            Limpiar();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["iDusuarioDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["nombreDataGridViewTextBoxColumn"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["usernameDataGridViewTextBoxColumn"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["passwordDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["tipousuarioDataGridViewTextBoxColumn"].Value.ToString();




            comboBox1.Visible = true;
            label1.Visible = true;

            textBox2.Visible = true;
            label12.Visible = true;

            textBox3.Visible = true;
            label3.Visible = true;

            label4.Visible = true;
            label4.Visible = true;

            comboBox2.Visible = true;
            label5.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
