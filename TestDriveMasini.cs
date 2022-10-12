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
    public partial class TestDriveMasini : Form
    {
        public TestDriveMasini()
        {
            InitializeComponent();
            FillComboNumarFormularTestDrive();
            FillComboCodMasina();
            FillComboCodAngajat();
            FillComboCodCheieMasina();
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
                    int sAng = dataReader.GetInt32("idAngajat");
                    comboBox9.Items.Add(sAng);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboNumarFormularTestDrive()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM TestDrive";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrFrmTest = dataReader.GetInt32("idFormularTestDrive");
                    comboBox1.Items.Add(sNrFrmTest);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboCodMasina()
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
                    int sNrMas = dataReader.GetInt32("idMasina");
                    comboBox2.Items.Add(sNrMas);
                    comboBox5.Items.Add(sNrMas);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboCodCheieMasina()
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
                    int sNrChMas = dataReader.GetInt32("idCheieMasina");
                    comboBox3.Items.Add(sNrChMas);
                    comboBox6.Items.Add(sNrChMas);
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
                SqlCommand command = new SqlCommand("Select * From TestDrive where idFormularTestDrive = '" + Convert.ToInt32(comboBox1.SelectedItem.ToString()) + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command1 = new SqlCommand();
            SqlDataReader sr = null;
            command1.Connection = connection1;
            command1.CommandText = "Select * From TestDrive where idFormularTestDrive = '" + Convert.ToInt32(comboBox1.SelectedItem.ToString()) + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                textBox5.Text = sr.GetValue(0).ToString();
                comboBox5.Text = sr.GetValue(1).ToString();
                comboBox6.Text = sr.GetValue(2).ToString();
                comboBox7.Text = sr.GetValue(3).ToString();
                comboBox8.Text = sr.GetValue(4).ToString();
                textBox1.Text = sr.GetValue(5).ToString();
                textBox2.Text = sr.GetValue(6).ToString();
                textBox3.Text = sr.GetValue(7).ToString();
                numericUpDown1.Text = sr.GetValue(8).ToString();
                comboBox9.Text = sr.GetValue(9).ToString();
                textBox4.Text = sr.GetValue(10).ToString();
                dateTimePicker1.Text = sr.GetValue(11).ToString();
                dateTimePicker2.Text = sr.GetValue(12).ToString();
                numericUpDown2.Text = sr.GetValue(13).ToString();
            }
            connection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From TestDrive where idMasina = '" + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command1 = new SqlCommand();
            SqlDataReader sr = null;
            command1.Connection = connection1;
            command1.CommandText = "Select * From TestDrive where idMasina = '" + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                textBox5.Text = sr.GetValue(0).ToString();
                comboBox5.Text = sr.GetValue(1).ToString();
                comboBox6.Text = sr.GetValue(2).ToString();
                comboBox7.Text = sr.GetValue(3).ToString();
                comboBox8.Text = sr.GetValue(4).ToString();
                textBox1.Text = sr.GetValue(5).ToString();
                textBox2.Text = sr.GetValue(6).ToString();
                textBox3.Text = sr.GetValue(7).ToString();
                numericUpDown1.Text = sr.GetValue(8).ToString();
                comboBox9.Text = sr.GetValue(9).ToString();
                textBox4.Text = sr.GetValue(10).ToString();
                dateTimePicker1.Text = sr.GetValue(11).ToString();
                dateTimePicker2.Text = sr.GetValue(12).ToString();
                numericUpDown2.Text = sr.GetValue(13).ToString();
            }
            connection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From TestDrive where idCheieMasina = '" + Convert.ToInt32(comboBox3.SelectedItem.ToString()) + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command1 = new SqlCommand();
            SqlDataReader sr = null;
            command1.Connection = connection1;
            command1.CommandText = "Select * From TestDrive where idCheieMasina = '" + Convert.ToInt32(comboBox3.SelectedItem.ToString()) + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                textBox5.Text = sr.GetValue(0).ToString();
                comboBox5.Text = sr.GetValue(1).ToString();
                comboBox6.Text = sr.GetValue(2).ToString();
                comboBox7.Text = sr.GetValue(3).ToString();
                comboBox8.Text = sr.GetValue(4).ToString();
                textBox1.Text = sr.GetValue(5).ToString();
                textBox2.Text = sr.GetValue(6).ToString();
                textBox3.Text = sr.GetValue(7).ToString();
                numericUpDown1.Text = sr.GetValue(8).ToString();
                comboBox9.Text = sr.GetValue(9).ToString();
                textBox4.Text = sr.GetValue(10).ToString();
                dateTimePicker1.Text = sr.GetValue(11).ToString();
                dateTimePicker2.Text = sr.GetValue(12).ToString();
                numericUpDown2.Text = sr.GetValue(13).ToString();
            }
            connection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1)  idFormularTestDrive, idMasina, idCheieMasina, permis, marca,model,versiune,nrInmatriculare,nivelCombustibil,idAngajat,nrPermisClient,dataValabilitateDeLa,dataValabilitatePanaLa,timpAlocat From TestDrive order by idFormularTestDrive desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                textBox5.Text = sr.GetValue(0).ToString();
                comboBox5.Text = sr.GetValue(1).ToString();
                comboBox6.Text = sr.GetValue(2).ToString();
                comboBox7.Text = sr.GetValue(3).ToString();
                comboBox8.Text = sr.GetValue(4).ToString();
                textBox1.Text = sr.GetValue(5).ToString();
                textBox2.Text = sr.GetValue(6).ToString();
                textBox3.Text = sr.GetValue(7).ToString();
                numericUpDown1.Text = sr.GetValue(8).ToString();
                comboBox9.Text = sr.GetValue(9).ToString();
                textBox4.Text = sr.GetValue(10).ToString();
                dateTimePicker1.Text = sr.GetValue(11).ToString();
                dateTimePicker2.Text = sr.GetValue(12).ToString();
                numericUpDown2.Text = sr.GetValue(13).ToString();
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO TestDrive(idMasina, idCheieMasina, permis, marca,model,versiune,nrInmatriculare,nivelCombustibil,idAngajat,nrPermisClient,dataValabilitateDeLa,dataValabilitatePanaLa,timpAlocat) VALUES ('" + Convert.ToInt32(comboBox5.Text.ToString()) + "','" + Convert.ToInt32(comboBox6.Text.ToString()) + "','" + comboBox7.Text.ToString() + "','" + comboBox8.Text.ToString() + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + Convert.ToInt32(numericUpDown1.Value) + "','" + Convert.ToInt32(comboBox9.Text.ToString()) + "','" + Convert.ToInt32(textBox4.Text) + "','" + dateTimePicker1.Value.Date + "','" + dateTimePicker2.Value.Date + "','" + Convert.ToInt32(numericUpDown2.Value) + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes", "Inserare Angajat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                textBox5.Text = "";
                comboBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                numericUpDown1.Text = "";
                comboBox9.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Text = "";
                dateTimePicker2.Text = "";
                numericUpDown2.Text = "";
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori de referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                if (MessageBox.Show("Doriți să ștergeți înregistrarea?", "Ștergere Înregistrare", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM TestDrive WHERE idFormularTestDrive='" + Convert.ToInt32(textBox5.Text) + "'", connection);
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
            SqlCommand command = new SqlCommand("UPDATE TestDrive SET idMasina=@idMasina, idCheieMasina=@idCheieMasina, permis=@permis, marca=@marca,model=@model,versiune=@versiune,nrInmatriculare=@nrInmatriculare,nivelCombustibil=@nivelCombustibil,idAngajat=@idAngajat,nrPermisClient=@nrPermisClient,dataValabilitateDeLa=@dataValabilitatePanaLa,timpAlocat=@timpAlocat WHERE idFormularTestDrive=@idFormularTestDrive", connection);
            command.Parameters.AddWithValue("@idFormularTestDrive", Convert.ToInt32(textBox5.Text));
            command.Parameters.AddWithValue("@idMasina", Convert.ToInt32(comboBox5.Text.ToString()));
            command.Parameters.AddWithValue("@idCheieMasina", Convert.ToInt32(comboBox6.Text.ToString()));
            command.Parameters.AddWithValue("@permis", comboBox7.Text);
            command.Parameters.AddWithValue("@marca", comboBox8.Text);
            command.Parameters.AddWithValue("@model", textBox1.Text);
            command.Parameters.AddWithValue("@versiune", textBox2.Text);
            command.Parameters.AddWithValue("@nrInmatriculare", textBox3.Text);
            command.Parameters.AddWithValue("@nivelCombustibil", Convert.ToInt32(numericUpDown1.Text));
            command.Parameters.AddWithValue("@idAngajat", Convert.ToInt32(comboBox9.Text.ToString()));
            command.Parameters.AddWithValue("@nrPermisClient", Convert.ToInt32(textBox4.Text.ToString()));
            command.Parameters.AddWithValue("@dataValabilitateDela", dateTimePicker1.Value.Date);
            command.Parameters.AddWithValue("@dataValabilitatePanala", dateTimePicker2.Value.Date);
            command.Parameters.AddWithValue("@timpAlocat", Convert.ToInt32(numericUpDown2.Text));
            command.ExecuteNonQuery();
            MessageBox.Show("Update cu succes", "Fereastră de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
