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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }
        //to identify the server instance and database to connect to and to determine what driver, login, etc. to use to connect to the SQL Server instance
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-7V83D5D;Initial Catalog=RADProject;Integrated Security=True");

        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                //Sql query for insert data to table
                conn.Open();
                SqlCommand command = new SqlCommand("insert into Login(username,password,firstname,lastname,address,mobileno)values(@username,@pass,@fname,@lname,@add,@mno)", conn);
                command.Parameters.AddWithValue("@username",textBox_username.Text);
                command.Parameters.AddWithValue("@pass", textBox_password.Text);
                command.Parameters.AddWithValue("@fname", textBox_fname.Text);
                command.Parameters.AddWithValue("@lname", textBox_lname.Text);
                command.Parameters.AddWithValue("@add", textBox_address.Text);
                command.Parameters.AddWithValue("@mno", int.Parse(textBox_mobileno.Text));


                command.ExecuteNonQuery();
                MessageBox.Show("Succsefully Inseerted");
                conn.Close();
                 

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            //Clear data in Textboxes
            textBox_username.Clear();
            textBox_password.Clear();
            textBox_address.Clear();
            textBox_fname.Clear();
            textBox_lname.Clear();
            textBox_mobileno.Clear();
            
        }

        private void btn_login_Click_1(object sender, EventArgs e)
        {
            //Open Form1
            Form1 a = new Form1();
            a.ShowDialog();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
