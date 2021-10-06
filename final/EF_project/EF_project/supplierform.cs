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
    public partial class supplierform : Form
    {
        public supplierform()
        {
            InitializeComponent();
        }

        private void supplier_Load(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet51);
            sqlConnection1.Close();
            dataGridView1.DataSource = dataSet51.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow dr = dataSet51.Tables[0].NewRow();
            //dr[0] = textBox1.Text;
            dr[0] = textBox2.Text;
            dr[1] = int.Parse(textBox3.Text);
            dr[2] = textBox4.Text;
            dr[3] =int.Parse( textBox5.Text);
            dr[4] = textBox6.Text;
            dr[5] =int.Parse( textBox7.Text);
           dataSet51.Tables[0].Rows.Add(dr);
            sqlConnection1.Open();
            sqlDataAdapter1.Update(dataSet51);
            sqlConnection1.Close();
            MessageBox.Show("You Inserted Succesfully");
           textBox2.Text = textBox3.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();

            DataRow dr = dataSet51.Tables[0].Rows.Find(textBox2.Text);
            if (dr != null)
            {
                dr[0] = textBox2.Text;
                dr[1] = textBox3.Text;
                dr[2] = textBox4.Text;
                dr[3] = textBox5.Text;
                dr[4] = textBox6.Text;
                dr[5] = textBox7.Text;
                 textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = string.Empty;
                sqlDataAdapter1.Update(dataSet51);

                MessageBox.Show("Your Data Is Updated Succesfully");
            }
            else { MessageBox.Show("Faild"); }
            sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SupplierREport sup = new SupplierREport();
            sup.ShowDialog();
        }
    }
}
