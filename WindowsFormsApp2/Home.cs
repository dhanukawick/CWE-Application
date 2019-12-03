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
    public partial class Home : Form
    {
        public Home(string emp)
        {
            InitializeComponent();
            metroLabel1.Text = emp;
            filltree();
            
        }
        DataTable dtable;
        string afselected;
        string issue;

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //Exit exi = new Exit();
            //exi.ShowDialog();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            afselected = treeView1.SelectedNode.Text;
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "Select * from dbo.Inventory where office_name ='" + afselected + "' and issue ='"+issue+"' ";
            SqlCommand cmd = new SqlCommand(qry, cn);

            try
            {
                SqlDataAdapter nsda = new SqlDataAdapter();
                nsda.SelectCommand = cmd;
                dtable = new DataTable();
                nsda.Fill(dtable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dtable;
                dataGridView1.DataSource = bSource;
                nsda.Update(dtable);

                dataGridView1.Columns["Id"].Visible = false;
                //dataGridView1.Columns["item_name"].DisplayIndex = 1;
                //dataGridView1.Columns["amount"].DisplayIndex = 2;
                //dataGridView1.Columns["office_name"].DisplayIndex = 3;
                //dataGridView1.Columns["date"].DisplayIndex = 4;
                //dataGridView1.Columns["issue"].DisplayIndex = 5;

                dataGridView1.Columns["item_name"].HeaderText = "Item Name";
                dataGridView1.Columns["amount"].HeaderText = "QTY";
                dataGridView1.Columns["office_name"].HeaderText = "Office Name";
                dataGridView1.Columns["date"].HeaderText = "Date";
                dataGridView1.Columns["issue"].HeaderText = "Issued/Returned";
                dataGridView1.Columns["price"].HeaderText = "Total Price";
                dataGridView1.Columns["retun_des"].HeaderText = "Return Description";


                dataGridView1.AutoResizeColumns();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.ShowDialog();
        }
        void filltree()
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from Offices", con);
            da.Fill(dt);



            treeView1.Nodes.Add("Offices");

            DataTable cdt = new DataTable();
            SqlDataAdapter cda = new SqlDataAdapter("Select * from Inventory", con);
            cda.Fill(cdt);

            foreach (DataRow dr in dt.Rows)
            {
                TreeNode nod = new TreeNode(dr["office_name"].ToString());

                treeView1.Nodes.Add(nod);

                

                


                /*foreach (DataRow dar in cdt.Rows)
                {
                    TreeNode cnod = new TreeNode(dar["issue"].ToString());

                    

                    nod.Nodes.Add(cnod);
                }*/

                
                

                
               
    
            
                
                
                //nod.Nodes.Add("Returned").ToString();


                

                
                /*{
                    
                    SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
                    string qry = "Select * from dbo.Inventory where office_name ='" + sel + "'";
                    SqlCommand cmd = new SqlCommand(qry, cn);

                    try
                    {
                        SqlDataAdapter nsda = new SqlDataAdapter();
                        nsda.SelectCommand = cmd;
                        DataTable dtable = new DataTable();
                        nsda.Fill(dtable);
                        BindingSource bSource = new BindingSource();

                        bSource.DataSource = dtable;
                        dataGridView1.DataSource = bSource;
                        nsda.Update(dtable);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }*/
                
            }
        }

        private void Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Issue i = new Issue();
            i.ShowDialog();
           
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            Issue i = new Issue();
            i.ShowDialog();

        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure want to sign out?", "Sign Out", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Signin si = new Signin();
                si.Show();
                this.Hide();
            }
            else if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            Inventory inv = new Inventory();
            inv.ShowDialog();

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            @return rtn = new @return();
            rtn.ShowDialog();
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            @return rtn = new @return();
            rtn.ShowDialog();
        }
        private void grid()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "Select * from dbo.Inventory ";
            SqlCommand cmd = new SqlCommand(qry, cn);

            try
            {
                SqlDataAdapter nsda = new SqlDataAdapter();
                nsda.SelectCommand = cmd;
                DataTable dtable = new DataTable();
                nsda.Fill(dtable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dtable;
                dataGridView1.DataSource = bSource;
                nsda.Update(dtable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        void issued()
        {
            string isss = "issued";
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "Select * from dbo.Inventory where office_name ='" + afselected + "' and issue = '"+isss+"'";
            SqlCommand cmd = new SqlCommand(qry, cn);

            try
            {
                SqlDataAdapter nsda = new SqlDataAdapter();
                nsda.SelectCommand = cmd;
                DataTable dtable = new DataTable();
                nsda.Fill(dtable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dtable;
                dataGridView1.DataSource = bSource;
                nsda.Update(dtable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            /*if (checkBox1.Checked)
            {

                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("issue LIKE 'Issued'", checkBox1.Checked);
                dataGridView1.DataSource = DV;
            }
            else
            {
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("issue LIKE 'Returned'", checkBox1.Checked);
                dataGridView1.DataSource = DV;
            }*/
        }

        private void CheckBox2_CheckStateChanged(object sender, EventArgs e)
        {
            /*if (checkBox2.Checked)
            {
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("issue LIKE 'Returned'", checkBox1.Checked);
                dataGridView1.DataSource = DV;
            }
            else
            {
                DataView DV = new DataView(dtable);
                DV.RowFilter = string.Format("issue LIKE 'Issued'", checkBox1.Checked);
                dataGridView1.DataSource = DV;
            }*/
        }

        private void RbIssue_CheckedChanged(object sender, EventArgs e)
        {
            issue = "Issued";

        }

        private void RbReturn_CheckedChanged(object sender, EventArgs e)
        {
            issue = "Returned";
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
