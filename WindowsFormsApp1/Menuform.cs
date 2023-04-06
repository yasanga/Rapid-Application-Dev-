using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Represents a Transact-SQL statement or stored procedure to execute against a SQL Server database
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class Menuform : Form
    { 
        public Menuform()
        {
            InitializeComponent();
            BindData();
        }
        //to identify the server instance and database to connect to and to determine what driver, login, etc. to use to connect to the SQL Server instance
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-7V83D5D;Initial Catalog=RADProject;Integrated Security=True");


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Menuform_Load(object sender, EventArgs e)
        {
           
            BindData();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                //Sql query for insert data to table
                SqlCommand command = new SqlCommand("insert into ProductInfo(ProductID,ItemName,Quantity,Addres,Catagory)values(@productId,@iName,@gun,@add,@cat)", conn);
                command.Parameters.AddWithValue("@productId",int.Parse(textBox1.Text));
                command.Parameters.AddWithValue("@iName", textBox2.Text);
                command.Parameters.AddWithValue("@gun", textBox4.Text);
                command.Parameters.AddWithValue("@add", textBox3.Text);
                command.Parameters.AddWithValue("@cat", comboBox2.Text);


                command.ExecuteNonQuery();
                MessageBox.Show("Succsefully Inseerted");
                conn.Close();
                BindData();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //It's a methode use for view data in DataGrid View 
        void BindData()
        {
            conn.Open();
            SqlCommand command = new SqlCommand("Select * from ProductInfo",conn);
            SqlDataAdapter sd = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) 
        {
            //Call BindData methode
            BindData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            //Update quary 
            SqlCommand command = new SqlCommand("update ProductInfo set ItemName = '" + textBox2.Text + "',Quantity = '" + textBox4.Text + "',Addres = '" + textBox3.Text + "' where ProductID='" + int.Parse(textBox1.Text) + "'", conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Succesfully Updated");
            BindData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //
            if(textBox1.Text != ""){
                conn.Open();
                //Delete Quary
                SqlCommand command = new SqlCommand("delete ProductInfo where ProductID ='" + int.Parse(textBox1.Text) + "'",conn);
                command.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully Deletesd");
                BindData();
            }
            else
            {
                MessageBox.Show("Put ProductID");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Exit button  
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

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            CheckStatus mfrm = new CheckStatus();
            mfrm.Show();
        }
    }
}
