using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kursach
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        public static OleDbConnection connection = new OleDbConnection("Provider = " + "Microsoft.Ace.OLEDB.12.0; Data Source = |DataDirectory|\\Кравцов.accdb");

        public static DataSet ds = new DataSet();

        public static void Table_Fill(string name, string sql)
        {
            if (ds.Tables[name] != null) ds.Tables[name].Clear();
            OleDbDataAdapter dat;
            dat = new OleDbDataAdapter(sql, connection);
            dat.Fill(ds, name);
            connection.Close();
        }

        public static bool Modification_Execute(string sql)
        {
            OleDbCommand com = new OleDbCommand(sql, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            return true;
        }

        private void судентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            students student = new students();
            student.Show();
        }

        private void вУСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vuss vus = new vuss();
            vus.Show();
        }

        private void вУЗToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vuzs vuz = new vuzs();
            vuz.Show();
        }

        private void журналПризывниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            journal jour = new journal();
            jour.Show();
        }
    }
}
