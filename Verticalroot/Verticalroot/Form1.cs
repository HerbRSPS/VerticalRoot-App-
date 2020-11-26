using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Verticalroot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "server=studmysql01.fhict.local;database=dbi467376;username=dbi467376;password=password123"; //database server name and mysql port and username and password
                //string mysql = "SELECT * FROM dbi467376.tbl_datadetails;";

                MySqlConnection conn = new MySqlConnection(connectionString);
                //MySqlCommand command = new MySqlCommand(mysql, conn);

                conn.Open();
                /*
                MySqlDataAdapter dtb = new MySqlDataAdapter();
                dtb.SelectCommand = command;

                DataTable dtable = new DataTable();
                dtb.Fill(dtable);
                dataGridView1.DataSource = dtb;
                */
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
