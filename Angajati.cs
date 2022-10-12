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
    public partial class Angajati : Form
    {
        public Angajati()
        {
            InitializeComponent();
            FillComboCodAngajat();
            FillComboNrFisaAngajat();
            FillComboNumeAngajat();
        }
        void FillComboCodAngajat()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM Angajati";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrFisa = dataReader.GetInt32("idAngajat");
                    comboBox1.Items.Add(sNrFisa);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboNrFisaAngajat()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM FisaAngajati";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrFisa = dataReader.GetInt32("NrFisaAngajat");
                    comboBox2.Items.Add(sNrFisa);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboNumeAngajat()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM FisaAngajati";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    string sNrFisa = dataReader.GetString("numeAngajat");
                    comboBox3.Items.Add(sNrFisa);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && comboBox2.Text == "" && comboBox3.Text == "")
            {
                MessageBox.Show("Nu există valori de curațat", "Mesaj de informare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Doriți să goliți celulele?", "Ștergere conținut celule", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    MessageBox.Show("Datele din celule au fost șterse", "Ștergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "")
            {
                MessageBox.Show("Nu există valori de curațat", "Mesaj de informare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Doriți să goliți celulele?", "Ștergere conținut celule", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    MessageBox.Show("Datele din celule au fost șterse", "Ștergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) idAngajat, NrFisaAngajat, numeAngajat, prenumeAngajat From Angajati order by idAngajat desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr.GetValue(0).ToString();
                textBox2.Text = sr.GetValue(1).ToString();
                textBox3.Text = sr.GetValue(2).ToString();
                textBox4.Text = sr.GetValue(3).ToString();
                MessageBox.Show("Ultimul ID de Angajat este: " + textBox1.Text + ". " +
                    "\nNumarul de fisa: " + textBox2.Text + ". " + 
                    "\nNumele Angajatului: " +textBox3.Text + ". "+
                    "\nPrenumele Angajatului: "+textBox4.Text);
            }
            connection.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Angajati( NrFisaAngajat, numeAngajat, prenumeAngajat) VALUES ('"+ int.Parse(textBox2.Text) + "','" + textBox3.Text + "','" + textBox4.Text + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes");
                connection.Close();
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori de referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Doriți să ștergeți înregistrarea?", "Ștergere Înregistrare", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM Angajati WHERE idAngajat='" + int.Parse(textBox1.Text) + "'", connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ștergere cu succes");
                    connection.Close();
                }
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE FisaAngajati SET NrFisaAngajat=@NrFisaAngajat, numeAngajat=@numeAngajat, prenumeAngajat=@prenumeAngajat WHERE idAngajat=@idAngajat", connection);
            command.Parameters.AddWithValue("@idAngajat", int.Parse(textBox1.Text));
            command.Parameters.AddWithValue("@NrFisaAngajat", int.Parse(textBox2.Text));
            command.Parameters.AddWithValue("@numeAngajat", textBox3.Text);
            command.Parameters.AddWithValue("@prenumeAngajat", textBox4.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Update cu succes", "Fereastră de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați forma anterioara", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Choose2 c2 = new Choose2();
                c2.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From Angajati where idAngajat = '" + comboBox1.SelectedItem.ToString() + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From Angajati where idAngajat = '" + comboBox1.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox1.Text = sr.GetValue(0).ToString();
                    textBox2.Text = sr.GetValue(1).ToString();
                    textBox3.Text = sr.GetValue(2).ToString();
                    textBox4.Text = sr.GetValue(3).ToString();
                }
                connection1.Close();
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
                SqlCommand command = new SqlCommand("Select * From FisaAngajati where NrFisaAngajat = '" + comboBox2.SelectedItem.ToString() + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From Angajati where NrFisaAngajat = '" + comboBox2.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox1.Text = sr.GetValue(0).ToString();
                    textBox2.Text = sr.GetValue(1).ToString();
                    textBox3.Text = sr.GetValue(2).ToString();
                    textBox4.Text = sr.GetValue(3).ToString();
                }
                connection1.Close();
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
                SqlCommand command = new SqlCommand("Select * From FisaAngajati where numeAngajat = '" + comboBox3.SelectedItem.ToString() + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From Angajati where numeAngajat = '" + comboBox3.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox1.Text = sr.GetValue(0).ToString();
                    textBox2.Text = sr.GetValue(1).ToString();
                    textBox3.Text = sr.GetValue(2).ToString();
                    textBox4.Text = sr.GetValue(3).ToString();
                }
                connection1.Close();
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
