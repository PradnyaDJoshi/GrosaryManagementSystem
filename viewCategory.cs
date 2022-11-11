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
    public partial class viewCategory : Form
    {
        public viewCategory()
        {
            InitializeComponent();
        }

        private void viewCategory_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Category Where Category_id LIKE'" + search.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        private void cellclick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());   

            }

            panel1.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database= GroceryManagementSystem;Integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Category where Category_id=" + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtcategoryid.Text = ds.Tables[0].Rows[0][0].ToString();
            txtCategoryName.Text = ds.Tables[0].Rows[0][1].ToString();
            tp.Text = ds.Tables[0].Rows[0][2].ToString();
            //texCategoryId.Text = ds.Tables[0].Rows[0][3].ToString();
        }

        private void Update_Click(object sender, EventArgs e)
        {
           
        }

        private void delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Deleted.Confirm?", "Conformation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Category where Category_id ='" + txtcategoryid.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
        }

        private void Cancle_Click(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
        }

        private void textchange(object sender, EventArgs e)
        {
            if (search.Text != " ")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database= GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Category where Category_Name like'" + search.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Category ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
            }
        }

        private void Update_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String cid = txtcategoryid.Text;
                String cname = txtCategoryName.Text;
                String ctp = tp.Text;
                //String cidd = texCategoryId.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update Category set Category_Name='" + cname + "',Total_Products =" + ctp + " Where Category_id=" + cid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }

 }

