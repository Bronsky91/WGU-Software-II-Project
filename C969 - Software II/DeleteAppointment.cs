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
    public partial class DeleteAppointment : Form
    {
        public DeleteAppointment()
        {
            InitializeComponent();
        }

        public MainForm mainFormObject;
        public static Dictionary<string, string> appointmentDetails = new Dictionary<string, string>();

        public static bool deleteAppointment()
        {
            MySqlConnection c = new MySqlConnection(DataHelper.conString);
            c.Open();

            // Deletes Customer 
            string recDelete = $"DELETE FROM appointment" +
                $" WHERE appointmentId = '{appointmentDetails["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(recDelete, c);
            int appointmentDeleted = cmd.ExecuteNonQuery();

            c.Close();

            if (appointmentDeleted != 0)
                return true;
            else
                return false;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string appointmentId = searchBar.Text;
            appointmentDetails = DataHelper.getAppointmentDetails(appointmentId);
            customerIdLabel.Text = appointmentDetails["customerId"];
            typeLabel.Text = appointmentDetails["type"];
            startLabel.Text = appointmentDetails["start"];
            endLabel.Text = appointmentDetails["end"];
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            // Gives user confirmation dialog box to confirm deletion
            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this appointment?", "Deletion Confirm", MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {
                // Deletes customer records
                if (deleteAppointment())
                {
                    mainFormObject.updateCalendar();
                    MessageBox.Show($"Customer: {appointmentDetails["type"]} was successfully deleted");
                }
                else
                    MessageBox.Show($"Customer: {appointmentDetails["type"]} could not be deleted");
            }

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
