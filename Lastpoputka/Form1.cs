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
    public partial class Form1 : Form
    {
        public int selectedRow;
        public Form1()
        {
            Program.main = this;
            InitializeComponent();
            var column1 = new DataGridViewColumn();
            column1.HeaderText = "Immd";
            column1.Width = 50;
            column1.CellTemplate = new DataGridViewTextBoxCell();

            var column2 = new DataGridViewColumn();
            column2.HeaderText = "Name";
            column2.CellTemplate = new DataGridViewTextBoxCell();

            var column3 = new DataGridViewColumn();
            column3.HeaderText = "Work";
            column3.CellTemplate = new DataGridViewTextBoxCell();

            var column4 = new DataGridViewColumn();
            column4.HeaderText = "NameR";
            column4.CellTemplate = new DataGridViewTextBoxCell();

            var column5 = new DataGridViewColumn();
            column5.HeaderText = "HardEasy";
            column5.CellTemplate = new DataGridViewTextBoxCell();

            dataGridView1.Columns.Add(column1);
            dataGridView1.Columns.Add(column2);
            dataGridView1.Columns.Add(column3);
            dataGridView1.Columns.Add(column4);
            dataGridView1.Columns.Add(column5);

            dataGridView1.AllowUserToAddRows = false;

            using (ReesterContext db = new ReesterContext())
            {
                for (int i = 0; i < db.Reesters.Count(); i++)
                {
                    dataGridView1.Rows.Add();
                }
                for (int i = 0; i < db.Reesters.Count(); i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = db.Reesters.ToList()[i].Id;
                    dataGridView1.Rows[i].Cells[1].Value = db.Reesters.ToList()[i].Name;
                    dataGridView1.Rows[i].Cells[2].Value = db.Reesters.ToList()[i].Work;
                    dataGridView1.Rows[i].Cells[3].Value = db.Reesters.ToList()[i].NameR;
                    dataGridView1.Rows[i].Cells[4].Value = db.Reesters.ToList()[i].HardEasy;
                }
            }
        }//edit

        private void button1_Click(object sender, EventArgs e)
        {
            ResForm res = new ResForm();
            res.date = this.dataGridView1;
            res.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ReesterContext db = new ReesterContext())
            {
                int selected = (int)dataGridView1.CurrentRow.Cells[0].Value;
                foreach (Reester reester in db.Reesters)
                {
                        if (reester.Id == selected)
                        {
                            db.Reesters.Remove(reester);
                            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                        }
                }
                db.SaveChanges();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            selectedRow = (int)dataGridView1.CurrentRow.Cells[0].Value;
            Edit ed = new Edit();
            ed.date = this.dataGridView1;
            ed.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
    }
}
