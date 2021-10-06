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
    public partial class customerform : Form
    {
        public customerform()
        {
            InitializeComponent();
        }

        private void customer_Load(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet12);
            sqlConnection1.Close();
            dataGridView1.DataSource =dataSet12.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow dr = dataSet12.Tables[0].NewRow();
            dr[0] = textBox1.Text;
            dr[1] = textBox2.Text;
            dr[2] = textBox3.Text;
            dr[3] = textBox4.Text;
            dr[4] = textBox5.Text;
            dr[5] = textBox6.Text;
            dr[6] = textBox7.Text;
            dataSet12.Tables[0].Rows.Add(dr);
            sqlConnection1.Open();
            sqlDataAdapter1.Update(dataSet12);
            sqlConnection1.Close();
            MessageBox.Show("You Inserted Succesfully");
            textBox1.Text = textBox2.Text = textBox3.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection1.Open();

            DataRow dr = dataSet12.Tables[0].Rows.Find(textBox1.Text);
            if (dr != null)
            {
                dr[1] = textBox2.Text;
                dr[2] = textBox3.Text;
                dr[3] = textBox4.Text;
                dr[4] = textBox5.Text;
                dr[5] = textBox6.Text;
                dr[6] = textBox7.Text;
                textBox1.Text = textBox2.Text = textBox3.Text=textBox4.Text= textBox5.Text=textBox6.Text= textBox7.Text=string.Empty;
                sqlDataAdapter1.Update(dataSet12);

                MessageBox.Show("Your Data Is Updated Succesfully");
            }
            else { MessageBox.Show("Faild"); }
            sqlConnection1.Close();
        }
    }
}
