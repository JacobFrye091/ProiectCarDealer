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
    public partial class FisaClienti : Form
    {
        public FisaClienti()
        {
            InitializeComponent();
            FillComboFisaClient();
            FillComboRezervare();
            FillComboNumeClientRezervare();
        }
        void FillComboFisaClient()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM FisaClienti";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrFisa = dataReader.GetInt32("NrFisaClient");
                    comboBox1.Items.Add(sNrFisa);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboRezervare()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM RezervariClienti";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrRez = dataReader.GetInt32("idRezervare");
                    comboBox2.Items.Add(sNrRez);
                    comboBox4.Items.Add(sNrRez);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboNumeClientRezervare()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM RezervariClienti";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    string sNume = dataReader.GetString("numeClient");
                    comboBox3.Items.Add(sNume);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați forma anterioara", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Choose3 c3 = new Choose3();
                c3.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) NrFisaClient, idRezervare, numeClient, prenumeClient, domiciliat, judet, serieCI, nrCI, CNP, telefon, email, confirmareGDPR From FisaClienti order by NrFisaClient desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr.GetValue(0).ToString();
                comboBox4.Text = sr.GetValue(1).ToString();
                textBox2.Text = sr.GetValue(2).ToString();
                textBox3.Text = sr.GetValue(3).ToString();
                comboBox5.Text = sr.GetValue(4).ToString();
                textBox4.Text = sr.GetValue(5).ToString();
                textBox5.Text = sr.GetValue(6).ToString();
                textBox6.Text = sr.GetValue(7).ToString();
                textBox7.Text = sr.GetValue(8).ToString();
                textBox8.Text = sr.GetValue(9).ToString();
                textBox9.Text = sr.GetValue(10).ToString();
                comboBox6.Text = sr.GetValue(11).ToString();
                MessageBox.Show("Ultima Fisa de Client emisa este: " + textBox1.Text + ". " +
                    "\nCu Numarul de Rezervare: " + comboBox4.Text + ". " +
                    "\nNumele Clientului : " + textBox2.Text + ". " + 
                    "\nPrenumele Clientului: "+ textBox3.Text + ". ");
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == ""  && textBox8.Text == "" && textBox9.Text == ""  && comboBox4.Text == "" && comboBox5.Text == "" && comboBox6.Text == "")
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
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    comboBox4.Text = "";
                    comboBox5.Text = "";
                    comboBox6.Text = "";
                    MessageBox.Show("Datele din celule au fost șterse", "Ștergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO FisaClienti(idRezervare, numeClient, prenumeClient, domiciliat, judet, serieCI, nrCI, CNP, telefon, email, confirmareGDPR) VALUES ('" + Convert.ToInt32(comboBox4.SelectedItem.ToString()) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox5.SelectedItem.ToString() + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox6.Text.ToString() + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes", "Inserare Fisa Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                comboBox4.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
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
                    SqlCommand command = new SqlCommand("DELETE FROM FisaClienti WHERE NrFisaClient='" + textBox1.Text + "'", connection);
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
            SqlCommand command = new SqlCommand("UPDATE FisaClienti SET idRezervare=@idRezervare, numeClient=@numeClient, prenumeClient=@prenumeClient, domiciliat=@domiciliat, judet=@judet, serieCI=@serieCI, nrCI=@nrCI, CNP=@CNP, telefon=@telefon, email=@email, confirmareGDPR=@confirmareGDPR WHERE NrFisaClient=@NrFisaClient", connection);
            command.Parameters.AddWithValue("@NrFisaClient", textBox1.Text);
            command.Parameters.AddWithValue("@idRezervare", comboBox4.Text.ToString());
            command.Parameters.AddWithValue("@numeClient", textBox2.Text);
            command.Parameters.AddWithValue("@prenumeClient", textBox3.Text);
            command.Parameters.AddWithValue("@domiciliat", comboBox5.Text.ToString());
            command.Parameters.AddWithValue("@judet", textBox4.Text);
            command.Parameters.AddWithValue("@serieCI", textBox5.Text);
            command.Parameters.AddWithValue("@nrCI", textBox6.Text);
            command.Parameters.AddWithValue("@CNP", textBox7.Text);
            command.Parameters.AddWithValue("@telefon", textBox8.Text);
            command.Parameters.AddWithValue("@email", textBox3.Text);
            command.Parameters.AddWithValue("@confirmareGDPR", comboBox6.Text.ToString());
            command.ExecuteNonQuery();
            MessageBox.Show("Update cu succes", "Fereastră de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From FisaClienti where NrFisaClient = '" + comboBox1.SelectedItem.ToString() + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From FisaClienti where NrFisaClient = '" + comboBox1.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox1.Text = sr.GetValue(0).ToString();
                    comboBox4.Text = sr.GetValue(1).ToString();
                    textBox2.Text = sr.GetValue(2).ToString();
                    textBox3.Text = sr.GetValue(3).ToString();
                    comboBox5.Text = sr.GetValue(4).ToString();
                    textBox4.Text = sr.GetValue(5).ToString();
                    textBox5.Text = sr.GetValue(6).ToString();
                    textBox6.Text = sr.GetValue(7).ToString();
                    textBox7.Text = sr.GetValue(8).ToString();
                    textBox8.Text = sr.GetValue(9).ToString();
                    textBox9.Text = sr.GetValue(10).ToString();
                    comboBox6.Text = sr.GetValue(11).ToString();
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
                SqlCommand command = new SqlCommand("Select * From RezervariClienti where numeClient = '" + comboBox3.SelectedItem.ToString() + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From RezervariClienti where numeClient = '" + comboBox3.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox1.Text = sr.GetValue(0).ToString();
                    comboBox4.Text = sr.GetValue(1).ToString();
                    textBox2.Text = sr.GetValue(2).ToString();
                    textBox3.Text = sr.GetValue(3).ToString();
                    comboBox5.Text = sr.GetValue(4).ToString();
                    textBox4.Text = sr.GetValue(5).ToString();
                    textBox5.Text = sr.GetValue(6).ToString();
                    textBox6.Text = sr.GetValue(7).ToString();
                    textBox7.Text = sr.GetValue(8).ToString();
                    textBox8.Text = sr.GetValue(9).ToString();
                    textBox9.Text = sr.GetValue(10).ToString();
                    comboBox6.Text = sr.GetValue(11).ToString();
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
                SqlCommand command = new SqlCommand("Select * From RezervariClienti where idRezervare = '" + comboBox2.SelectedItem.ToString() + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From RezervariClienti where idRezervare = '" + comboBox2.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox1.Text = sr.GetValue(0).ToString();
                    comboBox4.Text = sr.GetValue(1).ToString();
                    textBox2.Text = sr.GetValue(2).ToString();
                    textBox3.Text = sr.GetValue(3).ToString();
                    comboBox5.Text = sr.GetValue(4).ToString();
                    textBox4.Text = sr.GetValue(5).ToString();
                    textBox5.Text = sr.GetValue(6).ToString();
                    textBox6.Text = sr.GetValue(7).ToString();
                    textBox7.Text = sr.GetValue(8).ToString();
                    textBox8.Text = sr.GetValue(9).ToString();
                    textBox9.Text = sr.GetValue(10).ToString();
                    comboBox6.Text = sr.GetValue(11).ToString();
                }
                connection1.Close();
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
