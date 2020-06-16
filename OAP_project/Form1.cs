using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAP_project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitDataGridView();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            Program.MakeHandle(
                Convert.ToDouble(dgv1.Rows[size].Cells[0].Value), 
                Convert.ToDouble(dgv1.Rows[size].Cells[1].Value),
                Convert.ToDouble(dgv1.Rows[size].Cells[2].Value),
                Convert.ToDouble(dgv1.Rows[size].Cells[3].Value),
                Convert.ToDouble(dgv1.Rows[size].Cells[4].Value)
                );
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown2.Value;
            Program.MakePin(Convert.ToDouble(dgv2.Rows[size].Cells[0].Value), Convert.ToDouble(dgv2.Rows[size].Cells[1].Value), Convert.ToDouble(dgv2.Rows[size].Cells[2].Value));
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int size = (int)numericUpDown3.Value;
            Program.MakeFingerPin(
                Convert.ToDouble(dgv3.Rows[size].Cells[0].Value),
                 Convert.ToDouble(dgv3.Rows[size].Cells[1].Value),
                  Convert.ToDouble(dgv3.Rows[size].Cells[2].Value),
                   Convert.ToDouble(dgv3.Rows[size].Cells[3].Value)
                );
            this.Close();
        }
        public void InitDataGridView()
        {
            dgv1.ColumnCount = 5;
            dgv1.Columns[0].Name = "L";
            dgv1.Columns[1].Name = "L1";
            dgv1.Columns[2].Name = "d1";
            dgv1.Columns[3].Name = "d2";
            dgv1.Columns[4].Name = "l";
            dgv1.Rows.Add(62, 52, 6, 4, 5);
            dgv1.Rows.Add(82, 70, 8, 5, 6);
            dgv1.Rows.Add(102, 88, 10, 6, 7);
            dgv1.Rows.Add(122, 106, 13, 8, 8);
            dgv1.Rows.Add(132, 114, 16, 9, 9); 
            dgv1.Rows.Add(182, 164, 16, 9, 9);

            dgv2.ColumnCount = 3;
            dgv2.Columns[0].Name = "d";
            dgv2.Columns[1].Name = "c";
            dgv2.Columns[2].Name = "l";
            dgv2.Rows.Add(1, 0.2, 6);
            dgv2.Rows.Add(3, 0.5, 18);
            dgv2.Rows.Add(8, 1.2, 45);
            dgv2.Rows.Add(10, 1.5, 57);

            dgv3.ColumnCount = 4;
            dgv3.Columns[0].Name = "d";
            dgv3.Columns[1].Name = "d1";
            dgv3.Columns[2].Name = "H";
            dgv3.Columns[3].Name = "h";
            dgv3.Rows.Add(12, 6, 16,8);
            dgv3.Rows.Add(14, 8, 18, 9);
            dgv3.Rows.Add(16, 10, 20, 10);
            dgv3.Rows.Add(18, 12, 22, 11);
            dgv3.Rows.Add(20, 12, 24, 12);
        }
    }
}
