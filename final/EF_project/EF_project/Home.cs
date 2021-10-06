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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            warehouseform ware = new warehouseform();
            ware.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            categoryform cat = new categoryform();
            cat.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            customerform cust = new customerform();
            cust.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            supplierform sup = new supplierform();
            sup.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            authorizationForm a = new authorizationForm();
            a.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Permissionsale per = new Permissionsale();
            per.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            convert con = new convert();
            con.ShowDialog();
        }
    }
}
