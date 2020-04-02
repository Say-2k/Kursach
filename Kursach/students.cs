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
    public partial class students : Form
    {
        public students()
        {
            InitializeComponent();
        }

        int n = 0;

        private void FieldsForm_Fill()
        {
            textBox1.Text = menu.ds.Tables["student"].Rows[n]["student_code"].ToString();
            textBox2.Text = menu.ds.Tables["student"].Rows[n]["surname"].ToString();
            textBox6.Text = menu.ds.Tables["student"].Rows[n]["name"].ToString();
            textBox7.Text = menu.ds.Tables["student"].Rows[n]["patronymic"].ToString();
            if (menu.ds.Tables["student"].Rows[n]["birthday"] != DBNull.Value)
            {
                dateTimePicker2.Value = Convert.ToDateTime(menu.ds.Tables["student"].Rows[n]["birthday"]);
            }
            textBox3.Text = menu.ds.Tables["student"].Rows[n]["vuz_code"].ToString();
            maskedTextBox1.Text = menu.ds.Tables["passport"].Rows[n]["passport_series"].ToString();
            maskedTextBox2.Text = menu.ds.Tables["passport"].Rows[n]["passport_number"].ToString();
            if (menu.ds.Tables["passport"].Rows[n]["when_issued"] != DBNull.Value)
            {
                dateTimePicker1.Value = Convert.ToDateTime(menu.ds.Tables["passport"].Rows[n]["when_issued"]);
            }
            maskedTextBox3.Text = menu.ds.Tables["passport"].Rows[n]["department_code"].ToString();
            textBox5.Text = menu.ds.Tables["passport"].Rows[n]["issued_by"].ToString();
            maskedTextBox4.Text = menu.ds.Tables["vb"].Rows[n]["vb_serial"].ToString();
            maskedTextBox5.Text = menu.ds.Tables["vb"].Rows[n]["vb_number"].ToString();
            comboBox1.Text = menu.ds.Tables["vb"].Rows[n]["category"].ToString();
            textBox1.Enabled = false;
        }

        private void FieldsForm_Clear()
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker2.Value = DateTime.Today;
            textBox3.Text = "0";
            maskedTextBox1.Text = "0";
            maskedTextBox2.Text = "0";
            dateTimePicker1.Value = DateTime.Today;
            maskedTextBox3.Text = "0";
            textBox5.Text = "";
            maskedTextBox4.Text = "0";
            maskedTextBox5.Text = "0";
            comboBox1.Text = "";
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void students_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT * FROM student";
            menu.Table_Fill("student", sql);
            sql = "SELECT * FROM passport";
            menu.Table_Fill("passport", sql);
            sql = "SELECT * FROM vb";
            menu.Table_Fill("vb", sql);
            if(menu.ds.Tables["student"].Rows.Count > 0)
            {
                n = 0; FieldsForm_Fill();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (menu.ds.Tables["student"].Rows.Count > 0)
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
            if (n + 1 < menu.ds.Tables["student"].Rows.Count)
            {
                n++;
                FieldsForm_Fill();
            }
            else { n++; FieldsForm_Clear(); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            n = menu.ds.Tables["student"].Rows.Count;
            FieldsForm_Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sql;
            if(n == menu.ds.Tables["passport"].Rows.Count)
            {
                sql = "INSERT INTO passport values(" + textBox1.Text + ", " + maskedTextBox1.Text + ", " + maskedTextBox2.Text + ", '" + maskedTextBox3.Text + "', '" + textBox5.Text + "', '" + dateTimePicker1.Value + "')";
                menu.Modification_Execute(sql);
                textBox1.Enabled = false;
                menu.ds.Tables["passport"].Rows.Add(new object[] { textBox1.Text, maskedTextBox1.Text, maskedTextBox2.Text, maskedTextBox3.Text, textBox5.Text, dateTimePicker2.Value });
            }
            else
            {
                sql = "UPDATE passport SET passport_series=" + maskedTextBox1.Text + ", passport_number=" + maskedTextBox2.Text + ", department_code='" + maskedTextBox3.Text + "', issued_by='" + textBox5.Text + "', when_issued='" + dateTimePicker1.Value +"' WHERE passport_code=" + textBox1.Text;
                menu.Modification_Execute(sql);
                menu.ds.Tables["passport"].Rows[n].ItemArray = new object[] { textBox1.Text, maskedTextBox1.Text, maskedTextBox2.Text, maskedTextBox3.Text, textBox5.Text, dateTimePicker2.Value };
            }
            if (n == menu.ds.Tables["vb"].Rows.Count)
            {
                sql = "INSERT INTO vb values(" + textBox1.Text + ", '" + comboBox1.Text + "', '" + maskedTextBox4.Text + "', " + maskedTextBox5.Text + ")";
                menu.Modification_Execute(sql);
                textBox1.Enabled = false;
                menu.ds.Tables["vb"].Rows.Add(new object[] { textBox1.Text, comboBox1.Text, maskedTextBox4.Text, maskedTextBox5.Text });
            }
            else
            {
                sql = "UPDATE vb SET category='" + comboBox1.Text + "', vb_serial='" + maskedTextBox4.Text + "', vb_number=" + maskedTextBox5.Text + " WHERE vb_code=" + textBox1.Text;
                menu.Modification_Execute(sql);
                menu.ds.Tables["vb"].Rows[n].ItemArray = new object[] { textBox1.Text, comboBox1.Text, maskedTextBox4.Text, maskedTextBox5.Text };
            }
            if (n == menu.ds.Tables["student"].Rows.Count)
            {
                sql = "INSERT INTO student values(" + textBox1.Text + ", '" + textBox2.Text + "', '" + textBox6.Text + "', '" + textBox7.Text + "', '" + dateTimePicker2.Value + "', " + textBox3.Text + ")";
                menu.Modification_Execute(sql);
                textBox1.Enabled = false;
                menu.ds.Tables["student"].Rows.Add(new object[] { textBox1.Text, textBox2.Text, textBox6.Text, textBox7.Text, dateTimePicker2.Value, textBox3.Text });
            }
            else
            {
                sql = "UPDATE student SET surname='" + textBox2.Text + "', name='" + textBox6.Text + "', patronymic='" + textBox7.Text + "', birthday='" + dateTimePicker2.Value + "', vuz_code=" + textBox3.Text + " WHERE student_code=" + textBox1.Text;
                menu.Modification_Execute(sql);
                menu.ds.Tables["student"].Rows[n].ItemArray = new object[] { textBox1.Text, textBox2.Text, textBox6.Text, textBox7.Text, dateTimePicker2.Value, textBox3.Text };
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string mes = "Вы точно хотите удалить из картотеки студента с кодом " + textBox1.Text + "?";
            string cap = "Удаление студента";
            MessageBoxButtons but = MessageBoxButtons.YesNo;
            DialogResult rezult = MessageBox.Show(mes, cap, but);
            if (rezult == DialogResult.No) { return; }
            string sql = "DELETE FROM student WHERE student_code=" + textBox1.Text;
            menu.Modification_Execute(sql);
            menu.ds.Tables["student"].Rows.RemoveAt(n); 
            sql = "DELETE FROM passport WHERE passport_code=" + textBox1.Text;
            menu.Modification_Execute(sql);
            menu.ds.Tables["passport"].Rows.RemoveAt(n);
            sql = "DELETE FROM vb WHERE vb_code=" + textBox1.Text;
            menu.Modification_Execute(sql);
            menu.ds.Tables["vb"].Rows.RemoveAt(n);
            if (menu.ds.Tables["vb"].Rows.Count > n)
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
