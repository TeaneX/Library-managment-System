using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_managment_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int lateDays = int.Parse(t1.Text);
                double finePerDay = double.Parse(t2.Text);
                double totalFine = lateDays * finePerDay;
                label4.Text = "This student's fine is " + totalFine.ToString("N2");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid input! Please enter numeric values only.\n" + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Issue_Books hh = new Issue_Books();
            hh.Show();
        }

        private void t1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
