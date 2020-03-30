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
            textBox1.Text = menu.ds.Tables["vus"].Rows[n]["code_vus"].ToString();
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
    }
}
