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
    public partial class Producto : Form

    {
        SqlConnection conexion = new SqlConnection("integrated security=SSPI;data source=SAUL\\SQLEXPRESS;" + "persist security info = False;initial catalog=wallmartBD");
        public Producto()
        {
            InitializeComponent();
        }

        private void Producto_Load(object sender, EventArgs e)
        {

            Llnargridproductos();

            SqlCommand command = new SqlCommand("Get1", conexion);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Get1");
            adapter.Fill(dt);
            this.comboBox1.DataSource = dt;
            this.comboBox1.DisplayMember = "Codigo";
            this.comboBox1.ValueMember = "Codigo";


        }


        private void Limpiar()
        {
            textBox2.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            Guadar.Enabled = true;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            command.CommandText = "InsertProductos3";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar));
            command.Parameters["@Nombre"].Value = textBox2.Text;
            command.Parameters.Add(new SqlParameter("@IDcategoria", SqlDbType.Int));
            command.Parameters["@IDcategoria"].Value = textBox4.Text;
            command.Parameters.Add(new SqlParameter("@Preciocompra", SqlDbType.Decimal));
            command.Parameters["@Preciocompra"].Value = textBox1.Text;
            command.Parameters.Add(new SqlParameter("@Precioventa", SqlDbType.Decimal));
            command.Parameters["@Precioventa"].Value = textBox3.Text;

            conexion.Open();
            command.ExecuteNonQuery();
            MessageBox.Show("guardado correctamente");
            
            
            conexion.Close();
            Guadar.Enabled = false;
            Llnargridproductos();
            Limpiar();






        }
    

        private void Llnargridproductos()
        {
          DataTable data = new DataTable();
            SqlCommand command = new SqlCommand();
            command.Connection = conexion;
            SqlDataAdapter adapter = new SqlDataAdapter("Productos3",conexion);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(data);
            dataGridView1.DataSource = data;

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Limpiar();
            Guadar.Enabled = true;


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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["codigoDataGridViewTextBoxColumn"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["nombreDataGridViewTextBoxColumn"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["idcategoriaDataGridViewTextBoxColumn"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["preciocompraDataGridViewTextBoxColumn"].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells["precioventaDataGridViewTextBoxColumn"].Value.ToString();




            comboBox1.Visible = true;
            label1.Visible = true;

            textBox2.Visible = true;
            label12.Visible = true;

            textBox1.Visible = true;
            label6.Visible = true;

            label3.Visible = true;
            label3.Visible = true;

            textBox4.Visible = true;
            label4.Visible = true;
        }
    }
}
