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
    public partial class journal : Form
    {
        public journal()
        {
            InitializeComponent();
        }
        
        public static int n = -1;

        private void journal_Load(object sender, EventArgs e)
        {
            string sql;
            sql = "SELECT journal.numb AS [№ п/п], (student.surname & ' ' & student.name & ' ' & student.patronymic) AS [Фамилия, имя и отчество], student.birthday AS [Год рождения], (passport.passport_series & ' ' & passport.passport_number) AS [Серия и номер паспорта], vuz.specialty AS [Специальность], vus.n_vus AS [N ВУС], vb.category AS [Категория годности к военной службе], (vb.vb_serial & ' ' & vb.vb_number) AS [Серия и номер военного билета], journal.note_jn AS [Примечание]" +
            " FROM (((([journal] LEFT JOIN [vus] ON [journal].[vus_code]=[vus].[vus_code])" +
            " LEFT JOIN [student] ON [journal].[student_code]=[student].[student_code])" +
            " LEFT JOIN [vuz] ON [student].[vuz_code]=[vuz].[vuz_code])" +
            " LEFT JOIN [passport] ON [student].[student_code]=[passport].[passport_code])" +
            " LEFT JOIN [vb] ON [student].[student_code]=[vb].[vb_code]";
            menu.Table_Fill("journal", sql);
            dataGridView1.DataSource = menu.ds.Tables["journal"];
            dataGridView1.BackgroundColor = SystemColors.Control;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (authorization.polz != "Администратор")
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void journal_Activated(object sender, EventArgs e)
        {
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;

            string sql = "SELECT * FROM vuz";
            menu.Table_Fill("vuz", sql);
            comboBox1.Items.Clear();
            for (int i = 0; i < menu.ds.Tables["vuz"].Rows.Count; i++)
            {
                comboBox1.Items.Add(menu.ds.Tables["vuz"].Rows[i]["specialty"].ToString());
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            n = dataGridView1.CurrentRow.Index;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n = dataGridView1.Rows.Count;
            int kod = 0;
            if (n > 0)
            {
                kod = Convert.ToInt32(dataGridView1.Rows[n - 1].Cells["№ п/п"].Value) + 1;
            }
            else { kod = 1; }
            string sql = "INSERT INTO journal(numb) VALUES(" + kod + ")";
            menu.Modification_Execute(sql);
            menu.ds.Tables["journal"].Rows.Add(new object[] { kod, null, null, null });
            dataGridView1.CurrentCell = null;
            prizivnik prizivnik = new prizivnik();
            prizivnik.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            prizivnik prizivnik = new prizivnik();
            prizivnik.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mes = "Вы точно хотите удалить заказ с номером " + dataGridView1.Rows[n].Cells["№ п/п"].Value + "?";
            string cap = "Удаление заказа";
            MessageBoxButtons but = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(mes, cap, but);
            if (result == DialogResult.No) { return; }
            string sql;
            sql = "DELETE FROM journal WHERE numb=" + dataGridView1.Rows[n].Cells["№ п/п"].Value;
            menu.Modification_Execute(sql);
            menu.ds.Tables["journal"].Rows.RemoveAt(n);
            dataGridView1.AutoResizeColumns();
            dataGridView1.CurrentCell = null;
            n = -1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            menu.ds.Tables["journal"].DefaultView.RowFilter = "";
            dataGridView1.CurrentCell = null;
            dataGridView1.Sort(dataGridView1.Columns["№ п/п"], ListSortDirection.Ascending);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            menu.ds.Tables["journal"].DefaultView.RowFilter = "";
            dataGridView1.CurrentCell = null;
            dataGridView1.Sort(dataGridView1.Columns["№ п/п"], ListSortDirection.Descending);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton4.Checked = false;
            menu.ds.Tables["journal"].DefaultView.RowFilter = "[Год рождения] >= " + textBox1.Text + " AND [Год рождения] <= " + textBox2.Text;
            dataGridView1.CurrentCell = null;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            menu.ds.Tables["journal"].DefaultView.RowFilter = "[Специальность] = '" + comboBox1.Text + "'";
            dataGridView1.CurrentCell = null;
        }
    }
}
