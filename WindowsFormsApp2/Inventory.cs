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
    public partial class Inventory : MetroFramework.Forms.MetroForm
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void MetroGrid2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            
            SqlConnection cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\Databases\Sathosa.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "Select * from dbo.Items ";
            SqlCommand cmd = new SqlCommand(qry, cn);

            try
            {
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataTable dtable = new DataTable();
                sda.Fill(dtable);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dtable;
                metroGrid1.DataSource = bSource;
                sda.Update(dtable);

                metroGrid1.Columns["Id"].Visible = false;
                //dataGridView1.Columns["item_name"].DisplayIndex = 1;
                //dataGridView1.Columns["amount"].DisplayIndex = 2;
                //dataGridView1.Columns["office_name"].DisplayIndex = 3;
                //dataGridView1.Columns["date"].DisplayIndex = 4;
                //dataGridView1.Columns["issue"].DisplayIndex = 5;

                metroGrid1.Columns["item_no"].HeaderText = "Item No";
                metroGrid1.Columns["item_name"].HeaderText = "Item Name";
                metroGrid1.Columns["item_amout"].HeaderText = "QTY";
                

                metroGrid1.AutoResizeColumns();




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
