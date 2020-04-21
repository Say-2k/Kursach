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
    public partial class authorization : Form
    {
        public authorization()
        {
            InitializeComponent();
        }

        private void authorization_Load(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM auth";
            menu.Table_Fill("auth", sql);
            comboBox1.Items.Clear();
            for (int i = 0; i < menu.ds.Tables["auth"].Rows.Count; i++)
            {
                comboBox1.Items.Add(menu.ds.Tables["auth"].Rows[i]["login"].ToString());
            }
            textBox1.UseSystemPasswordChar = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox1.UseSystemPasswordChar = false; }
            else { textBox1.UseSystemPasswordChar = true; }
        }

        public static string polz = "";

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < menu.ds.Tables["auth"].Rows.Count; i++)
            {
                if (menu.ds.Tables["auth"].Rows[i]["login"].ToString() == comboBox1.Text)
                {
                    if (menu.ds.Tables["auth"].Rows[i]["passwd"].ToString() == textBox1.Text)
                    {
                        polz = comboBox1.Text;
                        Hide();
                        menu menu = new menu();
                        menu.ShowDialog();
                        Close();
                    }
                    else { MessageBox.Show("Неверный пароль"); }
                    break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
