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
            textBox1.Text = menu.ds.Tables["vuz"].Rows[n]["code_vuza"].ToString();
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

        }
    }
}
