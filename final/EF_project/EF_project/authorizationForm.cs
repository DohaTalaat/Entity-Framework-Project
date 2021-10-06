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
    public partial class authorizationForm : Form
    {
        public authorizationForm()
        {
            InitializeComponent();
        }

        private void authorizationForm_Load(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet81);
            dataGridView1.DataSource = dataSet81.Tables[0];
            sqlConnection1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Warehouse ware = new Warehouse();
            Permission Per = new Permission();
            DataRow dr = dataSet81.Tables[0].NewRow();
            string n = textBox1.Text;
            Model1 mod = new Model1();
            Warehouse war = (from p in mod.Warehouses
                             where p.Name == n
                             select p).First();
            dr[0] = n;//name of sotrage
            int id = int.Parse(textBox2.Text);
            Category cate = (from p in mod.Categories
                             where p.code == id
                             select p).First();
            dr[1] = id;//code of cate  
            dr[2] = cate.name;
            dr[5] = int.Parse(textBox4.Text);
            dr[6] = textBox5.Text;

            Has hs = (from p in mod.Hass
                             where p.code == id
                             select p).First();
            dr[3] = hs.Quantity_of_Category;
            string nam = textBox3.Text;
            Supplier sup = new Supplier();

            Supplier su = (from p in mod.Suppliers
                           where p.Name  == nam
                           select p).First();
            dr[4] = nam;
            dataSet81.Tables[0].Rows.Add(dr);
            MessageBox.Show("you inserted succesfully");
            mod.SaveChanges();
        }
    }
}
