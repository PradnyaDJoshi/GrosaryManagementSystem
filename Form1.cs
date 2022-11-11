using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void addNewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategory ad = new AddCategory();
            ad.Show();
        }

        private void viewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewCategory vc = new viewCategory();
            vc.Show();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProducts ac = new AddProducts();
            ac.Show();
        }

        private void viewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewProduct vP = new viewProduct();
            vP.Show();
        }
    }
}
