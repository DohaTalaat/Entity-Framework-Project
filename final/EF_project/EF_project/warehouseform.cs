using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_project
{
    public partial class warehouseform : Form
    {
        public warehouseform()
        {
            InitializeComponent();
        }

        private void warehouse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'trading_CompanyDataSet.Warehouse' table. You can move, or remove it, as needed.
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(trading_CompanyDataSet1);
            sqlConnection1.Close();
            dataGridView1.DataSource = trading_CompanyDataSet1.Tables[0];

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow dr = trading_CompanyDataSet1.Tables[0].NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            trading_CompanyDataSet1.Tables[0].Rows.Add(dr);
            sqlDataAdapter1.Update(trading_CompanyDataSet1);
            MessageBox.Show("You Inserted Succesfully");
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();

            DataRow dr = trading_CompanyDataSet1.Tables[0].Rows.Find(textBox1.Text);
            if (dr != null)
            {
                dr[1] = textBox2.Text;
                dr[2] = textBox3.Text;
                textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
                sqlDataAdapter1.Update(trading_CompanyDataSet1);
               
                MessageBox.Show("Your Data Is Updated Succesfully");
            }
            else { MessageBox.Show("Faild"); }
            sqlConnection1.Close();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            Home home = new Home();
            home.Show();
            //this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            warehousesreport ware = new warehousesreport();
            ware.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AllWareHousesREport all = new AllWareHousesREport();
            all.ShowDialog();
        }
    }
}
