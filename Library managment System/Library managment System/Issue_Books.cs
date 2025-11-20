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
    public partial class Issue_Books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINRG-D1K35D6\SQLEXPRESS;Initial Catalog=Library_managment_system;Integrated Security=True");
        public Issue_Books()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hh = new Home();
            hh.Show();
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

                string sqlInsert = "INSERT INTO Issue_Books (s_Id, s_Name, b_Id, b_name, b_Issue, b_End) " +
                                   "VALUES (@s_Id, @s_Name, @b_Id, @b_name, @b_Issue, @b_End);";

                SqlCommand cmd = new SqlCommand(sqlInsert, con);

                cmd.Parameters.AddWithValue("@s_Id", t1.Text);
                cmd.Parameters.AddWithValue("@s_Name", t2.Text);
                cmd.Parameters.AddWithValue("@b_Id", t3.Text);
                cmd.Parameters.AddWithValue("@b_name", t4.Text);
                cmd.Parameters.AddWithValue("@b_Issue", Convert.ToDateTime(t5.Text));  
                cmd.Parameters.AddWithValue("@b_End", Convert.ToDateTime(t6.Text));    

                cmd.ExecuteNonQuery();

                MessageBox.Show("Issue record added successfully.");
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sqlUpdate = "UPDATE Issue_Books SET s_Name = @s_Name, b_Id = @b_Id, b_name = @b_name, " +
                                   "b_Issue = @b_Issue, b_End = @b_End WHERE s_Id = @s_Id";
                SqlCommand cmd = new SqlCommand(sqlUpdate, con);
                cmd.Parameters.AddWithValue("@s_Id", t1.Text);
                cmd.Parameters.AddWithValue("@s_Name", t2.Text);
                cmd.Parameters.AddWithValue("@b_Id", t3.Text);
                cmd.Parameters.AddWithValue("@b_name", t4.Text);
                cmd.Parameters.AddWithValue("@b_Issue", Convert.ToDateTime(t5.Text));
                cmd.Parameters.AddWithValue("@b_End", Convert.ToDateTime(t6.Text));

                int rows = cmd.ExecuteNonQuery();
                {
                    MessageBox.Show("Issue record updated successfully.");
                }
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

        private void button6_Click(object sender, EventArgs e)
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();
            t5.Text = "";
            t6.Text = "";
            t1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 hh = new Form2();
            hh.Show();
        }
    }
}
