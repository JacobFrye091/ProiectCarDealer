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
    public partial class Choose4 : Form
    {
        public Choose4()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați CONTRACTELE DE CUMPARARE?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                ContracteMasini cm = new ContracteMasini();
                cm.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați FACTURI?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                FacturiMasini fm = new FacturiMasini();
                fm.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați FISE AUTOVEHICULE?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                FisaAutovehicul fa = new FisaAutovehicul();
                fa.Show();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați CHEI AUTOVEHICULE?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                CheiMasini chm = new CheiMasini();
                chm.Show();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați TEST DRIVE?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                TestDriveMasini td = new TestDriveMasini();
                td.Show();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați FEEDBACK?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Feedback fb = new Feedback();
                fb.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați CONTRACTE?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                AdaugareFisaAutovehicul adg = new AdaugareFisaAutovehicul();
                adg.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să reveniți la forma anterioară?", "Casuță de informare", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Choose1 c1 = new Choose1();
                c1.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați AUTOVEHICULE?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Masini mas = new Masini();
                mas.Show();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("* Alegeți meniul pe care doriți să îl accessați din butoanele de mai jos." +
                "\n* Fiecare buton din partea stângă corespunde submeniului cu care se ocupă", "Casuță de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("→Butonul CONTRACTE AUTO (Cumpărare) va accesa submeniul care se ocupă de evidența contractelor de cumpărare." +
                "\n→Butonul FACTURI CUMPARARE va accesa submeniul care se ocupă de evidența facturilor de cumpărare." +
                "\n→Butonul FISE AUTOVEHICULE va accesa submeniul care se ocupă de evidența fișelor autovehiculelor." +
                "\n→Butonul CHEI AUTO va accesa submeniul care se ocupă de evidența cheilor autovehiculelor." +
                "\n→Butonul TEST DRIVE va accesa submeniul care se ocupă de evidența acțiunilor de test-drive." +
                "\n→Butonul FEEDBACK va accesa submeniul care se ocupă de evidența feedback-urilor clienților în urma unui test-drive." +
                "\n→Butonul INAPOI va accesa meniul principal anterior" +
                "\n→Buton EXIT va închide aplicația", "Casuță de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
