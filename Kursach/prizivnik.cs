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
    public partial class prizivnik : Form
    {
        public prizivnik()
        {
            InitializeComponent();
        }

        private void prizivnik_Load(object sender, EventArgs e)
        {
            {
                textBox1.Text = menu.ds.Tables["journal"].Rows[journal.n]["№ п/п"].ToString();
                comboBox1.Text = menu.ds.Tables["journal"].Rows[journal.n]["Фамилия, имя и отчество"].ToString();
                textBox7.Text = menu.ds.Tables["journal"].Rows[journal.n]["Год рождения"].ToString();
                textBox3.Text = menu.ds.Tables["journal"].Rows[journal.n]["Серия и номер паспорта"].ToString();
                textBox4.Text = menu.ds.Tables["journal"].Rows[journal.n]["Специальность"].ToString();
                comboBox2.Text = menu.ds.Tables["journal"].Rows[journal.n]["N ВУС"].ToString();
                textBox5.Text = menu.ds.Tables["journal"].Rows[journal.n]["Категория годности к военной службе"].ToString();
                textBox6.Text = menu.ds.Tables["journal"].Rows[journal.n]["Серия и номер военного билета"].ToString();
                textBox2.Text = menu.ds.Tables["journal"].Rows[journal.n]["Примечание"].ToString();
                textBox1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kod1 = null, kod2 = null;
            string sravnenie;
            for (int i = 0; i < menu.ds.Tables["student"].Rows.Count; i++)
            {
                sravnenie = menu.ds.Tables["student"].Rows[i]["surname"].ToString() + " " + menu.ds.Tables["student"].Rows[i]["name"].ToString() + " " + menu.ds.Tables["student"].Rows[i]["patronymic"].ToString();
                if (sravnenie == comboBox1.Text) { kod1 = menu.ds.Tables["student"].Rows[i]["student_code"].ToString(); break; }
            }
            for (int i = 0; i < menu.ds.Tables["vus"].Rows.Count; i++)
            {
                if (menu.ds.Tables["vus"].Rows[i]["n_vus"].ToString() == comboBox2.Text) { kod2 = menu.ds.Tables["vus"].Rows[i]["vus_code"].ToString(); break; }
            }
            string sql = "UPDATE journal SET note_jn='" + textBox2.Text + "', student_code=" + kod1 + ", vus_code=" + kod2 +  
                " WHERE numb=" + textBox1.Text;
            menu.Modification_Execute(sql);
            menu.ds.Tables["journal"].Rows[journal.n].ItemArray = new object[] { textBox1.Text, comboBox1.Text, textBox7.Text, textBox3.Text, textBox4.Text, comboBox2.Text, textBox5.Text, textBox6.Text, textBox2.Text };
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            students students = new students();
            students.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vuss vuss = new vuss();
            vuss.Show();
        }

        private void prizivnik_Activated(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM student ORDER BY surname";
            menu.Table_Fill("student", sql);
            comboBox1.Items.Clear();
            for (int i = 0; i < menu.ds.Tables["student"].Rows.Count; i++)
            {
                comboBox1.Items.Add(menu.ds.Tables["student"].Rows[i]["surname"].ToString() + " " + menu.ds.Tables["student"].Rows[i]["name"].ToString() + " " + menu.ds.Tables["student"].Rows[i]["patronymic"].ToString());
            }

            sql = "SELECT * FROM vus ORDER BY vus_code";
            menu.Table_Fill("vus", sql);
            comboBox2.Items.Clear();
            for (int i = 0; i < menu.ds.Tables["vus"].Rows.Count; i++)
            {
                comboBox2.Items.Add(menu.ds.Tables["vus"].Rows[i]["n_vus"].ToString());
            }

            sql = "SELECT * FROM passport";
            menu.Table_Fill("passport", sql);

            sql = "SELECT * FROM vb";
            menu.Table_Fill("vb", sql);

            sql = "SELECT * FROM vuz";
            menu.Table_Fill("vuz", sql);
        }

        private void prizivnik_FormClosed(object sender, FormClosedEventArgs e)
        {
            journal.n = -1;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            int j = 0;
            string kod = null;
            string sravnenie;
            for (int i = 0; i < menu.ds.Tables["student"].Rows.Count; i++)
            {
                sravnenie = menu.ds.Tables["student"].Rows[i]["surname"].ToString() + " " + menu.ds.Tables["student"].Rows[i]["name"].ToString() + " " + menu.ds.Tables["student"].Rows[i]["patronymic"].ToString();
                if (sravnenie == comboBox1.Text) { j = i; kod = menu.ds.Tables["student"].Rows[i]["vuz_code"].ToString(); break; }
            }
            textBox7.Text = menu.ds.Tables["student"].Rows[j]["birthday"].ToString();
            textBox3.Text = menu.ds.Tables["passport"].Rows[j]["passport_series"].ToString() + " " + menu.ds.Tables["passport"].Rows[j]["passport_number"].ToString();
            textBox5.Text = menu.ds.Tables["vb"].Rows[j]["category"].ToString();
            textBox6.Text = menu.ds.Tables["vb"].Rows[j]["vb_serial"].ToString();
            for (int i = 0; i < menu.ds.Tables["vuz"].Rows.Count; i++)
            {
                if (menu.ds.Tables["vuz"].Rows[i]["vuz_code"].ToString() == kod) { textBox4.Text = menu.ds.Tables["vuz"].Rows[i]["specialty"].ToString(); break; }
            }
        }
    }
}
