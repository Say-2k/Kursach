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
            textBox1.Text = menu.ds.Tables["student"].Rows[n]["code"].ToString();
            textBox2.Text = menu.ds.Tables["student"].Rows[n]["surname"].ToString();
            textBox6.Text = menu.ds.Tables["student"].Rows[n]["name"].ToString();
            textBox7.Text = menu.ds.Tables["student"].Rows[n]["patronymic"].ToString();
            if (menu.ds.Tables["student"].Rows[n]["birthday"] != DBNull.Value)
            {
                dateTimePicker2.Value = Convert.ToDateTime(menu.ds.Tables["student"].Rows[n]["birthday"]);
            }
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
            maskedTextBox1.Text = "0";
            maskedTextBox2.Text = "0";
            dateTimePicker1.Value = DateTime.Today;
            maskedTextBox1.Text = "0";
            textBox5.Text = "";
            maskedTextBox4.Text = "0";
            maskedTextBox4.Text = "0";
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
    }
}
