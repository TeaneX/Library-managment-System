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
    public partial class Books : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=ADMINRG-D1K35D6\SQLEXPRESS;Initial Catalog=Library_managment_system;Integrated Security=True");
        public Books()
        {
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hh = new Home();
            hh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string sqlInsert = "INSERT INTO book (b_Id, b_name, b_Author, b_purchase, b_publication, b_Price, b_quantity) " +
                                   "VALUES (@b_Id, @b_name, @b_Author, @b_purchase, @b_publication, @b_Price, @b_quantity);";

                SqlCommand cmd = new SqlCommand(sqlInsert, con);

                cmd.Parameters.AddWithValue("@b_Id", t1.Text);
                cmd.Parameters.AddWithValue("@b_name", t2.Text);
                cmd.Parameters.AddWithValue("@b_Author", t3.Text);
                cmd.Parameters.AddWithValue("@b_purchase", Convert.ToDateTime(t4.Text));
                cmd.Parameters.AddWithValue("@b_publication", Convert.ToDateTime(t5.Text));
                cmd.Parameters.AddWithValue("@b_Price", t6.Text);
                cmd.Parameters.AddWithValue("@b_quantity", t7.Text);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Book inserted successfully.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sqlSearch = "SELECT b_name, b_Author, b_purchase, b_publication, b_Price, b_quantity FROM book WHERE b_Id = @b_Id";
                SqlCommand cmd = new SqlCommand(sqlSearch, con);
                cmd.Parameters.AddWithValue("@b_Id", t1.Text);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    t2.Text = reader["b_name"].ToString();
                    t3.Text = reader["b_Author"].ToString();
                    t4.Text = reader["b_purchase"].ToString();
                    t5.Text = reader["b_publication"].ToString();
                    t6.Text = reader["b_Price"].ToString();
                    t7.Text = reader["b_quantity"].ToString();

                }
                else
                {
                    MessageBox.Show("Book not found.");
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string sqlUpdate = "UPDATE book SET b_name = @b_name, b_Author = @b_Author, b_purchase = @b_purchase, " +
                                   "b_publication = @b_publication, b_Price = @b_Price, b_quantity = @b_quantity " +
                                   "WHERE b_Id = @b_Id";

                SqlCommand cmd = new SqlCommand(sqlUpdate, con);

                cmd.Parameters.AddWithValue("@b_Id", t1.Text);
                cmd.Parameters.AddWithValue("@b_name", t2.Text);
                cmd.Parameters.AddWithValue("@b_Author", t3.Text);
                cmd.Parameters.AddWithValue("@b_purchase", Convert.ToDateTime(t4.Text));
                cmd.Parameters.AddWithValue("@b_publication", Convert.ToDateTime(t5.Text));
                cmd.Parameters.AddWithValue("@b_Price", t6.Text);
                cmd.Parameters.AddWithValue("@b_quantity", t7.Text);

                int rows = cmd.ExecuteNonQuery();

                MessageBox.Show("Book updated successfully.");
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string sqlDelete = "DELETE FROM book WHERE b_Id = @b_Id";

                SqlCommand cmd = new SqlCommand(sqlDelete, con);
                cmd.Parameters.AddWithValue("@b_Id", t1.Text); 
                int rowsAffected = cmd.ExecuteNonQuery();

                {
                    MessageBox.Show("Book record Deleted successfully.");
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

        private void button6_Click(object sender, EventArgs e)
        {
            t1.Clear();
            t2.Clear();
            t3.Clear();
            t4.Text = "";
            t5.Text = "";
            t6.Clear();
            t7.Clear();
            t1.Focus();
        }

        private void b7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hh = new Home();
            hh.Show();
        }
    }
}
