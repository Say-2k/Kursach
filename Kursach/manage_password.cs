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
    public partial class manage_password : Form
    {
        public manage_password()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql;
            for (int i = 0; i < menu.ds.Tables["auth"].Rows.Count; i++)
            {
                if ((menu.ds.Tables["auth"].Rows[i]["login"].ToString() == comboBox1.Text) && (menu.ds.Tables["auth"].Rows[i]["passwd"].ToString() == textBox1.Text))
                {
                    if (textBox2.Text == textBox3.Text)
                    {
                        sql = "UPDATE auth SET passwd='" + textBox3.Text + "' WHERE login='" + comboBox1.Text + "';"; 
                        menu.Modification_Execute(sql);                                                               
                        menu.ds.Tables["auth"].Rows[i].ItemArray = new object[] { menu.ds.Tables["auth"].Rows[i]["auth_code"].ToString(), comboBox1.Text, textBox3.Text };
                        textBox1.Clear(); textBox2.Clear(); textBox3.Clear();         
                    }
                    else { MessageBox.Show("Новые пароли не совпадают"); }
                }
                else if (i < menu.ds.Tables["auth"].Rows.Count) { continue; }
                else { MessageBox.Show("Неверный старый пароль"); }
                break;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void manage_password_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            for (int i = 0; i < menu.ds.Tables["auth"].Rows.Count; i++)
            {
                comboBox1.Items.Add(menu.ds.Tables["auth"].Rows[i]["login"].ToString());
            }
        }
    }
}
