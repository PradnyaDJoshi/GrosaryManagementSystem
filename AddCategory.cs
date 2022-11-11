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
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (txtcategoryid.Text != "" && txtCategoryName.Text != "" && textBox3.Text != "")
            {
                String cid = txtcategoryid.Text;
                String cname = txtCategoryName.Text;
                String tp = textBox3.Text;
                //String Semester = txtStdSemester.Text;
                //Int64 Contact_No = Int64.Parse(txtStdContact.Text);
                //String Email_ID = txtEmailID.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into Category(Category_id,Category_Name,Total_Products) values(" + cid + ",'" + cname + "'," + tp+ ")";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill Empty Fields", "Suggest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Cancle_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
