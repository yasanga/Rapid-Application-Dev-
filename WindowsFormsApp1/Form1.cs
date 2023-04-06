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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //to identify the server instance and database to connect to and to determine what driver, login, etc. to use to connect to the SQL Server instance
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-7V83D5D;Initial Catalog=RADProject;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
             
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            //allows to define a block of code to be tested for errors while it is being executed
            try
            {
                //checks if the text boxes are empty
                if (textBox_username.Text == "" && textBox_password.Text == "")
                {
                    MessageBox.Show("please enter username ane password");
                }
                //If the Boxes are not empty check the text box details with text boxes 
                else
                {
                    SqlCommand cmd = new SqlCommand("select * from Login where username=@uname and password=@password", conn);
                    cmd.Parameters.AddWithValue("@uname", textBox_username.Text);
                    cmd.Parameters.AddWithValue("@password", textBox_password.Text);             
                    conn.Open();
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    conn.Close();
                    int count = ds.Tables[0].Rows.Count;
                    //If the text boxes are correct open the MenuForm
                    if (count > 0)
                    {
                        Menuform mfrm = new Menuform();
                        mfrm.Show();
                    }
                    //Is there any Incorect user name or password  show the error message
                    else
                    {
                        MessageBox.Show("invalid user name and password");
                    }
                }

            }
            //catch statement allows  to define a block of code to be executed, if an error occurs in the try block
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Clear button 
        private void btn_clear_Click(object sender, EventArgs e)
        {
            textBox_username.Clear();
            textBox_password.Clear();

            textBox_username.Focus();
        }

        //Exit Button
        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();

            }
        }
        
        //Open the SignUp Form
        private void button1_Click(object sender, EventArgs e)
        {
            SignUp a = new SignUp();
            a.ShowDialog();

        }

        private void textBox_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //allows to define a block of code to be tested for errors while it is being executed
            try
            {
                //checks if the text boxes are empty
                if (textBox_username.Text == "" && textBox_password.Text == "")
                {
                    MessageBox.Show("please enter username ane password");
                }
                //If the Boxes are not empty check the text box details with text boxes 
                else
                {
                    SqlCommand cmd = new SqlCommand("select * from AdminLogin where username=@uname and password=@password", conn);
                    cmd.Parameters.AddWithValue("@uname", textBox_username.Text);
                    cmd.Parameters.AddWithValue("@password", textBox_password.Text);
                    conn.Open();
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    conn.Close();
                    int count = ds.Tables[0].Rows.Count;
                    //If the text boxes are correct open the MenuForm
                    if (count > 0)
                    {
                        SetOrderStatus mfrm = new SetOrderStatus();
                        mfrm.Show();
                    }
                    //Is there any Incorect user name or password  show the error message
                    else
                    {
                        MessageBox.Show("invalid user name and password");
                    }
                }

            }
            //catch statement allows  to define a block of code to be executed, if an error occurs in the try block
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
