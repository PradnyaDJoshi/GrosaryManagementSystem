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
    public partial class viewProduct : Form
    {
        public viewProduct()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            panel1.Visible = false;
        }

        private void viewProduct_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Product Where Product_id LIKE'" + textBox1.Text + "' ";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        private void cellclickevent(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());   

            }

            panel1.Visible = true;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "select * from Product where Product_id=" + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            txtProductID.Text = ds.Tables[0].Rows[0][0].ToString();
            txtProductName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtProductPrice.Text = ds.Tables[0].Rows[0][2].ToString();
            txtCategoryID.Text = ds.Tables[0].Rows[0][3].ToString();
        }


        private void textchange(object sender, EventArgs e)
        {
            if (textBox1.Text != " ")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database= GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "select * from Product where Product_Name like'" + textBox1.Text + "%'";
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
                cmd.CommandText = "select * from Product ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Update_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String pid = txtProductID.Text;
                String pname = txtProductName.Text;
                String ptp = txtProductPrice.Text;
                String cid = txtCategoryID.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update Product set Product_Name='" + pname + "',Price=" + ptp + " Where Product_id=" + pid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void delete_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Deleted.Confirm?", "Conformation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = LAPTOP-PJAL8K0R;database=GroceryManagementSystem;Integrated security= True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Delete from Product where Category_id ='" + txtCategoryID.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

            }
        }

        private void Cancle_Click_1(object sender, EventArgs e)
        {
            Form1 Form = new Form1();
            Form.Show();
        }
    } }
