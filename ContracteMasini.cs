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
    public partial class ContracteMasini : Form
    {
        public ContracteMasini()
        {
            InitializeComponent();
            FillComboNumarContract();
        }
        void FillComboNumarContract()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM ContracteMasini";
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
                    comboBox1.Items.Add(sNrCnt);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
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

        private void button5_Click(object sender, EventArgs e)
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
                SqlCommand command = new SqlCommand("Select * From ContracteMasini where NrContract = '" + comboBox1.SelectedItem.ToString() + "'", connection);
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
            command1.CommandText = "Select * From ContracteMasini where NrContract = '" + comboBox1.SelectedItem.ToString() + "'";
            connection1.Open();
            sr = command1.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr.GetValue(0).ToString();
                comboBox2.Text = sr.GetValue(1).ToString();
                textBox2.Text = sr.GetValue(2).ToString();
                comboBox3.Text = sr.GetValue(3).ToString();
                comboBox4.Text = sr.GetValue(4).ToString();
                textBox4.Text = sr.GetValue(5).ToString();
                textBox5.Text = sr.GetValue(6).ToString();
                comboBox5.Text = sr.GetValue(7).ToString();
                textBox6.Text = sr.GetValue(8).ToString();
                numericUpDown1.Text = sr.GetValue(9).ToString();
                textBox11.Text = sr.GetValue(10).ToString();
                comboBox8.Text = sr.GetValue(11).ToString();
                comboBox7.Text = sr.GetValue(12).ToString();
                textBox9.Text = sr.GetValue(13).ToString();
                textBox8.Text = sr.GetValue(14).ToString();
                comboBox6.Text = sr.GetValue(15).ToString();
                textBox7.Text = sr.GetValue(16).ToString();
                numericUpDown2.Text = sr.GetValue(17).ToString();
                textBox12.Text = sr.GetValue(18).ToString();
                dateTimePicker1.Text = sr.GetValue(19).ToString();
            }
            connection1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) NrContract, RolContract, NumeVanzator, FunctiaVanzator, DomiciliuVanzator, JudetVanzator, CodPostalVanzator, SectorVanzator, StradaVanzator, NrStradaVanzator, NumeCumparator, FunctiaCumparator, DomiciliuCumparator, JudetCumparator, CodPostalCumparator, SectorCumparator, StradaCumparator, NrStradaCumparator, PretContract, DataContract From ContracteMasini order by NrContract desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr.GetValue(0).ToString();
                comboBox2.Text = sr.GetValue(1).ToString();
                textBox2.Text = sr.GetValue(2).ToString();
                comboBox3.Text = sr.GetValue(3).ToString();
                comboBox4.Text = sr.GetValue(4).ToString();
                textBox4.Text = sr.GetValue(5).ToString();
                textBox5.Text = sr.GetValue(6).ToString();
                comboBox5.Text = sr.GetValue(7).ToString();
                textBox6.Text = sr.GetValue(8).ToString();
                numericUpDown1.Text = sr.GetValue(9).ToString();
                textBox11.Text = sr.GetValue(10).ToString();
                comboBox8.Text = sr.GetValue(11).ToString();
                comboBox7.Text = sr.GetValue(12).ToString();
                textBox9.Text = sr.GetValue(13).ToString();
                textBox8.Text = sr.GetValue(14).ToString();
                comboBox6.Text = sr.GetValue(15).ToString();
                textBox7.Text = sr.GetValue(16).ToString();
                numericUpDown2.Text = sr.GetValue(17).ToString();
                textBox12.Text = sr.GetValue(18).ToString();
                dateTimePicker1.Text = sr.GetValue(19).ToString();
            }
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ContracteMasini(RolContract, NumeVanzator, FunctiaVanzator, DomiciliuVanzator, JudetVanzator, CodPostalVanzator, SectorVanzator, StradaVanzator, NrStradaVanzator, NumeCumparator, FunctiaCumparator, DomiciliuCumparator, JudetCumparator, CodPostalCumparator, SectorCumparator, StradaCumparator, NrStradaCumparator, PretContract, DataContract) VALUES ('" + comboBox2.Text.ToString() + "','" + textBox2.Text + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox5.Text.ToString() + "','" + textBox6.Text + "','" + numericUpDown1.Text + "','" + textBox11.Text +  "','" + comboBox8.Text.ToString() + "','" + comboBox7.Text.ToString() + "','" + textBox9.Text + "','" + textBox8.Text + "','" + comboBox6.Text.ToString() + "','" + textBox7.Text + "','" + numericUpDown2.Text + "','" + textBox12.Text + "','" + dateTimePicker1.Value.Date + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes", "Inserare Contract Cumparare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                textBox1.Text = "";
                comboBox2.Text = "";
                textBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox5.Text = "";
                textBox6.Text = "";
                numericUpDown1.Text = "";
                textBox11.Text = "";
                comboBox8.Text = "";
                comboBox7.Text = "";
                textBox9.Text = "";
                textBox8.Text = "";
                comboBox6.Text = "";
                textBox7.Text = "";
                numericUpDown2.Text = "";
                textBox12.Text = "";
                dateTimePicker1.Text = "";
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori de referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" )
            {
                MessageBox.Show("Nu există valori de curațat", "Mesaj de informare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Doriți să goliți celulele?", "Ștergere conținut celule", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    textBox1.Text = "";
                    comboBox2.Text = "";
                    textBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox5.Text = "";
                    textBox6.Text = "";
                    numericUpDown1.Text = "";
                    textBox11.Text = "";
                    comboBox8.Text = "";
                    comboBox7.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                    comboBox6.Text = "";
                    textBox7.Text = "";
                    numericUpDown2.Text = "";
                    textBox12.Text = "";
                    dateTimePicker1.Text = "";
                    MessageBox.Show("Datele din celule au fost șterse", "Ștergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Doriți să ștergeți înregistrarea?", "Ștergere Înregistrare", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM ContracteMasini WHERE NrContract='" + textBox1.Text + "'", connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Ștergere cu succes");
                    connection.Close();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand("UPDATE ContracteMasini SET RolContract=@RolContract, NumeVanzator=@NumeVanzator, FunctiaVanzator=@FunctiaVanzator, DomiciliuVanzator=@DomiciliuVanzator, JudetVanzator=@JudetVanzator, CodPostalVanzator=@CodPostalVanzator, SectorVanzator=@SectorVanzator, StradaVanzator=@StradaVanzator, NrStradaVanzator=@NrStradaVanzator, NumeCumparator=@NumeCumparator, FunctiaCumparator=@FunctiaCumparator, DomiciliuCumparator=@DomiciliuCumparator, JudetCumparator=@JudetCumparator, CodPostalCumparator=@CodPostalCumparator, SectorCumparator=@SectorCumparator, StradaCumparator=@StradaCumparator, NrStradaCumparator=@NrStradaCumparator, PretContract=@PretContract, DataContract=@DataContract WHERE NrContract=@NrContract", connection);
            command.Parameters.AddWithValue("@NrContract", textBox1.Text);
            command.Parameters.AddWithValue("@RolContract", comboBox2.Text.ToString());
            command.Parameters.AddWithValue("@NumeVanzator", textBox2.Text);
            command.Parameters.AddWithValue("@FunctiaVanzator", comboBox3.Text.ToString());
            command.Parameters.AddWithValue("@DomiciliuVanzator", comboBox4.Text.ToString());
            command.Parameters.AddWithValue("@JudetVanzator", textBox4.Text);
            command.Parameters.AddWithValue("@CodPostalVanzator", textBox5.Text);
            command.Parameters.AddWithValue("@SectorVanzator", comboBox5.Text.ToString());
            command.Parameters.AddWithValue("@StradaVanzator", textBox6.Text);
            command.Parameters.AddWithValue("@NrStradaVanzator", numericUpDown1.Text);
            command.Parameters.AddWithValue("@NumeCumparator", textBox11.Text);
            command.Parameters.AddWithValue("@FunctiaCumparator", comboBox8.Text.ToString());
            command.Parameters.AddWithValue("@DomiciliuCumparator", comboBox7.Text.ToString());
            command.Parameters.AddWithValue("@JudetCumparator", textBox9.Text);
            command.Parameters.AddWithValue("@CodPostalCumparator", textBox8.Text);
            command.Parameters.AddWithValue("@SectorCumparator", comboBox6.Text.ToString());
            command.Parameters.AddWithValue("@StradaCumparator", textBox7.Text);
            command.Parameters.AddWithValue("@NrStradaCumparator", numericUpDown2.Text);
            command.Parameters.AddWithValue("@PretContract", textBox12.Text);
            command.Parameters.AddWithValue("@DataContract", dateTimePicker1.Value.Date);
            command.ExecuteNonQuery();
            MessageBox.Show("Update cu succes", "Fereastră de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesati CONTRACTELE DE VANZARE?", "Casuță de informare", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                ContracteMasini1 c1 = new ContracteMasini1();
                c1.Show();
            }
        }
    }
}
