using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ed2026Stefan
{
    public partial class Form1 : Form
    {
        int br_red;
        DataTable podaci;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable podaci = new DataTable();
            string CS = "Data Source=DESKTOP-A02KV2H\\SQLEXPRESS; Initial Catalog=ed2026b; Integrated Security=True";
            SqlConnection veza = new SqlConnection(CS);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ucenik", veza);
            adapter.Fill(podaci);
            br_red = 0;
            prikaz();
        }

        private void prikaz()
        {
            textBox1.Text = podaci.Rows[br_red]["id"].ToString();
            textBox2.Text = podaci.Rows[br_red]["ime"].ToString();
            textBox3.Text = podaci.Rows[br_red]["prezime"].ToString();
            textBox4.Text = podaci.Rows[br_red]["jmbg"].ToString();
            textBox5.Text = podaci.Rows[br_red]["email"].ToString();
            textBox6.Text = podaci.Rows[br_red]["pass"].ToString();
            textBox7.Text = podaci.Rows[br_red]["adresa"].ToString();
            textBox8.Text = podaci.Rows[br_red]["uloga"].ToString();
            if (br_red == 0)
            {
                btnPrevious.Enabled = false;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            br_red++;
            prikaz();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            br_red--; 
            prikaz();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            br_red = 0;
            prikaz();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            br_red = podaci.Rows.Count - 1;
            prikaz();
        }
    }
}
