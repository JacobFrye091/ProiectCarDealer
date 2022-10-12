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
    public partial class AdaugareFisaAutovehicul : Form
    {
        public AdaugareFisaAutovehicul()
        {
            InitializeComponent();
            FillComboNumarContract();
            FillComboNumarFisa();
        }
        void FillComboNumarFisa()
        {
            string constring = @"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True";
            string Query = "SELECT * FROM FisaAuto";
            SqlConnection conDataBase = new SqlConnection(constring);
            SqlCommand cmdDatabase = new SqlCommand(Query, conDataBase);
            SqlDataReader dataReader;
            try
            {
                conDataBase.Open();
                dataReader = cmdDatabase.ExecuteReader();
                while (dataReader.Read())
                {
                    int sNrFisa = dataReader.GetInt32("NrFisaAuto");
                    comboBox22.Items.Add(sNrFisa);
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
                    int sNrCtr = dataReader.GetInt32("NrContract");
                    comboBox1.Items.Add(sNrCtr);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să reveniți la forma anterioară?", "Casuță de informare", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                FisaAutovehicul fa = new FisaAutovehicul();
                fa.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO FisaAuto(NrContract, pret, oferitDe, categorie, marca, model, versiune, an, km, combustibil, putere, capacitateCilindrica, transmisie, cutieDeViteze, normaPoluare, filtruDeParticule, consumUrban, tipCaroserie, emisiiCO2, VIN, numarPortiere, culoare, optiuniCuloare, seEmiteFactura, eligibilPentruFinantare, sauInLimitaA, garantieDealer, taraOrigine, inmatriculat, primulProprietar, faraAccidentInIstoric, carteService, stare) VALUES ('" + Convert.ToInt32(comboBox1.Text.ToString()) + "','" + Convert.ToInt32(textBox12.Text) + "','" + comboBox2.Text.ToString() + "','" + comboBox3.Text.ToString() + "','" + comboBox4.Text.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "','" + Convert.ToInt32(comboBox21.Text.ToString()) + "','" + Convert.ToInt32(textBox13.Text) + "','" + comboBox5.Text.ToString() + "','" + Convert.ToInt32(textBox4.Text) + "','" + Convert.ToInt32(textBox5.Text) + "','" + comboBox6.Text.ToString() + "','" + comboBox7.Text.ToString() + "','" + comboBox8.Text.ToString() + "','" + comboBox9.Text.ToString() + "','" + Convert.ToInt32(textBox6.Text) + "','" + comboBox10.Text.ToString() + "','" + textBox7.Text + "','" + textBox8.Text + "','" + Convert.ToInt32(comboBox11.Text.ToString()) + "','" + textBox9.Text + "','" + textBox10.Text + "','" + comboBox12.Text.ToString() + "','" + comboBox13.Text.ToString() + "','" + textBox11.Text + "','" + comboBox14.Text.ToString() + "','" + comboBox15.Text.ToString() + "','" + comboBox16.Text.ToString() + "','" + comboBox17.Text.ToString() + "','" + comboBox18.Text.ToString() + "','" + comboBox19.Text.ToString() + "','" + comboBox20.Text.ToString() + "')", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Inserare cu succes", "Inserare Fisa Autovehicul", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
                textBox1.Text = "";
                comboBox1.Text = "";
                textBox12.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox21.Text = "";
                textBox13.Text = "";
                comboBox5.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox6.Text = "";
                comboBox7.Text = "";
                comboBox8.Text = "";
                comboBox9.Text = "";
                textBox6.Text = "";
                comboBox10.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                comboBox11.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                comboBox12.Text = "";
                comboBox13.Text = "";
                textBox11.Text = "";
                comboBox14.Text = "";
                comboBox15.Text = "";
                comboBox16.Text = "";
                comboBox17.Text = "";
                comboBox18.Text = "";
                comboBox19.Text = "";
                comboBox20.Text = "";
            }
            else
            {
                MessageBox.Show("Introduceți valori de referință", "Lipsă valori de referință", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            SqlDataReader sr = null;
            command.Connection = connection;
            command.CommandText = "Select Top(1) NrFisaAuto, NrContract, pret, oferitDe, categorie, marca, model, versiune, an, km, combustibil, putere, capacitateCilindrica, transmisie, cutieDeViteze, normaPoluare, filtruDeParticule, consumUrban, tipCaroserie, emisiiCO2, VIN, numarPortiere, culoare, optiuniCuloare, seEmiteFactura, eligibilPentruFinantare, sauInLimitaA, garantieDealer, taraOrigine, inmatriculat, primulProprietar, faraAccidentInIstoric, carteService, stare From FisaAuto order by NrFisaAuto desc";
            connection.Open();
            sr = command.ExecuteReader();
            if (sr.Read())
            {
                textBox1.Text = sr.GetValue(0).ToString();
                comboBox1.Text = sr.GetValue(1).ToString();
                textBox12.Text = sr.GetValue(2).ToString();
                comboBox2.Text = sr.GetValue(3).ToString();
                comboBox3.Text = sr.GetValue(4).ToString();
                comboBox4.Text = sr.GetValue(5).ToString();
                textBox2.Text = sr.GetValue(6).ToString();
                textBox3.Text = sr.GetValue(7).ToString();
                comboBox21.Text = sr.GetValue(8).ToString();
                textBox13.Text = sr.GetValue(9).ToString();
                comboBox5.Text = sr.GetValue(10).ToString();
                textBox4.Text = sr.GetValue(11).ToString();
                textBox5.Text = sr.GetValue(12).ToString();
                comboBox6.Text = sr.GetValue(13).ToString();
                comboBox7.Text = sr.GetValue(14).ToString();
                comboBox8.Text = sr.GetValue(15).ToString();
                comboBox9.Text = sr.GetValue(16).ToString();
                textBox6.Text = sr.GetValue(17).ToString();
                comboBox10.Text = sr.GetValue(18).ToString();
                textBox7.Text = sr.GetValue(19).ToString();
                textBox8.Text = sr.GetValue(20).ToString();
                comboBox11.Text = sr.GetValue(21).ToString();
                textBox9.Text = sr.GetValue(22).ToString();
                textBox10.Text = sr.GetValue(23).ToString();
                comboBox12.Text = sr.GetValue(24).ToString();
                comboBox13.Text = sr.GetValue(25).ToString();
                textBox11.Text = sr.GetValue(26).ToString();
                comboBox14.Text = sr.GetValue(27).ToString();
                comboBox15.Text = sr.GetValue(28).ToString();
                comboBox16.Text = sr.GetValue(29).ToString();
                comboBox17.Text = sr.GetValue(30).ToString();
                comboBox18.Text = sr.GetValue(31).ToString();
                comboBox19.Text = sr.GetValue(32).ToString();
                comboBox20.Text = sr.GetValue(33).ToString();

            }
            connection.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (MessageBox.Show("Doriți să ștergeți înregistrarea?", "Ștergere Înregistrare", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                    connection.Open();
                    SqlCommand command = new SqlCommand("DELETE FROM FisaAuto WHERE NrFisaAuto='" + textBox1.Text + "'", connection);
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
            SqlCommand command = new SqlCommand("UPDATE FisaAuto SET NrContract=@NrContract, pret=@pret, oferitDe=@oferitDe, categorie=@categorie, marca=@marca, model=@model, versiune=@versiune, an=@an, km=@km, combustibil=@combustibil, putere=@putere, capacitateCilindrica=@capacitateCilindrica, transmisie=@transmisie, cutieDeViteze=@cutieDeViteze, normaPoluare=@normaPoluare, filtruDeParticule=@filtruDeParticule, consumUrban=@consumUrban, tipCaroserie=@tipCaroserie, emisiiCO2=@emisiiCO2, VIN=@VIN, numarPortiere=@numarPortiere, culoare=@culoare, optiuniCuloare=@optiuniCuloare, seEmiteFactura=@seEmiteFactura, eligibilPentruFinantare=@eligibilPentruFinantare, sauInLimitaA=@sauInLimitaA, garantieDealer=@garantieDealer, taraOrigine=@taraOrigine, inmatriculat=@inmatriculat, primulProprietar=@primulProprietar, faraAccidentInIstoric=@faraAccidentInIstoric, carteService=@carteService, stare=@stare WHERE NrFisaAuto=@NrFisaAuto", connection);
            command.Parameters.AddWithValue("@NrFisaAuto", textBox1.Text);//
            command.Parameters.AddWithValue("@NrContract", Convert.ToInt32(comboBox1.Text.ToString()));//
            command.Parameters.AddWithValue("@pret", Convert.ToInt32(textBox12.Text));//
            command.Parameters.AddWithValue("@oferitDe", comboBox2.Text.ToString());//
            command.Parameters.AddWithValue("@categorie", comboBox3.Text.ToString());//
            command.Parameters.AddWithValue("@marca", comboBox4.Text.ToString());//
            command.Parameters.AddWithValue("@model", textBox2.Text);//
            command.Parameters.AddWithValue("@versiune", textBox3.Text);//
            command.Parameters.AddWithValue("@an", Convert.ToInt32(comboBox21.Text.ToString()));//
            command.Parameters.AddWithValue("@km", Convert.ToInt32(textBox13.Text));//
            command.Parameters.AddWithValue("@combustibil", comboBox5.Text.ToString());//
            command.Parameters.AddWithValue("@putere", Convert.ToInt32(textBox4.Text));//
            command.Parameters.AddWithValue("@capacitateCilindrica", Convert.ToInt32(textBox5.Text));//
            command.Parameters.AddWithValue("@transmisie", comboBox6.Text.ToString());//
            command.Parameters.AddWithValue("@cutieDeViteze", comboBox7.Text.ToString());//
            command.Parameters.AddWithValue("@normaPoluare", comboBox8.Text.ToString());//
            command.Parameters.AddWithValue("@filtruDeParticule", comboBox9.Text.ToString());//
            command.Parameters.AddWithValue("@consumUrban", Convert.ToDecimal(textBox6.Text));//
            command.Parameters.AddWithValue("@tipCaroserie", comboBox10.Text.ToString());//
            command.Parameters.AddWithValue("@emisiiCO2", textBox7.Text);//
            command.Parameters.AddWithValue("@VIN", textBox8.Text);//
            command.Parameters.AddWithValue("@numarPortiere", Convert.ToInt32(comboBox11.Text.ToString()));//
            command.Parameters.AddWithValue("@culoare", textBox9.Text);//
            command.Parameters.AddWithValue("@optiuniCuloare", textBox10.Text);//
            command.Parameters.AddWithValue("@seEmiteFactura", comboBox12.Text.ToString());//
            command.Parameters.AddWithValue("@eligibilPentruFinantare", comboBox13.Text.ToString());//
            command.Parameters.AddWithValue("@sauInLimitaA", textBox11.Text);//
            command.Parameters.AddWithValue("@garantieDealer", comboBox14.Text.ToString());//
            command.Parameters.AddWithValue("@taraOrigine", comboBox15.Text.ToString());
            command.Parameters.AddWithValue("@inmatriculat", comboBox16.Text.ToString());
            command.Parameters.AddWithValue("@primulProprietar", comboBox17.Text.ToString());
            command.Parameters.AddWithValue("@faraAccidentInIstoric", comboBox18.Text.ToString());
            command.Parameters.AddWithValue("@carteService", comboBox19.Text.ToString());
            command.Parameters.AddWithValue("@stare", comboBox20.Text.ToString());
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
                    comboBox1.Text = "";
                    textBox12.Text = "";
                    comboBox2.Text = "";
                    comboBox3.Text = "";
                    comboBox4.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    comboBox21.Text = "";
                    textBox13.Text = "";
                    comboBox5.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    comboBox6.Text = "";
                    comboBox7.Text = "";
                    comboBox8.Text = "";
                    comboBox9.Text = "";
                    textBox6.Text = "";
                    comboBox10.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    comboBox11.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    comboBox12.Text = "";
                    comboBox13.Text = "";
                    textBox11.Text = "";
                    comboBox14.Text = "";
                    comboBox15.Text = "";
                    comboBox16.Text = "";
                    comboBox17.Text = "";
                    comboBox18.Text = "";
                    comboBox19.Text = "";
                    comboBox20.Text = "";
                    MessageBox.Show("Datele din celule au fost șterse", "Ștergere", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox22.Text != "")
            {
                SqlConnection connection1 = new SqlConnection(@"Data Source=HP_ANDREI\SQLEXPRESS;Initial Catalog=ProiectLicenta;Integrated Security=True");
                SqlCommand command1 = new SqlCommand();
                SqlDataReader sr = null;
                command1.Connection = connection1;
                command1.CommandText = "Select * From FisaAuto where NrFisaAuto = '" + comboBox22.SelectedItem.ToString() + "'";
                connection1.Open();
                sr = command1.ExecuteReader();
                if (sr.Read())
                {
                    textBox1.Text = sr.GetValue(0).ToString();
                    comboBox1.Text = sr.GetValue(1).ToString();
                    textBox12.Text = sr.GetValue(2).ToString();
                    comboBox2.Text = sr.GetValue(3).ToString();
                    comboBox3.Text = sr.GetValue(4).ToString();
                    comboBox4.Text = sr.GetValue(5).ToString();
                    textBox2.Text = sr.GetValue(6).ToString();
                    textBox3.Text = sr.GetValue(7).ToString();
                    comboBox21.Text = sr.GetValue(8).ToString();
                    textBox13.Text = sr.GetValue(9).ToString();
                    comboBox5.Text = sr.GetValue(10).ToString();
                    textBox4.Text = sr.GetValue(11).ToString();
                    textBox5.Text = sr.GetValue(12).ToString();
                    comboBox6.Text = sr.GetValue(13).ToString();
                    comboBox7.Text = sr.GetValue(14).ToString();
                    comboBox8.Text = sr.GetValue(15).ToString();
                    comboBox9.Text = sr.GetValue(16).ToString();
                    textBox6.Text = sr.GetValue(17).ToString();
                    comboBox10.Text = sr.GetValue(18).ToString();
                    textBox7.Text = sr.GetValue(19).ToString();
                    textBox8.Text = sr.GetValue(20).ToString();
                    comboBox11.Text = sr.GetValue(21).ToString();
                    textBox9.Text = sr.GetValue(22).ToString();
                    textBox10.Text = sr.GetValue(23).ToString();
                    comboBox12.Text = sr.GetValue(24).ToString();
                    comboBox13.Text = sr.GetValue(25).ToString();
                    textBox11.Text = sr.GetValue(26).ToString();
                    comboBox14.Text = sr.GetValue(27).ToString();
                    comboBox15.Text = sr.GetValue(28).ToString();
                    comboBox16.Text = sr.GetValue(29).ToString();
                    comboBox17.Text = sr.GetValue(30).ToString();
                    comboBox18.Text = sr.GetValue(31).ToString();
                    comboBox19.Text = sr.GetValue(32).ToString();
                    comboBox20.Text = sr.GetValue(33).ToString();
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
