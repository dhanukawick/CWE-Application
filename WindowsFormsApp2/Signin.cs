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
    public partial class Signin : Form
    {
        public Signin()
        {
            InitializeComponent();
        }

        private void Label8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label8_Click_1(object sender, EventArgs e)
        {

            Exit exi = new Exit();
            exi.ShowDialog();
        }

        private void Label10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.ShowDialog();
        }

        private void BtnSignin_Click(object sender, EventArgs e)
        {
            

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "SELECT * FROM dbo.Signup WHERE emp ='" + txtEmp.Text + "' AND  password = '" + txtPass.Text + "'";
                SqlCommand cmd = new SqlCommand(qry, con);

                try
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    
                    if(sdr.Read())
                    {
                        MessageBox.Show("You Signed in");
                        this.Hide();
                        Home ho = new Home("Employee No:" +txtEmp.Text);
                        ho.Show();
                    }
                    else
                    {
                        MessageBox.Show("Employee Number or Password Incorrect");
                    }
                    con.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            catch(SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            txtEmp.Text = "";
            txtPass.Text = "";
        }
    }
}
