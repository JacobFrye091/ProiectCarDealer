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
    public partial class FisaAngajati : Form
    {
        public FisaAngajati()
        {
            InitializeComponent();
            FillComboFisaAngajati();
            FillComboNumeAngajat();
        }
        void FillComboFisaAngajati()
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
                    comboBox1.Items.Add(sNrFisa);
                }
            }catch(Exception e)
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
                    string sNumAng = dataReader.GetString("numeAngajat");
                    comboBox2.Items.Add(sNumAng);
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
                SqlCommand command = new SqlCommand("Select * From FisaAngajati where NrFisaAngajat = '" + comboBox1.SelectedItem.ToString() + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From FisaAngajati where NrFisaAngajat = '" + comboBox1.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox2.Text = sr.GetValue(0).ToString();
                    textBox3.Text = sr.GetValue(1).ToString();
                    textBox4.Text = sr.GetValue(2).ToString();
                    textBox5.Text = sr.GetValue(3).ToString();
                    textBox6.Text = sr.GetValue(4).ToString();
                    textBox7.Text = sr.GetValue(5).ToString();
                    textBox8.Text = sr.GetValue(6).ToString();
                    dateTimePicker1.Text = sr.GetValue(7).ToString();
                    comboBox4.Text = sr.GetValue(8).ToString();
                    textBox10.Text = sr.GetValue(9).ToString();
                    textBox11.Text = sr.GetValue(10).ToString();
                    textBox12.Text = sr.GetValue(11).ToString();
                    comboBox3.Text = sr.GetValue(12).ToString();
                    dateTimePicker2.Text = sr.GetValue(13).ToString();
                    dateTimePicker3.Text = sr.GetValue(14).ToString();
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
                SqlCommand command = new SqlCommand("Select * From FisaAngajati where numeAngajat = '" + comboBox2.SelectedItem.ToString() + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From FisaAngajati where numeAngajat = '" + comboBox2.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox2.Text = sr.GetValue(0).ToString();
                    textBox3.Text = sr.GetValue(1).ToString();
                    textBox4.Text = sr.GetValue(2).ToString();
                    textBox5.Text = sr.GetValue(3).ToString();
                    textBox6.Text = sr.GetValue(4).ToString();
                    textBox7.Text = sr.GetValue(5).ToString();
                    textBox8.Text = sr.GetValue(6).ToString();
                    dateTimePicker1.Text = sr.GetValue(7).ToString();
                    comboBox4.Text = sr.GetValue(8).ToString();
                    textBox10.Text = sr.GetValue(9).ToString();
                    textBox11.Text = sr.GetValue(10).ToString();
                    textBox12.Text = sr.GetValue(11).ToString();
                    comboBox3.Text = sr.GetValue(12).ToString();
                    dateTimePicker2.Text = sr.GetValue(13).ToString();
                    dateTimePicker3.Text = sr.GetValue(14).ToString();
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
            if (textBox1.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From FisaAngajati where CNP = '" + textBox1.Text + "'", connection);
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From FisaAngajati where CNP = '" + textBox1.Text + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox2.Text = sr.GetValue(0).ToString();
                    textBox3.Text = sr.GetValue(1).ToString();
                    textBox4.Text = sr.GetValue(2).ToString();
                    textBox5.Text = sr.GetValue(3).ToString();
                    textBox6.Text = sr.GetValue(4).ToString();
                    textBox7.Text = sr.GetValue(5).ToString();
                    textBox8.Text = sr.GetValue(6).ToString();
                    dateTimePicker1.Text = sr.GetValue(7).ToString();
                    comboBox4.Text = sr.GetValue(8).ToString();
                    textBox10.Text = sr.GetValue(9).ToString();
                    textBox11.Text = sr.GetValue(10).ToString();
                    textBox12.Text = sr.GetValue(11).ToString();
                    comboBox3.Text = sr.GetValue(12).ToString();
                    dateTimePicker2.Text = sr.GetValue(13).ToString();
                    dateTimePicker3.Text = sr.GetValue(14).ToString();
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
            if (textBox1.Text == "" && comboBox1.Text==""&& comboBox2.Text=="")
            {
                MessageBox.Show("Nu există valori de curațat", "Mesaj de informare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Doriți să goliți celulele?", "Ștergere conținut celule", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textBox1.Text = "";
                    comboBox1.Text= "";
                    comboBox2.Text= "";
                    MessageBox.Show("Datele din celule au fost șterse", "Ștergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) NrFisaAngajat, numeAngajat, prenumeAngajat, CNP, actDeIdentitate, nr, eliberatDe, domiciliul, strada, nrStrada, apartament, sector From FisaAngajati order by NrFisaAngajat desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                textBox2.Text = sr.GetValue(0).ToString();
                textBox3.Text = sr.GetValue(1).ToString();
                textBox4.Text = sr.GetValue(2).ToString();
                textBox5.Text = sr.GetValue(3).ToString();
                textBox6.Text = sr.GetValue(4).ToString();
                textBox7.Text = sr.GetValue(5).ToString();
                textBox8.Text = sr.GetValue(6).ToString();
                comboBox4.Text = sr.GetValue(7).ToString();
                textBox10.Text = sr.GetValue(8).ToString();
                textBox11.Text = sr.GetValue(9).ToString();
                textBox12.Text = sr.GetValue(10).ToString();
                comboBox3.Text = sr.GetValue(11).ToString();
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                dateTimePicker3.Visible = false;
                label11.Visible = false;
                label17.Visible = false;
                label18.Visible = false;
                MessageBox.Show("Ultima fișă emisă este: " + textBox2.Text + "\n" +
                    "Numele Angajatului: " + textBox3.Text + "\n" +
                    "Prenumele Angajatului: "+textBox4.Text + "\n" + 
                    "Data Angajarii: "+dateTimePicker2.Text);
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                dateTimePicker3.Visible = true;
                label11.Visible = true;
                label17.Visible = true;
                label18.Visible = true;
            }
            connection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO FisaAngajati(numeAngajat, prenumeAngajat, CNP, actDeIdentitate, nr, eliberatDe, dataEliberarii, domiciliul, strada, nrStrada, apartament, sector, data_inceput_ang, data_semnare_contract) VALUES ('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + dateTimePicker1.Value.Date + "','" + comboBox4.Text.ToString() + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + comboBox3.Text.ToString() + "','" + dateTimePicker2.Value.Date + "','" + dateTimePicker3.Value.Date + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes","Inserare Fisa Angajat",MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                comboBox4.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                comboBox3.Text = "";
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori de referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == ""&& textBox4.Text == "" && textBox5.Text == "" && textBox6.Text == "" && textBox7.Text == "" && textBox7.Text == "" && textBox8.Text == "" && comboBox4.Text == "" && textBox10.Text == "" && textBox11.Text == "" && textBox12.Text == "" && comboBox3.Text == "")
            {
                MessageBox.Show("Nu există valori de curațat", "Mesaj de informare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Doriți să goliți celulele?", "Ștergere conținut celule", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    comboBox4.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    comboBox3.Text = "";
                    MessageBox.Show("Datele din celule au fost șterse", "Ștergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați forma anterioara", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Choose2 c2 = new Choose2();
                c2.Show();
            }
        }

        private void FisaAngajati_Load(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (MessageBox.Show("Doriți să ștergeți înregistrarea?", "Ștergere Înregistrare", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM FisaAngajati WHERE NrFisaAngajat='" + comboBox1.SelectedItem.ToString() + "'", connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ștergere cu succes");
                    connection.Close();
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE FisaAngajati SET numeAngajat=@numeAngajat, prenumeAngajat=@prenumeAngajat, CNP=@CNP, actDeIdentitate=@actDeIdentitate, nr=@nr, eliberatDe=@eliberatDe, dataEliberarii=@dataEliberarii, domiciliul=@domiciliul, strada=@strada, nrStrada=@nrStrada, apartament=@apartament, sector=@sector, data_inceput_ang =@data_inceput_ang, data_semnare_contract=@data_semnare_contract WHERE NrFisaAngajat=@NrFisaAngajat", connection);
            command.Parameters.AddWithValue("@NrFisaAngajat", textBox2.Text);
            command.Parameters.AddWithValue("@numeAngajat", textBox3.Text);
            command.Parameters.AddWithValue("@prenumeAngajat", textBox4.Text);
            command.Parameters.AddWithValue("@CNP", textBox5.Text);
            command.Parameters.AddWithValue("@actDeIdentitate", textBox6.Text);
            command.Parameters.AddWithValue("@nr", textBox7.Text);
            command.Parameters.AddWithValue("@eliberatDe", textBox8.Text);
            command.Parameters.AddWithValue("@dataEliberarii", dateTimePicker1.Value.Date);
            command.Parameters.AddWithValue("@domiciliul", comboBox4.Text.ToString());
            command.Parameters.AddWithValue("@strada", textBox10.Text);
            command.Parameters.AddWithValue("@nrStrada", textBox11.Text);
            command.Parameters.AddWithValue("@apartament", textBox12.Text);
            command.Parameters.AddWithValue("@sector", comboBox3.Text.ToString());
            command.Parameters.AddWithValue("@data_inceput_ang", dateTimePicker2.Value.Date);
            command.Parameters.AddWithValue("@data_semnare_contract", dateTimePicker3.Value.Date);
            command.ExecuteNonQuery();
            MessageBox.Show("Update cu succes", "Fereastră de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

        }
        Bitmap bitmap;
        private void button12_Click(object sender, EventArgs e)
        {
            int height = dataGridView1.Height;
            dataGridView1.Height = dataGridView1.RowCount * dataGridView1.RowTemplate.Height * 2;
            bitmap = new Bitmap(dataGridView1.Width, dataGridView1.Height);
            dataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView1.Width, dataGridView1.Height));
            printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            printPreviewDialog1.ShowDialog();
            dataGridView1.Height = height;

        }

        private void FisaAngajati_Click(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap,0,0);
        }
    }
}
