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
    public partial class Feedback : Form
    {
        public Feedback()
        {
            InitializeComponent();
            FillComboNrFormularFeedBack();
            FillComboNrFormularTestDrive();
            FillComboCodMasina();
            FillComboCodAngajat();
        }
        void FillComboNrFormularFeedBack()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM Feedback";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrForm = dataReader.GetInt32("idFormularFeedback");
                    comboBox1.Items.Add(sNrForm);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboNrFormularTestDrive()
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
                    int sNrForm = dataReader.GetInt32("idFormularTestDrive");
                    comboBox2.Items.Add(sNrForm);
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
                    comboBox3.Items.Add(sNrMas);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
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
                    int sNrAng = dataReader.GetInt32("idAngajat");
                    comboBox4.Items.Add(sNrAng);
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
                SqlCommand command = new SqlCommand("Select * From Feedback where idFormularFeedback = '" + Convert.ToInt32(comboBox1.SelectedItem.ToString()) + "'", connection);
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
            command1.CommandText = "Select * From Feedback where idFormularFeedback = '" + Convert.ToInt32(comboBox1.SelectedItem.ToString()) + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                comboBox1.Text = sr.GetValue(0).ToString();
                comboBox2.Text = sr.GetValue(1).ToString();
                comboBox3.Text = sr.GetValue(2).ToString();
                comboBox4.Text = sr.GetValue(3).ToString();
                textBox1.Text = sr.GetValue(4).ToString();
            }
            connection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From Feedback where idFormularTestDrive = '" + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + "'", connection);
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
            command1.CommandText = "Select * From Feedback where idFormularTestDrive = '" + Convert.ToInt32(comboBox2.SelectedItem.ToString()) + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                comboBox1.Text = sr.GetValue(0).ToString();
                comboBox2.Text = sr.GetValue(1).ToString();
                comboBox3.Text = sr.GetValue(2).ToString();
                comboBox4.Text = sr.GetValue(3).ToString();
                textBox1.Text = sr.GetValue(4).ToString();
            }
            connection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) idFormularFeedback, idFormularTestDrive, idMasina,idAngajat,feedback From Feedback order by idFormularFeedback desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                comboBox1.Text = sr.GetValue(0).ToString();
                comboBox2.Text = sr.GetValue(1).ToString();
                comboBox3.Text = sr.GetValue(2).ToString();
                comboBox4.Text = sr.GetValue(3).ToString();
                textBox1.Text = sr.GetValue(4).ToString();
            }
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Feedback(idFormularTestDrive, idMasina,idAngajat,feedback) VALUES ('" + Convert.ToInt32(comboBox2.Text.ToString()) + "','" + Convert.ToInt32(comboBox3.Text.ToString()) + "','" + Convert.ToInt32(comboBox4.Text.ToString()) + "','" + textBox1.Text + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes", "Inserare Formular Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                textBox1.Text = "";
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
                    SqlCommand command = new SqlCommand("DELETE FROM Feedback WHERE idFormularFeedback='" + Convert.ToInt32(comboBox1.Text.ToString()) + "'", connection);
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
            SqlCommand command = new SqlCommand("UPDATE Feedback SET idFormularTestDrive=@idFormularTestDrive, idMasina=@idMasina, idAngajat=@idAngajat, feedback=@feedback WHERE idFormularFeedback=@idFormularFeedback", connection);
            command.Parameters.AddWithValue("@idFormularFeedback", Convert.ToInt32(comboBox1.Text.ToString()));
            command.Parameters.AddWithValue("@idFormularTestDrive", Convert.ToInt32(comboBox2.Text.ToString()));
            command.Parameters.AddWithValue("@idMasina", Convert.ToInt32(comboBox3.Text.ToString()));
            command.Parameters.AddWithValue("@idAngajat", Convert.ToInt32(comboBox4.Text.ToString()));
            command.Parameters.AddWithValue("@feedback", textBox1.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Update cu succes", "Fereastră de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
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
    }

}
