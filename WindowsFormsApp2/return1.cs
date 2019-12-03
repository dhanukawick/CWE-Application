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
    public partial class @return : Form
    {
        public @return()
        {
            InitializeComponent();
            Customdate();

            Filloffice();
            Fillitem();
        }
        void updateitems()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "UPDATE Items SET item_amout= item_amout+ '" + this.textBox1.Text + "' WHERE item_name = '" + this.comboBox1.Text + "';";
                SqlCommand cmd = new SqlCommand(qry, con);

                try
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    MessageBox.Show("item table updated");

                    while (sdr.Read())
                    {

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
        }

        void issreturn()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "INSERT INTO Inventory (issue) VALUES ('Issued')";
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Filloffice()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select office_name from dbo.Offices ";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["office_name"].ToString());
                comboBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox2.AutoCompleteSource = AutoCompleteSource.ListItems;
            }
        }
        private void Fillitem()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select item_name from dbo.Items ";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["item_name"].ToString());
                comboBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
                comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            }

        }
        void Customdate()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            string item = comboBox1.Text;
            string amount = textBox1.Text;
            string office = comboBox2.Text;
            string date = dateTimePicker1.Text;
            string issue = "Returned";




                try
                {
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "INSERT INTO Inventory (item_name,amount,office_name,date,issue) VALUES ('" + item + "','" + amount + "','" + office + "','" + date + "','" + issue + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException se)
                {
                    MessageBox.Show(se.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            updateitems();

            /* item = "";
             amount = "";
             office = "";
             date = "";*/



            this.Hide();

        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            string item = comboBox1.Text;
            string amount = textBox1.Text;
            string office = comboBox2.Text;
            string date = dateTimePicker1.Text;
            string issue = "Returned";
            string des = textBox2.Text;




            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "INSERT INTO Inventory (item_name,amount,office_name,date,issue,retun_des) VALUES ('" + item + "','" + amount + "','" + office + "','" + date + "','" + issue + "','"+des+"')";
                SqlCommand cmd = new SqlCommand(qry, con);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            updateitems();

            /* item = "";
             amount = "";
             office = "";
             date = "";*/



            this.Hide();
        }
    }
}
