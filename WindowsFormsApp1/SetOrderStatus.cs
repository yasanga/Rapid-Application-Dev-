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

namespace WindowsFormsApp1
{
    public partial class SetOrderStatus : Form
    {
        public SetOrderStatus()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-7V83D5D;Initial Catalog=RADProject;Integrated Security=True");

        void BindData()
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from Status", conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void SetOrderStatus_Load(object sender, EventArgs e)
        {
            display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                //Sql query for insert data to table
                SqlCommand command = new SqlCommand("insert into Status(Status)values(@sta)", conn);
                command.Parameters.AddWithValue("@sta", comboBox1.Text);

                command.ExecuteNonQuery();
                MessageBox.Show("Succsefully Inseerted");
                conn.Close();
                display();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BindData();
        }
        public void display()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select ID,Status,ItemName from Status,ProductInfo where ProductInfo.ProductID=Status.ID", conn);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            //Update quary 
            SqlCommand command = new SqlCommand("update Status set Status = '" + comboBox1.Text + "'where ID='" + int.Parse(textBox1.Text) + "'", conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succesfully Updated");
            display();
        }
    }
}
