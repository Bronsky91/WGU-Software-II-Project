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
    public partial class UpdateAppointment : Form
    {
       
        public UpdateAppointment()
        {
            InitializeComponent();
        }

        public MainForm mainFormObject;
        public static Dictionary<string, string> aForm = new Dictionary<string, string>();

        public static bool updateAppointment(Dictionary<string, string> updatedForm)
        {
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();

            // Updates Customer Table
            string recUpdate = $"UPDATE appointment" +
                $" SET customerId = '{updatedForm["customerId"]}', start = '{updatedForm["start"]}', end = '{updatedForm["end"]}', type = '{updatedForm["type"]}', lastUpdate = '{DataHelper.createTimestamp()}', lastUpdateBy = '{DataHelper.getCurrentUserName()}'" +
                $" WHERE appointmentId = '{aForm["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int appointmentUpdated = cmd.ExecuteNonQuery();

            if (appointmentUpdated != 0)
                return true;
            else
                return false;
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            string appointmentId = searchBar.Text;
            aForm = DataHelper.getAppointmentDetails(appointmentId);
            customerIdTextBox.Text = aForm["customerId"];
            typeTextBox.Text = aForm["type"];
            startTimePicker.Value = DateTime.Parse(DataHelper.convertToTimezone(aForm["start"]));
            endTimePicker.Value = DateTime.Parse(DataHelper.convertToTimezone(aForm["end"]));

        }
   
        private void updateButton_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedForm = new Dictionary<string, string>();
            updatedForm.Add("type", typeTextBox.Text);
            updatedForm.Add("customerId", customerIdTextBox.Text);
            updatedForm.Add("start", startTimePicker.Value.ToUniversalTime().ToString("u"));
            updatedForm.Add("end", endTimePicker.Value.ToUniversalTime().ToString("u"));

            if (updateAppointment(updatedForm))
            {
                mainFormObject.updateCalendar();
                MessageBox.Show("Update Complete!");
            }
            else
            {
                MessageBox.Show("Update could not complete");
            }

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}
