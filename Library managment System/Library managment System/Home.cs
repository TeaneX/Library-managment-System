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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Books hh = new Books();
            hh.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student hh = new Student();
            hh.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Issue_Books hh = new Issue_Books();
            hh.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Return_Books hh = new Return_Books();
            hh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
