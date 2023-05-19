using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace DataAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ustvarimo povezavo z bazo
            string connectionString = "Data Source = filmi.sqlite; Version = 3;";
            SQLiteConnection conn = new SQLiteConnection(connectionString);

            //Napišemo poizvedbo
            string sqlQuery = "SELECT naslov FROM film";

            //Ustvarimo adapter iz povezave in poizvedbe
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, conn);

            //naredimo nov dataset
            DataSet dataset = new DataSet();

            //dodajmo dataset v adapter
            adapter.Fill(dataset, "film");

            //Izpišimo vse kar se nahaja v datasetu
            DataTable table = dataset.Tables["film"];
            foreach (DataRow row in table.Rows) {
                foreach (DataColumn col in table.Columns) {
                    listBox1.Items.Add(row[col]); 
                }
            }
            conn.Close();
        }
    }
}
