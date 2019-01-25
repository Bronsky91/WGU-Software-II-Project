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

namespace C969___Software_II
{
    public partial class MainForm : Form
    {
        public Login loginForm;

        public MainForm()
        {
            InitializeComponent();
            appointmentCalendar.DataSource = getCalendar(weekRadioButton.Checked);
        }

        static public Array getCalendar(bool weekView)
        {
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();
            // Queries the DB for all the appointments related to the logged in user
            string query = $"SELECT customerId, type, start, end, appointmentId FROM appointment WHERE userid = '{DataHelper.getCurrentUserId()}'";
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            Dictionary<int, Dictionary<string, object>> appointments = new Dictionary<int, Dictionary<string, object>>();

            // Creates a dictionary of all the appointments
            while (rdr.Read())
            {

                Dictionary<string, object> appointment = new Dictionary<string, object>();
                appointment.Add("customerId", rdr[0]);
                appointment.Add("type", rdr[1]);
                appointment.Add("start", rdr[2]);
                appointment.Add("end", rdr[3]);

                appointments.Add(Convert.ToInt32(rdr[4]), appointment);
            }
            rdr.Close();

            // Assigns the proper Customer to each Appointment dictionary
            foreach(var app in appointments.Values)
            {
                query = $"SELECT customerName FROM customer WHERE customerId = '{app["customerId"]}'";
                cmd = new MySqlCommand(query, c);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                app.Add("customerName", rdr[0]);
                rdr.Close();
            }

            Dictionary<int, Dictionary<string, object>> parsedAppointments = new Dictionary<int, Dictionary<string, object>>();
            // Adjusts appointments that will end up in calendar based on if the Week or Month view is chosen.
            foreach (var app in appointments)
            {
                DateTime startTime = DateTime.Parse(app.Value["start"].ToString());
                DateTime endTime = DateTime.Parse(app.Value["end"].ToString());
                DateTime today = DateTime.UtcNow;

                if (weekView)
                {
                    DateTime sunday = today.AddDays(-(int)today.DayOfWeek);
                    DateTime saturday = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Saturday);

                    if (startTime >= sunday && endTime < saturday)
                    {
                        // only include the apps that get here
                        parsedAppointments.Add(app.Key, app.Value);
                    }
                }
                else
                {
                    DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    if (startTime >= firstDayOfMonth && endTime < lastDayOfMonth)
                    {
                        //  only include app that get here
                        parsedAppointments.Add(app.Key, app.Value);
                    }
                }
            }

            // Forms final datasource of calendar that will be shown to user
            var appointmentArray = from row in parsedAppointments select new {
                ID = row.Key,
                Type = row.Value["type"],
                StartTime = row.Value["start"],
                EndTime = row.Value["end"],
                Customer = row.Value["customerName"]
            };

            c.Close();

            return appointmentArray.ToArray();
        }

        private void createCustomerButton_Click(object sender, EventArgs e)
        {
            CreateCustomer createCustomer = new CreateCustomer();
            createCustomer.Show();
        }

        private void updateCustomerButton_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            updateCustomer.Show();
        }

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginForm.Close();
        }

        private void weekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            appointmentCalendar.DataSource = getCalendar(weekRadioButton.Checked);
        }
    }
}
