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
    public partial class CheiMasini : Form
    {
        public CheiMasini()
        {
            InitializeComponent();
            FillComboNCodCheieMasina();
            FillComboNCodMasina();
            FillComboNLocatorMasina();
        }
        void FillComboNCodCheieMasina()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM CheiMasini";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrCnt = dataReader.GetInt32("idCheieMasina");
                    comboBox1.Items.Add(sNrCnt);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboNCodMasina()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM Masini";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrCnt = dataReader.GetInt32("idMasina");
                    comboBox2.Items.Add(sNrCnt);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboNLocatorMasina()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM CheiMasini";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrCnt = dataReader.GetInt32("locator");
                    comboBox3.Items.Add(sNrCnt);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați forma anterioara", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Choose4 c4 = new Choose4();
                c4.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From CheiMasini where idCheieMasina = '" + Convert.ToInt32(comboBox1.SelectedItem.ToString()) + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From CheiMasini where idMasina = '" + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From CheiMasini where locator = '" + Convert.ToInt32(comboBox3.SelectedItem.ToString()) + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) idCheieMasina, idMasina, locator From CheiMasini order by idCheieMasina desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                comboBox1.Text = sr.GetValue(0).ToString();
                comboBox2.Text = sr.GetValue(1).ToString();
                comboBox3.Text = sr.GetValue(2).ToString();
                MessageBox.Show("Ultima cheie înregistrată este: " + comboBox1.Text + "\n" +
                    "Locatorul: " + comboBox3.Text + "\n");
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO CheiMasini(idMasina, locator) VALUES ('" + Convert.ToInt32(comboBox2.Text.ToString()) + "','" + comboBox3.Text.ToString() + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes", "Inserare Cheie Masina", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori de referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (MessageBox.Show("Doriți să ștergeți înregistrarea?", "Ștergere Înregistrare", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM CheiMasini WHERE idCheieMasina='" + comboBox1.Text + "'", connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ștergere cu succes");
                    connection.Close();
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE CheiMasini SET idMasina=@idMasina, locator=@locator WHERE idCheieMasina=@idCheieMasina", connection);
            command.Parameters.AddWithValue("@idCheieMasina", Convert.ToInt32(comboBox1.Text.ToString()));
            command.Parameters.AddWithValue("@idMasina", Convert.ToInt32(comboBox2.Text.ToString()));
            command.Parameters.AddWithValue("@locator", Convert.ToInt32(comboBox3.Text.ToString()));
            command.ExecuteNonQuery();
            MessageBox.Show("Update cu succes", "Fereastră de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }
    }
}
