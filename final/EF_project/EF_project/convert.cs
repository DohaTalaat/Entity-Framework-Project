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
    public partial class convert : Form
    {
        public convert()
        {
            InitializeComponent();
        }
        // convert from to another 
        private void button1_Click(object sender, EventArgs e)
        {

            Model1 mod = new Model1();
            Has h = (from h1 in mod.Hass
                     where h1.name == textBox1.Text
                     select h1).First();
            // name/cate/time
            Warehouse war = (from w1 in mod.Warehouses
                             where w1.Name == textBox2.Text
                             select w1).First();
            //name from warehouse and all date of this name
            Has h2 = new Has();
            h2.name = war.Name;
            h2.code = int.Parse(textBox3.Text);
            // h2.time_input_storage = textBox8.Text;
            h2.Quantity_of_Category = int.Parse(textBox4.Text);
            h.Quantity_of_Category = h.Quantity_of_Category - int.Parse(textBox4.Text);
            int category_code = int.Parse(textBox3.Text);
            Category cate = (from cat in mod.Categories
                             where cat.code == category_code
                             select cat).First();
            textBox6.Text = cate.production_Date.ToString();
            textBox7.Text = cate.Final_Date.ToString();
            mod.Hass.Add(h2);
            // mod.Hass.Add(h);
            

            Supplier sup = new Supplier();
            //supplier in warehouse (from)
            Permission per = (from pr in mod.Permissions
                              where pr.N_Ware == textBox1.Text
                              select pr).First();
            // supplier in warehous(to)
            Permission per1 = (from pr in mod.Permissions
                               where pr.N_Ware==textBox1.Text
                               select pr).First();
            per1.num_Sup = textBox5.Text;
            per1.perm_date = per.perm_date;
            //per1.perm_num = per.perm_num;
            mod.Permissions.Add(per1);
            textBox5.Text = per1.num_Sup;
            MessageBox.Show("Converted succesfully");
            mod.SaveChanges();

        }
    }
}
