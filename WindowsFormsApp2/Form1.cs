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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BunifuTextBox1_TextChange(object sender, EventArgs e)
        {

        }

        private void Label8_Click(object sender, EventArgs e)
        {
            Exit exi = new Exit();
            exi.ShowDialog();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string nic   = txtNic.Text;
            string emp   = txtEmp.Text;
            string email = txtEmail.Text;
            string pass = txtPass.Text;
            string cpass = txtCpass.Text;
            

            if (pass != cpass)
            {
                MessageBox.Show("Password is Missmatch");
            }
            else
            {
                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "INSERT INTO Signup Values('" + nic + "','" + emp + "','" + email + "','" + pass + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Registered Successfully");


                }
                catch(SqlException se)
                {
                    MessageBox.Show(se.Message);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }   


        }

        private void Label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Signin sn = new Signin();
            sn.ShowDialog();
        }
    }
}
