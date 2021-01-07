using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using Dapper;

namespace VerticalRoot
{
    public partial class databaseconnection : Window
    {
        public databaseconnection()
        {
            InitializeComponent();
            DBUtils dbUtils = new DBUtils();
        }
        public class showTable
        {
            public int ID { get; set; }
            public string Pid { get; set; }
            public int Name { get; set; }


            public override string ToString()
            {
                return this.Name.ToString();
            }
        }
        //public void CheckAmount()
        //{
        //    try
        //    {
                //using (MySqlDataReader plantValues = a.ExecuteReader())
                //{
                //    // get al data from tbl_datadetails
                //    //string mysql = "SELECT * FROM tbl_datadetails WHERE plant_id = 1;";
                //    //MySqlCommand command = new MySqlCommand(mysql, conn);

                //    //get al data from plantdetails connected to user and clicked plant

                //    //if the user data.celsius > command2.celsuis
                //    //using (MySqlDataReader plantValues = command2.ExecuteReader())
                //    ////using (MySqlDataReader currentValues = command.ExecuteReader())
                //    //{
                //    //int currentPlantldr = Convert.ToInt32(currentValues["ldr"]);
                //    if (plantValues.HasRows)
                //    {
                //        while (plantValues.Read())
                //        {
                //            int currentSetPlantValues = Convert.ToInt32(currentValues["set_celsius"]);
                //            int currentPlantCelsius = Convert.ToInt32(plantValues["celsius"]);

                //            //int setPlantCelsius = plantValues.GetInt32(0);
                //            //int currentPlantCelius = Convert.ToInt32(setValues["celsius"]);

                //            if (currentPlantCelsius < currentSetPlantValues)
                //            {
                //                System.Windows.Forms.MessageBox.Show("werkt");
                //                //MessageBox.Show(currentPlantCelsius.ToString());
                //                //MessageBox.Show(setPlantCelsius.ToString());
                //            }
                //            else
                //            {
                //                MessageBox.Show("nah lol");

                //            }
                //        }
                //    }
                //}
                //}
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }
        //}
        public class PlantDetails
        {
            public int Col1 { get; set; }
            public int Col2 { get; set; }
        }
        public void ShowData()
        {
            try
            {
                string connectionString = "Server=studmysql01.fhict.local;Uid=dbi467376;Database=dbi467376;Pwd=password123;"; //database server name and mysql port and username and password
                string mysql = "SELECT * FROM tbl_datadetails;";

                MySqlConnection conn = new MySqlConnection(connectionString);
                MySqlCommand command = new MySqlCommand(mysql, conn);

                conn.Open();

                //MySqlDataAdapter dtb = new MySqlDataAdapter();
                // dtb.SelectCommand = command;

                //datatable dt = new datatable();
                //dt.load(command.executereader());

                MySqlDataAdapter da = new MySqlDataAdapter(command);
                DataTable dtt = new DataTable();
                da.Fill(dtt);
                DataGrid dg = new DataGrid();
                dtGrid.ItemsSource = dtt.AsDataView();

                var list1 = conn.Query<int>("select ldr from tbl_datadetails").ToList();
                var list2 = conn.Query<int>("select humidity from tbl_datadetails").ToList();
                var list3 = conn.Query<int>("select celsius from tbl_datadetails").ToList();
                var list4 = conn.Query<int>("select water_use from tbl_datadetails").ToList();
                var list5 = conn.Query<int>("select moisture from tbl_datadetails").ToList();
                //testlist.ItemsSource = list;

                var users = new List<showTable>();
                //get user id,

                //for (int i = 0; i < list1.Count; ++i)
                //{
                //    users.Add(new showTable {  ID = i, Name = list1[i]});
                //}

                using (var e1 = list1.GetEnumerator())
                using (var e2 = list2.GetEnumerator())
                using (var e3 = list3.GetEnumerator())
                using (var e4 = list4.GetEnumerator())
                using (var e5 = list5.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext() && e3.MoveNext() && e4.MoveNext() && e5.MoveNext())
                    {
                        var item1 = e1.Current;
                        var item2 = e2.Current;
                        var item3 = e3.Current;
                        var item4 = e4.Current;
                        var item5 = e5.Current;
                        string k = "-------------------------------";
                        users.Add(new showTable { ID = item1, Pid = "LDR", Name = item1 });
                        users.Add(new showTable { ID = item2, Pid = "LDR", Name = item2 });
                        users.Add(new showTable { ID = item3, Pid = "LDR", Name = item3 });
                        users.Add(new showTable { ID = item4, Pid = "LDR", Name = item4 });
                        users.Add(new showTable { ID = item5, Pid = "LDR", Name = item5 });
                        users.Add(new showTable { Pid = k });

                        // use item1 and item2
                    }
                }
                myListView.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DtGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //string uid = "2";
            //    string pid = "1";
            //welke is geklikt

            //stuur door naar de nieuwe form
            // return [uid, pid];
        }
    }
}