using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_management
{
    public partial class LB : Form
    {
        public LB()
        {
            InitializeComponent();
        }

        private void LB_Load(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\asus\source\repos\Library management\Library management\Database1.mdf;Integrated Security=True");
            sc.Open();
            string query = "SELECT * FROM MB";
            SqlCommand command = new SqlCommand(query, sc);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            sc.Close();
            dataGridView1.DataSource = dt;
        }

        private void LB_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
