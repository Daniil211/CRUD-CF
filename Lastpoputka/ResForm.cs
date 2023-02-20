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
    public partial class ResForm : Form
    {
        public DataGridView date;
        public ResForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ReesterContext db = new ReesterContext())
            {
                if (textBox1.Text != "" || comboBox1.Text != "" || textBox3.Text != "")
                {
                    Reester reester = new Reester(textBox1.Text, comboBox1.Text, textBox3.Text, trackBar1.Value);
                    db.Reesters.Add(reester);

                    db.SaveChanges();
                    MessageBox.Show("Запись успешно добавлена");
                }
                else
                    MessageBox.Show("Вы ввели не все данные");
            }
            using(ReesterContext db = new ReesterContext())
            {
                if (textBox1.Text != "" || comboBox1.Text != "" || textBox3.Text != "")
                {
                    int n = db.Reesters.Count() - 1;
                    date.Rows.Add();
                    date.Rows[n].Cells[0].Value = db.Reesters.ToList()[n].Id;
                    date.Rows[n].Cells[1].Value = db.Reesters.ToList()[n].Name;
                    date.Rows[n].Cells[2].Value = db.Reesters.ToList()[n].Work;
                    date.Rows[n].Cells[3].Value = db.Reesters.ToList()[n].NameR;
                    date.Rows[n].Cells[4].Value = db.Reesters.ToList()[n].HardEasy;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
