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
                string connectionString = "datasource=localhost;port=3306;username=root;password="; //database server name and mysql port and username and password
                string mysql = "SELECT * FROM vertical_root.users;";

                //frfrfreee
                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand(mysql, conn);

                conn.Open();

                MySqlDataAdapter dtb = new MySqlDataAdapter();
                dtb.SelectCommand = command;

                DataTable dtable = new DataTable();
                dtb.Fill(dtable);
                dataGridView1.DataSource = dtb;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
