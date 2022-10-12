using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectLicenta
{
    public partial class Choose1 : Form
    {
        public Choose1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("* Alegeti meniul pe care doriti sa il accessati din butoanele de mai jos" +
                "\n* Fiecare buton din partea stanga corespunda submeniului cu care se ocupa", "Casuta de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("→Butonul ANGAJATI va accesa submeniul care se ocupa de evidenta angajatilor" +
                "\n→Butonul CLIENTI va accesa submeniul care se ocupa cu evidenta clientilor" +
                "\n→Butonul AUTOVEHICULE va accesa submeniul care se ocupa cu evidenta autovehiculelor", "Casuta de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația?", "Inchidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați ANGAJAȚI?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Choose2 c2 = new Choose2();
                c2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați CLIENTI?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Choose3 c3 = new Choose3();
                c3.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați AUTOVEHICULE?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Choose4 c4 = new Choose4();
                c4.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Rapoarte rapoarte = new Rapoarte();
            rapoarte.Show();
        }
    }
}
