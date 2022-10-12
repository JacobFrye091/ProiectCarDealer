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
    public partial class FacturiMasini1 : Form
    {
        public FacturiMasini1()
        {
            InitializeComponent();
            FillComboNumarFactura();
            FillComboNumarContract();
        }
        void FillComboNumarFactura()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM FacturiMasiniV";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrFact = dataReader.GetInt32("NrFactura");
                    comboBox1.Items.Add(sNrFact);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        void FillComboNumarContract()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM ContracteMasiniV";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrCnt = dataReader.GetInt32("NrContract");
                    comboBox2.Items.Add(sNrCnt);
                    comboBox4.Items.Add(sNrCnt);
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
                SqlCommand command = new SqlCommand("Select * From FacturiMasiniV where NrFactura = '" + comboBox1.SelectedItem.ToString() + "'", connection);
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
            command1.CommandText = "Select * From FacturiMasiniV where NrFactura = '" + comboBox1.SelectedItem.ToString() + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr.GetValue(0).ToString();
                comboBox4.Text = sr.GetValue(1).ToString();
                dateTimePicker2.Text = sr.GetValue(2).ToString();
                textBox2.Text = sr.GetValue(3).ToString();
                textBox3.Text = sr.GetValue(4).ToString();
                textBox4.Text = sr.GetValue(5).ToString();
                textBox5.Text = sr.GetValue(6).ToString();
                textBox6.Text = sr.GetValue(7).ToString();
                textBox7.Text = sr.GetValue(8).ToString();
                textBox8.Text = sr.GetValue(9).ToString();
                textBox9.Text = sr.GetValue(10).ToString();
                textBox10.Text = sr.GetValue(11).ToString();
                textBox11.Text = sr.GetValue(12).ToString();
                textBox12.Text = sr.GetValue(13).ToString();
                textBox13.Text = sr.GetValue(14).ToString();
                textBox14.Text = sr.GetValue(15).ToString();
                textBox15.Text = sr.GetValue(16).ToString();
                textBox16.Text = sr.GetValue(17).ToString();
                numericUpDown1.Text = sr.GetValue(18).ToString();
                numericUpDown2.Text = sr.GetValue(19).ToString();
                numericUpDown3.Text = sr.GetValue(20).ToString();
                numericUpDown4.Text = sr.GetValue(21).ToString();
                numericUpDown5.Text = sr.GetValue(22).ToString();
                comboBox5.Text = sr.GetValue(23).ToString();
            }
            connection1.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From ContracteMasiniV where NrContract = '" + comboBox2.SelectedItem.ToString() + "'", connection);
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
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-1RL6T53;Initial Catalog=ProiectLicenta;Integrated Security=True;");
            SqlCommand command = new SqlCommand("Select * From FacturiMasiniV where dataFactura = @dataFactura", connection);
            command.Parameters.AddWithValue("@dataFactura", dateTimePicker1.Value.Date);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command1 = new SqlCommand();
            SqlDataReader sr = null;
            command1.Connection = connection1;
            command1.CommandText = "Select * From FacturiMasiniV where dataFactura = '" + dateTimePicker1.Value.Date + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                comboBox4.Text = sr.GetValue(0).ToString();
                dateTimePicker2.Text = sr.GetValue(1).ToString();
                textBox2.Text = sr.GetValue(2).ToString();
                textBox3.Text = sr.GetValue(3).ToString();
                textBox4.Text = sr.GetValue(4).ToString();
                textBox5.Text = sr.GetValue(5).ToString();
                textBox6.Text = sr.GetValue(6).ToString();
                textBox7.Text = sr.GetValue(7).ToString();
                textBox8.Text = sr.GetValue(8).ToString();
                textBox9.Text = sr.GetValue(9).ToString();
                textBox10.Text = sr.GetValue(10).ToString();
                textBox11.Text = sr.GetValue(11).ToString();
                textBox12.Text = sr.GetValue(12).ToString();
                textBox13.Text = sr.GetValue(13).ToString();
                textBox14.Text = sr.GetValue(14).ToString();
                textBox15.Text = sr.GetValue(15).ToString();
                textBox16.Text = sr.GetValue(16).ToString();
                numericUpDown1.Text = sr.GetValue(17).ToString();
                numericUpDown2.Text = sr.GetValue(18).ToString();
                numericUpDown3.Text = sr.GetValue(19).ToString();
                numericUpDown4.Text = sr.GetValue(20).ToString();
                numericUpDown5.Text = sr.GetValue(21).ToString();
                comboBox5.Text = sr.GetValue(22).ToString();
            }
            connection1.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command = new SqlCommand("Select * From FacturiMasiniV where tipFactura = '" + comboBox3.SelectedItem.ToString() + "'", connection);
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
            command1.CommandText = "Select * From FacturiMasiniV where tipFactura = '" + comboBox3.SelectedItem.ToString() + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                comboBox4.Text = sr.GetValue(0).ToString();
                dateTimePicker2.Text = sr.GetValue(1).ToString();
                textBox2.Text = sr.GetValue(2).ToString();
                textBox3.Text = sr.GetValue(3).ToString();
                textBox4.Text = sr.GetValue(4).ToString();
                textBox5.Text = sr.GetValue(5).ToString();
                textBox6.Text = sr.GetValue(6).ToString();
                textBox7.Text = sr.GetValue(7).ToString();
                textBox8.Text = sr.GetValue(8).ToString();
                textBox9.Text = sr.GetValue(9).ToString();
                textBox10.Text = sr.GetValue(10).ToString();
                textBox11.Text = sr.GetValue(11).ToString();
                textBox12.Text = sr.GetValue(12).ToString();
                textBox13.Text = sr.GetValue(13).ToString();
                textBox14.Text = sr.GetValue(14).ToString();
                textBox15.Text = sr.GetValue(15).ToString();
                textBox16.Text = sr.GetValue(16).ToString();
                numericUpDown1.Text = sr.GetValue(17).ToString();
                numericUpDown2.Text = sr.GetValue(18).ToString();
                numericUpDown3.Text = sr.GetValue(19).ToString();
                numericUpDown4.Text = sr.GetValue(20).ToString();
                numericUpDown5.Text = sr.GetValue(21).ToString();
                comboBox5.Text = sr.GetValue(22).ToString();
            }
            connection1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) NrFactura, NrContract, dataFactura, seriaFactura, furnizor, nrRegComFurniz, capitalSocialFurniz, contFurniz, bancaFurniz, sediuFurniz, telefonFurniz, cumparator, nrRegComCump, CIF_Cump, sediuCump, contCump, bancaCump, denumireProdus, pretUnitarFaraTva, cotaTVA, valoareLei, valoareTVA, total, tipFactura From FacturiMasiniV order by NrFactura desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr.GetValue(0).ToString();
                comboBox4.Text = sr.GetValue(1).ToString();
                dateTimePicker2.Text = sr.GetValue(2).ToString();
                textBox2.Text = sr.GetValue(3).ToString();
                textBox3.Text = sr.GetValue(4).ToString();
                textBox4.Text = sr.GetValue(5).ToString();
                textBox5.Text = sr.GetValue(6).ToString();
                textBox6.Text = sr.GetValue(7).ToString();
                textBox7.Text = sr.GetValue(8).ToString();
                textBox8.Text = sr.GetValue(9).ToString();
                textBox9.Text = sr.GetValue(10).ToString();
                textBox10.Text = sr.GetValue(11).ToString();
                textBox11.Text = sr.GetValue(12).ToString();
                textBox12.Text = sr.GetValue(13).ToString();
                textBox13.Text = sr.GetValue(14).ToString();
                textBox14.Text = sr.GetValue(15).ToString();
                textBox15.Text = sr.GetValue(16).ToString();
                textBox16.Text = sr.GetValue(17).ToString();
                numericUpDown1.Text = sr.GetValue(18).ToString();
                numericUpDown2.Text = sr.GetValue(19).ToString();
                numericUpDown3.Text = sr.GetValue(20).ToString();
                numericUpDown4.Text = sr.GetValue(21).ToString();
                numericUpDown5.Text = sr.GetValue(22).ToString();
                comboBox5.Text = sr.GetValue(23).ToString();
            }
            connection.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO FacturiMasiniV(NrContract, dataFactura, seriaFactura, furnizor, nrRegComFurniz, capitalSocialFurniz, contFurniz, bancaFurniz, sediuFurniz, telefonFurniz, cumparator, nrRegComCump, CIF_Cump, sediuCump, contCump, bancaCump, denumireProdus, pretUnitarFaraTva, cotaTVA, valoareLei, valoareTVA, total, tipFactura) VALUES ('" + Convert.ToInt32(comboBox4.Text.ToString()) + "','" + dateTimePicker2.Value.Date + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + Convert.ToInt32(textBox5.Text) + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + Convert.ToInt32(numericUpDown1.Text) + "','" + Convert.ToInt32(numericUpDown2.Text) + "','" + Convert.ToInt32(numericUpDown3.Text) + "','" + Convert.ToInt32(numericUpDown4.Text) + "','" + Convert.ToInt32(numericUpDown5.Text) + "','" + comboBox5.Text.ToString() + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes", "Inserare Factura Cumparare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                textBox1.Text = "";
                comboBox4.Text = "";
                dateTimePicker2.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox11.Text = "";
                textBox12.Text = "";
                textBox13.Text = "";
                textBox14.Text = "";
                textBox15.Text = "";
                textBox16.Text = "";
                numericUpDown1.Text = "";
                numericUpDown2.Text = "";
                numericUpDown3.Text = "";
                numericUpDown4.Text = "";
                numericUpDown5.Text = "";
                comboBox5.Text = "";
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori de referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Doriți să ștergeți înregistrarea?", "Ștergere Înregistrare", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM FacturiMasiniV WHERE NrFactura='" + textBox1.Text + "'", connection);
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
            SqlCommand command = new SqlCommand("UPDATE FacturiMasiniV SET NrContract=@NrContract, dataFactura=@dataFactura, seriaFactura=@seriaFactura, furnizor=@furnizor, nrRegComFurniz=@nrRegComFurniz, capitalSocialFurniz=@capitalSocialFurniz, contFurniz=@contFurniz, bancaFurniz=@bancaFurniz, sediuFurniz=@sediuFurniz, telefonFurniz=@telefonFurniz, cumparator=@cumparator, nrRegComCump=@nrRegComCump, CIF_Cump=@CIF_Cump, sediuCump=@sediuCump, contCump=@contCump, bancaCump=@bancaCump, denumireProdus=@denumireProdus, pretUnitarFaraTva=@pretUnitarFaraTva, cotaTVA=@cotaTVA, valoareLei=@valoareLei, valoareTVA=@valoareTVA, total=@total, tipFactura=@tipFactura  WHERE NrFactura=@NrFactura", connection);
            command.Parameters.AddWithValue("@NrFactura", textBox1.Text);
            command.Parameters.AddWithValue("@NrContract", comboBox4.Text.ToString());
            command.Parameters.AddWithValue("@dataFactura", dateTimePicker2.Value.Date);
            command.Parameters.AddWithValue("@seriaFactura", textBox2.Text);
            command.Parameters.AddWithValue("@furnizor", textBox3.Text);
            command.Parameters.AddWithValue("@nrRegComFurniz", textBox4.Text);
            command.Parameters.AddWithValue("@capitalSocialFurniz", textBox5.Text);
            command.Parameters.AddWithValue("@contFurniz", textBox6.Text);
            command.Parameters.AddWithValue("@bancaFurniz", textBox7.Text);
            command.Parameters.AddWithValue("@sediuFurniz", textBox8.Text);
            command.Parameters.AddWithValue("@telefonFurniz", textBox9.Text);
            command.Parameters.AddWithValue("@cumparator", textBox10.Text);
            command.Parameters.AddWithValue("@nrRegComCump", textBox11.Text);
            command.Parameters.AddWithValue("@CIF_Cump", textBox12.Text);
            command.Parameters.AddWithValue("@sediuCump", textBox13.Text);
            command.Parameters.AddWithValue("@contCump", textBox14.Text);
            command.Parameters.AddWithValue("@bancaCump", textBox15.Text);
            command.Parameters.AddWithValue("@denumireProdus", textBox16.Text);
            command.Parameters.AddWithValue("@pretUnitarFaraTva", numericUpDown1.Text);
            command.Parameters.AddWithValue("@cotaTVA", numericUpDown2.Text);
            command.Parameters.AddWithValue("@valoareLei", numericUpDown3.Text);
            command.Parameters.AddWithValue("@valoareTVA", numericUpDown4.Text);
            command.Parameters.AddWithValue("@total", numericUpDown5.Text);
            command.Parameters.AddWithValue("@tipFactura", comboBox5.Text.ToString());
            command.ExecuteNonQuery();
            MessageBox.Show("Update cu succes", "Fereastră de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Nu există valori de curațat", "Mesaj de informare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Doriți să goliți celulele?", "Ștergere conținut celule", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textBox1.Text = "";
                    comboBox4.Text = "";
                    dateTimePicker2.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox12.Text = "";
                    textBox13.Text = "";
                    textBox14.Text = "";
                    textBox15.Text = "";
                    textBox16.Text = "";
                    numericUpDown1.Text = "";
                    numericUpDown2.Text = "";
                    numericUpDown3.Text = "";
                    numericUpDown4.Text = "";
                    numericUpDown5.Text = "";
                    comboBox5.Text = "";
                    MessageBox.Show("Datele din celule au fost șterse", "Ștergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să reveniți la forma anterioară?", "Casuță de informare", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Choose4 c4 = new Choose4();
                c4.Show();
            }
        }
    }
}
