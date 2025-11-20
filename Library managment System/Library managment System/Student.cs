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
    public partial class Student : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINRG-D1K35D6\SQLEXPRESS;Initial Catalog=Library_managment_system;Integrated Security=True");
        public Student()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void t5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hh = new Home();
            hh.Show();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string sqlInsert = "INSERT INTO Student (s_Id, s_Name, s_Birthday, s_Contact, s_Email, s_Address) " +
                                   "VALUES (@s_Id, @s_Name, @s_Birthday, @s_Contact, @s_Email, @s_Address);";

                SqlCommand cmd = new SqlCommand(sqlInsert, con);

                cmd.Parameters.AddWithValue("@s_Id", t1.Text);
                cmd.Parameters.AddWithValue("@s_Name", t2.Text);
                cmd.Parameters.AddWithValue("@s_Birthday", t3.Text);
                cmd.Parameters.AddWithValue("@s_Contact", t4.Text);
                cmd.Parameters.AddWithValue("@s_Email", t5.Text);
                cmd.Parameters.AddWithValue("@s_Address", t6.Text);

                cmd.ExecuteNonQuery(); 

                MessageBox.Show("Student record added successfully.");
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

        private void b1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sqlSearch = "SELECT s_Name, s_Birthday, s_Contact, s_Email, s_Address FROM Student WHERE s_Id = @s_Id";
                SqlCommand cmd = new SqlCommand(sqlSearch, con);
                cmd.Parameters.AddWithValue("@s_Id", t1.Text); 
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    t2.Text = reader["s_Name"].ToString();
                    t3.Text = reader["s_Birthday"].ToString();
                    t4.Text = reader["s_Contact"].ToString();
                    t5.Text = reader["s_Email"].ToString();
                    t6.Text = reader["s_Address"].ToString();
                }
                else
                {
                    MessageBox.Show("Student not found.");
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

        private void b4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sqlUpdate = "UPDATE Student SET s_Name = @s_Name, s_Birthday = @s_Birthday, " +
                                   "s_Contact = @s_Contact, s_Email = @s_Email, s_Address = @s_Address " +
                                   "WHERE s_Id = @s_Id";

                SqlCommand cmd = new SqlCommand(sqlUpdate, con);

                cmd.Parameters.AddWithValue("@s_Id", t1.Text);
                cmd.Parameters.AddWithValue("@s_Name", t2.Text);
                cmd.Parameters.AddWithValue("@s_Birthday", t3.Text);
                cmd.Parameters.AddWithValue("@s_Contact", t4.Text);
                cmd.Parameters.AddWithValue("@s_Email", t5.Text);
                cmd.Parameters.AddWithValue("@s_Address", t6.Text);

               int rows = cmd.ExecuteNonQuery();
                {
                    MessageBox.Show("Student record Update  successfully");
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

        private void b6_Click(object sender, EventArgs e)
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Clear();
            t5.Clear();
            t6.Clear();
            t1.Focus();
        }

        private void b5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string sqlDelete = "DELETE FROM Student WHERE s_Id = @s_Id";

                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("@s_Id", t1.Text);  

                int rowsAffected = cmd.ExecuteNonQuery();

                {
                    MessageBox.Show("Student record deleted successfully");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error: " + error.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
