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
    public partial class RezervariClienti : Form
    {
        public RezervariClienti()
        {
            InitializeComponent();
            FillComboCodRezervare();
            FillComboAngajat();
        }
        void FillComboCodRezervare()
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
                    int sRez = dataReader.GetInt32("idRezervare");
                    comboBox1.Items.Add(sRez);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboAngajat()
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
                    int sAng = dataReader.GetInt32("idAngajat");
                    comboBox2.Items.Add(sAng);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From RezervariClienti where idRezervare = '" + Convert.ToInt32(comboBox1.SelectedItem.ToString()) + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From RezervariClienti where idRezervare = '" + Convert.ToInt32(comboBox1.SelectedItem.ToString()) + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox1.Text = sr.GetValue(0).ToString();
                    textBox2.Text = sr.GetValue(1).ToString();
                    textBox3.Text = sr.GetValue(2).ToString();
                    dateTimePicker1.Text = sr.GetValue(3).ToString();
                    comboBox2.Text = sr.GetValue(4).ToString();
                }
                connection1.Close();
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) idRezervare, numeClient, prenumeClient, dataRezervare, idAngajat From RezervariClienti order by idRezervare desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr.GetValue(0).ToString();
                textBox2.Text = sr.GetValue(1).ToString();
                textBox3.Text = sr.GetValue(2).ToString();
                dateTimePicker1.Text = sr.GetValue(3).ToString();
                comboBox2.Text = sr.GetValue(4).ToString();
                MessageBox.Show("Ultima Programare emisa este pe data: " + dateTimePicker1.Text + ". " +
                    "\nCu Codul de Programare: " + textBox1.Text + ". " +
                    "\nNumele Clientului : " + textBox2.Text + ". " +
                    "\nPrenumele Clientului: " + textBox3.Text + ". ");
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text == "" && dateTimePicker1.Text == "" && comboBox2.Text == "")
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
                    dateTimePicker1.Text = "";
                    comboBox2.Text = "";
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
                SqlCommand command = new SqlCommand("INSERT INTO RezervariClienti(numeClient, prenumeClient, dataRezervare, idAngajat) VALUES ('" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value.Date + "','" + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes", "Inserare Fisa Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Text = "";
                comboBox2.Text = "";
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
                    SqlCommand command = new SqlCommand("DELETE FROM RezervariClienti WHERE idRezervare='" + textBox1.Text + "'", connection);
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
            SqlCommand command = new SqlCommand("UPDATE RezervariClienti SET numeClient=@numeClient, prenumeClient=@prenumeClient, dataRezervare=@dataRezervare, idAngajat=@idAngajat WHERE idRezervare=@idRezervare", connection);
            command.Parameters.AddWithValue("@idRezervare", textBox1.Text);
            command.Parameters.AddWithValue("@numeClient", textBox2.Text);
            command.Parameters.AddWithValue("@prenumeClient", textBox3.Text);
            command.Parameters.AddWithValue("@dataRezervare", dateTimePicker1.Value.Date);
            command.Parameters.AddWithValue("@idAngajat", comboBox2.Text.ToString());
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
            if(MessageBox.Show("Doriți să accesați forma anterioara", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Choose3 c3 = new Choose3();
                c3.Show();
            }
        }
    }
}
