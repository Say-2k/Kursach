using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursach
{
    public partial class vuss : Form
    {
        public vuss()
        {
            InitializeComponent();
        }

        int n = 0;

        private void FieldsForm_Fill()
        {
            textBox1.Text = menu.ds.Tables["vus"].Rows[n]["vus_code"].ToString();
            textBox2.Text = menu.ds.Tables["vus"].Rows[n]["n_vus"].ToString();
            textBox1.Enabled = false;
        }

        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void vuss_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM vus";
            menu.Table_Fill("vus", sql);
            if(menu.ds.Tables["vus"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menu.ds.Tables["vus"].Rows.Count > 0)
            {
                n = 0;
                FieldsForm_Fill();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n > 0)
            {
                n--;
                FieldsForm_Fill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (n + 1 < menu.ds.Tables["vus"].Rows.Count)
            {
                n++;
                FieldsForm_Fill();
            }
            else { n++; FieldsForm_Clear(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = menu.ds.Tables["vus"].Rows.Count;
            FieldsForm_Clear();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            if (n == menu.ds.Tables["vus"].Rows.Count)
            {
                sql = "INSERT INTO vus values(" + textBox1.Text + ", '" + textBox2.Text.ToUpper() + "')";
                menu.Modification_Execute(sql);
                textBox1.Enabled = false;
                menu.ds.Tables["vus"].Rows.Add(new object[] { textBox1.Text, textBox2.Text.ToUpper() });
            }
            else
            {
                sql = "UPDATE vus SET n_vus='" + textBox2.Text.ToUpper() + "' WHERE vus_code=" + textBox1.Text;
                menu.Modification_Execute(sql);
                menu.ds.Tables["vus"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text.ToUpper() };
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string mes = "Вы точно хотите удалить из картотеки ВУС с кодом " + textBox1.Text + "?";
            string cap = "Удаление ВУСа";
            MessageBoxButtons but = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(mes, cap, but);
            if (rezult == DialogResult.No) { return; }
            string sql = "DELETE FROM vus WHERE vus_code=" + textBox1.Text;
            menu.Modification_Execute(sql);
            menu.ds.Tables["vus"].Rows.RemoveAt(n);
            if (menu.ds.Tables["vus"].Rows.Count > n)
            {
                FieldsForm_Fill();
            }
            else
            {
                FieldsForm_Clear();
            }
        }
    }
}
