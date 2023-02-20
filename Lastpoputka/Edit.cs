using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lastpoputka
{
    public partial class Edit : Form
    {
        public DataGridView date;
        public Edit()
        {
            InitializeComponent();
            using (ReesterContext db = new ReesterContext())
            {
                foreach (Reester reester in db.Reesters)
                {
                    if (reester.Id == Program.main.selectedRow)
                    {
                        textBox1.Text = reester.Name;
                        comboBox1.Text = reester.Work;
                        textBox3.Text = reester.NameR;
                        trackBar1.Value = reester.HardEasy;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ReesterContext db = new ReesterContext())
            {
                foreach (Reester reester in db.Reesters)
                {
                    if (reester.Id == Program.main.selectedRow)
                    {
                        reester.Name = textBox1.Text;
                        reester.Work = comboBox1.Text;
                        reester.NameR = textBox3.Text;
                        reester.HardEasy = trackBar1.Value;
                    }
                }
                db.SaveChanges();
            }
            Program.main.dataGridView1.Rows.Clear();
            using (ReesterContext db = new ReesterContext())
            {
                for (int i = 0; i < db.Reesters.Count(); i++)
                {
                    Program.main.dataGridView1.Rows.Add();
                }
                for (int i = 0; i < db.Reesters.Count(); i++)
                {
                    Program.main.dataGridView1.Rows[i].Cells[0].Value = db.Reesters.ToList()[i].Id;
                    Program.main.dataGridView1.Rows[i].Cells[1].Value = db.Reesters.ToList()[i].Name;
                    Program.main.dataGridView1.Rows[i].Cells[2].Value = db.Reesters.ToList()[i].Work;
                    Program.main.dataGridView1.Rows[i].Cells[3].Value = db.Reesters.ToList()[i].NameR;
                    Program.main.dataGridView1.Rows[i].Cells[4].Value = db.Reesters.ToList()[i].HardEasy;
                }
            }
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
