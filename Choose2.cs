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
    public partial class Choose2 : Form
    {
        public Choose2()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("* Alegeți meniul pe care doriți să îl accessați din butoanele de mai jos" +
                "\n* Fiecare buton din partea stângă corespunde submeniului cu care se ocupă", "Căsuță de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("→Butonul FISE ANGAJAJATI va accesa submeniul care se ocupă de evidența fișelor angajaților" +
                "\n→Butonul ANGAJATI va accesa submeniul care se ocupă cu evidența angajaților" +
                "\n→Butonul INAPOI va accesa meniul principal anterior" +
                "\n→Buton EXIT va închide aplicația", "Casuță de informare", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să reveniți la forma anterioară?", "Casuță de informare", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Choose1 c1 = new Choose1();
                c1.Show();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să închideți aplicația", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați Fisele de ANGAJAȚI?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                FisaAngajati fa = new FisaAngajati();
                fa.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Doriți să accesați ANGAJAȚI?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                Angajati ang = new Angajati();
                ang.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*if (MessageBox.Show("Doriți să accesați ANGAJAȚI DATE PRIVATE?", "Căsuță de informare", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Hide();
                AngajatiDatePrivate angp = new AngajatiDatePrivate();
                angp.Show();
            }*/
        }
    }
}
