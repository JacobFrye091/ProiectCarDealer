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

namespace ProiectLicenta
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlDataAdapter dataAdapter = new SqlDataAdapter("Select Count(*) From Utilizatori where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", connection);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            if (dataTable.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Choose1 c1 = new Choose1();
                c1.Show();
            }
            else
            {
                MessageBox.Show("Datele de înregistrare au fost introduse eronat!");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriţi sa închideţi aplicaţia", "Închidere aplicaţie", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
