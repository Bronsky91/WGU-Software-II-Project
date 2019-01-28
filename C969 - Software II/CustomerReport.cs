using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace C969___Software_II
{
    public struct Customer{
        public string customerName;
        public int numberOfApps;
    }

    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
            customerReportView.DataSource = getReport();
        }

        public static DataTable getReport()
        {
            // Display each customer's name and how many appointments they have

            Dictionary<int, Hashtable> appointments = DataHelper.getAppointments();

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Customer");
            dt.Columns.Add("Appointments");

            IEnumerable<string> customers = appointments.Select(i => i.Value["customerName"].ToString()).Distinct(); // Lambda used to select each customer distinctly from the appointments collection

            foreach (string customer in customers)
            {
                DataRow row = dt.NewRow();
                row["Customer"] = customer;
                row["Appointments"] = appointments.Where(i => i.Value["customerName"].ToString() == customer.ToString()).Count().ToString(); // Lambda used to count the number of appointments each customer has from appointments collection
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
