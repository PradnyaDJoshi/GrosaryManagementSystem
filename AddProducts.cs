using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment
{
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();
        }

        private void Cancle_Click(object sender, EventArgs e)

        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (txtProductID.Text != "" && txtProductName.Text != "" && txtProductPrice.Text != "" && txtCategoryID.Text != "")
            {
                String pid = txtProductID.Text;
                String pname = txtProductName.Text;
                String pprice = txtProductPrice.Text;
                String ccid= txtCategoryID.Text;
               


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "Insert into Product(Product_id,Product_Name,Category_id,Price) values("+pid+",'"+pname+"',"+ccid+","+pprice+")";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {

        }
    }
}
