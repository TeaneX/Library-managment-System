using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Library_managment_System
{
    public partial class Return_Books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINRG-D1K35D6\SQLEXPRESS;Initial Catalog=Library_managment_system;Integrated Security=True");
        public Return_Books()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hh = new Home();
            hh.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sqlSearch = "SELECT s_Name, b_Id, b_name, b_Issue, b_End FROM Issue_Books WHERE s_Id = @s_Id";
                SqlCommand cmd = new SqlCommand(sqlSearch, con);
                cmd.Parameters.AddWithValue("@s_Id", t1.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    t2.Text = reader["s_Name"].ToString();
                    t3.Text = reader["b_Id"].ToString();
                    t4.Text = reader["b_name"].ToString();
                    t5.Text = reader["b_Issue"].ToString();
                    t6.Text = reader["b_End"].ToString();
                }
                else
                {
                    MessageBox.Show("No record found for this Student ID.");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string issueQuery = "SELECT * FROM Issue_Books";
                SqlDataAdapter da1 = new SqlDataAdapter(issueQuery, con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;

                string returnQuery = "SELECT * FROM Return_Books";
                SqlDataAdapter da2 = new SqlDataAdapter(returnQuery, con);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                dataGridView2.DataSource = dt2;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sqlInsert = "INSERT INTO Return_Books (s_Id, s_Name, b_Id, b_name, b_Issue, b_Return) " +
                                   "VALUES (@s_Id, @s_Name, @b_Id, @b_name, @b_Issue, @b_Return);";

                SqlCommand cmdInsert = new SqlCommand(sqlInsert, con);

                cmdInsert.Parameters.AddWithValue("@s_Id", t1.Text);
                cmdInsert.Parameters.AddWithValue("@s_Name", t2.Text);
                cmdInsert.Parameters.AddWithValue("@b_Id", t3.Text);
                cmdInsert.Parameters.AddWithValue("@b_name", t4.Text);
                cmdInsert.Parameters.AddWithValue("@b_Issue", Convert.ToDateTime(t5.Text));  
                cmdInsert.Parameters.AddWithValue("@b_Return", Convert.ToDateTime(t6.Text)); 

                cmdInsert.ExecuteNonQuery();
                string sqlDelete = "DELETE FROM Issue_Books WHERE s_Id = @s_Id AND b_Id = @b_Id";

                SqlCommand cmdDelete = new SqlCommand(sqlDelete, con);
                cmdDelete.Parameters.AddWithValue("@s_Id", t1.Text);
                cmdDelete.Parameters.AddWithValue("@b_Id", t3.Text);

                cmdDelete.ExecuteNonQuery();

                MessageBox.Show("Book returned successfully.");
                t1.Clear();
                t2.Clear();
                t3.Clear();
                t4.Clear();
                t5.Text = "";
                t6.Text = "";
                t1.Focus();
  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
