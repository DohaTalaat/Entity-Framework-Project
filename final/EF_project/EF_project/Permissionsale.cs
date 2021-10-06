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
    public partial class Permissionsale : Form
    {
        public Permissionsale()
        {
            InitializeComponent();
        }

        private void Permissionsale_Load(object sender, EventArgs e)
        {
            sqlConnection1.Open();
            sqlDataAdapter1.Fill(dataSet91);
            dataGridView1.DataSource = dataSet91.Tables[0];
            sqlConnection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Warehouse ware = new Warehouse();
           // Permission Per = new Permission();
            DataRow dr = dataSet91.Tables[0].NewRow();
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
            Has hs = (from p in mod.Hass
                      where p.code == id
                      select p).First();
            dr[3] = hs.Quantity_of_Category;

            int id_cust = int.Parse(textBox3.Text);
           Customer cust = (from p in mod.Customers
                           where p.ID==id_cust
                           select p).First();
            dr[4] = id_cust;
            dr[5] = int.Parse(textBox4.Text);
            dr[6] = textBox5.Text;
            dataSet91.Tables[0].Rows.Add(dr);
            Permission Per = new Permission();
            Per.ID_Cust = id_cust;
            Per.N_Ware = n;
            Per.c_cate = id;
            Per.perm_num = int.Parse(textBox4.Text);
            //Per.perm_date = (DateTime)textBox5.Text;
           
            mod.Permissions.Add(Per);
            MessageBox.Show("you inserted succesfully");
            mod.SaveChanges();

        }
    }
}
