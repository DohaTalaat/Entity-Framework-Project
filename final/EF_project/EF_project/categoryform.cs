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
    public partial class categoryform : Form
    {
        public categoryform()
        {
            InitializeComponent();
        }

        private void category_Load(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet61);
            sqlConnection1.Close();
            dataGridView1.DataSource =dataSet61.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Insert in Table
          
            DataRow dr = dataSet61.Tables[0].NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = textBox4.Text;
            dataSet61.Tables[0].Rows.Add(dr);
            sqlConnection1.Open();
            sqlDataAdapter1.Update(dataSet61);
            sqlConnection1.Close();
            MessageBox.Show("You Inserted Succesfully");

            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();

            DataRow dr = dataSet61.Tables[0].Rows.Find(textBox1.Text);
            if (dr != null)
            {
                dr[1] = textBox2.Text;
                dr[2] = textBox3.Text;
                dr[3] = textBox4.Text;
                textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
                sqlDataAdapter1.Update(dataSet61);
                MessageBox.Show("Your Data Is Updated Succesfully");
            }
            else { MessageBox.Show("Faild"); }
            sqlConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoryREport cat = new CategoryREport();
            cat.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CatREportInSTORE cat = new CatREportInSTORE();
            cat.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reminder_Date rem = new Reminder_Date();
            rem.ShowDialog();

        }
    }
}
