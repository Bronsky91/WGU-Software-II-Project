using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___Software_II
{
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
            endTimePicker.Value = endTimePicker.Value.AddHours(1);
        }

        public MainForm mainFormObject;

        private void addButton_Click(object sender, EventArgs e)
        {
            string timestamp = DataHelper.createTimestamp();
            int userId = DataHelper.getCurrentUserId();
            string username = DataHelper.getCurrentUserName();
            // 'customerId', 'start', 'end', 'type',
            DataHelper.createRecord(timestamp, username, "appointment", $"'{customerIdTextBox.Text}', '{startTimePicker.Text}', '{endTimePicker.Text}', '{typeTextBox.Text}'", userId);

            mainFormObject.updateCalendar();

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
