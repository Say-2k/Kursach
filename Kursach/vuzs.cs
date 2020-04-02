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
    public partial class vuzs : Form
    {
        public vuzs()
        {
            InitializeComponent();
        }

        int n = 0;
            
        private void FieldsForm_Fill()
        {
            textBox1.Text = menu.ds.Tables["vuz"].Rows[n]["vuz_code"].ToString();
            textBox2.Text = menu.ds.Tables["vuz"].Rows[n]["specialty"].ToString();
            textBox1.Enabled = false;
        }

        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void vuzs_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM vuz";
            menu.Table_Fill("vuz", sql);
            if(menu.ds.Tables["vuz"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menu.ds.Tables["vuz"].Rows.Count > 0)
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
            if (n + 1 < menu.ds.Tables["vuz"].Rows.Count)
            {
                n++;
                FieldsForm_Fill();
            }
            else { n++; FieldsForm_Clear(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = menu.ds.Tables["vuz"].Rows.Count;
            FieldsForm_Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            if (n == menu.ds.Tables["vuz"].Rows.Count)
            {
                sql = "INSERT INTO vuz values(" + textBox1.Text + ", '" + textBox2.Text + "')";
                menu.Modification_Execute(sql);
                textBox1.Enabled = false;
                menu.ds.Tables["vuz"].Rows.Add(new object[] { textBox1.Text, textBox2.Text });
            }
            else
            {
                sql = "UPDATE vuz SET specialty='" + textBox2.Text + "' WHERE vuz_code=" + textBox1.Text;
                menu.Modification_Execute(sql);
                menu.ds.Tables["vuz"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text };
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string mes = "Вы точно хотите удалить из картотеки ВУЗ с кодом " + textBox1.Text + "?";
            string cap = "Удаление ВУЗа";
            MessageBoxButtons but = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(mes, cap, but);
            if (rezult == DialogResult.No) { return; }
            string sql = "DELETE FROM vuz WHERE vuz_code=" + textBox1.Text;
            menu.Modification_Execute(sql);
            menu.ds.Tables["vuz"].Rows.RemoveAt(n);
            if (menu.ds.Tables["vuz"].Rows.Count > n)
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
