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
    public partial class Issue : Form
    {
        public Issue()
        {
            InitializeComponent();
            Customdate();
            
            Filloffice();
            Fillitem();
        }
        string selectedItem;
        string selectedOffice;
        int selectedAmount;

        void calculation()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
            string qry ="Select * from dbo.Items Where item_name ='"+selectedItem+"'";
            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    lblcal.Text = sdr["item_name"].ToString();
                    int total =Convert.ToInt32(sdr["item_price"]) * selectedAmount;
                    lbltot.Text = total.ToString();

                }
                else
                {
                    MessageBox.Show("Select a item and office first");
                }
                
            }
            catch(SqlException se)
            {
                MessageBox.Show("" + se);
            }
            catch(Exception ex)
            {
                MessageBox.Show("" + ex);
            }


        }
        void updateitems()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "UPDATE Items SET item_amout= item_amout- '" + this.textBox1.Text + "' WHERE item_name = '" + this.comboBox1.Text + "';";
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
            catch(SqlException se)
            {
                MessageBox.Show(se.Message);
            }
            catch(Exception ex)
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

            foreach(DataRow dr in dt.Rows)
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
            string issue = "Issued";
            string price = lbltot.Text;

          


            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "INSERT INTO Inventory (item_name,amount,office_name,date,issue,price) VALUES ('"+item+"','"+amount+"','"+office+"','"+date+"','"+issue+"','"+price+"')";
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

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = comboBox1.Text;
        }

        private void BtnTotal_Click(object sender, EventArgs e)
        {
            lbloffice.Text = selectedOffice;
            lblqun.Text = selectedAmount.ToString();
            calculation();
            
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedOffice = comboBox2.Text;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1 == null)
            {
                selectedAmount = 0;
            }
            else
            {

                try
                {
                    selectedAmount = int.Parse(textBox1.Text);
                }
                catch (System.FormatException fe)
                {
                    MessageBox.Show("Item Amount cannot be Empty");
                }
            }
            
        }
    }
}
